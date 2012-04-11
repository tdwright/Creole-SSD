using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;

namespace CreoleSSD
{
    public partial class Main : Form
    {

        VideoCaptureDevice videoSource;
        Rectangle ROI;
        Audio audioOutput;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // initialise ROI
            this.ROI = new Rectangle(304, 224, 32, 32);
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
            // initialise the audio output
            this.audioOutput = new Audio();
            // start the video source
            this.videoSource.Start();
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            int[,] rawValues = new int[32,32];
            Bitmap tmp = (Bitmap)eventArgs.Frame.Clone();
            
            // throw away everything except the ROI
            Bitmap sub = new Bitmap(this.ROI.Width, this.ROI.Height);
            using (Graphics g = Graphics.FromImage(sub))
            {
                g.DrawImage(tmp, 0, 0, this.ROI, GraphicsUnit.Pixel);
            }

            // Read out the values
            BitmapData bmpData = sub.LockBits(new Rectangle(0, 0, sub.Width, sub.Height), ImageLockMode.ReadOnly, sub.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int bytes = Math.Abs(bmpData.Stride) * sub.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);
            for (int i = 0; i < 1024; i++)
            {
                int row = (int)Math.Floor((double)i / 32d);
                int col = i % 32;
                int[] rgb = { rgbValues[i * 3], rgbValues[i * 3 + 1], rgbValues[i * 3 + 2] };
                rawValues[col, row] = (int)Math.Round(rgb.Average());
            }
            sub.UnlockBits(bmpData);
            
            // Collapse the data
            int[,] weightedValues = new int[4, 5];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int cumulative = 0;
                    int radius = (int)Math.Pow(2, j);
                    int excRadius = (int)Math.Pow(2, j-1);
                    if (j==0) excRadius = 0;
                    int incX; int excX;
                    if((i%2)==0)
                    {
                        incX = 16 - radius;
                        excX = (16 - radius) + excRadius;
                    }
                    else
                    {
                        incX = 16;
                        excX = 16;
                    }
                    int incY; int excY;
                    if(i<2)
                    {
                        incY = 16 - radius;
                        excY = (16 - radius) + excRadius;
                    }
                    else
                    {
                        incY = 16;
                        excY = 16;
                    }
                    Rectangle exclude = new Rectangle(excX, excY, excRadius, excRadius);
                    for (int x = 0; x < radius; x++)
                    {
                        for (int y = 0; y < radius; y++)
                        {
                            int absX = incX+x;
                            int absY = incY+y;
                            if(!exclude.Contains(new Point(absX,absY)))
                            {
                                cumulative += rawValues[absX,absY];
                            }
                        }
                    }
                    int area = (int)(Math.Pow(radius, 2) - Math.Pow(excRadius, 2));
                    weightedValues[i,j] = (int)Math.Round((double)cumulative/(double)area);
                }
            }

            // Generate visual representation
            int scalingfactor = 20;
            Bitmap repSmall = new Bitmap(10 * scalingfactor, 10 * scalingfactor);
            using (Graphics repG = Graphics.FromImage(repSmall))
            {
                int Xo, Yo;
                for (int i = 0; i < 4; i++)
                {
                    if ((i % 2) == 0) Xo = -1; // Left half
                    else Xo = 0; // Right half
                    if (i < 2) Yo = -1; // Top half
                    else Yo = 0; // Bottom half
                    for (int j = 4; j >= 0; j--)
                    {
                        int radius = j + 1;
                        Brush b = new SolidBrush(Color.FromArgb(weightedValues[i,j],weightedValues[i,j],weightedValues[i,j]));
                        Rectangle r = new Rectangle((5 + (radius * Xo)) * scalingfactor, (5 + (radius * Yo)) * scalingfactor, radius * scalingfactor, radius * scalingfactor);
                        repG.FillRectangle(b, r);
                    }
                }
            }

            // Draw ROI on original
            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.DrawRectangle(new Pen(new SolidBrush(Color.Red)), this.ROI);
            }

            // Update UI (via the correct thread)
            this.rawPictureBox.BeginInvoke(new Action(
                () =>
                {
                    this.rawPictureBox.Image = tmp;
                }));
            this.repPictureBox.BeginInvoke(new Action(
                () =>
                {
                    this.repPictureBox.Image = repSmall;
                }));
            this.ROIbox.BeginInvoke(new Action(
                () =>
                {
                    this.ROIbox.Image = sub;
                }));

            this.audioOutput.SetLevels(weightedValues);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.videoSource.SignalToStop();
        }
    }
}
