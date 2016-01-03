using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        private ArrayList shapes = new ArrayList();
        bool nextOutline;
        bool nextFill;
        int nextSize;
        Color colour;
        Color inFillColour;
        int state=0;
        Point p1, p2;
        int deletion = 0;
        public Form1()
        {
            InitializeComponent();
            this.penColour.SelectedIndex = 0;
            this.penWidth.SelectedIndex = 0;
            this.fillColour.SelectedIndex = 0;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
        }
        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void drawings_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (deletion == 0)
            {
                if (Line.Checked)
                    shapes.Add(new CustomLine(p1, p2, nextSize, colour));
                else if (Rectangle.Checked)
                    shapes.Add(new CustomRect(p1, p2, nextSize, colour, inFillColour, nextFill, nextOutline));
                else if (Ellipse.Checked)
                    shapes.Add(new CustomEllipse(p1, p2, nextSize, colour, inFillColour, nextFill, nextOutline));
                else if (text.Checked)
                    shapes.Add(new CustomText(p1, p2, inputText.Text));
            }
            else deletion = 0;
            
            foreach (graphicsElements element in shapes)
                element.Draw(g);
        }

        private void drawings_MouseClick(object sender, MouseEventArgs e)
        {
            if (state == 0)
            {
                p1 = new Point(e.X, e.Y);
                state = 1;
            }
            else
            {
                p2 = new Point(e.X, e.Y);
                state = 0;
                // Properties of the shape
                nextSize = Int32.Parse(penWidth.SelectedItem.ToString());
                inFillColour = Color.FromName(fillColour.SelectedItem.ToString());
                colour = Color.FromName(penColour.SelectedItem.ToString());
                nextOutline = Outline.Checked;
                nextFill = Fill.Checked;

                drawings.Invalidate();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            deletion = 1;
            drawings.Invalidate();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shapes.Count > 0)
            {
                shapes.RemoveAt(shapes.Count-1 );
                deletion = 1;
                drawings.Invalidate();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
