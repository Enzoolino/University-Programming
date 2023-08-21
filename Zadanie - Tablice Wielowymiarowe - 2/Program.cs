


using System.Runtime.Serialization.Formatters;
using System;
using System.Linq;

namespace Tablice2D
{
    class Tablica2
    {

        static void Main()
        {

            //Deklaracja macierzy A
            string[] sizeOfA = Console.ReadLine().Split(" ");

            int dimension1OfA = int.Parse(sizeOfA[0]);
            int dimension2OfA = int.Parse(sizeOfA[1]);


            int[,] arrayA = new int[dimension1OfA, dimension2OfA];

            string arrayAValues = Console.ReadLine();
            int[] fillerOfA = Array.ConvertAll<string, int>(arrayAValues.Split(" "), int.Parse);

            int counterA = 0;

            for (int i = 0; i < dimension1OfA; i++)
            {

                for (int j = 0; j < dimension2OfA; j++)
                {
                    arrayA[i, j] = fillerOfA[counterA];
                    counterA++; 
                }
            }


            //Deklaracja macierzy B

            string[] sizeOfB = Console.ReadLine().Split(" ");

            int dimension1OfB = int.Parse(sizeOfB[0]);
            int dimension2OfB = int.Parse(sizeOfB[1]);

            int[,] arrayB = new int[dimension1OfB, dimension2OfB];

            string arrayBValues = Console.ReadLine();
            int[] fillerOfB = Array.ConvertAll<string, int>(arrayBValues.Split(" "), int.Parse);

            int counterB = 0;


            for (int i = 0; i < dimension1OfB; i++)
            {
                for (int j = 0; j < dimension2OfB; j++)
                {
                    arrayB[i, j] = fillerOfB[counterB];
                    counterB++;
                }
            }




            //Wypisz wynik jeśli możliwe
            int[,] C = MultiplyMatrices(arrayA, arrayB, dimension1OfA, dimension2OfA, dimension1OfB, dimension2OfB);

            if (C != null)
            {
                for (int i = 0; i < dimension1OfA; i++)
                {
                    for (int j = 0; j < dimension2OfB; j++) 
                    {
                        Console.Write(C[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("impossible");
            }
        }





        //FUNKCJA: liczy elementy iloczynu  macierzy AxB

        static int[,] MultiplyMatrices(int[,] arrayA, int[,] arrayB, int dimension1OfA, int dimension2OfA, int dimension1OfB, int dimension2OfB)
        {

            if (dimension2OfA != dimension1OfB)
            {
                return null;
            }

            int[,] C = new int[dimension1OfA, dimension2OfB];




            for (int i = 0; i < dimension1OfA; i++)
            {
                for (int j = 0; j < dimension2OfB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < dimension2OfA; k++)
                    {
                        sum += arrayA[i, k] * arrayB[k, j];
                    }
                    C[i, j] = sum;
                }
            }
            return C;

        }
             
    }
}



