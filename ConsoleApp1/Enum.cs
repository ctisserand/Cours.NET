using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum MyEnum
{
    A,
    B,
    C,
    D,
}

public enum MyLongEnum : long
{
    A = 0b0000_0001, // 1
    B = 0b0000_0010, // 2
    C = 0b0000_0100, // 4
    D = 0b0000_1000, // 8
}

[Flags]
public enum MyFlags : long
{
    A = 0b0000_0001, // 1
    B = 0b0000_0010, // 2
    C = 0b0000_0100, // 4
    D = 0b0000_1000, // 8
    All = A | B | C | D // 15
}

class EnumClass
{
    public static void Main()
    {
        Console.WriteLine($"{MyLongEnum.A}"); // -> A
        Console.WriteLine($"{(int)MyLongEnum.A}"); // -> 1
        Console.WriteLine($"{(MyLongEnum)2}"); // -> B
        Console.WriteLine($"{(MyLongEnum)5}"); // -> 5 (valid !)
        Console.WriteLine($"{Enum.IsDefined(typeof(MyLongEnum), 2L)}"); // -> true
        Console.WriteLine($"{Enum.IsDefined(typeof(MyLongEnum), 5L)}"); // -> false
        Console.WriteLine($"{Enum.IsDefined(typeof(MyLongEnum), "C")}"); // -> true
        Console.WriteLine($"{Enum.IsDefined(typeof(MyLongEnum), "F")}"); // -> false
    }
}
class EnumFlagClass
{
    public static void Main()
    {
        Console.WriteLine($"{MyFlags.A}"); // -> A
        Console.WriteLine($"{(int)MyFlags.A}"); // -> 1
        Console.WriteLine($"{MyFlags.A | MyFlags.C}"); // -> A, C
        Console.WriteLine($"{(int)(MyFlags.A | MyFlags.C)}"); // -> 5
        Console.WriteLine($"{(MyFlags)2}"); // -> B
        Console.WriteLine($"{(MyFlags)5}"); // -> A, C
        Console.WriteLine($"{Enum.IsDefined(typeof(MyFlags), 2L)}"); // -> true
        Console.WriteLine($"{Enum.IsDefined(typeof(MyFlags), 5L)}"); // -> false
        Console.WriteLine($"{Enum.IsDefined(typeof(MyFlags), 0b0000_0110L)}"); // -> false
    }
}

