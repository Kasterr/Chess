using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn:Piece
    {
        public Pawn(Color color, Type type) : base(color, type)
        {
            this.Color = color;
            this.Type = type;
            this.Selected = false;
        }

        public override void SelectFields(int y, int x)
        {
            this.Selected = true;

            if (Pieces.piece[y, x].Color == Color.White)
            { //WHITE PAWN
                if (y == 6 && Pieces.piece[y - 2, x].Color == Color.NULL && Pieces.piece[y - 1, x].Color == Color.NULL)
                {
                    Pieces.board[y-1, x].BackColor = System.Drawing.Color.SkyBlue;
                    Pieces.board[y-2, x].BackColor = System.Drawing.Color.SkyBlue;
                }
                if (Pieces.piece[y - 1, x].Color == Color.NULL)
                    Pieces.board[y - 1, x].BackColor = System.Drawing.Color.SkyBlue;
                if(x!=7)
                    if (Pieces.piece[y - 1, x + 1].Color == Color.Black)
                        Pieces.board[y - 1, x + 1].BackColor = System.Drawing.Color.SkyBlue;
                if(x!=0)
                    if (Pieces.piece[y - 1, x - 1].Color == Color.Black)
                        Pieces.board[y - 1, x - 1].BackColor = System.Drawing.Color.SkyBlue;
                Pieces.board[y, x].BackColor = System.Drawing.Color.LimeGreen;
            }
            else
            { //BLACK PAWN
                if (y == 1 && Pieces.piece[y + 2, x].Color == Color.NULL && Pieces.piece[y + 1, x].Color == Color.NULL)
                {
                    Pieces.board[y + 1, x].BackColor = System.Drawing.Color.SkyBlue;
                    Pieces.board[y + 2, x].BackColor = System.Drawing.Color.SkyBlue;
                }
                if (Pieces.piece[y + 1, x].Color == Color.NULL)
                    Pieces.board[y + 1, x].BackColor = System.Drawing.Color.SkyBlue;
                if (x != 7)
                    if (Pieces.piece[y + 1, x + 1].Color == Color.White)
                        Pieces.board[y + 1, x + 1].BackColor = System.Drawing.Color.SkyBlue;
                if (x != 0)
                    if (Pieces.piece[y + 1, x - 1].Color == Color.White)
                        Pieces.board[y + 1, x - 1].BackColor = System.Drawing.Color.SkyBlue;
                Pieces.board[y, x].BackColor = System.Drawing.Color.LimeGreen;
            }

            //SPECIAL MOVE SELECT: EN PASSANT
            if(Pieces.passantFlag1 == true && Pieces.pawnY==y && (Pieces.pawnX==x-1 || Pieces.pawnX==x+1) && Pieces.piece[y,x].Color!=Pieces.piece[Pieces.pawnY,Pieces.pawnX].Color)
                {
                    if(Pieces.piece[Pieces.pawnY,Pieces.pawnX].Color==Color.White)
                    { //White piece is EnPassant-able
                            Pieces.board[Pieces.pawnY + 1, Pieces.pawnX].BackColor = System.Drawing.Color.SkyBlue;
                    }
                    else if (Pieces.piece[Pieces.pawnY, Pieces.pawnX].Color == Color.Black)
                    { //Black piece is EnPassant-able
                            Pieces.board[Pieces.pawnY - 1, Pieces.pawnX].BackColor = System.Drawing.Color.SkyBlue;
                    }
                    Pieces.passantFlag2 = true;
                }
        }
    }
}
