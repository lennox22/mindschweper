using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper
{
    public class RandomGenerator
    {
        Random rand = new Random();

        public bool GetRandomBool()
        {
            int temp = rand.Next(2);
            bool onOff;
            if (temp == 0)
            {
                onOff = false;
            }
            else
            {
                onOff = true;
            }
            return onOff;
        }
        public int randoX(int rows)
        {
            int x = rand.Next(rows);
            return x;
        }
        public int randoY(int columns)
        {
            int y = rand.Next(columns);
            return y;
        }
    }
}
