using Table;
using Table.Enums;

namespace ChessGame.Pieces
{
    class King : Piece
    {
        public King(TableClass table, Color color) : base(table, color)
        {
        }

        private bool CanMove(Position pos)
        {
            Piece p = Table.PieceMethod(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Table.Lines, Table.Collums];
            Position pos = new Position(0, 0);
            //acima
            pos.DefineVallues(Position.Line - 1, Position.Columm);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Columm] = true;
            }
            //ne
            pos.DefineVallues(Position.Line - 1, Position.Columm + 1);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Columm] = true;
            }
            //direita
            pos.DefineVallues(Position.Line, Position.Columm + 1);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Columm] = true;
            }

            //se
            pos.DefineVallues(Position.Line + 1, Position.Columm + 1);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Columm] = true;
            }

            //abaixo
            pos.DefineVallues(Position.Line + 1, Position.Columm);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Columm] = true;
            }

            //so
            pos.DefineVallues(Position.Line + 1, Position.Columm - 1);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Columm] = true;
            }

            // esquerda
            pos.DefineVallues(Position.Line, Position.Columm - 1);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Columm] = true;
            }
            //no
            pos.DefineVallues(Position.Line - 1, Position.Columm - 1);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Columm] = true;
            }

            return mat;

        }

        public override string ToString()
        {
            return "R";
        }


    }

}

