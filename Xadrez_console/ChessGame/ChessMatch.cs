using ChessGame.Pieces;
using Table;
using Table.Enums;

namespace ChessGame
{
    class ChessMatch
    {
        public TableClass Tab { get; private set; }
        private int Turn;
        private Color ActivePlayer;
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Tab = new TableClass(8, 8);
            Turn = 1;
            ActivePlayer = Color.White;
            Finished = false;
            PiecePlacement();
        }

        public void MovementExecution(Position origin, Position destiny)
        {
            Piece p = Tab.RemovePiece(origin);
            p.IncrementMoventQtd();
            Piece capturedPiece = Tab.RemovePiece(destiny);
            Tab.PlacePiece(p, destiny);
        }

        private void PiecePlacement()
        {
            Tab.PlacePiece(new King(Tab, Color.Black), new PositionChess('c', 1).ToPosition());
        }
    }
}
