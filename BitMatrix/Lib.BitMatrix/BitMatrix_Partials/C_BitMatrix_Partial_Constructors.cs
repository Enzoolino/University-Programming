
using System;
using System.Collections;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Lib_BitMatrix
{
    public partial class BitMatrix
    {
        //Przeciążony Konstruktor 1
        public BitMatrix(int numberOfRows, int numberOfColumns, params int[] bits)
        {
            int maxSizeOfArray = numberOfColumns * numberOfRows;

            //Wyjątek od wielkości tablicy.
            if (numberOfRows < 1 || numberOfColumns < 1)
                throw new ArgumentOutOfRangeException("Incorrect size of matrix");

            //Array z kolejnymi boolami BitMatrix.
            bool[] myBools = new bool[maxSizeOfArray];


            if (bits == null || bits.Length == 0)
            {
                for (int i = 0; i < myBools.Length; i++)
                {
                    myBools[i] = false;
                }
            }
            else
            {
                int counter = 0;

                for (int i = 0; i < numberOfRows; i++)
                {
                    for (int j = 0; j < numberOfColumns; j++)
                    {
                        if (bits.Length >= maxSizeOfArray || bits.Length < maxSizeOfArray && counter < bits.Length)
                        {
                            bool b = BitToBool(bits[counter]);
                            myBools[counter] = b;
                            counter++;
                        }
                        else if (counter >= bits.Length)
                        {
                            myBools[counter] = false;
                            counter++;
                        }  
                    }
                }
            }

            data = new BitArray(myBools);
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
        }

        //Przeciążony Konstruktor 2
        public BitMatrix(int[,] bits)
        {
            //Reguły wyjątków.
            if (bits == null)
                throw new NullReferenceException();
            else if (bits.Length == 0)
                throw new ArgumentOutOfRangeException();

            bool[] myBools = new bool[bits.GetLength(0) * bits.GetLength(1)];

            int counter = 0;

            for (int i = 0; i < bits.GetLength(0); i++)
            {
                for (int j = 0; j < bits.GetLength(1); j++)
                {
                    myBools[counter] = BitToBool(bits[i, j]);
                    counter++;
                }
            }

            data = new BitArray(myBools);
            NumberOfRows = bits.GetLength(0);
            NumberOfColumns = bits.GetLength(1);
        }

        //Przeciążony Konstruktor 3
        public BitMatrix(bool[,] bits)
        {
            //Reguły wyjątków.
            if (bits == null)
                throw new NullReferenceException();
            else if (bits.Length == 0)
                throw new ArgumentOutOfRangeException();

            bool[] myBools = new bool[bits.GetLength(0) * bits.GetLength(1)];

            int counter = 0;

            for (int i = 0; i < bits.GetLength(0); i++)
            {
                for (int j = 0; j < bits.GetLength(1); j++)
                {
                    myBools[counter] = bits[i, j];
                    counter++;
                }
            }

            data = new BitArray(myBools);
            NumberOfRows = bits.GetLength(0);
            NumberOfColumns = bits.GetLength(1);
        }

        //Przedstawienie tekstowe ToString().
        /*
        public override string ToString()
        {
            int counter = 0;
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    if (data[counter] == true)
                        Console.Write(1);
                    else
                        Console.Write(0);

                    counter++;
                }
                Console.Write(Environment.NewLine);
            }
            return "";
        }
        */
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            int counter = 0;

            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    if (data[counter] == true)
                        sb.Append(1);
                    else 
                        sb.Append(0);
                    counter++;
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }



    }

}
