﻿using Table;
using Table.Enums;

namespace ChessGame.Pieces
{
    class King : Piece
    {
        public King(TableClass table, Color color) : base(table, color)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }

}
