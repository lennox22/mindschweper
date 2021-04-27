using System;
using System.Collections.Generic;

namespace MineSweeper
{
    
    
    class Program
    {
        static void Main(string[] args)
        {
            //animations.gameName();   //for quicker testing disable this line
            GenerateBoard.CreateBoard();
            GenerateMinds.loadMinds();


        }
    }
}
