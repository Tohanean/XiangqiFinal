using System.Drawing;

namespace XiangqiFinal
{
    public interface Piece
    {
        void Paint(Graphics g, int x, int y);

        bool CheckMovement(int fromX, int fromY, int toX, int toY, Piece[,] BoardPosition);

        bool[,] GetPossibleMovements(int fromX, int fromY, Piece[,] BoardPosition);

        Rectangle GetRec();

        Player GetPlayer();
        Piece Duplicate();
    }
}