using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King:Piece
    {
        public King(Color color, Type type) : base(color, type)
        {
            this.Color = color;
            this.Type = type;
            this.Selected = false;
        }

        public override void SelectFields(int y, int x)
        {
            int i, j;
            this.Selected = true;

            for (i = 0; i < 8; i++)
                for (j = 0; j < 8; j++)
                {
                    if((Math.Abs(i-x)==1 || Math.Abs(i-x)==0) && (Math.Abs(j - y) == 1 || Math.Abs(j - y) == 0))
                        if(Pieces.piece[j,i].Color==Color.NULL || Pieces.piece[j, i].Color != Pieces.piece[y, x].Color)
                            Pieces.board[j, i].BackColor = System.Drawing.Color.SkyBlue;
                }

            //SPECIAL MOVE SELECT: CASTLING
            if(Pieces.piece[7, 5].Color==Color.NULL && Pieces.piece[7, 6].Color == Color.NULL)
                if (y == 7 && x == 4 && Pieces.piece[y, x].Color == Color.White && Pieces.piece[7,7].Type==Type.Rook && Pieces.piece[7, 7].Color == Color.White)
                {
                    Pieces.board[7, 7].BackColor = System.Drawing.Color.SkyBlue;
                    Pieces.castleFlag = true;
                }
            if (Pieces.piece[7, 3].Color == Color.NULL && Pieces.piece[7, 2].Color == Color.NULL && Pieces.piece[7, 1].Color == Color.NULL)
                if (y == 7 && x == 4 && Pieces.piece[y, x].Color == Color.White && Pieces.piece[7, 0].Type == Type.Rook && Pieces.piece[7, 0].Color == Color.White)
                {
                    Pieces.board[7, 0].BackColor = System.Drawing.Color.SkyBlue;
                    Pieces.castleFlag = true;
                }
            if (Pieces.piece[0, 5].Color == Color.NULL && Pieces.piece[0, 6].Color == Color.NULL)
                if (y == 0 && x == 4 && Pieces.piece[y, x].Color == Color.Black && Pieces.piece[0, 7].Type == Type.Rook && Pieces.piece[0, 7].Color == Color.Black)
                {
                    Pieces.board[0, 7].BackColor = System.Drawing.Color.SkyBlue;
                    Pieces.castleFlag = true;
                }
            if (Pieces.piece[0, 3].Color == Color.NULL && Pieces.piece[0, 2].Color == Color.NULL && Pieces.piece[0, 1].Color == Color.NULL)
                if (y == 0 && x == 4 && Pieces.piece[y, x].Color == Color.Black && Pieces.piece[0, 0].Type == Type.Rook && Pieces.piece[0, 0].Color == Color.Black)
                {
                    Pieces.board[0, 0].BackColor = System.Drawing.Color.SkyBlue;
                    Pieces.castleFlag = true;
                }

            Pieces.board[y, x].BackColor = System.Drawing.Color.LimeGreen;

        }
    }
}
