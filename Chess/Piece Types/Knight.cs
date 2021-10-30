using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Knight:Piece
    {
        public Knight(Color color, Type type) : base(color, type)
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
                    if ((x+2==i && (y+1==j || y-1==j)) || (x - 2 == i && (y + 1 == j || y - 1 == j)) || (y - 2 == j && (x + 1 == i || x - 1 == i)) || (y + 2 == j && (x + 1 == i || x - 1 == i)))
                        if (Pieces.piece[j, i].Color == Color.NULL || Pieces.piece[j, i].Color != Pieces.piece[y, x].Color)
                            Pieces.board[j, i].BackColor = System.Drawing.Color.SkyBlue;
                }

            Pieces.board[y, x].BackColor = System.Drawing.Color.LimeGreen;
        }
    }
}
