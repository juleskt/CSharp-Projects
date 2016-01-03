using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Engine
    {
        //Engine contains the grid
        public enum CellSelection { N, O, X };
        public CellSelection[,] inGrid = new CellSelection[3, 3];
        public CellSelection moveType = CellSelection.O;
        //To track the state of the game
        public bool over = false;

        //Default constructor builds the board
        public Engine()
        {
            gameStart();
        }

        //Resets/builds a board
        public void gameStart()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    inGrid[x, y] = CellSelection.N;
                }
            }

            over = false;
        }

        //Checks if the board has any moves left
        public bool fullBoard()
        {
            int empty = 0;

            for(int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    if (moveIsValid(x, y))
                        empty++;
                }
            }

            if (empty == 0)
            {
                over = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Checks victory conditions
        public Tuple<CellSelection,bool> victory()
        {
            for(int x = 0; x < 3; x++)
            {
                //Horizontal
                if( (inGrid[x,0] == inGrid[x,1]) && (inGrid[x,1] == inGrid[x,2]) && (inGrid[x,0] != CellSelection.N) )
                {
                    over = true;
                    return Tuple.Create(inGrid[x,0], true);
                }
                //Vertical
                else if( (inGrid[0,x] == inGrid[1,x]) && (inGrid[1,x] == inGrid[2,x]) && (inGrid[0,x] != CellSelection.N) )
                {
                    over = true;
                    return Tuple.Create(inGrid[0,x], true);
                }
            }

            //Diagonal
            if( (inGrid[0,0] == inGrid[1,1]) && (inGrid[1,1] == inGrid[2,2]) && (inGrid[0,0] != CellSelection.N) )
            {
                over = true;
                return Tuple.Create(inGrid[0,0], true);
            }
            else if ((inGrid[0,2] == inGrid[1, 1]) && (inGrid[1, 1] == inGrid[2,0]) && (inGrid[0, 2] != CellSelection.N))
            {
                over = true;
                return Tuple.Create(inGrid[0,2], true);
            }

                return Tuple.Create(inGrid[0,0], false);
        }

        //Checks if a move is valid
        public bool moveIsValid(int x , int y)
        {
            return (this.inGrid[x, y] == CellSelection.N);
        }
        //Winning/blocking moves
        public bool absoluteMove()
        {
            for (int x = 0; x < 3; x++)
            {
                //Horizontal moves
                //Absolute is rightmost
                if ((inGrid[x, 0] == inGrid[x, 1]) && (inGrid[x, 0] != CellSelection.N))
                {
                    if (moveIsValid(x, 2))
                    {
                        inGrid[x, 2] = moveType;
                        return true;
                    }
                }
                //Absolute is leftmost
                if ((inGrid[x, 1] == inGrid[x, 2]) && (inGrid[x, 2] != CellSelection.N))
                {
                    if (moveIsValid(x, 0))
                    {
                        inGrid[x, 0] = moveType;
                        return true;
                    }
                }
                //Absolute is in the middle
                if ((inGrid[x, 0] == inGrid[x, 2]) && (inGrid[x, 0] != CellSelection.N))
                {
                    if (moveIsValid(x, 1))
                    {
                        inGrid[x, 1] = moveType;
                        return true;
                    }
                }
                //Vertical moves
                //Absolute is bottom
                if ((inGrid[0, x] == inGrid[1, x]) && (inGrid[0, x] != CellSelection.N))
                {
                    if(moveIsValid(2,x))
                    {
                        inGrid[2, x] = moveType;
                        return true;
                    }
                }
                //Absolute is middle
                if ((inGrid[0, x] == inGrid[2, x]) && (inGrid[0, x] != CellSelection.N))
                {
                    if (moveIsValid(1, x))
                    {
                        inGrid[1, x] = moveType;
                        return true;
                    }
                }
                //Absolute is top
                if ((inGrid[1, x] == inGrid[2, x]) && (inGrid[1, x] != CellSelection.N))
                {
                    if (moveIsValid(0, x))
                    {
                        inGrid[0, x] = moveType;
                        return true;
                    }
                }
            }
            //Diagonal moves
            //Absolute is lower-right
            if ((inGrid[0, 0] == inGrid[1, 1]) && (inGrid[0, 0] != CellSelection.N))
            {
                if(moveIsValid(2,2))
                {
                    inGrid[2, 2] = moveType;
                    return true;
                }
            }
            //Absolute is upper-left
            if ((inGrid[1, 1] == inGrid[2, 2]) && (inGrid[1, 1] != CellSelection.N))
            {
                if (moveIsValid(0, 0))
                {
                    inGrid[0, 0] = moveType;
                    return true;
                }
            }
            //Absolute is middle
            if ((inGrid[0, 0] == inGrid[2, 2]) && (inGrid[0, 0] != CellSelection.N))
            {
                if (moveIsValid(1, 1))
                {
                    inGrid[1, 1] = moveType;
                    return true;
                }
            }
            //Absolute is upper-right
            if ((inGrid[0, 2] == inGrid[1, 1]) && (inGrid[0, 2] != CellSelection.N))
            {
                if (moveIsValid(2, 0))
                {
                    inGrid[2, 0] = moveType;
                    return true;
                }
            }
            //Absolute is lower-left
            if ((inGrid[1, 1] == inGrid[2, 0]) && (inGrid[1, 1] != CellSelection.N))
            {
                if (moveIsValid(0, 2))
                {
                    inGrid[0, 2] = moveType;
                    return true;
                }
            }
            //Absolute is middle
            if ((inGrid[0, 2] == inGrid[0, 2]) && (inGrid[2, 0] != CellSelection.N))
            {
                if (moveIsValid(1, 1))
                {
                    inGrid[1,1] = moveType;
                    return true;
                }
            }

            return false;
        }
        //Random move
        private CellSelection[,] randMove(CellSelection[,] inGrid)
        {
            Random random = new Random();
            int x, y;

            while (true)
            {
                x = random.Next(0, 3);
                y = random.Next(0, 3);

                if ( moveIsValid(x,y) )
                {
                    inGrid[x, y] = moveType;
                    return inGrid;
                }
            }
        }
        //Actuall make a move
        public void makeMove()
        {
            bool result;
            result = absoluteMove();
            //If an absolute move was not taken
            if (!result)
            {
                //Move randomly
                randMove(inGrid);
            }
        }
        //Check to make sure the player's move is valid
        public void playerMove(int x, int y)
        {
            if (moveIsValid(x, y))
            {
                this.inGrid[x, y] = CellSelection.X;
            }
        }
    }
}
