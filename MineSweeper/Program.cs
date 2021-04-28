using System;
using System.Collections.Generic;

namespace MineSweeper
{
    
    
    class Program
    {
        static void Main(string[] args)
        {
            bool notover = true;
            //animations.gameName();   //for quicker testing disable this line
            GenerateBoard.CreateBoard();
            
            GenerateBoard.showboard();
            do
            {
                PlayerMove.userMove();
            } while (notover);

        }
    }
}
