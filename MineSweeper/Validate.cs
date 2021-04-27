using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    class Validate
    {
        public static int input2int()
        {
            string input;
            bool invalid = true;
            int columns = 0;

            do
            {
                input = Console.ReadLine();
                try
                {
                    columns = Int32.Parse(input);
                    if (columns > 0 && columns < 31)
                    {
                        invalid = false;
                    }
                    else
                    {
                        Messages.invalid(1);
                    }
                }
                catch
                {
                    Messages.invalid(1);
                }
            } while (invalid);
            return columns;
        }
        public static int input2minds()
        {
            string input;
            bool invalid = true;
            int minds = 0;
            do
            {
                input = Console.ReadLine();
                try
                {
                    minds = Int32.Parse(input);
                    if(minds > 0 && minds < GenerateBoard.gameboard.Length)
                    {
                        invalid = false;
                    }
                    else
                    {
                        Messages.invalid(2);
                    }
                }
            } while (invalid);
            return minds;
        }
    }
}
