using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MemorySpan
{
    public static void Main()
    {
        int[] array = new int[100000];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i;
        }
        
        var mem = new Memory<int>(array, 100, 10);
        Console.WriteLine($"Before value: {mem.Span[5]}");
        ModifyItem(mem.Span);
        Console.WriteLine($"After value: {mem.Span[5]}");

        //var mem = new Memory<int>(array, 100, 110);

        Console.WriteLine($"Original array: {String.Join(",",array[100..110])}");
    }

    public static void ModifyItem(Span<int> mem)
    {
        Console.WriteLine($"Working array size: {mem.Length}");
        mem[5] = 999;
    }
}
