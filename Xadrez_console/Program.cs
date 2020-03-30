﻿using System;
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
                    Console.Clear();
                    Screen.PrintTable(match.Tab);

                    Console.Write("Origem: ");
                    Position origin = Screen.ReadPosChess().ToPosition();

                    bool[,] possiblePosition = match.Tab.PieceMethod(origin).PossibleMovements();

                    Console.Clear();
                    Screen.PrintTable(match.Tab, possiblePosition);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position destiny = Screen.ReadPosChess().ToPosition();

                    match.MovementExecution(origin, destiny);

                }


            }
            catch(TableException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
