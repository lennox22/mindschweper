using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    class PlayerMove
    {
        public static void userMove()
        {
            int colChoice;
            int rowChoice;
            bool invalid = true;
            do
            {
                Console.Write($"\n\nEnter the column for the square you choose: ");
                colChoice = Validate.input2ColumnChoice();
                Console.Write($"Enter the row for the square you choose: ");
                rowChoice = Validate.input2RowChoice();
                if (GenerateBoard.userboard[rowChoice - 1, colChoice - 1] != " ")
                {
                    Messages.invalid(5);
                }
                else
                {
                    invalid = false;
                    if (GenerateBoard.mappedboard[rowChoice - 1, colChoice - 1] == -1)
                    {
                        GenerateBoard.userboard[rowChoice - 1, colChoice - 1] = "*";
                    }
                    else
                    {
                        GenerateBoard.userboard[rowChoice - 1, colChoice - 1] = GenerateBoard.mappedboard[rowChoice - 1, colChoice - 1].ToString();
                        if (GenerateBoard.userboard[rowChoice - 1, colChoice - 1] == "0")
                        {
                            GenerateBoard.userboard[rowChoice - 1, colChoice - 1] = "X";
                            check4NoMinds(rowChoice - 1, colChoice - 1);
                        }


                    }
                }

            } while (invalid);
            GenerateBoard.showboard();

        }
        public static void check4NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                }
            }
            catch
            {
            }
            try //NW
            {
                if (GenerateBoard.mappedboard[x - 1, y - 1] == 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = "X";
                }
            }
            catch
            {
            }
            try  //W
            {
                if (GenerateBoard.mappedboard[x, y - 1] == 0)
                {
                    GenerateBoard.userboard[x, y - 1] = "X";
                }
            }
            catch
            {
            }
            try  //SW
            {
                if (GenerateBoard.mappedboard[x + 1, y - 1] == 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = "X";
                }
            }
            catch
            {
            }
            try  //S
            {
                if (GenerateBoard.mappedboard[x + 1, y] == 0)
                {
                    GenerateBoard.userboard[x + 1, y] = "X";
                }
            }
            catch
            {
            }
            try //SE
            {
                if (GenerateBoard.mappedboard[x + 1, y + 1] == 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = "X";
                }
            }
            catch
            {
            }
            try //E
            {
                if (GenerateBoard.mappedboard[x, y + 1] == 0)
                {
                    GenerateBoard.userboard[x, y + 1] = "X";
                }
            }
            catch
            {
            }
            try //NE
            {
                if (GenerateBoard.mappedboard[x - 1, y + 1] == 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = "X";
                }
            }
            catch
            {
            }
        }
    }
}
