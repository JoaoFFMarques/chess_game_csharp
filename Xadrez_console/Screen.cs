using Table;
using System;
using Table.Enums;
using ChessGame;
using System.Collections.Generic;

namespace Xadrez_console
{
    class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {
            Screen.PrintTable(match.Tab);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turno: " + match.Turn);
            Console.WriteLine("Aguardando jogada: " + match.ActivePlayer);
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            PrintSet(match.CapturedPiecesSet(Color.Branca));
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Pretas: ");
            PrintSet(match.CapturedPiecesSet(Color.Preta));
            Console.ForegroundColor = aux;

        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach(Piece obj in set)
            {
                Console.Write(obj + " ");
            }
            Console.WriteLine("]");

        }

        public static void PrintTable(TableClass table)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;

            for(int i = 0; i < table.Lines; i++)
            {
                Console.Write(8 - i + "|");
                for(int j = 0; j < table.Columns; j++)
                {


                    PrintPiece(table.PieceMethod(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintTable(TableClass table, bool[,] possiblePositions)
        {
            Console.SetCursorPosition(0, 0);
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alterBackGround = ConsoleColor.DarkGray;


            for(int i = 0; i < table.Lines; i++)
            {
                Console.Write(8 - i + "|");
                for(int j = 0; j < table.Columns; j++)
                {
                    if(possiblePositions[i, j])
                    {
                        Console.BackgroundColor = alterBackGround;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }

                    PrintPiece(table.PieceMethod(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static PositionChess ReadPosChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionChess(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if(piece == null)
            {
                Console.Write("_|");
            }
            else
            {
                if(piece.Color == Color.Branca)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write("|");
            }
        }
    }
}
