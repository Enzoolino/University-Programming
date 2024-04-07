using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib_BitMatrix
{
    public partial class BitMatrix
    {
        public static explicit operator BitMatrix(int[,] arr)
        {
            return new BitMatrix(arr);
        }

        public static implicit operator int[,](BitMatrix matrix)
        {
            int[,] result = new int[matrix.NumberOfRows, matrix.NumberOfColumns];

            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfColumns; j++)
                {
                    result[i, j] = matrix[i, j];
                }
            }
            return result;
        }

        public static explicit operator BitMatrix(bool[,] arr)
        {
            return new BitMatrix(arr);
        }

        public static implicit operator bool[,](BitMatrix matrix)
        {
            bool[,] result = new bool[matrix.NumberOfRows, matrix.NumberOfColumns];

            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfColumns; j++)
                {
                    result[i, j] = BitToBool(matrix[i, j]);
                }
            }
            return result;
        }

        public static explicit operator BitArray(BitMatrix matrix)
        {
            BitMatrix result = (BitMatrix)matrix.Clone();

            return result.data;
        }

        



    }
}
