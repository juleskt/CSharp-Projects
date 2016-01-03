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
    class Circle
    {
        public int WIDTH = 20;
        public int HEIGHT = 20;
        public Point p;
        String color;
    
        public Circle(Point p)
        {
            this.p.X = p.X;
            this.p.Y = p.Y;
            this.color = "black";
        }

        public String getColor()
        {
            return color;
        }
    
        public void setColor(String s)
        {
            this.color = s;
        }
    
        public bool hitBox(Point m)
        {
            if (m.X > (this.p.X - this.WIDTH / 2) && m.X < (this.p.X + this.WIDTH / 2) )
            {
                if (m.Y > (this.p.Y - this.HEIGHT / 2)  && m.Y < (this.p.Y + this.HEIGHT / 2) )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
