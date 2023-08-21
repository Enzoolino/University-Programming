




using System.ComponentModel;
using System;
using System.Linq;
using System.Collections.Generic;


namespace TabliceWielowymiarowe
{
    class Tablice3
    {

        static void Main()
        {

            List<int[]> matrix = new List<int[]>();

            string line;
            while ((line = Console.ReadLine()) != null)
            {
                int[] parsedInput = line.Split(' ').Select(x => int.Parse(x)).ToArray();
                matrix.Add(parsedInput);
            }


            int columns = matrix[0].Length;

            //Znajdywanie ineksu kolumny o największej sumie
            int maxSumIndex = 0;
            int maxSum = 0;

            for (int i = 0; i < columns; i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.Count; j++)
                {
                    sum += matrix[j][i];
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxSumIndex = i;
                }
                else if (sum == maxSum && i < maxSumIndex)
                {
                    maxSumIndex = i;
                }
            }
            Console.WriteLine(maxSumIndex);

          

        }
    }
}