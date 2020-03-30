
using Table.Excepetion;

namespace Table
{
    class TableClass
    {
        public int Lines { get; set; }
        public int Collums { get; set; }
        private Piece[,] Pieces;

        public TableClass(int lines, int collums)
        {
            Lines = lines;
            Collums = collums;
            Pieces = new Piece[lines, collums];
        }

        public Piece PieceMethod(int line, int collum)
        {
            return Pieces[line, collum];
        }

        public Piece PieceMethod(Position pos)
        {
            return Pieces[pos.Line, pos.Columm];
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
            Pieces[pos.Line, pos.Columm] = p;
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
            Pieces[pos.Line, pos.Columm] = null;
            return aux;
        }

        public bool ValidPosition(Position pos)
        {
            if(pos.Line<0 || pos.Line>=Lines || pos.Columm<0 || pos.Columm >= Collums)
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
