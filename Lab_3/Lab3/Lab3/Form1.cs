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

namespace Lab3
{
    public partial class Form1 : Form
    {
        private List<Circle> Circles = new List<Circle>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Circles.Add(new Circle(new Point(e.X,e.Y)));
                this.Invalidate();
            }
            
            if(e.Button == MouseButtons.Right)
            {

                for (int x = 0; x < Circles.Count; x++)
                {
                  if(Circles[x].hitBox(new Point(e.X,e.Y)))
                    {
                        if (Circles[x].getColor() == "red")
                        {
                            this.Circles.RemoveAt(x);
                            x--;
                        }
                        else
                        {
                            Circles[x].setColor("red");
                        }
                
                    }
                }
                    this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            for (int x = 0; x < Circles.Count; x++)
            {
                Circle c = Circles[x];
                if (c.getColor() == "black")
                {
                    g.FillEllipse(Brushes.Black, c.p.X - c.WIDTH / 2, c.p.Y - c.HEIGHT / 2, c.WIDTH, c.HEIGHT);

                }
                else
                {
                    g.FillEllipse(Brushes.Red, c.p.X - c.WIDTH / 2, c.p.Y - c.HEIGHT / 2, c.WIDTH, c.HEIGHT);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Circles.Clear();
            this.Invalidate();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
