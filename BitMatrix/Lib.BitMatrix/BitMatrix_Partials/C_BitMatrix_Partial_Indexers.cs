using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lib_BitMatrix
{
    public partial class BitMatrix : IEnumerable<int>
    {

        //Indexer
        public int this[int x, int y]
        {
            get 
            {
                if (x >= NumberOfRows || y >= NumberOfColumns || x < 0 || y < 0)
                    throw new IndexOutOfRangeException();

                return BoolToBit(data[x * NumberOfColumns + y]); 
            }
            set 
            {
                if (x >= NumberOfRows || y >= NumberOfColumns || x < 0 || y < 0)
                    throw new IndexOutOfRangeException();

                data[x * NumberOfColumns + y] = BitToBool(value); 
            }
        }

        //Enumerator
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < NumberOfRows * NumberOfColumns; i++)
                yield return BoolToBit(data[i]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
    }
}
