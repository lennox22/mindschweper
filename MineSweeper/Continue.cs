using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    class Continue
    {
        public static bool YN()
        {
            bool playAgain = true;
            bool invalid = true;
            string input;
            do
            {
                Console.Write("\n\n:::Would you like to play again? (y/n): ");
                input = Console.ReadLine().ToLower();
                if (input != "y" && input != "n")
                {
                    Messages.invalid(6);
                }
                else if(input == "y")
                {
                    invalid = false;
                }
                else
                {
                    invalid = false;
                    playAgain = false;
                    Console.Write("\n\n:::Thank you for playing!:::\n\n");
                }
            } while (invalid);
            return playAgain;
        }
    }
}
