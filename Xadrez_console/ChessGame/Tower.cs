using Table;
using Table.Enums;

namespace ChessGame
{
    class Tower : Piece
    {
        public Tower(TableClass table, Color color) : base(table, color)
        { 
        }
        public override string ToString()
        {
            return "T";
        }
    }
}



