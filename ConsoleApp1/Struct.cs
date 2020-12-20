using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct MyStruct
{
    public int MyParam1 { get; set; }
}

class StructClass
{
    public static void Main()
    {
        MyStruct struct1 = new MyStruct { MyParam1 = 0 };
        MyStruct struct2 = struct1;
        struct1.MyParam1 = 20;
        Console.WriteLine($"{struct1.GetHashCode()} != {struct2.GetHashCode()}");
        Console.WriteLine($"{struct1.MyParam1} == 20");
        Console.WriteLine($"{struct2.MyParam1} == 0");

        var class1 = new StructClass();
        var class2 = class1;
        Console.WriteLine($"{class1.GetHashCode()} == {class2.GetHashCode()}");
    }
}
