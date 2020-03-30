using Table;
using Table.Enums;

namespace ChessGame.Pieces
{
    class Tower : Piece
    {
        public Tower(TableClass table, Color color) : base(table, color)
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
            while(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Columm] = true;
                if(Table.PieceMethod(pos) != null && Table.PieceMethod(pos).Color != Color)
                {
                    break;
                }
                pos.Line -= 1;
            }

            //direita
            pos.DefineVallues(Position.Line, Position.Columm + 1);
            while(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Columm] = true;
                if(Table.PieceMethod(pos) != null && Table.PieceMethod(pos).Color != Color)
                {
                    break;
                }
                pos.Columm += 1;
            }

            //abaixo
            pos.DefineVallues(Position.Line + 1, Position.Columm);
            while(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Columm] = true;
                if(Table.PieceMethod(pos) != null && Table.PieceMethod(pos).Color != Color)
                {
                    break;
                }
                pos.Line += 1;
            }

            // esquerda
            pos.DefineVallues(Position.Line, Position.Columm - 1);
            while(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Columm] = true;
                if(Table.PieceMethod(pos) != null && Table.PieceMethod(pos).Color != Color)
                {
                    break;
                }
                pos.Columm -= 1;
            }

            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}



