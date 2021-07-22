using System.Drawing;

namespace XiangqiFinal
{
    internal class EmptyPiece : Piece
    {
        private Player player;
        private Rectangle pieceLocation;

        public EmptyPiece()
        {
            player = Player.EMPTY;
            pieceLocation = new Rectangle(0, 0, 52, 52);

        }

        public EmptyPiece(EmptyPiece r)
        {
            this.player = r.GetPlayer();

            this.pieceLocation = r.GetRec();
        }

        public Rectangle GetRec()
        {
            return this.pieceLocation;
        }

        public Player GetPlayer()
        {
            return this.player;
        }

        public void Paint(Graphics g, int x, int y)
        {
            pieceLocation.X = x;
            pieceLocation.Y = y;

            g.DrawImage(PiceceBitmap.emptyPiece, pieceLocation);
        }

        public Piece Duplicate()
        {
            return new EmptyPiece(this);
        }

        public bool[,] GetPossibleMovements(int fromX, int fromY, Piece[,] BoardPosition)
        {
            return null;
        }
        public bool CheckMovement(int fromX, int fromY, int toX, int toY, Piece[,] BoardPosition)
        {
            return false;
        }

    }
}