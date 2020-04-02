
using Table.Excepetion;

namespace Table
{
    class TableClass
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public TableClass(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece PieceMethod(int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece PieceMethod(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }

        public bool PieceExist(Position pos)
        {
            ValidedPosition(pos);
            return PieceMethod(pos) != null;
        }

        public void PlacePiece(Piece p, Position pos)
        {
            if(PieceExist(pos))
            {
                throw new TableException("Já existe uma peça nessa posição!");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if(PieceMethod(pos) == null)
            {
                return null;
            }
            Piece aux = PieceMethod(pos);
            aux.Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position pos)
        {
            if(pos.Line<0 || pos.Line>=Lines || pos.Column<0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidedPosition(Position pos)
        {
            if(!ValidPosition(pos))
            {
                throw new TableException("Posição Inválida");
            }
        }        
    }
}
