using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    class GenerateMinds
    {
        public static void loadMinds()
        {
            int mindNumber = 0;
            if (GenerateBoard.gameboard.Length > 1)
            {
                Console.Write($"\n\nThe more minds, the harder the game. How many minds will there be? (between 1 and {GenerateBoard.gameboard.Length - 1})");
                mindNumber = Validate.input2int();
                for (int i = 0; i < GenerateBoard.gameboard.GetLength(0); i++)
                {

                }
            }
        }
    }
}
