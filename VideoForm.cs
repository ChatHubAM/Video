using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace AForge.WindowsForms
{
	public partial class VideoForm : Form
	{
		Socket sendSocket;
		byte[] sendBuffer;
		Socket sizeSenderSocket;
		byte[] sizeSenderBuffer;
		const string ip = "192.168.0.11";
		const int port = 9873;
		IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);
		IPEndPoint sizeSendEndPoint = new IPEndPoint(IPAddress.Parse(ip), 10002);
		IPEndPoint receiveEndPoint = new IPEndPoint(IPAddress.Any, 9786);
		IPEndPoint sizeReceiveEndPoint = new IPEndPoint(IPAddress.Any, 10002);
		private FilterInfoCollection videoDevicesList;
		private IVideoSource videoSource;


		public VideoForm()
		{
			InitializeComponent();
			// Calls Listener method(described below) in separate thread
			Thread clientthread = new Thread(Listener);
			clientthread.Start();
			// Gets list of video devices
			videoDevicesList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
			foreach (FilterInfo videoDevice in videoDevicesList)
			{
				cmbVideoSource.Items.Add(videoDevice.Name);
			}
			if (cmbVideoSource.Items.Count > 0)
			{
				cmbVideoSource.SelectedIndex = 0;
			}
			else
			{
				MessageBox.Show("No video sources found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			// Stops the camera on window close
			this.Closing += Form1_Closing;
		}

		//Defines actions,happening after closing the form: Stops the camera
		private void Form1_Closing(object sender, CancelEventArgs e)
		{			
			if (videoSource != null && videoSource.IsRunning)
			{
				videoSource.SignalToStop();
			}
		}
		//Gets the camera's taken image, sets it to senderBox, and, preventing senderBox from reuse, calls VideoSender method(described below)
		private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
		{			
			Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();			
			senderBox.Image = bitmap;
			if (senderBox.InvokeRequired) { senderBox.Invoke(new MethodInvoker(() => VideoSender())); } else VideoSender();						
		}
		//Defines actions,happening after clicking the Start button:Calls OpenConnections method(described below) and Starts the camera
		private void btnStart_Click(object sender, EventArgs e)
		{
			OpenConnections();
			videoSource = new VideoCaptureDevice(videoDevicesList[cmbVideoSource.SelectedIndex].MonikerString);
			videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);		
			videoSource.Start();
		}
		//Defines actions,happening after clicking the Stop button:Stops the camera,calls CloseConnections method(described below),disposes senderBox's image
		private void btnStop_Click(object sender, EventArgs e)
		{
			videoSource.SignalToStop();
			CloseConnections();
			if (videoSource != null && videoSource.IsRunning && senderBox.Image != null)
			{
				senderBox.Image.Dispose();
			}
		}
		
		//Always listens to the particular endpoint, receives images converted into bytes, reconverts them into images,sets images to receiverBox
		private void Listener()
		{
			byte[] buffer;
			byte[] sizeBuffer = new byte[4];
			using (Socket videoReceiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
			{
				using (Socket sizeReceiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
				{
					videoReceiveSocket.Bind(receiveEndPoint);
					videoReceiveSocket.Listen(1);
					sizeReceiveSocket.Bind(sizeReceiveEndPoint);
					sizeReceiveSocket.Listen(1);
					using (Socket client = videoReceiveSocket.Accept())
					{
						using (Socket sizeClient = sizeReceiveSocket.Accept())
						{
							MemoryStream stream;
							while (true)
							{
								sizeClient.Receive(sizeBuffer);								
								buffer = ReceiveLargeFile(client, BitConverter.ToInt32(sizeBuffer, 0));
								stream = new MemoryStream(buffer);
								receiverBox.Image = Image.FromStream(stream);
								stream.Position = 0;
							}
						}
					}
				}
			}
		}
		//Receives large data, prevents any data loss
		private byte[] ReceiveLargeFile(Socket socket, int lenght)
		{
			byte[] data = new byte[lenght];

			int size = lenght;
			var total = 0; 
			var dataleft = size; 

			while (total < size)
			{
				var recv = socket.Receive(data, total, dataleft, SocketFlags.None);
				if (recv == 0) 
				{
					data = null;
					break;
				}
				total += recv;  
				dataleft -= recv;
			}

			return data; 
		}		
		//Converts images into bytes,sends them to the particular endpoint
		private void VideoSender()
		{
			if (senderBox.Image != null)
			{
				var size = SizeCounter(senderBox.Image);
				sendBuffer = new byte[size];
				sizeSenderBuffer = BitConverter.GetBytes(size);
				MemoryStream stream = new MemoryStream(sendBuffer);
				SaveJpeg(stream, senderBox.Image, 30);
				sendSocket.Send(sendBuffer);
				sizeSenderSocket.Send(sizeSenderBuffer);
				stream.Position = 0;
			}
		}
		//Counts the size of the given image in bytes
		private int SizeCounter(Image img)
		{
			MemoryStream sizeStream = new MemoryStream();
			img.Save(sizeStream, System.Drawing.Imaging.ImageFormat.Jpeg);
			return sizeStream.ToArray().Length;
		}
		//Sets up necessary conections
		private void OpenConnections()
		{
			sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);			
			sendSocket.Connect(endPoint);
			sizeSenderSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			sizeSenderSocket.Connect(sizeSendEndPoint);
		}
		//Closes connections after using
		public void CloseConnections()
		{
			sendSocket.Shutdown(SocketShutdown.Both);
			sendSocket.Close();
		}
		//Saves image(in jpeg format) in given stream with chosen quality
		public static void SaveJpeg(MemoryStream stream, Image img, int quality)
		{
			if (quality < 0 || quality > 100)
				throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");

			EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
			ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
			EncoderParameters encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = qualityParam;
			img.Save(stream, jpegCodec, encoderParams);
		}
		// Gets image codecs for all image formats, finds the correct image codec
		private static ImageCodecInfo GetEncoderInfo(string mimeType)
		{
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
			
			for (int i = 0; i < codecs.Length; i++)
				if (codecs[i].MimeType == mimeType)
					return codecs[i];

			return null;
		}
	}
}