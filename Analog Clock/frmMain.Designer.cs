namespace Analog_Clock
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbxClock = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondHandColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minuteHandColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourHandColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figureColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClock)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxClock
            // 
            this.pbxClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxClock.Location = new System.Drawing.Point(0, 0);
            this.pbxClock.Name = "pbxClock";
            this.pbxClock.Size = new System.Drawing.Size(384, 361);
            this.pbxClock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxClock.TabIndex = 0;
            this.pbxClock.TabStop = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundColorToolStripMenuItem,
            this.secondHandColorToolStripMenuItem,
            this.minuteHandColorToolStripMenuItem,
            this.hourHandColorToolStripMenuItem,
            this.figureColorToolStripMenuItem,
            this.toolStripSeparator1,
            this.showDateToolStripMenuItem,
            this.dateColorToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(187, 186);
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.backgroundColorToolStripMenuItem.Text = "Background Color...";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.BackgroundColorToolStripMenuItem_Click);
            // 
            // secondHandColorToolStripMenuItem
            // 
            this.secondHandColorToolStripMenuItem.Name = "secondHandColorToolStripMenuItem";
            this.secondHandColorToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.secondHandColorToolStripMenuItem.Text = "Second Hand Color...";
            this.secondHandColorToolStripMenuItem.Click += new System.EventHandler(this.SecondHandColorToolStripMenuItem_Click);
            // 
            // minuteHandColorToolStripMenuItem
            // 
            this.minuteHandColorToolStripMenuItem.Name = "minuteHandColorToolStripMenuItem";
            this.minuteHandColorToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.minuteHandColorToolStripMenuItem.Text = "Minute Hand Color...";
            this.minuteHandColorToolStripMenuItem.Click += new System.EventHandler(this.MinuteHandColorToolStripMenuItem_Click);
            // 
            // hourHandColorToolStripMenuItem
            // 
            this.hourHandColorToolStripMenuItem.Name = "hourHandColorToolStripMenuItem";
            this.hourHandColorToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.hourHandColorToolStripMenuItem.Text = "Hour Hand Color...";
            this.hourHandColorToolStripMenuItem.Click += new System.EventHandler(this.HourHandColorToolStripMenuItem_Click);
            // 
            // figureColorToolStripMenuItem
            // 
            this.figureColorToolStripMenuItem.Name = "figureColorToolStripMenuItem";
            this.figureColorToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.figureColorToolStripMenuItem.Text = "Figure Color...";
            this.figureColorToolStripMenuItem.Click += new System.EventHandler(this.FigureColorToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
            // 
            // showDateToolStripMenuItem
            // 
            this.showDateToolStripMenuItem.Name = "showDateToolStripMenuItem";
            this.showDateToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.showDateToolStripMenuItem.Text = "Show Date";
            this.showDateToolStripMenuItem.Click += new System.EventHandler(this.ShowDateToolStripMenuItem_Click);
            // 
            // dateColorToolStripMenuItem
            // 
            this.dateColorToolStripMenuItem.Name = "dateColorToolStripMenuItem";
            this.dateColorToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.dateColorToolStripMenuItem.Text = "Date Color...";
            this.dateColorToolStripMenuItem.Click += new System.EventHandler(this.DateColorToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.pbxClock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Analog Clock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxClock)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxClock;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondHandColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minuteHandColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hourHandColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figureColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem dateColorToolStripMenuItem;
    }
}

