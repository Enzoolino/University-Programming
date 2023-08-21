using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrukturaStos
{
    public class StosEmptyException : Exception
    {
        public StosEmptyException() { }
        public StosEmptyException(string message) : base(message) { }
        public StosEmptyException(string message, Exception inner) : base(message, inner) { }
    }
}
