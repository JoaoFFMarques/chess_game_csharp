using System;
using System.Collections.Generic;
using System.Text;
using Table;

namespace ChessGame
{
    class PostionChess
    {
        public char Collum { get; set; }
        public int Line { get; set; }

        public PostionChess(char collum, int line)
        {
            Collum = collum;
            Line = line;
        }

        public Position ToPosition()
        {
            return new Position(8 - Line, Collum - 'a');
        }

        public override string ToString()
        {
            return "" + Collum + Line;
        }
    }
}
