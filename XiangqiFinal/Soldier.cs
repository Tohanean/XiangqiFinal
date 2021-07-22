using System.Drawing;

namespace XiangqiFinal
{
    internal class Soldier : Piece
    {
        private Player player;
        private Rectangle pieceLocation;
        private delegate bool compare(int i, int j);
        private delegate int compare2(int k);
        private delegate bool compare3(int i);


        public Soldier(Player player)
        {
            this.player = player;
            pieceLocation = new Rectangle(0, 0, PiceceBitmap.Width, PiceceBitmap.Height);

        }

        public Soldier(Soldier r)
        {
            this.player = r.GetPlayer();
            this.pieceLocation = r.GetRec();

        }

        public Rectangle GetRec()
        {
            return this.pieceLocation;
        }

        public Piece Duplicate()
        {
            return new Soldier(this);
        }

        public Player GetPlayer()
        {
            return this.player;
        }

        public void Paint(Graphics g, int x, int y)
        {
            pieceLocation.X = x;
            pieceLocation.Y = y;

            g.DrawImage(player == Player.P1 ? PiceceBitmap.soldierWesternBlack : PiceceBitmap.soldierWesternRed, pieceLocation);


        }

        public bool[,] GetPossibleMovements(int fromX, int fromY, Piece[,] BoardPosition)
        {
            return GetPossibleMovementsPiece(fromX, fromY, BoardPosition);
        }

        public bool CheckMovement(int fromX, int fromY, int toX, int toY, Piece[,] BoardPosition)
        {
            Player currentPlayer = BoardPosition[fromX, fromY].GetPlayer();
            bool passedRiver = false;

            if (currentPlayer == Player.P1)
                passedRiver = fromX < 5 ? false : true;
            //verific jos
            if((fromX + 1) < 10)
            {
                if ((fromX + 1) == toX && fromY == toY)
                {
                    return true;
                }
            }

            if(passedRiver)
            {
                //verific dreapta
                if((fromY + 1) < 9)
                {
                    if (fromX == toX &&(fromY + 1) == toY)
                    {
                        return true;
                    }
                }
                if ((fromY - 1) > -1)
                {
                    if (fromX == toX && (fromY - 1) == toY)
                    {
                        return true;
                    }
                }
            }

            if (currentPlayer == Player.P2)
            {
                passedRiver = fromX > 4 ? false : true;

                // verific sus.
                if ((fromX - 1) > -1)
                {
                    if ((fromX - 1) == toX && fromY == toY)
                    {
                        return true;
                    }
                }

                if (passedRiver)
                {
                    // verific dreapta
                    if ((fromY + 1) < 9)
                    {
                        if (fromX == toX && (fromY + 1) == toY)
                        {
                            return true;
                        }
                    }

                    // verific stanga
                    if ((fromY - 1) > -1)
                    {
                        if (fromX == toX && (fromY - 1) == toY)
                        {
                            return true;
                        }
                    }
                }
            }


            return false;
        }

        public bool[,] GetPossibleMovementsPiece(int fromX, int fromY, Piece[,] BoardPosition)
        {
            bool[,] possiblePositions = new bool[10, 9];

            Player currentSide = BoardPosition[fromX, fromY].GetPlayer();
            int riverRow = currentSide == Player.P1 ? 4 : 5;

            compare myDelegate = null;
            compare2 myDelegate2 = null;
            compare3 myDelegate3 = null;

            if (currentSide == Player.P1)
            {
                myDelegate = (i, j) => i > j;
                myDelegate2 = (k) => k + 1;
                myDelegate3 = (i) => i < 10;
            }
            else if (currentSide == Player.P2)
            {
                myDelegate = (i, j) => i < j;
                myDelegate2 = (k) => k - 1;
                myDelegate3 = (i) => i > -1;
            }

            bool passedRiver = myDelegate(fromX, riverRow);

            // Check down or up.
            if (myDelegate3(myDelegate2(fromX)))
            {
                possiblePositions[myDelegate2(fromX), fromY] = true;
            }

            if (passedRiver)
            {
                // Check right.
                if ((fromY + 1) < 9)
                {
                    possiblePositions[fromX, (fromY + 1)] = true;
                }

                // Check left.
                if ((fromY - 1) > -1)
                {
                    possiblePositions[fromX, (fromY - 1)] = true;
                }
            }

            return possiblePositions;
        }
    }
}