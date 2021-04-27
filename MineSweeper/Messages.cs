using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    class Messages
    {
        public static void invalid(int error)
        {
            switch (error)
            {
                case 1:
                    Console.Write("\n\n:::Please enter a positive integer greater than 0: ");
                    break;
                case 2:
                    Console.Write($"\n\n:::Please enter a positive integer greater than 0 and less than {GenerateBoard.gameboard.Length}: ");
                    break;
            }
        }
    }
}
