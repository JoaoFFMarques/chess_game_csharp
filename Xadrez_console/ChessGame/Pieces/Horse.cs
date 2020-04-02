using Table;
using Table.Enums;

namespace ChessGame.Pieces
{
    class Horse : Piece
    {

        public Horse(TableClass tab, Color color) : base(tab, color)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        private bool CanMover(Position pos)
        {
            Piece p = Table.PieceMethod(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Table.Lines, Table.Columns];

            Position pos = new Position(0, 0);

            pos.DefineVallues(Position.Line - 1, Position.Column - 2);
            if(Table.ValidPosition(pos) && CanMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefineVallues(Position.Line - 2, Position.Column - 1);
            if(Table.ValidPosition(pos) && CanMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefineVallues(Position.Line - 2, Position.Column + 1);
            if(Table.ValidPosition(pos) && CanMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefineVallues(Position.Line - 1, Position.Column + 2);
            if(Table.ValidPosition(pos) && CanMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefineVallues(Position.Line + 1, Position.Column + 2);
            if(Table.ValidPosition(pos) && CanMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefineVallues(Position.Line + 2, Position.Column + 1);
            if(Table.ValidPosition(pos) && CanMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefineVallues(Position.Line + 2, Position.Column - 1);
            if(Table.ValidPosition(pos) && CanMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefineVallues(Position.Line + 1, Position.Column - 2);
            if(Table.ValidPosition(pos) && CanMover(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
