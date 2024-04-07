using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_BitMatrix
{
    public partial class BitMatrix
    {
        public static void ExceptionThrower(BitMatrix a, BitMatrix b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException();

            if (a.NumberOfRows != b.NumberOfRows || a.NumberOfColumns != b.NumberOfColumns)
                throw new ArgumentException();
        }

        public BitMatrix And(BitMatrix other)
        {
            ExceptionThrower(this, other);

            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {
                    if (this[i, j] == 1 && other[i, j] == 1)
                    {
                        this[i, j] = 1;
                    }
                    else
                        this[i, j] = 0;
                }
            }
            return this;
        }

        public BitMatrix Or(BitMatrix other)
        {
            ExceptionThrower(this, other);

            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {
                    if (this[i, j] == 0 && other[i, j] == 0)
                    {
                        this[i, j] = 0;
                    }
                    else
                        this[i, j] = 1;
                }
            }
            return this;
        }

        public BitMatrix Xor(BitMatrix other)
        {
            ExceptionThrower(this, other);

            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {
                    if (this[i, j] != other[i, j])
                    {
                        this[i, j] = 1;
                    }
                    else
                        this[i, j] = 0;
                }
            }
            
            return this;
        }

        public BitMatrix Not()
        {
            if (this == null)
                throw new ArgumentNullException();

            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {
                    if (this[i, j] == 0)
                        this[i, j] = 1;
                    else
                        this[i, j] = 0;
                }
            }
            return this;
        }




        public static BitMatrix operator &(BitMatrix a, BitMatrix b)
        {
            ExceptionThrower(a, b);

            BitMatrix result = new BitMatrix(a.NumberOfRows, a.NumberOfColumns);

            for (int i = 0; i < a.NumberOfRows; i++)
            {
                for (int j = 0; j < a.NumberOfColumns; j++)
                {
                    if (a[i, j] == 1 && b[i, j] == 1)
                    {
                        result[i, j] = 1;
                    }
                    else
                        result[i, j] = 0;
                }
            }
            return result;
        }

        public static BitMatrix operator |(BitMatrix a, BitMatrix b)
        {
            ExceptionThrower(a, b);

            BitMatrix result = new BitMatrix(a.NumberOfRows, a.NumberOfColumns);

            for (int i = 0; i < a.NumberOfRows; i++)
            {
                for (int j = 0; j < a.NumberOfColumns; j++)
                {
                    if (a[i, j] == 0 && b[i, j] == 0)
                    {
                        result[i, j] = 0;
                    }
                    else
                        result[i, j] = 1;
                }
            }
            return result;
        }

        public static BitMatrix operator ^(BitMatrix a, BitMatrix b)
        {
            ExceptionThrower(a, b);

            BitMatrix result = new BitMatrix(a.NumberOfRows, a.NumberOfColumns);

            for (int i = 0; i < a.NumberOfRows; i++)
            {
                for (int j = 0; j < a.NumberOfColumns; j++)
                {
                    if (a[i, j] != b[i, j])
                    {
                        result[i, j] = 1;
                    }
                    else
                    {
                        result[i, j] = 0;
                    }
                }
            }
            return result;
        }

        public static BitMatrix operator !(BitMatrix a)
        {
            if (a == null)
                throw new ArgumentNullException();

            BitMatrix result = new BitMatrix(a.NumberOfRows, a.NumberOfColumns);

            for (int i = 0; i < a.NumberOfRows; i++)
            {
                for (int j = 0; j < a.NumberOfColumns; j++)
                {
                    if (a[i, j] == 0)
                        result[i, j] = 1;
                    else
                        result[i, j] = 0;
                }
            }

            return result;
        }



    }

}

