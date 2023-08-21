using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StrukturaStos
{
    public class Stos<T> : IStos<T>
    {
        public void Push(T value)
        {
            StosList.Add(value);
        }

        public T Peek
        {
            get { if(IsEmpty)throw new StosEmptyException(); return StosList.Last(); }
        }

        public T Pop()
        {
            if (IsEmpty) throw new StosEmptyException();
            else
            {
                object deleted = StosList.Last();
                StosList.Remove(StosList.Last());

                return (T)deleted;
            }
        }

        public int Count
        {
            get { return StosList.Count; }
        }

        public bool IsEmpty
        {
            get { if (StosList == null || StosList.Count == 0) return true; return false; }
        }

        public List<T> StosList { get; set; } = new List<T>();

        public void Clear()
        {
            StosList.Clear();
        }

        public T[] ToArray()
        {
            return StosList.ToArray();
        }

        
     
    }
    
}
