using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #nullable enable
class NullableClass
{
    public int K { get; set; }
    public static void ConditionalNull()
    {
        NullableClass variable = null;
        int? k = variable?.K;

        NullableClass[] array = null;
        k = array?[0].K;
        k = array?[0]?.K;

        NullableClass[] notnullarray = new NullableClass[] { new() };
        try
        {
            // vérifiez toujours que l'index est bien dans les limites du tableau
            k = notnullarray?[1]?.K;
        }
        catch(IndexOutOfRangeException e)
        {
            Console.WriteLine("L'index n'existe pas dans le tableau");
        }
    }

    public static void Main()
    {
        ConditionalNull();

        //Nullable<int> nullableNumber = null;
        int? nullableNumber = null;
        if (nullableNumber.HasValue) Console.WriteLine("HasValue");
        if(nullableNumber == null) Console.WriteLine("null");
        if(nullableNumber == 0) Console.WriteLine("== 0");

        int number = nullableNumber ?? 0;

        number = nullableNumber == null ? 0 : nullableNumber.Value;

        number = 0;
        if (nullableNumber == null)
            number = 0;
        else
            number = nullableNumber.Value;


        nullableNumber ??= 0;

        nullableNumber = null;
        nullableNumber = nullableNumber ?? 0;

        nullableNumber = null;
        nullableNumber = nullableNumber == null ? 0 : nullableNumber.Value;

        nullableNumber = null;
        nullableNumber = 0;
        if (nullableNumber == null)
            nullableNumber = 0;
        else
            nullableNumber = nullableNumber.Value;


        var c = new NullableClass();
    }
}
