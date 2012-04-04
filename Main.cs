using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;

namespace CreoleSSD
{
    public partial class Main : Form
    {

        VideoCaptureDevice videoSource;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // enumerate video devices
            FilterInfoCollection videoDevices = new FilterInfoCollection(
                    FilterCategory.VideoInputDevice);
            // create video source
            this.videoSource = new VideoCaptureDevice(
                    videoDevices[0].MonikerString);
            // set frame rate
            this.videoSource.DesiredFrameRate = 10;
            // set NewFrame event handler
            this.videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            // start the video source
            this.videoSource.Start();
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Image tmp = (Image)eventArgs.Frame.Clone();
            this.pictureBox1.Image = tmp;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.videoSource.SignalToStop();
        }
    }
}
