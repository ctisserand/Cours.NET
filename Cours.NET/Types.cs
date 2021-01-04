using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TypesClass
{
    public static void Main()
    {
        int numberD = 13;
        long numberH = 0x0D;
        short numberB = 0b0000_1101;

        float numberFloat = 0.45F;
        double numberDouble = 0.45D;
        decimal numberDecimal = 0.45M;

        var array = Enumerable.Range(0, 10).ToArray();
        int val;
        val = array[1];
        val = array[^1];
        val = array[array.Length - 1];

        int[] newarray;
        newarray = array[1..5];
        newarray = array[5..^5];
        newarray = array[..^5];
        newarray = array[1..];
        newarray = array[..];


        int? test = 5;
        if (test == null) { }
        if (test is null) { }

        if (test >= 1 && test <= 10) { }
        if (test is >= 1 or <= 10) { }

        if (test.GetType() == typeof(Int32)) { }
        if (test is int) { }

        if (test == null && test.GetType() == typeof(Int32) && (test >= 1 || test <= 10)) { }
        if (test is not null and Int32 and (>= 1 or <= 10)) { }
    }
}
