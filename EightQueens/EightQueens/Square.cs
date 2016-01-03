using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace EightQueens
{
    class Square
    {
        //Member variables
        String color;
        const int SIZE = 50;
        bool hasQueen;
        bool hintsOrNot;
        bool lineOfAttack;
        Rectangle me = new Rectangle();

        //Constructor
        public Square(String color, bool queen)
        {
            this.color = color;
            this.hasQueen = queen;
        }

        //Native draw function
        public void drawMe(PaintEventArgs e, int x, int y)
        {
            Graphics g = e.Graphics;

            //Draw the rectangle color based on color
            if(this.hintsOrNot && lineOfAttack)
            {
                g.FillRectangle(Brushes.Red, x, y, SIZE, SIZE);
                g.DrawRectangle(Pens.Black, x, y, SIZE, SIZE);
            }
            else if (this.color == "BLACK")
            {
                g.FillRectangle(Brushes.Black, x, y, SIZE, SIZE);
                g.DrawRectangle(Pens.Black, x, y, SIZE, SIZE);
            }
            else if(this.color == "WHITE")
            {
                g.FillRectangle(Brushes.White, x, y, SIZE, SIZE);
                g.DrawRectangle(Pens.Black, x, y, SIZE, SIZE);
            }

            //Checks if it has a Queen, if so, draw it in the correct color
            if ( (this.hasQueen && this.color == "WHITE") || (this.hasQueen && this.hintsOrNot) )
            {
                g.DrawString("Q", new Font("Arial", 30, FontStyle.Bold), Brushes.Black, x + SIZE / 24, y + SIZE / 24);
            }
            else if(this.hasQueen && this.color == "BLACK")
            {
                g.DrawString("Q", new Font("Arial", 30, FontStyle.Bold), Brushes.White, x + SIZE / 24, y + SIZE / 24);
            }

            //Set the native Rect object to the bounds and coords
            me.Width = SIZE;
            me.Height = SIZE;
            me.X = x;
            me.Y = y;
        }

        //GETTERS AND SETTERS
        public void addQueen(Point click)
        {
            if (!this.lineOfAttack && hasQueen == false)
            {
                if(me.Contains(click))
                {
                    this.hasQueen = true;
                }
            }
            else
            {
                System.Media.SystemSounds.Beep.Play();
            }
        }
        public void removeQueen()
        {
            this.hasQueen = false;
        }

        public bool checkQueen()
        {
            if (this.hasQueen)
                return true;
            else
                return false;
        }

        public bool checkClick(Point click)
        {
            if (me.Contains(click.X, click.Y))
                return true;
            else
                return false;
        }

        public void setHint(bool choice)
        {
            this.hintsOrNot = choice;
        }

        public void setLineOfAttack(bool line)
        {
            this.lineOfAttack = line;
        }

        public bool isSafe()
        {
            if(this.lineOfAttack)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
