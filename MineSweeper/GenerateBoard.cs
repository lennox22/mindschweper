using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class GenerateBoard
    {


        public static bool[,] gameboard;

        public GenerateBoard(bool[,] xgameboard)
        {
            gameboard = xgameboard;
        }
        public bool[,] xgameboard
        {
            get { return gameboard; }
            set { gameboard = value; }
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
            if (rows > 20)
            {
                Console.WindowHeight = (rows - 20) + 30;
            }

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
            Console.WriteLine("-");

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
    }
}
