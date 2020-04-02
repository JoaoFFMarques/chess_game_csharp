using ChessGame.Pieces;
using Table;
using Table.Enums;
using Table.Excepetion;

namespace ChessGame
{
    class ChessMatch
    {
        public TableClass Tab { get; private set; }
        public int Turn { get; private set; }
        public Color ActivePlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Tab = new TableClass(8, 8);
            Turn = 1;
            ActivePlayer = Color.Branca;
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

        public void TurnPlayed(Position origin, Position destiny)
        {
            MovementExecution(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void OriginPositionValided(Position pos)
        {
            if(Tab.PieceMethod(pos) == null)
            {
                throw new TableException("Não existe peça na posição de origem escolhida!");
            }
            if(ActivePlayer != Tab.PieceMethod(pos).Color)
            {
                throw new TableException("A peça de origem escolhida não é sua!");
            }
            if(!Tab.PieceMethod(pos).ExistsPossibleMovements())
            {
                throw new TableException("Não há movimentos posíveis para a peça de origem escolhida!");
            }
        }

        public void DestinyPositionValided(Position origin, Position destiny)
        {
            if(!Tab.PieceMethod(origin).CanMoveTo(destiny))
            {
                throw new TableException("Posição de destino inválida!");
            }
        }

        private void ChangePlayer()
        {
            if(ActivePlayer == Color.Branca)
            {
                ActivePlayer = Color.Preta;
            }
            else
            {
                ActivePlayer = Color.Branca;
            }
        }

        private void PiecePlacement()
        {
            Tab.PlacePiece(new Tower(Tab, Color.Branca), new PositionChess('c', 1).ToPosition());
        }
    }
}
