using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    class GenerateMinds
    {
        public static void loadMinds()
        {
            RandomGenerator newMinds = new RandomGenerator();
            int mindNumber = 0;
            int Xnumber;
            int Ynumber;
            if (GenerateBoard.gameboard.Length > 1)
            {
                Console.Write($"\n\nThe more minds, the harder the game. How many minds will there be? (between 1 and {GenerateBoard.gameboard.Length - 1}): ");
                mindNumber = Validate.input2minds();
                for (int i = 0; i < mindNumber; i++)
                {
                    Xnumber = newMinds.randoX(GenerateBoard.gameboard.GetLength(0));
                    Ynumber = newMinds.randoX(GenerateBoard.gameboard.GetLength(1));
                    if (GenerateBoard.gameboard[Xnumber, Ynumber] == true)
                    {
                        i--;
                    }
                    GenerateBoard.gameboard[Xnumber, Ynumber] = true;


                }
                //for (int i = 0; i < GenerateBoard.gameboard.GetLength(0); i++)
                //{

                //}
            }
        }
    }
}
