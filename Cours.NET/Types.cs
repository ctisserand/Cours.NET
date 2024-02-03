using System;
using System.Collections.Generic;
using System.Drawing;
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

        List<object[]> ps = new List<object[]>();
        for (int i = 0; i < 10; i++)
            ps.Add(new object[] { i.ToString(), i, i%2 == 0 ? new Point(i,i) : i });

        string res = "";
        foreach(var p in ps)
        {
            res += p switch
            {
                [var a, > 2, Point { X: >1 }] => a,
                [var a, > 2, > 0] => $"_",
                _ => 0
            };
        }
        // Les 3 permier objet sont ignorer (car p[1] <= 2) 
        // 1 item sur 2 à un _ car p[2] n'est pas de type Point mais > 0
        Console.WriteLine(res);
    }
}
