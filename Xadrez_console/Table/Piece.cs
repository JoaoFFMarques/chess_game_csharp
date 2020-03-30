﻿using Table.Enums;

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

        public abstract bool[,] PossibleMovements();
        



    }
}
