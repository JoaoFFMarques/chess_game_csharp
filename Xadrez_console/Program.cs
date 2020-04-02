using System;
using Table;
using ChessGame;
using Table.Excepetion;

namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while(!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.Write("Origem: ");
                        Position origin = Screen.ReadPosChess().ToPosition();
                        match.OriginPositionValided(origin);

                        bool[,] possiblePosition = match.Tab.PieceMethod(origin).PossibleMovements();

                        Screen.PrintTable(match.Tab, possiblePosition);
                        Console.SetCursorPosition(0, 17);
                        Console.Write("Destino: ");
                        Position destiny = Screen.ReadPosChess().ToPosition();
                        match.DestinyPositionValided(origin, destiny);

                        match.TurnPlayed(origin, destiny);
                    }
                    catch(TableException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }
                Console.Clear();
                Screen.PrintMatch(match);
            }
            catch(TableException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
