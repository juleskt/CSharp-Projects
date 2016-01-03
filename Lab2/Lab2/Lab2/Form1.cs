using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private ArrayList coords = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                this.coords.Add(p);
                this.Invalidate();
            }
            
            if(e.Button == MouseButtons.Right)
            {
                this.coords.Clear();
                this.Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            const int WIDTH = 20;
            const int HEIGHT = 20;
            Graphics g = e.Graphics;
            
            foreach (Point p in this.coords)
            {
                //Centering the text is also based on font, so I just manually tweaked it
                g.FillEllipse(Brushes.Black, p.X - WIDTH / 2, p.Y - HEIGHT / 2, WIDTH, HEIGHT);
                g.DrawString(p.X + "," + p.Y, Font, Brushes.Black, p.X+10, (p.Y - HEIGHT / 2) + (HEIGHT/4));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.coords.Clear();
            this.Invalidate();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
