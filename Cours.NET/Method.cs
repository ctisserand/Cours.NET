using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MethodClass
{
    public void MyFunction(int a, bool c = true, bool d = default)
    {

    }
    public void MyInfiniteFunction(String a, params int[] b)
    {
        return;
    }

    public static void Main()
    {
        var myClass = new MethodClass();
        myClass.MyFunction(0);
        myClass.MyFunction(0, false);
        myClass.MyFunction(0, false, true);
        myClass.MyFunction(0, d: true);
        myClass.MyFunction(a: 0, d: true);

        myClass.MyInfiniteFunction("0", 1, 2, 3, 5, 6, 8, 9);
        myClass.MyInfiniteFunction("0");
        myClass.MyInfiniteFunction("0", null);
    }
}

class TupleClass
{
    public (int, int, string) MyFunction()
    {
        return (0, 1, "");
    }
    public void Main()
    {
        (int, int, string) res = MyFunction();
        int resa = res.Item1;
        int resb = res.Item2;
        string resc = res.Item3;
        (_, var b, var c) = MyFunction();
    }
}

class InOut
{
    public int MyFunction3(String a, out List<int> p)
    {
        p = new List<int>();
        return 0;
    }
    public int MyFunction4(String a, in InOut p)
    {
        // p = new Program();
        return 0;
    }
    public int MyFunction5(ref int k)
    {
        k = 0;
        return 0;
    }
    public static void Main()
    {
        int j = 10;
        var myClass = new InOut();
        myClass.MyFunction5(ref j);
        Console.WriteLine($"{j}"); // -> j = 0
    }
}
