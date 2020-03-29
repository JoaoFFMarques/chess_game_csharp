using System;
using Table;
using ChessGame;
using Table.Enums;
using Table.Excepetion;

namespace Xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TableClass table = new TableClass(8, 8);

                table.PlacePiece(new Tower(table, Color.Black), new Position(1, 9));
                table.PlacePiece(new King(table, Color.Black), new Position(1, 3));


                Screen.PrintTable(table);
            }
            catch (TableException e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
    }
}
