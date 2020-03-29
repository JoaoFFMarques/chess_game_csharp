using Table;
using System;

namespace Xadrez_console
{
    class Screen
    {
        public static void PrintTable(TableClass table)
        {
            for(int i= 0; i< table.Lines; i++)
            {
                for(int j=0; j<table.Collums; j++)
                {
                    if(table.PieceMethod(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(table.PieceMethod(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
