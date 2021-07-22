using System.Drawing;

namespace XiangqiFinal
{
    internal class General : Piece
    {
        private Player player;
        private Rectangle pieceLocation;

        public General(Player player)
        {
            this.player = player;
            pieceLocation = new Rectangle(0, 0, PiceceBitmap.Width, PiceceBitmap.Height);

        }

        public General(General r)
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
            return new General(this);
        }

        public Player GetPlayer()
        {
            return this.player;
        }

        public void Paint(Graphics g, int x, int y)
        {
            pieceLocation.X = x;
            pieceLocation.Y = y;

            g.DrawImage(player == Player.P1 ? PiceceBitmap.generalWesternBlack : PiceceBitmap.generalWesternRed, pieceLocation);


        }

        public bool CheckMovement(int fromX, int fromY, int toX, int toY, Piece[,] BoardPosition)
        {
            Player currentSide = BoardPosition[fromX, fromY].GetPlayer();
            int rowMin = currentSide == Player.P1 ? 0 : 7;
            int rowMax = currentSide == Player.P1 ? 2 : 9;

            //Check if movement is inside palace.
            if (toY <= 5 && toY >= 3 && toX >= rowMin && toX <= rowMax)
            {
                // Check top.
                if ((fromX - 1) == toX && fromY == toY)
                {
                    return true;
                }

                // Check left.
                if (fromX == toX && (fromY - 1) == toY)
                {
                    return true;
                }

                // Check bottom.
                if ((fromX + 1) == toX && fromY == toY)
                {
                    return true;
                }

                // Check right.
                if (fromX == toX && (fromY + 1) == toY)
                {
                    return true;
                }
            }

            return false;
        }

        public bool[,] GetPossibleMovements(int fromX, int fromY, Piece[,] BoardPosition)
        {
            Player currentSide = BoardPosition[fromX, fromY].GetPlayer();
            int rowMin = currentSide == Player.P1 ? 0 : 7;
            int rowMax = currentSide == Player.P1 ? 2 : 9;

            bool[,] possiblePositions = new bool[10, 9];

            int possibleX;
            int possibleY;

            // Check top.
            possibleX = (fromX - 1);
            possibleY = fromY;

            //Check if movement is inside palace.
            if (possibleY <= 5 && possibleY >= 3 && possibleX >= rowMin && possibleX <= rowMax)
            {
                if (BoardPosition[possibleX, possibleY].GetPlayer() == Player.EMPTY || BoardPosition[possibleX, possibleY].GetPlayer() != currentSide)
                {
                    possiblePositions[possibleX, possibleY] = true;
                }
            }

            // Check left.
            possibleX = fromX;
            possibleY = (fromY - 1);

            //Check if movement is inside palace.
            if (possibleY <= 5 && possibleY >= 3 && possibleX >= rowMin && possibleX <= rowMax)
            {
                if (BoardPosition[possibleX, possibleY].GetPlayer() == Player.EMPTY || BoardPosition[possibleX, possibleY].GetPlayer() != currentSide)
                {
                    possiblePositions[possibleX, possibleY] = true;
                }
            }

            // Check bottom.
            possibleX = (fromX + 1);
            possibleY = fromY;

            //Check if movement is inside palace.
            if (possibleY <= 5 && possibleY >= 3 && possibleX >= rowMin && possibleX <= rowMax)
            {
                if (BoardPosition[possibleX, possibleY].GetPlayer() == Player.EMPTY || BoardPosition[possibleX, possibleY].GetPlayer() != currentSide)
                {
                    possiblePositions[possibleX, possibleY] = true;
                }
            }

            // Check right.
            possibleX = fromX;
            possibleY = (fromY + 1);

            //Check if movement is inside palace.
            if (possibleY <= 5 && possibleY >= 3 && possibleX >= rowMin && possibleX <= rowMax)
            {
                if (BoardPosition[possibleX, possibleY].GetPlayer() == Player.EMPTY || BoardPosition[possibleX, possibleY].GetPlayer() != currentSide)
                {
                    possiblePositions[possibleX, possibleY] = true;
                }
            }

            return possiblePositions;
        }
    }
}