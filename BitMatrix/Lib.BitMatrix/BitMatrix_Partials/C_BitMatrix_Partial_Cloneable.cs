using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_BitMatrix
{
    public partial class BitMatrix : ICloneable
    {
        public object Clone()
        {
            BitMatrix other = new BitMatrix(this.NumberOfRows, this.NumberOfColumns);
            other.data = new BitArray(this.data);
            return other;
        }
    }
}
