using RtspClientSharp;
using RtspClientSharp.RawFrames.Audio;
using RtspClientSharp.RawFrames.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RTSP_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HandleRTSP();
        }


        public static async void HandleRTSP()
        {
            var serverUri = new Uri("rtsp://service:Admin123%@192.168.6.45/rtsp_tunnel");
            //var credentials = new NetworkCredential("admin", "123456");
            var connectionParameters = new ConnectionParameters(serverUri);
            connectionParameters.RtpTransport = RtpTransportProtocol.TCP;
            using (var rtspClient = new RtspClient(connectionParameters))
            {
                rtspClient.FrameReceived += (sender, frame) =>
                {
                    switch (frame)
                    {
                        case RawH264IFrame h264IFrame:
                            DoSomething();
                            break;

                        case RawH264PFrame h264PFrame:
                            DoSomething();
                            break;

                        case RawJpegFrame jpegFrame:
                            DoSomething();
                            break;

                        case RawAACFrame aacFrame:
                            DoSomething();
                            break;

                        case RawG711AFrame g711AFrame:
                            DoSomething();
                            break;

                        case RawG711UFrame g711UFrame:
                            DoSomething();
                            break;

                        case RawPCMFrame pcmFrame:
                            DoSomething();
                            break;

                        case RawG726Frame g726Frame:
                            DoSomething();
                            break;

                    }
                };
                await rtspClient.ConnectAsync(CancellationToken.None);
                await rtspClient.ReceiveAsync(CancellationToken.None);
            }

        }

        public static void DoSomething()
        {

        }
    }
}
