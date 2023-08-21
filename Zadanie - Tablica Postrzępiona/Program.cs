
using System;
using System.Linq;

namespace TablicePostrzepione
{
    class TablicaPostrzepiona1
    {
        
        static void Main(string[] args)
        {
            char[][] jagged = ReadJaggedArrayFromStdInput();
            PrintJaggedArrayToStdOutput(jagged);
            jagged = TransposeJaggedArray(jagged);
            Console.WriteLine();
            PrintJaggedArrayToStdOutput(jagged);
        }
        

        static char[][] ReadJaggedArrayFromStdInput()
        {
            
            int numberOfRows = int.Parse(Console.ReadLine());

            char[][] jaggedArrayFinal = new char[numberOfRows][];


            int count = 0;
            while (count < numberOfRows)
            {
                string line = Console.ReadLine();
                count++;

                char[] parsedInput = Array.ConvertAll<string, char>(line.Split(' '), char.Parse);

                jaggedArrayFinal[count-1] = new char[parsedInput.Length];

                    for (int j = 0; j < parsedInput.Length; j++)
                    {
                        jaggedArrayFinal[count-1][j] = parsedInput[j];
                    }

            }

            return jaggedArrayFinal;

        }


        static char[][] TransposeJaggedArray(char[][] tab)
        {
            int maxRowLength = 0;
            foreach(char[] row in tab)
            {
                maxRowLength = Math.Max(maxRowLength, row.Length);
            }


            char[][] result = new char[maxRowLength][];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new char[tab.Length];
            }


            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < tab.Length; j++)
                {
                    result[i][j] = i < tab[j].Length ? tab[j][i] : ' ';
                }
            }



            return result;

        }


        static void PrintJaggedArrayToStdOutput(char[][] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
               for (int j = 0; j < tab[i].Length; j++)
                {
                    Console.Write(tab[i][j] + " ");
                }
               Console.WriteLine();
            }
        }

    }
}



