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
                        animations.boom();
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
        /*public static void check1NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check2MoreMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x-1,y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check2MoreMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check2MoreMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check2MoreMinds(x + 1, y - 1);
                }
                else if(GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check2MoreMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check2MoreMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check2MoreMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check2MoreMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check2MoreMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check3NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check3NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check3NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check3NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check3NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check3NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check3NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check3NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check3NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check4NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check4NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check4NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check4NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check4NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check4NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check4NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check4NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check4NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check5NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check5NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check5NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check5NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check5NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check5NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check5NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check5NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check5NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check6NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check6NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check6NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check6NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check6NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check6NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check6NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check6NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check6NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check7NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check7NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check7NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check7NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check7NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check7NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check7NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check7NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check7NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check8NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check8NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check8NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check8NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check8NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check8NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check8NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check8NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check8NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check9NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check9NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check9NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check9NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check9NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check9NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check9NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check9NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check9NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check10NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check10NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check10NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check10NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check10NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check10NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check10NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check10NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check10NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check11NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check11NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check11NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check11NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check11NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check11NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check11NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check11NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check11NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check12NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check12NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check12NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check12NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check12NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check12NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check12NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check12NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check12NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check13NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check13NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check13NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check13NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check13NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check13NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check13NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check13NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check13NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check14NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check14NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check14NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check14NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check14NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check14NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check14NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check14NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check14NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    check15NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    check15NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    check15NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    check15NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    check15NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    check15NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    check15NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    check15NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }
        public static void check15NoMinds(int x, int y)
        {
            try //north
            {
                if (GenerateBoard.mappedboard[x - 1, y] == 0)
                {
                    GenerateBoard.userboard[x - 1, y] = "X";
                    //check4NoMinds(x - 1, y);
                }
                else if (GenerateBoard.mappedboard[x - 1, y] > 0)
                {
                    GenerateBoard.userboard[x - 1, y] = GenerateBoard.mappedboard[x - 1, y].ToString();
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
                    //check4NoMinds(x - 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y - 1] = GenerateBoard.mappedboard[x - 1, y - 1].ToString();
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
                    //check4NoMinds(x, y - 1);
                }
                else if (GenerateBoard.mappedboard[x, y - 1] > 0)
                {
                    GenerateBoard.userboard[x, y - 1] = GenerateBoard.mappedboard[x, y - 1].ToString();
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
                    //check4NoMinds(x + 1, y - 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y - 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y - 1] = GenerateBoard.mappedboard[x + 1, y - 1].ToString();
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
                    //check4NoMinds(x + 1, y);
                }
                else if (GenerateBoard.mappedboard[x + 1, y] > 0)
                {
                    GenerateBoard.userboard[x + 1, y] = GenerateBoard.mappedboard[x + 1, y].ToString();
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
                    //check4NoMinds(x + 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x + 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x + 1, y + 1] = GenerateBoard.mappedboard[x + 1, y + 1].ToString();
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
                    //check4NoMinds(x, y + 1);
                }
                else if (GenerateBoard.mappedboard[x, y + 1] > 0)
                {
                    GenerateBoard.userboard[x, y + 1] = GenerateBoard.mappedboard[x, y + 1].ToString();
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
                    //check4NoMinds(x - 1, y + 1);
                }
                else if (GenerateBoard.mappedboard[x - 1, y + 1] > 0)
                {
                    GenerateBoard.userboard[x - 1, y + 1] = GenerateBoard.mappedboard[x - 1, y + 1].ToString();
                }
            }
            catch
            {
            }
        }*/
    }
}
