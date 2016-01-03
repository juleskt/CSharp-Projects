using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        //Create instance of Engine
        Engine myEngine = new Engine();

        //Define parameters
        private const float clientSize = 100;
        private const float lineLength = 80;
        private const float block = lineLength / 3;
        private const float offset = 10;
        private const float delta = 5;
        private float scale; //current scale factor 

        //Init form
        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        //Paint the board
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ApplyTransform(g);
            //draw board
            g.DrawLine(Pens.Black, block, 0, block, lineLength);
            g.DrawLine(Pens.Black, 2 * block, 0, 2 * block, lineLength);
            g.DrawLine(Pens.Black, 0, block, lineLength, block);
            g.DrawLine(Pens.Black, 0, 2 * block, lineLength, 2 * block);
            
            //Draw the items in the grid
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (myEngine.inGrid[i, j] == Engine.CellSelection.O)
                    {
                        DrawO(i, j, g);
                    }
                    else if (myEngine.inGrid[i, j] == Engine.CellSelection.X)
                    {
                        DrawX(i, j, g);
                    }
                }
            }
        }

        //Apply the scaling
        private void ApplyTransform(Graphics g)
        {
            scale = Math.Min(ClientRectangle.Width / clientSize,
            ClientRectangle.Height / clientSize);

            if (scale == 0f)
            {
                return;
            }

            g.ScaleTransform(scale, scale);
            g.TranslateTransform(offset, offset);
        }
        //Handles actually drawing O and X
        private void DrawX(int i, int j, Graphics g)
        {
            g.DrawLine(Pens.Black, i * block + delta, j * block + delta,
                (i * block) + block - delta, (j * block) + block - delta);

            g.DrawLine(Pens.Black, (i * block) + block - delta,
                j * block + delta, (i * block) + delta, (j * block) + block - delta);
        }
        private void DrawO(int i, int j, Graphics g)
        {
            g.DrawEllipse(Pens.Black, i * block + delta, j * block + delta,
                block - 2 * delta, block - 2 * delta);
        }
        //When clicked
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            ApplyTransform(g);
            PointF[] p = { new Point(e.X, e.Y) };
            g.TransformPoints(CoordinateSpace.World, CoordinateSpace.Device, p);

            if (p[0].X < 0 || p[0].Y < 0)
            {
                return;
            }

            int i = (int)(p[0].X / block);
            int j = (int)(p[0].Y / block);

            if (i > 2 || j > 2)
            {
                return;
            }

            //Check for victory
            Tuple<Engine.CellSelection, bool> result = myEngine.victory();

            //Let the user know if they won or lost
            if (result.Item2)
            {
                if (result.Item1 == Engine.CellSelection.O)
                {
                    MessageBox.Show("You Lost!");
                    return;
                }
                else
                {
                    MessageBox.Show("You Won!");
                    return;
                }
            }

            //only allow setting empty cells
            if ( myEngine.moveIsValid(i,j) )
            {
                //Let the player make a move
                if (e.Button == MouseButtons.Left)
                {
                    myEngine.playerMove(i, j);
                }

                if (e.Button == MouseButtons.Right)
                {
                    myEngine.playerMove(i, j);
                }

                //Redraw the screen
                Invalidate();

                //Check for a victory
                result = myEngine.victory();

                //Display victory/loss
                if (result.Item2)
                {
                    if (result.Item1 == Engine.CellSelection.O)
                    {
                        MessageBox.Show("You Lost!");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("You Won!");
                        return;
                    }
                }

                //If the board is not full
                if (!myEngine.fullBoard())
                {
                    //Make a move, redraw, and check for victory
                    myEngine.makeMove();
                    Invalidate();
                    result = myEngine.victory();

                    if (result.Item2)
                    {
                        if (result.Item1 == Engine.CellSelection.O)
                        {
                            MessageBox.Show("You Lost!");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("You Won!");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Game Over!");
                    return;
                }
            }
            //If the move is not valid, check for bad move
            else
            {
                MessageBox.Show("Bad Move!");
            }
        }

        //If user hits computer start, the engine will make a move
        private void computerStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //It will only move if the game is still in session
            if (!myEngine.fullBoard() && !myEngine.over)
            {
                myEngine.makeMove();
                Invalidate();
            }
        }
        //Resets game
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myEngine.gameStart();
            Invalidate();
        }
    }
}
