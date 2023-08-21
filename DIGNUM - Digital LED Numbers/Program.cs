











using System;
using System.Text;
using System.Linq;

namespace LED
{
    internal class LED1
    {

        public static void Main()
        {

            var scale = 1;
            var input = Console.ReadLine();

            PrintLine(input, "", "14", "", 2);
            PrintLine(input, "1237", "1", "156", scale);
            PrintLine(input, "1237", "170", "56", 2);
            PrintLine(input, "134579", "", "2", scale);
            PrintLine(input, "134579", "1479", "2", 2);
        }

        static void PrintLine(string input, string leftMatch, string middleMatch, string rightMatch, int scale)
        {
            for (int i = 1; i < scale; i++)
            {
                foreach (var c in input)
                {

                    PrintDigitLine(c, leftMatch, '|', 1);
                    PrintDigitLine(c, middleMatch, '_', 1);
                    PrintDigitLine(c, rightMatch, '|', 1);

                }
                Console.Write("\n");
            }
        }

        private static void PrintDigitLine(char digit, string match, char charToPrint, int n)
        {
            for (int i = 0; i < n; i++) Console.Write(match.Contains(digit) || match == "" ? ' ' : charToPrint);
        }







    }



}













