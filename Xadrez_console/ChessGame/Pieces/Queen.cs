using Table;
using Table.Enums;

namespace ChessGame.Pieces
{

    class Queen : Piece
    {

        public Queen(TableClass tab, Color color) : base(tab, color)
        {
        }

        public override string ToString()
        {
            return "D";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Table.PieceMethod(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Table.Lines, Table.Columns];

            Position pos = new Position(0, 0);

            // esquerda
            pos.DefineVallues(Position.Line, Position.Column - 1);
            while(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Table.PieceMethod(pos) != null && Table.PieceMethod(pos).Color != Color)
                {
                    break;
                }
                pos.DefineVallues(pos.Line, pos.Column - 1);
            }

            // direita
            pos.DefineVallues(Position.Line, Position.Column + 1);
            while(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Table.PieceMethod(pos) != null && Table.PieceMethod(pos).Color != Color)
                {
                    break;
                }
                pos.DefineVallues(pos.Line, pos.Column + 1);
            }

            // acima
            pos.DefineVallues(Position.Line - 1, Position.Column);
            while(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Table.PieceMethod(pos) != null && Table.PieceMethod(pos).Color != Color)
                {
                    break;
                }
                pos.DefineVallues(pos.Line - 1, pos.Column);
            }

            // abaixo
            pos.DefineVallues(Position.Line + 1, Position.Column);
            while(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Table.PieceMethod(pos) != null && Table.PieceMethod(pos).Color != Color)
                {
                    break;
                }
                pos.DefineVallues(pos.Line + 1, pos.Column);
            }

            // NO
            pos.DefineVallues(Position.Line - 1, Position.Column - 1);
            while(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Table.PieceMethod(pos) != null && Table.PieceMethod(pos).Color != Color)
                {
                    break;
                }
                pos.DefineVallues(pos.Line - 1, pos.Column - 1);
            }

            // NE
            pos.DefineVallues(Position.Line - 1, Position.Column + 1);
            while(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Table.PieceMethod(pos) != null && Table.PieceMethod(pos).Color != Color)
                {
                    break;
                }
                pos.DefineVallues(pos.Line - 1, pos.Column + 1);
            }

            // SE
            pos.DefineVallues(Position.Line + 1, Position.Column + 1);
            while(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Table.PieceMethod(pos) != null && Table.PieceMethod(pos).Color != Color)
                {
                    break;
                }
                pos.DefineVallues(pos.Line + 1, pos.Column + 1);
            }

            // SO
            pos.DefineVallues(Position.Line + 1, Position.Column - 1);
            while(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Table.PieceMethod(pos) != null && Table.PieceMethod(pos).Color != Color)
                {
                    break;
                }
                pos.DefineVallues(pos.Line + 1, pos.Column - 1);
            }

            return mat;
        }
    }
}
