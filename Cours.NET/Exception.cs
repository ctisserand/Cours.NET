using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourDotNET
{
    class ExceptionClass : Exception
    {
        public static void Raise()
        {
            throw new ExceptionClass();
        }
        public static void Main()
        {

        }
    }
}
