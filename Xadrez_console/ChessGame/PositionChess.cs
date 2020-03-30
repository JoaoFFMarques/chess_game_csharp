using Table;

namespace ChessGame
{
    class PositionChess
    {
        public char Collum { get; set; }
        public int Line { get; set; }

        public PositionChess(char collum, int line)
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
