using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class graphicsElements
    {
        public Pen pen;
        public Point start;
        public Point end;
        public bool fillFlag;
        public float height, width;
        public bool outlineFlag;
        public SolidBrush brush;
        public Font myFont = new Font("Arial", 12, FontStyle.Regular);
        
        public virtual void Draw(Graphics g)
        {
            //poo
        }
    }
    class CustomText: graphicsElements
    {
        public string text;
        public CustomText(Point p1, Point p2,string inText)
        {
            start = new Point(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
            height = (Math.Max(p1.X, p2.X) - Math.Min(p1.X, p2.X));
            width = (Math.Max(p1.Y, p2.Y) - Math.Min(p1.Y, p2.Y));
            text = inText;
        }
        public override void Draw(Graphics g)
        {
            base.Draw(g);
            g.DrawString(text, myFont, Brushes.Black, new Rectangle(start, new Size((int)height, (int)width)));
        }
    }
    class CustomLine: graphicsElements
    {
        public CustomLine(Point p1, Point p2, int inSize, Color inColour)
        {
            start = p1;
            end = p2;
            pen = new Pen(inColour, inSize);
        }
        public override void Draw(Graphics g)
        {
            base.Draw(g);
            g.DrawLine(pen, start, end);
        }
    }

    class CustomRect: graphicsElements
    {
        public CustomRect(Point p1, Point p2, int inSize, Color inColour, Color inFillColour, bool inFillFlag, bool inOutlineFlag)
        {
            start = new Point(Math.Min(p1.X,p2.X),Math.Min(p1.Y,p2.Y));
            pen = new Pen(inColour, inSize);
            brush = new SolidBrush(inFillColour);
            height = (Math.Max(p1.X, p2.X) - Math.Min(p1.X, p2.X));
            width = (Math.Max(p1.Y, p2.Y) - Math.Min(p1.Y, p2.Y));
            fillFlag = inFillFlag;
            outlineFlag = inOutlineFlag;
        }
        public override void Draw(Graphics g)
        {
            base.Draw(g);
            if (fillFlag)
            {
                g.FillRectangle(brush, start.X, start.Y, height, width);
            }
            if(outlineFlag)
            {
                g.DrawRectangle(pen, start.X, start.Y, height, width);
            }
        }
    }

    class CustomEllipse: graphicsElements
    {
         public CustomEllipse(Point p1, Point p2, int inSize, Color inColour, Color inFillColour, bool inFillFlag, bool inOutlineFlag)
        {
            
            start = new Point(Math.Min(p1.X,p2.X),Math.Min(p1.Y,p2.Y));
            pen = new Pen(inColour, inSize);
            brush = new SolidBrush(inFillColour);
            height = (Math.Max(p1.X, p2.X) - Math.Min(p1.X, p2.X));
            width = (Math.Max(p1.Y, p2.Y) - Math.Min(p1.Y, p2.Y));
            fillFlag = inFillFlag;
            outlineFlag = inOutlineFlag;
        }
        public override void Draw(Graphics g)
        {
            base.Draw(g);
            if (fillFlag)
            {
                g.FillEllipse(brush, start.X, start.Y, height, width);
            }
            if(outlineFlag)
            {
                g.DrawEllipse(pen, start.X, start.Y, height, width);
            }
        }
    }
}
