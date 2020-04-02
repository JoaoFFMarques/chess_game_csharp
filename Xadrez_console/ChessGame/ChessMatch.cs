using ChessGame.Pieces;
using Table;
using Table.Enums;
using Table.Excepetion;
using System.Collections.Generic;

namespace ChessGame
{
    class ChessMatch
    {
        public TableClass Tab { get; private set; }
        public int Turn { get; private set; }
        public Color ActivePlayer { get; private set; }
        public bool Finished { get; private set; }
        public bool Check { get; private set; }
        public Piece EnPassantVulnerab { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;

        public ChessMatch()
        {
            Tab = new TableClass(8, 8);
            Turn = 1;
            ActivePlayer = Color.Branca;
            Finished = false;
            Check = false;
            EnPassantVulnerab = null;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PiecePlacement();
        }

        public Piece MovementExecution(Position origin, Position destiny)
        {
            Piece p = Tab.RemovePiece(origin);
            p.IncrementMoventQtd();
            Piece capturedPiece = Tab.RemovePiece(destiny);
            Tab.PlacePiece(p, destiny);
            if(capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }

            // #jogadaespecial roque pequeno
            if(p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(origin.Line, origin.Column + 1);
                Piece T = Tab.RemovePiece(originT);
                T.IncrementMoventQtd();
                Tab.PlacePiece(T, destinyT);
            }

            // #jogadaespecial roque grande
            if(p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(origin.Line, origin.Column - 1);
                Piece T = Tab.RemovePiece(originT);
                T.IncrementMoventQtd();
                Tab.PlacePiece(T, destinyT);
            }

            // #jogadaespecial en passant
            if(p is Peon)
            {
                if(origin.Column != destiny.Column && capturedPiece == null)
                {
                    Position posP;
                    if(p.Color == Color.Branca)
                    {
                        posP = new Position(destiny.Line + 1, destiny.Column);
                    }
                    else
                    {
                        posP = new Position(destiny.Line - 1, destiny.Column);
                    }
                    capturedPiece = Tab.RemovePiece(posP);
                    CapturedPieces.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }

        public void UndoMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = Tab.RemovePiece(destiny);
            p.DecreaseMoventQtd();
            if(capturedPiece != null)
            {
                Tab.PlacePiece(capturedPiece, destiny);
                CapturedPieces.Remove(capturedPiece);
            }
            Tab.PlacePiece(p, origin);

            // #jogadaespecial roque pequeno
            if(p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(origin.Line, origin.Column + 1);
                Piece T = Tab.RemovePiece(destinyT);
                T.DecreaseMoventQtd();
                Tab.PlacePiece(T, originT);
            }

            // #jogadaespecial roque grande
            if(p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(origin.Line, origin.Column - 1);
                Piece T = Tab.RemovePiece(destinyT);
                T.DecreaseMoventQtd();
                Tab.PlacePiece(T, originT);
            }

            // #jogadaespecial en passant
            if(p is Peon)
            {
                if(origin.Column != destiny.Column && capturedPiece == EnPassantVulnerab)
                {
                    Piece peon = Tab.RemovePiece(destiny);
                    Position posP;
                    if(p.Color == Color.Branca)
                    {
                        posP = new Position(3, destiny.Column);
                    }
                    else
                    {
                        posP = new Position(4, destiny.Column);
                    }
                    Tab.PlacePiece(peon, posP);
                }
            }
        }

        public void TurnPlayed(Position origin, Position destiny)
        {
            Piece capturedPiece = MovementExecution(origin, destiny);

            if(InCheck(ActivePlayer))
            {
                UndoMovement(origin, destiny, capturedPiece);
                throw new TableException("Você não pode se colocar em xeque!");
            }

            Piece p = Tab.PieceMethod(destiny);

            // #jogadaespecial promocao
            if(p is Peon)
            {
                if((p.Color == Color.Branca && destiny.Line == 0) || (p.Color == Color.Preta && destiny.Line == 7))
                {
                    p = Tab.RemovePiece(destiny);
                    Pieces.Remove(p);
                    Piece queen = new Queen(Tab, p.Color);
                    Tab.PlacePiece(queen, destiny);
                    Pieces.Add(queen);
                }
            }

            if(InCheck(Opponent(ActivePlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if(CheckMateTest(Opponent(ActivePlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

            // #jogadaespecial en passant
            if(p is Peon && (destiny.Line == origin.Line - 2 || destiny.Line == origin.Line + 2))
            {
                EnPassantVulnerab = p;
            }
            else
            {
                EnPassantVulnerab = null;
            }
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

        public HashSet<Piece> CapturedPiecesSet(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece obj in CapturedPieces)
            {
                if(obj.Color == color)
                {
                    aux.Add(obj);
                }
            }
            return aux;
        }

        public HashSet<Piece> InGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece obj in Pieces)
            {
                if(obj.Color == color)
                {
                    aux.Add(obj);
                }
            }
            aux.ExceptWith(CapturedPiecesSet(color));
            return aux;
        }

        private Color Opponent(Color color)
        {
            if(color == Color.Branca)
            {
                return Color.Preta;
            }
            else
            {
                return Color.Branca;
            }
        }

        private Piece KingPiece(Color color)
        {
            foreach(Piece obj in InGamePieces(color))
            {
                if(obj is King)
                {
                    return obj;
                }
            }
            return null;
        }

        public bool InCheck(Color color)
        {
            Piece K = KingPiece(color);
            if(K == null)
            {
                throw new TableException("Não tem rei da cor " + color + " no tabuleiro!");
            }
            foreach(Piece obj in InGamePieces(Opponent(color)))
            {
                bool[,] mat = obj.PossibleMovements();
                if(mat[K.Position.Line, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckMateTest(Color color)
        {
            if(!InCheck(color))
            {
                return false;
            }
            foreach(Piece obj in InGamePieces(color))
            {
                bool[,] mat = obj.PossibleMovements();
                for(int i = 0; i < Tab.Lines; i++)
                {
                    for(int j = 0; j < Tab.Columns; j++)
                    {
                        if(mat[i, j])
                        {
                            Position origin = obj.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = MovementExecution(origin, destiny);
                            bool checkTest = InCheck(color);
                            UndoMovement(origin, destiny, capturedPiece);
                            if(!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }


        public void PlaceNewPiece(char column, int line, Piece piece)
        {
            Tab.PlacePiece(piece, new PositionChess(column, line).ToPosition());
            Pieces.Add(piece);
        }

        private void PiecePlacement()
        {
            //torres
            PlaceNewPiece('a', 1, new Tower(Tab, Color.Branca));
            PlaceNewPiece('h', 1, new Tower(Tab, Color.Branca));
            PlaceNewPiece('a', 8, new Tower(Tab, Color.Preta));
            PlaceNewPiece('h', 8, new Tower(Tab, Color.Preta));
            //rainhas
            PlaceNewPiece('d', 1, new Queen(Tab, Color.Branca));
            PlaceNewPiece('d', 8, new Queen(Tab, Color.Preta));
            //reis
            PlaceNewPiece('e', 1, new King(Tab, Color.Branca, this));
            PlaceNewPiece('e', 8, new King(Tab, Color.Preta, this));
            //Peoes Brancos
            PlaceNewPiece('a', 2, new Peon(Tab, Color.Branca, this));
            PlaceNewPiece('b', 2, new Peon(Tab, Color.Branca, this));
            PlaceNewPiece('c', 2, new Peon(Tab, Color.Branca, this));
            PlaceNewPiece('d', 2, new Peon(Tab, Color.Branca, this));
            PlaceNewPiece('e', 2, new Peon(Tab, Color.Branca, this));
            PlaceNewPiece('f', 2, new Peon(Tab, Color.Branca, this));
            PlaceNewPiece('g', 2, new Peon(Tab, Color.Branca, this));
            PlaceNewPiece('h', 2, new Peon(Tab, Color.Branca, this));
            //peoes Pretos
            PlaceNewPiece('a', 7, new Peon(Tab, Color.Preta, this));
            PlaceNewPiece('b', 7, new Peon(Tab, Color.Preta, this));
            PlaceNewPiece('c', 7, new Peon(Tab, Color.Preta, this));
            PlaceNewPiece('d', 7, new Peon(Tab, Color.Preta, this));
            PlaceNewPiece('e', 7, new Peon(Tab, Color.Preta, this));
            PlaceNewPiece('f', 7, new Peon(Tab, Color.Preta, this));
            PlaceNewPiece('g', 7, new Peon(Tab, Color.Preta, this));
            PlaceNewPiece('h', 7, new Peon(Tab, Color.Preta, this));

        }
    }
}
