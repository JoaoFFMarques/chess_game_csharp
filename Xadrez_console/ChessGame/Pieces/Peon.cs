using Table;
using Table.Enums;

namespace ChessGame.Pieces
{

    class Peon : Piece
    {

        private ChessMatch Match;

        public Peon(TableClass tab, Color color, ChessMatch match) : base(tab, color)
        {
            Match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool EnemyExists(Position pos)
        {
            Piece p = Table.PieceMethod(pos);
            return p != null && p.Color != Color;
        }

        private bool Freespot(Position pos)
        {
            return Table.PieceMethod(pos) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Table.Lines, Table.Columns];

            Position pos = new Position(0, 0);

            if(Color == Color.Branca)
            {
                pos.DefineVallues(Position.Line - 1, Position.Column);
                if(Table.ValidPosition(pos) && Freespot(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineVallues(Position.Line - 2, Position.Column);
                Position p2 = new Position(Position.Line - 1, Position.Column);
                if(Table.ValidPosition(p2) && Freespot(p2) && Table.ValidPosition(pos) && Freespot(pos) && QtdMovement == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineVallues(Position.Line - 1, Position.Column - 1);
                if(Table.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineVallues(Position.Line - 1, Position.Column + 1);
                if(Table.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #jogadaespecial en passant
                if(Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if(Table.ValidPosition(left) && EnemyExists(left) && Table.PieceMethod(left) == Match.EnPassantVulnerab)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if(Table.ValidPosition(right) && EnemyExists(right) && Table.PieceMethod(right) == Match.EnPassantVulnerab)
                    {

                        mat[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                pos.DefineVallues(Position.Line + 1, Position.Column);
                if(Table.ValidPosition(pos) && Freespot(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineVallues(Position.Line + 2, Position.Column);
                Position p2 = new Position(Position.Line + 1, Position.Column);
                if(Table.ValidPosition(p2) && Freespot(p2) && Table.ValidPosition(pos) && Freespot(pos) && QtdMovement == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineVallues(Position.Line + 1, Position.Column - 1);
                if(Table.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineVallues(Position.Line + 1, Position.Column + 1);
                if(Table.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #jogadaespecial en passant
                if(Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if(Table.ValidPosition(left) && EnemyExists(left) && Table.PieceMethod(left) == Match.EnPassantVulnerab)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if(Table.ValidPosition(right) && EnemyExists(right) && Table.PieceMethod(right) == Match.EnPassantVulnerab)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}
