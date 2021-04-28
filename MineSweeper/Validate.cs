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
                catch
                {
                    Messages.invalid(2);
                }
            } while (invalid);
            return minds;
        }
        public static int input2ColumnChoice()
        {
            int colChoice = 0;
            bool invalid = true;
            string input;
            do
            {
                input = Console.ReadLine();
                try
                {
                    colChoice = Int32.Parse(input);
                    if(colChoice > 0 && colChoice <= GenerateBoard.gameboard.GetLength(1))
                    {
                        invalid = false;
                    }
                    else
                    {
                        Messages.invalid(3);
                    }
                }
                catch
                {
                    Messages.invalid(3);
                }
            } while (invalid);
            return colChoice;
        }
        public static int input2RowChoice()
        {
            int rowChoice = 0;
            bool invalid = true;
            string input;
            do
            {
                input = Console.ReadLine();
                try
                {
                    rowChoice = Int32.Parse(input);
                    if (rowChoice > 0 && rowChoice <= GenerateBoard.gameboard.GetLength(0))
                    {
                        invalid = false;
                    }
                    else
                    {
                        Messages.invalid(4);
                    }
                }
                catch
                {
                    Messages.invalid(4);
                }
            } while (invalid);
            return rowChoice;
        }
    }
}
