using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GCClass
{
    public static void Main()
    {
        Console.Out.WriteLine(GC.GetTotalMemory(true));
        GC.Collect();
    }
}
