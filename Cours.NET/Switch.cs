using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SwitchClass
{
    public static void Main()
    {
        MyFlags e = MyFlags.C | MyFlags.D;
        switch(e) {
            case var t when e.HasFlag(MyFlags.C | MyFlags.D) && !e.HasFlag(MyFlags.A | MyFlags.B):
                Console.Out.WriteLine(t);
                break;
            case var t when e.HasFlag(MyFlags.A | MyFlags.B) && !e.HasFlag(MyFlags.C | MyFlags.D):
                Console.Out.WriteLine(t);
                break;
            case MyFlags.B:
            case MyFlags.A:
                Console.Out.WriteLine("A | B");
                break;
            case MyFlags.All:
                Console.Out.WriteLine("ALL");
                break;
            default:
                break;

        }

        string str = "2";
        switch(str) {
            case "1":
                Console.Out.WriteLine("Case 1");
                break;
            case "2":
                Console.Out.WriteLine("Case 2");
                break;
        }

        object obj = new String("");
        switch (obj)
        {
            case Array arr:
                break;
            case IEnumerable<int> ieInt:
                break;
            case IList lst:
                break;
            case String s:
                break;
            case null:
                break;
            default:
                break;

        }
    }
    public static void Process<T>(T obj)
    {
        switch (obj)
        {
            case Array arr:
                break;
            case IEnumerable<int> ieInt:
                break;
            case IList lst:
                break;
            case String s:
                break;
            case null:
                break;
            default:
                break;

        }
    }
}