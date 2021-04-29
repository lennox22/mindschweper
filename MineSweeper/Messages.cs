using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    class Messages
    {
        public static void invalid(int error)
        {
            switch (error)
            {
                case 1:
                    Console.Write("\n\n:::Please enter a positive integer between 1 and no more than 30: ");
                    break;
                case 2:
                    Console.Write($"\n\n:::Please enter a positive integer between 1 and {GenerateBoard.gameboard.Length-1}: ");
                    break;
                case 3:
                    Console.Write($"\n\n:::Please enter a positive integer between 1 and {GenerateBoard.gameboard.GetLength(1)}: ");
                    break;
                case 4:
                    Console.Write($"\n\n:::Please enter a positive integer between 1 and {GenerateBoard.gameboard.GetLength(0)}: ");
                    break;
                case 5:
                    Console.Write($"\n\n:::You've already uncovered that square. Please choose another.");
                    break;
                case 6:
                    Console.Write($"\n\n:::Please enter either y or n for yes or no to continue playing:::\n\n");
                    break;
            }
        }
        public static void gameover()
        {
            Console.Write("\n\n:::You hit a mind and went boom. Game Over. Maybe try again or something:::\n\n\nPress enter to continue");
            Console.ReadLine();
        }
        public static void won()
        {
            Console.Write("\n\n:::HURRAY! You've cleared the board and we're all safe from the MINDS!:::\n\nPress enter to continue");
            Console.ReadLine();
        }
        public static void showScore()
        {

            Console.Write($"\n\n:::Games won: {Program.wins} :::\n:::Games lost: {Program.losses} :::");
        }
    }
}
