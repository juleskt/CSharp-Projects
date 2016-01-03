using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EightQueens
{
    public partial class Form1 : Form
    {
        //Set up X,Y Board to draw Square objects
        List<List<Square>> Board = new List<List<Square>>();
        //Global hints
        bool Hints;
        //Global Queen Count
        int numQueens = 0;

        public Form1()
        {
            //Create the squares
            for (int x = 0; x < 8; x++ )
            {
                //Create strips of squares along Y 
                List<Square> subList = new List<Square>();
                for(int y = 0; y < 8; y++)
                {
                    //Color according to location
                    if(x%2 == 1)
                    {
                        if(y%2 == 0)
                            subList.Add(new Square("BLACK", false));
                        else
                            subList.Add(new Square("WHITE", false));
                    }
                    else 
                    {
                        if (y%2 == 0)
                            subList.Add(new Square("WHITE", false));

                        else
                            subList.Add(new Square("BLACK", false));
                    }
                }
                //Add the vertical chains to the main list
                Board.Add(subList);
            }
            //Init form
            InitializeComponent();
            //Center
            this.CenterToScreen();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            //Draw the board with X Ys
            for(int x = 0; x < 8; x++)
            {
                for(int y = 0; y < 8; y++)
                {
                    //Math for the locations
                    Board[x][y].drawMe(e, (100 + x * 50), (100 + y * 50));
                }
            }
            Graphics g = e.Graphics;

            //Draw strings based on number of Queens
            if (numQueens != 1)
            {
                g.DrawString("You have " + numQueens + " Queens on the board.", Font, Brushes.Black, 200, 30);
            }
            else
            {
                g.DrawString("You have " + numQueens + " Queen on the board.", Font, Brushes.Black, 200, 30);
            }
        }

        private void Board_MouseClick(object sender, MouseEventArgs e)
        {
            //Flag for determining whether or not to call OnPaint
            bool reDraw = false;
            Point clicked = new Point(e.X, e.Y);
            if(e.Button == MouseButtons.Left)
            {
                //Flag to break out of nested loop
                bool flag = false;
                //Loop through every square and see if the click contained it
                for(int x = 0; x < 8; x++)
                {
                    for(int y = 0; y < 8; y++)
                    {
                        //Check if the click was contained in the board
                        if(Board[x][y].checkClick(clicked))
                        {
                            //Add the Queen and set flags
                            Board[x][y].addQueen(clicked);
                            reDraw = true;
                            flag = true;
                            break;
                        }
                    }
                    //Break out of the inner for loop
                    if(flag)
                    {
                        break;
                    }
                }
            }
            else if(e.Button == MouseButtons.Right)
            {
                bool flag = false;
                //Loop through every square and see if the click contained it
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        //Check the click with the Square
                        if(Board[x][y].checkClick(clicked))
                        {
                            //Remove the Queen on that Square
                            Board[x][y].removeQueen();

                            //Set the horizontal and verticle positions from the Queen as safe
                            for (int z = 0; z < 8; z++)
                            {
                                Board[x][z].setLineOfAttack(false);
                                Board[z][y].setLineOfAttack(false);
                            }

                            /*MARKING DIAGONALS AS SAFE*/
                            //Negative slope above the point
                            int yTransform = 1;
                            for (int z = x - 1; z >= 0; z--)
                            {
                                if (y - yTransform > -1)
                                {
                                    Board[z][y - yTransform].setLineOfAttack(false);
                                }
                                else
                                    break;
                                yTransform++;
                            }
                            //Negative slope below the point
                            yTransform = 1;
                            for (int z = x + 1; z < 8; z++)
                            {
                                if (y + yTransform < 8)
                                {
                                    Board[z][y + yTransform].setLineOfAttack(false);
                                }
                                else
                                    break;
                                yTransform++;
                            }
                            //Positive slope, above the point
                            int xTransform = 1;
                            for (int z = y - 1; z >= 0; z--)
                            {
                                if (x + xTransform < 8)
                                {
                                    Board[xTransform + x][z].setLineOfAttack(false);
                                }
                                else
                                    break;
                                xTransform++;
                            }
                            //Positive slope, below the point
                            xTransform = 1;
                            for (int z = y + 1; z < 8; z++)
                            {
                                if (x - xTransform > -1)
                                {
                                    Board[x - xTransform][z].setLineOfAttack(false);
                                }
                                else
                                    break;
                                xTransform++;
                            }

                            //Set flags
                            reDraw = true;
                            flag = true;
                            break;
                        }
                    }
                    //Break out of nested for
                    if(flag)
                    {
                        break;
                    }
                }
            }
            //Flag for calling Invalidate
            if (reDraw)
            {
                updateBoard();
                this.Invalidate();
                //If they won, let them know!
                if (numQueens == 8)
                {
                    MessageBox.Show("You did it!");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //If clear was hit, clear the board of Queens
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Board[x][y].removeQueen();
                    Board[x][y].setLineOfAttack(false);
                }
            }
            //Reset count and redraw board
            numQueens = 0;
            updateBoard();
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void HintBox_CheckedChanged(object sender, EventArgs e)
        {
            //Create a list of X Y coordinates of queens
            List<Tuple<int, int>> qCoords = new List<Tuple<int, int>>();

            //If the hintbox is checked
            if(HintBox.Checked)
            {
                Hints = true;
                //Loop through entire board and check for queens
                for(int x = 0; x < 8; x++)
                {
                    for(int y = 0; y < 8; y++)
                    {
                        //Add the coordinates of the found queen
                        if(Board[x][y].checkQueen())
                        {
                            qCoords.Add(new Tuple<int,int>(x,y));
                        }
                    }
                }
                //Set the proper squares to hint mode to be red
                for(int qCount = 0; qCount < qCoords.Count; qCount++)
                {
                    for(int x = 0; x < 8; x++)
                    {
                        Board[x][qCoords[qCount].Item2].setHint(true);
                        Board[qCoords[qCount].Item1][x].setHint(true);
                    }
                }
            }
            else
            {   
                //Remove the reds if hints is turned off
                Hints = false;
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        Board[x][y].setHint(false);
                    }
                }
            }
            //Redraw
            updateBoard();
            this.Invalidate();
        }
        
        private void updateBoard()
        {
            //Create a list of X Y coordinates of queens
            List<Tuple<int, int>> qCoords = new List<Tuple<int, int>>();

            //Check for Queens
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    //Add the coordinates of found queens
                    if (Board[x][y].checkQueen())
                    {
                        qCoords.Add(new Tuple<int, int>(x, y));
                    }
                }
            }
            //Set the proper squares to hint mode
            for (int qCount = 0; qCount < qCoords.Count; qCount++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Board[x][qCoords[qCount].Item2].setLineOfAttack(true);
                    Board[qCoords[qCount].Item1][x].setLineOfAttack(true);

                    if (Hints)
                    {
                        Board[x][qCoords[qCount].Item2].setHint(true);
                        Board[qCoords[qCount].Item1][x].setHint(true);
                    }
                }
                //Set the num Queens to the count
                numQueens = qCoords.Count;

                /*MARKING THE DIAGONALS AS UNSAFE*/

                //Negative slope above the point
                int yTransform = 1;
                for (int x = qCoords[qCount].Item1 - 1; x >= 0; x--)
                {
                    if (qCoords[qCount].Item2 - yTransform > -1)
                    {
                        Board[x][qCoords[qCount].Item2 - yTransform].setLineOfAttack(true);

                        if (Hints)
                            Board[x][qCoords[qCount].Item2 - yTransform].setHint(true);
                    }
                    else
                        break;
                    yTransform++;
                }
                //Negative slope below the point
                yTransform = 1;
                for (int x = qCoords[qCount].Item1 + 1; x < 8; x++)
                {
                    if (qCoords[qCount].Item2 + yTransform < 8)
                    {
                        Board[x][qCoords[qCount].Item2 + yTransform].setLineOfAttack(true);

                        if (Hints)
                            Board[x][qCoords[qCount].Item2 + yTransform].setHint(true);
                    }
                    else
                        break;
                    yTransform++;
                }
                //Positive slope above the point
                int xTransform = 1;
                for (int y = qCoords[qCount].Item2 - 1; y >= 0; y--)
                {
                    if (qCoords[qCount].Item1 + xTransform < 8)
                    {
                        Board[xTransform + qCoords[qCount].Item1][y].setLineOfAttack(true);
                        if (Hints)
                            Board[xTransform + qCoords[qCount].Item1][y].setHint(true);
                    }
                    else
                        break;
                    xTransform++;
                }
                //Positive slope below the point
                xTransform = 1;
                for (int y = qCoords[qCount].Item2 + 1; y < 8; y++)
                {
                    if (qCoords[qCount].Item1 - xTransform > -1)
                    {
                        Board[qCoords[qCount].Item1 - xTransform][y].setLineOfAttack(true);
                        if (Hints)
                            Board[qCoords[qCount].Item1 - xTransform][y].setHint(true);
                    }
                    else
                        break;
                    xTransform++;
                }
            }
        }
    }
}
