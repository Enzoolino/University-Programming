
using System;
using System.Linq;

namespace TablicaWymiarowa
{
    class TablicaWymiarowa1
    {
        static void Main(string[] args)
        {

            string[] lengths = Console.ReadLine().Split(" ");

            int dimension1 = int.Parse(lengths[0]);
            int dimension2 = int.Parse(lengths[1]);

            int[,] dimensionalArray = new int[dimension1, dimension2];


            for (int i = 0; i < dimension1; i++)
            {
                string row = Console.ReadLine();
                int[] dataRow = Array.ConvertAll<string, int>(row.Split(" "), int.Parse);

                for (int j = 0; j < dimension2; j++)
                {

                    dimensionalArray[i, j] = dataRow[j];

                }

            }


            for (int i = 0; i < dimension2; i++)
            {

                for (int j = 0; j < dimension1; j++)
                {
                    Console.Write(dimensionalArray[j, i] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
