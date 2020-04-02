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
            Console.SetWindowSize(90, 30);
            try
            {
                ChessMatch match = new ChessMatch();

                while(!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintTable(match.Tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + match.Turn);
                        Console.WriteLine("Aguardando jogada: " + match.ActivePlayer);

                        Console.Write("Origem: ");
                        Position origin = Screen.ReadPosChess().ToPosition();
                        match.OriginPositionValided(origin);

                        bool[,] possiblePosition = match.Tab.PieceMethod(origin).PossibleMovements();

                        Console.Clear();
                        Screen.PrintTable(match.Tab, possiblePosition);

                        Console.WriteLine();
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


            }
            catch(TableException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
