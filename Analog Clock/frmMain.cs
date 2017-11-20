using System;
using System.Drawing;
using System.Windows.Forms;

namespace Analog_Clock
{
    public partial class frmMain : Form
    {
        // Timer
        Timer t = new Timer();

        // Size
        int width = 300;
        int height = 300;

        // Handler
        int secHandler = 140;
        int minHandler = 110;
        int hrHandler = 80;

        // Colors
        Color colorBackground;
        Color colorSecondHand;
        Color colorMinuteHand;
        Color colorHourHand;
        Color colorFigure;
        Color colorDate;

        // Center
        int cx;
        int cy;

        // Bitmaps and Graphics
        Bitmap bmp;
        Graphics g;

        // Misc
        bool showDate;

        public frmMain()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.if_Clock___Time_11035;

            CreateBitmap();
            CenterOfScreen();
            DefineBackcolor();
            EnableTimer();
        }

        public void CreateBitmap()
        {
            // Create bitmap
            bmp = new Bitmap(width + 1, height + 1);
        }

        private void CenterOfScreen()
        {
            // Define center of screen
            cx = width / 2;
            cy = height / 2;
        }

        private void DefineBackcolor()
        {
            this.BackColor = Color.BlanchedAlmond;
        }

        private void EnableTimer()
        {
            t.Interval = 250;      // in milliseconds
            t.Tick += new EventHandler(this.T_Tick);
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            // Create graphics
            g = Graphics.FromImage(bmp);

            // Get current time and date
            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;
            string date = DateTime.Now.ToShortDateString();
            int[] handCoord = new int[2];

            // Clear
            g.Clear(colorBackground);

            // Draw circle
            g.DrawEllipse(new Pen(colorFigure, 1f), 0, 0, width, height);

            // Draw figure
            g.DrawString("12", new Font("Arial", 12), new SolidBrush(colorFigure), new PointF(140, 2));
            g.DrawString("3", new Font("Arial", 12), new SolidBrush(colorFigure), new PointF(286, 140));
            g.DrawString("6", new Font("Arial", 12), new SolidBrush(colorFigure), new PointF(142, 282));
            g.DrawString("9", new Font("Arial", 12), new SolidBrush(colorFigure), new PointF(0, 140));

            // Draw date
            if (showDate)
            {
                g.DrawString(date, new Font("Arial", 12), new SolidBrush(colorDate), new PointF(cx / 1.4f, cy / 3 * 2));
            }

            // Second handler
            handCoord = MsCoordinates(ss, secHandler);
            g.DrawLine(new Pen(colorSecondHand, 1f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            // Minute handler
            handCoord = MsCoordinates(mm, minHandler);
            g.DrawLine(new Pen(colorMinuteHand, 2f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            // Hour handler
            handCoord = HrCoordinates(hh % 12 ,mm , hrHandler);
            g.DrawLine(new Pen(colorHourHand, 3f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            // Load bitmap in PictureBox
            pbxClock.Image = bmp;

            // Dispose
            g.Dispose();
        }

        // Coord for minute handler
        private int [] MsCoordinates(int val, int hlen)
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
        private int[] HrCoordinates(int hval,int mval, int hlen)
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

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Load location
            this.Location = Properties.Settings.Default.frmMainPosition;

            // load background color
            this.BackColor = Properties.Settings.Default.frmMainBGColor;
            colorBackground = this.BackColor;

            // Load second hand color
            colorSecondHand = Properties.Settings.Default.frmMainColorSecondHand;

            // Load minute hand color
            colorMinuteHand = Properties.Settings.Default.frmMainColorMinuteHand;

            // Load show date
            showDate = Properties.Settings.Default.frmMainShowDate;
            showDateToolStripMenuItem.Checked = showDate;

            // Load figure color
            colorFigure = Properties.Settings.Default.frmMainColorFigure;

            // Load date color
            colorDate = Properties.Settings.Default.frmMainColorDate;

            // Load hour hand color
            colorHourHand = Properties.Settings.Default.frmMainColorHourHand;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save window location
            Properties.Settings.Default.frmMainPosition = this.Location;

            // Save background color
            Properties.Settings.Default.frmMainBGColor = colorBackground;

            // Save second hand color
            Properties.Settings.Default.frmMainColorSecondHand = colorSecondHand;

            // Save minute hand color
            Properties.Settings.Default.frmMainColorMinuteHand = colorMinuteHand;

            // Save hour hand color
            Properties.Settings.Default.frmMainColorHourHand = colorHourHand;

            // Save show date
            Properties.Settings.Default.frmMainShowDate = showDate;

            // Save figure color
            Properties.Settings.Default.frmMainColorFigure = colorFigure;

            // Save date color
            Properties.Settings.Default.frmMainColorDate = colorDate;

            // Sync settings
            Properties.Settings.Default.Save();
        }

        private void BackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colDialog = new ColorDialog();

            // Show the color dialog.
            DialogResult result = colDialog.ShowDialog();

            // If the user pressed ok.
            if (result == DialogResult.OK)
            {
                this.BackColor = colDialog.Color;
                colorBackground = this.BackColor;

                Properties.Settings.Default.frmMainBGColor = this.BackColor;
                Properties.Settings.Default.Save();
            }

            colDialog = null;
        }

        private void SecondHandColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colDialog = new ColorDialog();

            // Show the dialog.
            DialogResult result = colDialog.ShowDialog();

            // If the user pressed ok.
            if (result == DialogResult.OK)
            {
                colorSecondHand = colDialog.Color;

                Properties.Settings.Default.frmMainColorSecondHand = colorSecondHand;
                Properties.Settings.Default.Save();
            }

            colDialog = null;
        }

        private void MinuteHandColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colDialog = new ColorDialog();

            // Show the dialog.
            DialogResult result = colDialog.ShowDialog();

            // If the user pressed ok.
            if (result == DialogResult.OK)
            {
                colorMinuteHand = colDialog.Color;

                Properties.Settings.Default.frmMainColorMinuteHand = colorMinuteHand;
                Properties.Settings.Default.Save();
            }

            colDialog = null;
        }

        private void HourHandColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colDialog = new ColorDialog();

            // Show the dialog.
            DialogResult result = colDialog.ShowDialog();

            // If the user pressed ok.
            if (result == DialogResult.OK)
            {
                colorHourHand = colDialog.Color;

                Properties.Settings.Default.frmMainColorHourHand = colorHourHand;
                Properties.Settings.Default.Save();
            }

            colDialog = null;
        }

        private void ShowDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showDate = !showDate;
            showDateToolStripMenuItem.Checked = showDate;
        }

        private void FigureColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colDialog = new ColorDialog();

            // Show the dialog.
            DialogResult result = colDialog.ShowDialog();

            // If the user pressed ok.
            if (result == DialogResult.OK)
            {
                colorFigure = colDialog.Color;

                Properties.Settings.Default.frmMainColorFigure = colorFigure;
                Properties.Settings.Default.Save();
            }

            colDialog = null;
        }

        private void DateColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colDialog = new ColorDialog();

            // Show the dialog.
            DialogResult result = colDialog.ShowDialog();

            // If the user pressed ok.
            if (result == DialogResult.OK)
            {
                colorDate = colDialog.Color;

                Properties.Settings.Default.frmMainColorDate = colorDate;
                Properties.Settings.Default.Save();
            }

            colDialog = null;
        }
    }
}