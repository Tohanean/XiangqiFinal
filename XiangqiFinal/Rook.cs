using System.Drawing;

namespace XiangqiFinal
{
    internal class Rook : Piece
    {
        private Player player;
        private Rectangle pieceLocation;

        public Rook(Player player)
        {
            this.player = player;
            pieceLocation = new Rectangle(0, 0, PiceceBitmap.Width, PiceceBitmap.Height);

        }

        public Rook(Rook r)
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
            return new Rook(this);
        }
        public Player GetPlayer()
        {
            return this.player;
        }

        public void Paint(Graphics g, int x, int y)
        {
            pieceLocation.X = x;
            pieceLocation.Y = y;

            g.DrawImage(player == Player.P1 ? PiceceBitmap.rookWesternBlack : PiceceBitmap.rookWesternRed, pieceLocation);


        }

        public bool[,] GetPossibleMovements(int fromX, int fromY, Piece[,] BoardPosition)
        {
            return GetPossibleMovementsPiece(fromX, fromY, BoardPosition);
        }


        public bool CheckMovement(int fromX, int fromY, int toX, int toY, Piece[,] BoardPosition)
        {
            Player currentPlayer = BoardPosition[fromX, fromY].GetPlayer();
            bool pieceMoved = false;

            
            if (fromY == toY)
            {
                //verific sus
                for (int row = (fromX - 1); row > -1; row--)
                {
                    if (row == toX)
                    {
                        return true;
                    }
                    else
                    {
                        if (BoardPosition[row, toY].GetPlayer() != Player.EMPTY)
                        {
                            break;
                        }
                    }
                }

                //verific in jos

                for (int row = (fromX + 1); row<10; row++)
                    if (row == toX)
                    {
                        return true;
                    }
                    else
                    {
                        if (BoardPosition[row, toY].GetPlayer() != Player.EMPTY)
                        {
                            break;
                        }
                    }

                

                // Movement is on the same row.
                if (fromX == toX)
                {
                    //Check horizontal right.
                    for (int col = (fromY + 1); col < 9; col++)
                    {
                        if (col == toY)
                        {
                            return true;
                        }
                        else
                        {
                            if (BoardPosition[toX, col].GetPlayer() != Player.EMPTY)
                            {
                                break;
                            }
                        }
                    }

                    //Check horizontal left.
                    for (int col = (fromY - 1); col > -1; col--)
                    {
                        if (col == toY)
                        {
                            return true;
                        }
                        else
                        {
                            if (BoardPosition[toX, col].GetPlayer() != Player.EMPTY)
                            {
                                break;
                            }
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
            bool piecePassed = false;

            //Check vertical up.
            for (int row = (fromX - 1); row > -1; row--)
            {
                if (piecePassed)
                {
                    piecePassed = false;
                    break;
                }

                possiblePositions[row, fromY] = true;

                if (BoardPosition[row, fromY].GetPlayer() != Player.EMPTY)
                {
                    // Same pawn color.
                    if (BoardPosition[row, fromY].GetPlayer() == BoardPosition[fromX, fromY].GetPlayer())
                    {
                        possiblePositions[row, fromY] = false;
                    }
                    piecePassed = true;
                }
            }
            piecePassed = false;

            for (int row = (fromX + 1); row < 10; row++)
            {
                if (piecePassed)
                {
                    piecePassed = false;
                    break;
                }

                possiblePositions[row, fromY] = true;

                if (BoardPosition[row, fromY].GetPlayer() != Player.EMPTY)
                {
                    // Same pawn color.
                    if (BoardPosition[row, fromY].GetPlayer() == BoardPosition[fromX, fromY].GetPlayer())
                    {
                        possiblePositions[row, fromY] = false;
                    }
                    piecePassed = true;
                }
            }
            piecePassed = false;

            for (int col = (fromY + 1); col < 9; col++)
            {
                if (piecePassed)
                {
                    piecePassed = false;
                    break;
                }

                possiblePositions[fromX, col] = true;

                if (BoardPosition[fromX, col].GetPlayer() != Player.EMPTY)
                {
                    // Same pawn color.
                    if (BoardPosition[fromX, col].GetPlayer() == BoardPosition[fromX, fromY].GetPlayer())
                    {
                        possiblePositions[fromX, col] = false;
                    }
                    piecePassed = true;
                }
            }

            piecePassed = false;

            for (int col = (fromY - 1); col > -1; col++)
            {
                if (piecePassed)
                {
                    piecePassed = false;
                    break;
                }

                possiblePositions[fromX, col] = true;

                if (BoardPosition[fromX, col].GetPlayer() != Player.EMPTY)
                {
                    // Same pawn color.
                    if (BoardPosition[fromX, col].GetPlayer() == BoardPosition[fromX, fromY].GetPlayer())
                    {
                        possiblePositions[fromX, col] = false;
                    }
                    piecePassed = true;
                }
            }







            return possiblePositions;
        }
    }
}