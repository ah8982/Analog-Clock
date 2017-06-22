using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analog_Clock
{
    public partial class frmMain : Form
    {
        // Timer
        Timer t = new Timer();

        // Size
        int WIDTH = 300;
        int HEIGHT = 300;

        // Handler
        int secHANDLER = 140;
        int minHANDLER = 110;
        int hrHANDLER = 80;

        // Center
        int cx;
        int cy;

        // Bitmaps and Graphics
        Bitmap bmp;
        Graphics g;

        public frmMain()
        {
            InitializeComponent();
            createBitmap();
            centerOfScreen();
            defineBackcolor();
            enableTimer();
        }

        public void createBitmap()
        {
            // Create bitmap
            bmp = new Bitmap(WIDTH + 1, HEIGHT + 1);
        }

        private void centerOfScreen()
        {
            // Define center of screen
            cx = WIDTH / 2;
            cy = HEIGHT / 2;
        }

        private void defineBackcolor()
        {
            this.BackColor = Color.BlanchedAlmond;
        }

        private void enableTimer()
        {
            t.Interval = 1000;      // in milliseconds
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            // Create graphics
            g = Graphics.FromImage(bmp);

            // Get current time
            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;
            int[] handCoord = new int[2];

            // Clear
            g.Clear(Color.BlanchedAlmond);

            // Draw circle
            g.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, WIDTH, HEIGHT);

            // Draw figure
            g.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF(140, 2));
            g.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(286, 140));
            g.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF(142, 282));
            g.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(0, 140));

            // Second handler
            handCoord = msCoordinates(ss, secHANDLER);
            g.DrawLine(new Pen(Color.Red, 1f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            // Minute handler
            handCoord = msCoordinates(mm, minHANDLER);
            g.DrawLine(new Pen(Color.Black, 2f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            // Hour handler
            handCoord = hrCoordinates(hh % 12 ,mm , hrHANDLER);
            g.DrawLine(new Pen(Color.Gray, 3f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            // Load bitmap in PictureBox
            pbxClock.Image = bmp;

            // Dispose
            g.Dispose();
        }

        // Coord for minute handler
        private int [] msCoordinates(int val, int hlen)
        {
            int[] coord = new int[2];
            val *= 6;               // Each minute and second makes 6 degree

            if (val>=0 && val<=180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }

            return coord;
        }

        // Coord for hour handler
        private int[] hrCoordinates(int hval,int mval, int hlen)
        {
            int[] coord = new int[2];

            // Each hour is 30 degrees
            // Each minute is 0.5 degrees
            int val = (int)((hval * 30) + (mval * .5));

            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }

            return coord;
        }
    }
}
