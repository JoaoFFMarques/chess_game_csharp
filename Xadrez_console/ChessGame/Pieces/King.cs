using Table;
using Table.Enums;

namespace ChessGame.Pieces
{
    class King : Piece
    {
        private ChessMatch Match;
        public King(TableClass table, Color color, ChessMatch match) : base(table, color)
        {
            Match = match;
        }

        private bool CanMove(Position pos)
        {
            Piece p = Table.PieceMethod(pos);
            return p == null || p.Color != Color;
        }

        private bool CastlingTesttoTower(Position pos)
        {
            Piece p = Table.PieceMethod(pos);
            return p != null && p is Tower && p.Color == Color && p.QtdMovement == 0;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Table.Lines, Table.Columns];
            Position pos = new Position(0, 0);
            //acima
            pos.DefineVallues(Position.Line - 1, Position.Column);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //ne
            pos.DefineVallues(Position.Line - 1, Position.Column + 1);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //direita
            pos.DefineVallues(Position.Line, Position.Column + 1);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //se
            pos.DefineVallues(Position.Line + 1, Position.Column + 1);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //abaixo
            pos.DefineVallues(Position.Line + 1, Position.Column);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //so
            pos.DefineVallues(Position.Line + 1, Position.Column - 1);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // esquerda
            pos.DefineVallues(Position.Line, Position.Column - 1);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //no
            pos.DefineVallues(Position.Line - 1, Position.Column - 1);
            if(Table.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // #jogadaespecial roque
            if(QtdMovement == 0 && !Match.Check)
            {
                // #jogadaespecial roque pequeno
                Position posT1 = new Position(Position.Line, Position.Column + 3);
                if(CastlingTesttoTower(posT1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if(Table.PieceMethod(p1) == null && Table.PieceMethod(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }
                // #jogadaespecial roque grande
                Position posT2 = new Position(Position.Line, Position.Column - 4);
                if(CastlingTesttoTower(posT2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if(Table.PieceMethod(p1) == null && Table.PieceMethod(p2) == null && Table.PieceMethod(p3) == null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }
            }
            return mat;
        }


        public override string ToString()
        {
            return "R";
        }


    }

}

