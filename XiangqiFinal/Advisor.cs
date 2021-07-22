using System.Drawing;

namespace XiangqiFinal
{
    internal class Advisor : Piece
    {
        private Player player;
        private Rectangle pieceLocation;

        public Advisor(Player player)
        {
            this.player = player;
            pieceLocation = new Rectangle(0, 0, PiceceBitmap.Width, PiceceBitmap.Height);

        }

        public Advisor(Advisor r)
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
            return new Advisor(this);
        }

        public Player GetPlayer()
        {
            return this.player;
        }

        public bool[,] GetPossibleMovements(int fromX, int fromY, Piece[,] BoardPosition)
        {
            return GetPossibleMovementsPiece(fromX, fromY, BoardPosition);
        }

        public void Paint(Graphics g, int x, int y)
        {
            pieceLocation.X = x;
            pieceLocation.Y = y;

            g.DrawImage(player == Player.P1 ? PiceceBitmap.advisorWesternBlack : PiceceBitmap.advisorWesternRed, pieceLocation);


        }

        public bool CheckMovement(int fromX, int fromY, int toX, int toY, Piece[,] BoardPosition)
        {
            Player currentPlayer = BoardPosition[fromX, fromY].GetPlayer();
            bool pieceMoved = false;

            // Movement is on the same column.
            if (fromY == toY)
            {
                //Check vertical up.
                for (int row = (fromX - 1); row > -1; row--)
                {
                    if (row == toX)
                    {
                        if (pieceMoved && BoardPosition[row, fromY].GetPlayer() != Player.EMPTY &&
                            BoardPosition[row, fromY].GetPlayer() != currentPlayer)
                        {
                            return true;
                        }
                        else if (!pieceMoved && BoardPosition[row, fromY].GetPlayer() == Player.EMPTY)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (BoardPosition[row, toY].GetPlayer() != Player.EMPTY)
                        {
                            if (!pieceMoved)
                            {
                                pieceMoved = true;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

                pieceMoved = false;
            }

            return false;
        }

        public bool[,] GetPossibleMovementsPiece(int fromX, int fromY, Piece[,] BoardPosition)
        {
            bool[,] possiblePositions = new bool[10, 9];

            Player currentSide = BoardPosition[fromX, fromY].GetPlayer();
            bool hasPassedPawn = false;

            //Check vertical up.
            for (int row = (fromX - 1); row > -1; row--)
            {
                if (hasPassedPawn && BoardPosition[row, fromY].GetPlayer() != Player.EMPTY &&
                    BoardPosition[row, fromY].GetPlayer() != currentSide)
                {
                    possiblePositions[row, fromY] = true;
                    break;
                }
                else if (!hasPassedPawn && BoardPosition[row, fromY].GetPlayer() == Player.EMPTY)
                {
                    possiblePositions[row, fromY] = true;
                }

                if (BoardPosition[row, fromY].GetPlayer() != Player.EMPTY)
                {
                    if (!hasPassedPawn)
                    {
                        hasPassedPawn = true;
                    }
                }
            }

            return possiblePositions;
        }
    }
}