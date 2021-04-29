using System;
using System.Collections.Generic;

namespace MineSweeper
{
    
    
    class Program
    {
        public static int wins = 0;
        public static int losses = 0;
        static void Main(string[] args)
        {
            bool playAgain = true;
            bool notover = true;
            //animations.gameName();   //for quicker testing disable this line
            do
            {

                GenerateBoard.CreateBoard();

                GenerateBoard.showboard();
                do
                {
                    notover = PlayerMove.userMove();
                    if (notover == true)
                    {
                        notover = PlayerMove.winner();
                    }
                } while (notover);
                playAgain = Continue.YN();
            } while (playAgain);
        }
    }
}
