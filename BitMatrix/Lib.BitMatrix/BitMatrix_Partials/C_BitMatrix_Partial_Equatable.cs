using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_BitMatrix
{
    public partial class BitMatrix : IEquatable<BitMatrix>
    {
        public bool Equals(BitMatrix other)
        {
            if (other == null ) return false;
            if (Object.ReferenceEquals(this, other)) return true;

            if (this.NumberOfColumns != other.NumberOfColumns ||
                this.NumberOfRows != other.NumberOfRows)
            {
                return false;
            }

            for (int i = 0; i < this.data.Length; i++)
            {

                if (this.data[i] != other.data[i])
                {
                    return false;
                }
            }

            return true;
            
        }

        public override bool Equals(object obj)
        {
            return obj is BitMatrix ? Equals((BitMatrix)obj) : false;
        }

        public override int GetHashCode() => (data, NumberOfColumns, NumberOfRows, IsReadOnly).GetHashCode();

        public static bool operator ==(BitMatrix b1, BitMatrix b2)
        {
            if (object.ReferenceEquals(b1, null) || object.ReferenceEquals(b2, null))
                return object.ReferenceEquals(b1, b2);

            return b1.Equals(b2);
        }

        public static bool operator !=(BitMatrix b1, BitMatrix b2) => !(b1 == b2);
        
    }
}
