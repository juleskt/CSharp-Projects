using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Slides : Form
    {
        List<string> filesToPlay = new List<string>();
        int timing;
        int numSlides;
        int slideCounter = 0;

        public Slides(List<string> files, int interval)
        {
            this.filesToPlay = files;
            this.timing = interval;
            this.numSlides = filesToPlay.Count;
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.ShowDialog();
        }
       
        private void Slides_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            if (slideCounter == numSlides)
            {
                Close();
            }
            else
            {
                slideCounter++;
            }

            base.OnPaint(e);
            Graphics g = e.Graphics;

            try
            {
                Image currImage = Image.FromFile(filesToPlay[slideCounter-1]);
                SizeF client = ClientSize;
                int imgH = currImage.Height;
                int imgW = currImage.Width;

                if(client.Height / imgH < client.Width / imgW)
                {
                    float shift = client.Height / imgH;
                    g.DrawImage(currImage, (client.Width - imgW * shift) / 2,
                       (client.Height - imgH * shift) / 2,
                       imgW * shift, imgH * shift);
                }
                else
                {
                    float shift = client.Width / imgW;
                    g.DrawImage(currImage, (client.Width - imgW * shift) / 2,
                      (client.Height - imgH * shift) / 2,
                      imgW * shift, imgH * shift);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Not a valid file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void Slides_Load(object sender, EventArgs e)
        {
            timer1.Interval = timing * 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
