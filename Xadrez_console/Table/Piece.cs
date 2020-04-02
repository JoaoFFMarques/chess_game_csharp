using Table.Enums;

namespace Table
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtdMovement { get; protected set; }
        public TableClass Table { get; protected set; }

        public Piece(TableClass table, Color color)
        {
            Position = null;
            Color = color;
            Table = table;
            QtdMovement = 0;
        }

        public void IncrementMoventQtd()
        {
            QtdMovement++;
        }

        public bool ExistsPossibleMovements()
        {
            bool[,] mat = PossibleMovements();
            for(int i = 0; i < Table.Lines; i++)
            {
                for(int j = 0; j < Table.Collums; j++)
                {
                    if(mat[i, j])
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return PossibleMovements()[pos.Line, pos.Columm];
        }

        public abstract bool[,] PossibleMovements();
        



    }
}
