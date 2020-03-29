
namespace Table
{
    class Table
    {
        public int Lines { get; set; }
        public int Collums { get; set; }
        private Piece[,] Pieces;

        public Table(int lines, int collums)
        {
            Lines = lines;
            Collums = collums;
            Pieces = new Piece[lines, collums];
        }
    }
}
