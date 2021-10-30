using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public enum Type { King, Queen, Rook, Knight, Bishop, Pawn, NULL}
    public enum Color { Black, White, NULL}
    public class Piece
    {
        private Color color;
        private Type type;
        private bool selected;
        
        public Piece(Color color, Type type)
        {
            this.color = color;
            this.type = type;
            this.selected = false;
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public Type Type
        {
            get { return type; }
            set { type = value; }
        }
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        public virtual void SelectFields(int y, int x) { } 

    }

}
