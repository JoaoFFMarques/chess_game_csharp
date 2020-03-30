using Table;
using System;
using Table.Enums;
using ChessGame;

namespace Xadrez_console
{
    class Screen
    {
        public static void PrintTable(TableClass table)
        {
            for(int i = 0; i < table.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < table.Collums; j++)
                {
                    if(table.PieceMethod(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(table.PieceMethod(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static PositionChess ReadPosChess()
        {
            string s = Console.ReadLine();
            char collum = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionChess(collum, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if(piece.Color == Color.White)
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
        }
    }
}
