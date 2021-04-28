using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class GenerateBoard
    {


        public static bool[,] gameboard;
        public static int[,] mappedboard;
        public static string[,] userboard;

        public GenerateBoard(bool[,] xgameboard, int[,] xmappedboard, string[,] xuserboard)
        {
            gameboard = xgameboard;
            mappedboard = xmappedboard;
            userboard = xuserboard;
        }
        public string[,] xuserboard
        {
            get { return userboard; }
            set { userboard = value; }
        }
        public int[,] xmappedboard
        {
            get { return mappedboard; }
            set { mappedboard = value; }
        }
        public bool[,] xgameboard
        {
            get { return gameboard; }
            set { gameboard = value; }
        }
        public static int checksurrounding(int x, int y)
        {
            int counter = 0;
            try //north
            {
                if (gameboard[x - 1, y] == true)
                {
                    counter++;
                }
            }
            catch
            {
            }
            try //NW
            {
                if (gameboard[x - 1, y - 1] == true)
                {
                    counter++;
                }
            }
            catch
            {
            }
            try  //W
            {
                if (gameboard[x, y - 1] == true)
                {
                    counter++;
                }
            }
            catch
            {
            }
            try  //SW
            {
                if (gameboard[x + 1, y - 1] == true)
                {
                    counter++;
                }
            }
            catch
            {
            }
            try  //S
            {
                if (gameboard[x + 1, y] == true)
                {
                    counter++;
                }
            }
            catch
            {
            }
            try //SE
            {
                if (gameboard[x + 1, y + 1] == true)
                {
                    counter++;
                }
            }
            catch
            {
            }
            try //E
            {
                if (gameboard[x, y + 1] == true)
                {
                    counter++;
                }
            }
            catch
            {
            }
            try //NE
            {
                if (gameboard[x - 1, y + 1] == true)
                {
                    counter++;
                }
            }
            catch
            {
            }
            return counter;
        }
        public static void mappingboard(int columns, int rows)
        {
            mappedboard = new int[rows, columns];
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    if (gameboard[x, y] == true)
                    {
                        mappedboard[x, y] = -1;
                    }
                    else
                    {
                        int counter = checksurrounding(x, y);
                        mappedboard[x, y] = counter;
                    }
                }
            }
        }

        public static void initializeBlankBoard(int columns, int rows)
        {
            gameboard = new bool[rows, columns];
            for (int x = 0; x < rows; x++)       //row first
            {
                for (int y = 0; y < columns; y++)   //column next to get all spots in the 2d array
                {
                    gameboard[x, y] = false;
                }
            }
            userboard = new string[rows, columns];
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    userboard[x, y] = " ";
                }
            }
        }
        public static void CreateBoard()
        {
            int columns;
            int rows;
            Console.Write($"How big of a game board will we have?\nEnter the number of columns (between 1 and 30): ");
            columns = Validate.input2int();
            Console.Write($"\nGreat! Now how many rows (between 1 and 30): ");
            rows = Validate.input2int();
            initializeBlankBoard(columns, rows);
            GenerateMinds.loadMinds();
            mappingboard(columns, rows);
            /*
            Console.Clear();
            Console.WriteLine("\n\n\n");

            Console.Write("    ");
            for (int i = 1; i <= columns; i++)
            {
                if (i < 10)
                {

                    Console.Write($"{i}  ");
                }
                else
                {
                    Console.Write($"{i} ");
                }
            }
            Console.Write("\n  -");
            for (int i = 1; i <= columns; i++)
            {

                Console.Write($"---");

            }
            Console.WriteLine("-");

            for (int i = 1; i <= rows; i++)
            {
                if (i < 10)
                {
                    Console.Write($" {i}|");

                }
                else
                {
                    Console.Write($"{i}|");
                }
                for (int x = 1; x <= columns; x++)
                {
                    Console.Write($"[ ]");
                }
                Console.Write("|\n");
            }
            Console.Write("  -");
            for (int i = 1; i <= columns; i++)
            {

                Console.Write($"---");

            }
            Console.WriteLine("-");*/

            //Console.Write("    1  2  3  4  5  6  7  8  9  10\n  ----------------------------------\n");
            //for (int x = 0; x < GenerateBoard.gameboard.GetLength(0); x++)
            //{
            //    if (x + 1 < 10)
            //    {
            //        Console.Write($"{x + 1} | ");
            //    }
            //    else
            //    {
            //        Console.Write($"{x + 1}| ");

            //    }
            //    for (int y = 0; y < GenerateBoard.gameboard.GetLength(1); y++)
            //    {
            //        if (GenerateBoard.gameboard[x, y] == true)
            //        {
            //            Console.Write("[X]");
            //        }
            //        else
            //        {
            //            Console.Write("[ ]");
            //        }
            //    }
            //    Console.Write(" |\n");
            //}
            //Console.Write("  ----------------------------------\n");
        }
        public static void showboard()
        {
            if (gameboard.GetLength(0) > 20)
            {
                Console.WindowHeight = (gameboard.GetLength(0) - 20) + 30;
            }
            Console.Clear();
            Console.WriteLine("\t\tMIND\tSCHWEPER\nX = no minds in or around this square\t* = mind in this square\nNo. 1-8 show how many minds are around this square");

            Console.Write("    ");
            for (int y = 0; y < gameboard.GetLength(1); y++)
            {
                if (y < 9)
                {

                    Console.Write($"{y + 1}  ");
                }
                else
                {
                    Console.Write($"{y + 1} ");
                }
            }
            Console.Write("\n  -");
            for (int y = 0; y < gameboard.GetLength(1); y++)
            {

                Console.Write($"---");

            }
            Console.WriteLine("-");

            for (int x = 0; x < gameboard.GetLength(0); x++)
            {
                if (x < 9)
                {
                    Console.Write($" {x + 1}|");

                }
                else
                {
                    Console.Write($"{x + 1}|");
                }
                for (int y = 0; y < gameboard.GetLength(1); y++)
                {
                    Console.Write($"[{GenerateBoard.userboard[x,y]}]");
                    //if (GenerateBoard.gameboard[x, i] == true)
                    //{
                    //    Console.Write($"[*]");
                    //}
                    //else
                    //{
                     //   Console.Write($"[{GenerateBoard.mappedboard[x, i]}]");

                    //}
                }
                Console.Write("|\n");
            }
            Console.Write("  -");
            for (int y = 0; y < gameboard.GetLength(1); y++)
            {

                Console.Write($"---");

            }
            Console.WriteLine("-");
        }
    }
}
