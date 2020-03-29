using Table.Enums;

namespace Table
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtdMovement { get; protected set; }
        public Table Table { get; protected set; }

        public Piece(Position position, Color color, Table table)
        {
            Position = position;
            Color = color;
            Table = table;
            QtdMovement = 0;
        }



    }
}
