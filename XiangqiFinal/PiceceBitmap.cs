using System.Drawing;

namespace XiangqiFinal
{
    internal class PiceceBitmap
    {
        public static int Width = 52;
        public static int Height = 52;

        public static Bitmap cannonWesternBlack = new Bitmap(XiangqiFinal.Properties.Resources.we_b_cannon);
        public static Bitmap generalWesternBlack = new Bitmap(XiangqiFinal.Properties.Resources.we_b_general);
        public static Bitmap advisorWesternBlack = new Bitmap(XiangqiFinal.Properties.Resources.we_b_advisor);
        public static Bitmap rookWesternBlack = new Bitmap(XiangqiFinal.Properties.Resources.we_b_rook);
        public static Bitmap elephantWesternBlack = new Bitmap(XiangqiFinal.Properties.Resources.we_b_elephant);
        public static Bitmap knightWesternBlack = new Bitmap(XiangqiFinal.Properties.Resources.we_b_knight);
        public static Bitmap soldierWesternBlack = new Bitmap(XiangqiFinal.Properties.Resources.we_b_soldier);

        public static Bitmap cannonWesternRed = new Bitmap(XiangqiFinal.Properties.Resources.we_r_cannon);
        public static Bitmap generalWesternRed = new Bitmap(XiangqiFinal.Properties.Resources.we_r_general);
        public static Bitmap advisorWesternRed = new Bitmap(XiangqiFinal.Properties.Resources.we_r_advisor);
        public static Bitmap rookWesternRed = new Bitmap(XiangqiFinal.Properties.Resources.we_r_rook);
        public static Bitmap elephantWesternRed = new Bitmap(XiangqiFinal.Properties.Resources.we_r_elephant);
        public static Bitmap knightWesternRed = new Bitmap(XiangqiFinal.Properties.Resources.we_r_knight);
        public static Bitmap soldierWesternRed = new Bitmap(XiangqiFinal.Properties.Resources.we_r_soldier);

        public static Bitmap selectedPiece = new Bitmap(XiangqiFinal.Properties.Resources.pawn_marker);
        public static Bitmap posibleMovement = new Bitmap(XiangqiFinal.Properties.Resources.possiblemovement);
        public static Bitmap emptyPiece = new Bitmap(XiangqiFinal.Properties.Resources.pawn_empty);
        public static Bitmap pieceMarker = new Bitmap(XiangqiFinal.Properties.Resources.piece_marker);
    }
}