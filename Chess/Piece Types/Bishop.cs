using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(Color color, Type type) : base(color, type)
        {
            this.Color = color;
            this.Type = type;
            this.Selected = false;
        }

        public override void SelectFields(int y, int x)
        {
            int i, j;
            bool hitFlag;
            this.Selected = true;

            for (i = 0; i < 8; i++)
                for (j = 0; j < 8; j++)
                {
                    if (Math.Abs(i - x) == Math.Abs(j - y))
                        if (Pieces.piece[j, i].Color == Color.NULL || Pieces.piece[j, i].Color != Pieces.piece[y, x].Color)
                            Pieces.board[j, i].BackColor = System.Drawing.Color.SkyBlue;
                }

            //COLLISION CHECK
            hitFlag = false;
            i = x - 1; j = y - 1;
            while (i >= 0 && j >= 0)
            {
                if (Pieces.piece[j, i].Color != Color.NULL && hitFlag == false)
                    hitFlag = true;
                else if (hitFlag == true)
                {
                    if ((j + i) % 2 == 1)
                        Pieces.board[j, i].BackColor = System.Drawing.Color.FromArgb(41, 41, 41);
                    else
                        Pieces.board[j, i].BackColor = System.Drawing.Color.FromArgb(81, 81, 81);
                }
                i--;
                j--;
            }//TOP LEFT
            hitFlag = false;
            i = x + 1; j = y - 1;
            while (i < 8 && j >= 0)
            {
                if (Pieces.piece[j, i].Color != Color.NULL && hitFlag == false)
                    hitFlag = true;
                else if (hitFlag == true)
                {
                    if ((j + i) % 2 == 1)
                        Pieces.board[j, i].BackColor = System.Drawing.Color.FromArgb(41, 41, 41);
                    else
                        Pieces.board[j, i].BackColor = System.Drawing.Color.FromArgb(81, 81, 81);
                }
                i++;
                j--;
            }//TOP RIGHT
            hitFlag = false;
            i = x + 1; j = y + 1;
            while (i < 8 && j < 8)
            {
                if (Pieces.piece[j, i].Color != Color.NULL && hitFlag == false)
                    hitFlag = true;
                else if (hitFlag == true)
                {
                    if ((j + i) % 2 == 1)
                        Pieces.board[j, i].BackColor = System.Drawing.Color.FromArgb(41, 41, 41);
                    else
                        Pieces.board[j, i].BackColor = System.Drawing.Color.FromArgb(81, 81, 81);
                }
                i++;
                j++;
            }//BOTTOM RIGHT
            hitFlag = false;
            i = x - 1; j = y + 1;
            while (i >= 0 && j < 8)
            {
                if (Pieces.piece[j, i].Color != Color.NULL && hitFlag == false)
                    hitFlag = true;
                else if (hitFlag == true)
                {
                    if ((j + i) % 2 == 1)
                        Pieces.board[j, i].BackColor = System.Drawing.Color.FromArgb(41, 41, 41);
                    else
                        Pieces.board[j, i].BackColor = System.Drawing.Color.FromArgb(81, 81, 81);
                }
                i--;
                j++;
            }//BOTTOM LEFT

            Pieces.board[y, x].BackColor = System.Drawing.Color.LimeGreen;

        }
    }
}
