using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

class AnyClass
{
}
static class ExtensionMethodClass
{
    public static  int MyMethod(this AnyClass  params1, int params2)
    {
        return params2;
    }

    public static void Main()
    {
        new AnyClass().MyMethod(1);
    }
}