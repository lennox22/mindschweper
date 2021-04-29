using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    class CoordinateBox
    {
        public int xCoor;
        public int yCoor;

        public CoordinateBox (int xSave, int ySave)
        {
            xCoor = xSave;
            yCoor = ySave;
        }
        public int xSave
        {
            get { return xCoor; }
            set { xCoor = value; }
        }
        public int ySave
        {
            get { return yCoor; }
            set { yCoor = value; }
        }
    }
    class PlayerMove
    {
        public static List<CoordinateBox> need2check = new List<CoordinateBox>();
        public static bool userMove()
        {
            bool notover = true;
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
                        notover = false;
                        Program.losses++;
                        animations.boom();
                        Messages.showScore();
                        Messages.gameover();
                    }
                    else
                    {
                        GenerateBoard.userboard[rowChoice - 1, colChoice - 1] = GenerateBoard.mappedboard[rowChoice - 1, colChoice - 1].ToString();
                        if (GenerateBoard.userboard[rowChoice - 1, colChoice - 1] == "0")
                        {
                            GenerateBoard.userboard[rowChoice - 1, colChoice - 1] = "X";
                            checkNoMinds(rowChoice - 1, colChoice - 1);
                        }
                        for (int i = 0; i < need2check.Count; i++)
                        {
                            checkNoMinds(need2check[i].xCoor, need2check[i].yCoor);
                        }
                        need2check.Clear();
                    }
                }

            } while (invalid);
            GenerateBoard.showboard();
            return notover;
        }
        public static void checkNoMinds(int x, int y)
        {
            CoordinateBox test;
            for (int row = 0; row < GenerateBoard.mappedboard.GetLength(0); row++)
            {
                for (int col = 0; col < GenerateBoard.mappedboard.GetLength(1); col++)
                {
                    if (row >= x - 1 && row <= x + 1 && col >= y - 1 && col <= y + 1 && GenerateBoard.userboard[row, col] == " ")
                    {
                        if (GenerateBoard.mappedboard[row, col] >= 0)
                        {
                            GenerateBoard.userboard[row, col] = GenerateBoard.mappedboard[row, col].ToString();
                            if(GenerateBoard.userboard[row,col] == "0")
                            {
                                GenerateBoard.userboard[row, col] = "X";
                                test = new CoordinateBox(row, col);
                                need2check.Add(test);
                            }
                        }

                    }
                }
            }
        }
        public static bool winner()
        {
            int counter = 0;
            bool loop = true;
            for (int x = 0; x < GenerateBoard.gameboard.GetLength(0); x++)
            {
                for (int y = 0; y < GenerateBoard.gameboard.GetLength(1); y++)
                {
                    if(GenerateBoard.userboard[x,y] == " ")
                    {
                        if(GenerateBoard.mappedboard[x,y] != -1)
                        {
                            counter++;
                        }
                    }
                }   
            }
            if (counter == 0)
            {
                loop = false;
                Program.wins++;
                Messages.showScore();
                Messages.won();
            }
            return loop;
        }
    }
}
