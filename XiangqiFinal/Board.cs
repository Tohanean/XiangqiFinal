using System;
using System.Drawing;
using System.Windows.Forms;

namespace XiangqiFinal
{
    public enum Player { P1, P2, EMPTY }
    public class Board
    {

        private Bitmap BoardImg;
        private Piece[,] BoardPosition;

        private int screenWidth;
        private int screenHeight;

        private int pieceWidth;
        private int pieceHeight;

        private Player previousPlayer;
        private Rectangle selectedPiece;
        private int selectedCol;
        private int selectedRow;
        private bool[,] selectedPiecePossibleMovements;




        public Board()
        {
            BoardImg = new Bitmap(XiangqiFinal.Properties.Resources.smboard);
            BoardPosition = new Piece[10, 9];

            previousPlayer = Player.P2;
            selectedPiece = Rectangle.Empty;

            pieceWidth = PiceceBitmap.Width;
            pieceHeight = PiceceBitmap.Height;

            
            screenWidth = GameScreen.width / 2;
            int BoardWidth = BoardImg.Width / 2;
            screenWidth = screenWidth - BoardWidth;

            screenHeight = GameScreen.height / 2;
            int BoardHeight = BoardImg.Height / 2;
            screenHeight = screenHeight - BoardHeight;

            
           
            InitPieces();

        }

       

        public  void Paint(PaintEventArgs e, Label l)
        {
            //Label label1 = new Label();
           

            PaintBoardImg(e);

            PaintPieces(e);
        }

         private void PaintBoardImg(PaintEventArgs e)
         {
             Graphics g = e.Graphics;
             g.DrawImage(BoardImg, new Rectangle(screenWidth, screenHeight, BoardImg.Width, BoardImg.Height));
         }

        internal void NewGame()
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    BoardPosition[row, col] = null;
                }
            }

            InitPieces();
            //  Player.P1;
        }

        public void HandleMouseClick(MouseEventArgs e)
         {
             if (e.Button == MouseButtons.Left)
             {
                OnMouseLeftClick(e);
               // new Soldier(Player.P1);
            }
            if (e.Button == MouseButtons.Right)
                OnMouseRightClick(e);
         }

        private void OnMouseRightClick(MouseEventArgs e)
        {
            selectedPiece = Rectangle.Empty;
            selectedCol = -1;
            selectedRow = -1;
            selectedPiecePossibleMovements = null;
        }

        private void OnMouseLeftClick(MouseEventArgs e)
        {
            if (!selectedPiece.IsEmpty) // Pawn already selected. Check if pawn can be moved.
            {
                bool pawnFound = false;

                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 10; col++)
                    {
                        // Verifica locatia
                        if (BoardPosition[col, row].GetRec().Contains(e.Location) && (BoardPosition[col, row].GetPlayer() == previousPlayer || BoardPosition[col, row].GetPlayer() == Player.EMPTY))
                        {
                            // verific daca locatia e aceasi cu ce vreau sa mut
                            if (col == selectedCol && row == selectedRow)
                            {
                                pawnFound = true;
                                break;
                            }
                            else
                            {
                                //verific daca piesa are voie sa se mute
                                if (BoardPosition[selectedCol, selectedRow].CheckMovement(selectedCol, selectedRow, col, row, BoardPosition))
                                {
                                    // se returneaza true daca se poate muta la locatie
                                    previousPlayer = previousPlayer == Player.P2 ? Player.P1 : Player.P2;
                                    Piece tempPawnStart = BoardPosition[selectedCol, selectedRow];
                                    Piece tempPawnEnd = BoardPosition[col, row];

                                    
                                
                               
                                    BoardPosition[col, row] = BoardPosition[selectedCol, selectedRow].Duplicate();
                                    BoardPosition[selectedCol, selectedRow] = new EmptyPiece();

                                    
                                

                                    //reset pt urm jucator
                                    selectedPiece = Rectangle.Empty;
                                    selectedCol = -1;
                                    selectedRow = -1;
                                    selectedPiecePossibleMovements = null;

                                    pawnFound = true;
                                    break;

                                }
                                else
                                {
                                    // piesa nu are voie sa se mute, inca e selectata
                                    pawnFound = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (pawnFound)
                    {
                        break;
                    }
                }
            }
            else if (selectedPiece.IsEmpty) 
            {
                bool pawnFound = false;

                for (int row = 0; row < 10; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (BoardPosition[row, col].GetPlayer() != Player.EMPTY && BoardPosition[row, col].GetPlayer() != previousPlayer && BoardPosition[row, col].GetRec().Contains(e.Location))
                        {
                            pawnFound = true;
                            selectedPiece = BoardPosition[row, col].GetRec();
                            selectedCol = row;
                            selectedRow = col;
                            selectedPiecePossibleMovements = BoardPosition[row, col].GetPossibleMovements(row, col, BoardPosition);

                            break;
                        }
                    }

                    if (pawnFound)
                    {
                        break;
                    }
                }
            }
        }

      




        private void PaintPieces(PaintEventArgs e)
         {
             Graphics g = e.Graphics;

             int locX = screenWidth - (pieceWidth / 2);
             int locY = screenHeight - (pieceHeight / 2);


             int marginX = pieceWidth + 12;
             int marginY = pieceHeight + 12;


            for (int row = 0; row < 10; row++)
             {
                 for (int col = 0; col < 9; col++)
                 {
                     if (BoardPosition[row, col] != null)
                     {
                         BoardPosition[row, col].Paint(g, (marginX * col) + locX, (marginY * row) + locY);
                     }
                 }
             }
            //InitPieces();
            if (!selectedPiece.IsEmpty)
            {
                g.DrawImage( PiceceBitmap.pieceMarker, selectedPiece);
            }

            if (selectedPiecePossibleMovements != null)
            {
                for (int row = 0; row < 10; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        if (selectedPiecePossibleMovements[row, col])
                        {
                            g.DrawImage(PiceceBitmap.pieceMarker, BoardPosition[row, col].GetRec());
                        }
                    }
                }
            }
        }
        
         private void InitPieces()
         {
             selectedPiece = Rectangle.Empty;
             selectedCol = -1;
             selectedRow = -1;
             selectedPiecePossibleMovements = null;
             BoardPosition[0, 4] = new General(Player.P1);
             BoardPosition[0, 3] = new Advisor(Player.P1);
             BoardPosition[0, 5] = new Advisor(Player.P1);
             BoardPosition[0, 1] = new Knight(Player.P1);
             BoardPosition[0, 7] = new Knight(Player.P1);
             BoardPosition[2, 1] = new Cannon(Player.P1);
             BoardPosition[2, 7] = new Cannon(Player.P1);
             BoardPosition[0, 0] = new Rook(Player.P1);
             BoardPosition[0, 8] = new Rook(Player.P1);
             BoardPosition[0, 2] = new Elephant(Player.P1);
             BoardPosition[0, 6] = new Elephant(Player.P1);
             BoardPosition[3, 0] = new Soldier(Player.P1);
             BoardPosition[3, 2] = new Soldier(Player.P1);
             BoardPosition[3, 4] = new Soldier(Player.P1);
             BoardPosition[3, 6] = new Soldier(Player.P1);
             BoardPosition[3, 8] = new Soldier(Player.P1);


             BoardPosition[9, 4] = new General(Player.P2);
             BoardPosition[9, 3] = new Advisor(Player.P2);
             BoardPosition[9, 5] = new Advisor(Player.P2);
             BoardPosition[9, 0] = new Rook(Player.P2);
             BoardPosition[9, 8] = new Rook(Player.P2);
             BoardPosition[9, 1] = new Knight(Player.P2);
             BoardPosition[9, 7] = new Knight(Player.P2);
             BoardPosition[7, 1] = new Cannon(Player.P2);
             BoardPosition[7, 7] = new Cannon(Player.P2);
             BoardPosition[9, 2] = new Elephant(Player.P2);
             BoardPosition[9, 6] = new Elephant(Player.P2);
             BoardPosition[6, 0] = new Soldier(Player.P2);
             BoardPosition[6, 2] = new Soldier(Player.P2);
             BoardPosition[6, 4] = new Soldier(Player.P2);
             BoardPosition[6, 6] = new Soldier(Player.P2);
             BoardPosition[6, 8] = new Soldier(Player.P2);

            //incarc locurile goale 
             for (int row = 0; row < 10; row++)
             {
                 for (int col = 0; col < 9; col++)
                 {
                     if (BoardPosition[row, col] == null)
                     {
                         BoardPosition[row, col] = new EmptyPiece();
                     }
                 }
             }




        }


    }
}