using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace XiangqiFinal
{
    public partial class GameScreen : Form
    {
        
        public static int width = 1024;
        public static int height = 800; 
        public Board board;
        public GameScreen()
        {

            InitializeComponent();

            Width = width;
            Height = height;
            CenterToScreen();
            Text = "Xiangqi";
            FormBorderStyle = FormBorderStyle.FixedSingle;

            DoubleBuffered = true;

            board = new Board();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

           // Board.Paint(e, label1);
        
            board.Paint(e ,label2);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            board.HandleMouseClick(e);
            Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void startGame_Click(object sender, EventArgs e)
        {
            board.NewGame();
            Refresh();
        }
    }
}
