using System;

namespace TDDTips
{
    public class NumbersToWords
    {
        public static string[] digitwords =
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };
        static string[] teenwords =
        {
            "ten",      // 10 - 10 = index 0
            "eleven",   // 11 - 10 = index 1
            "twelve",   // 12 - 10 = index 2
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"  // 19 - 10 = index 9
        };
        static string[] decawords =
        {
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
        };
        // This will be the only public function
        public string ConvertToString(int num)
        {
            int thousandspart = num / 1000;
            int hundredspart = num % 1000;
            if (num == 0)
            {
                return DigitToWord(0);
            }
            if (thousandspart == 0)
            {
                return $"{FullThreeDigitsToWord(hundredspart)}";
            }
            else if (hundredspart == 0)
            {
                return $"{FullThreeDigitsToWord(thousandspart)} thousand";
            }
            else
            {
                return $"{FullThreeDigitsToWord(thousandspart)} thousand {FullThreeDigitsToWord(hundredspart)}";
            }
        }
        // Only pass a single digit number into this function
        public string DigitToWord(int num)
        {
            return digitwords[num];
        }
        public string TeenToWord(int num)
        {
            return teenwords[num - 10];
        }
        public string TwoDigitToWord(int num)
        {
            int tensdigit = num / 10;
            int onesdigit = num % 10;
            if (onesdigit == 0)
            {
                return decawords[tensdigit - 2];
            }
            else
            {
                return decawords[tensdigit - 2] + " " + DigitToWord(onesdigit);
            }
        }
        public string ThreeDigitToWord(int num)
        {
            int hundredsdigit = num / 100;
            int restofnumber = num % 100;
            if (restofnumber == 0)
            {
                return DigitToWord(hundredsdigit) + " hundred";
            }
            if (restofnumber < 10)
            {
                return DigitToWord(hundredsdigit) + " hundred and " + DigitToWord(restofnumber);
            }
            else if (restofnumber < 20)
            {
                return DigitToWord(hundredsdigit) + " hundred and " + TeenToWord(restofnumber);
            }
            else
            {
                return DigitToWord(hundredsdigit) + " hundred and " + TwoDigitToWord(restofnumber);
            }
        }
        // This will handle ALL numbers from 0 to 999
        // Use this for all numbers 0 to 999. Don't use the earlier functions.
        // Those are "internal" functions
        public string FullThreeDigitsToWord(int num)
        {
            if (num == 0)
            {
                return "";
            }
            else if (num < 10)
            {
                return DigitToWord(num);
            }
            else if (num < 20)
            {
                return TeenToWord(num);
            }
            else if (num < 100)
            {
                return TwoDigitToWord(num);
            }
            else
            {
                return ThreeDigitToWord(num);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*int num = 101;
            int hd = num / 100;
            int rd = num % 100;
            Console.WriteLine(hd);
            Console.WriteLine(rd);*/
            NumbersToWords n2w = new NumbersToWords();
            /*Console.WriteLine(n2w.ConvertToString(543));
            Console.WriteLine(n2w.ConvertToString(5432));
            Console.WriteLine(n2w.ConvertToString(54321));
            Console.WriteLine(n2w.ConvertToString(654321));*/
            //Console.WriteLine(NumbersToWords.digitwords[3]);
            for (int i = 0; i < 1000000; i++)
            {
                Console.WriteLine($"{i} : {n2w.ConvertToString(i)}");
            }
            /*int x = 35;
            int y = x % 10;
            Console.WriteLine(y);*/

        }
    }
}
