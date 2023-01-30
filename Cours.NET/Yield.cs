using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Yield
{
    public static IEnumerable<int> GetList()
    {
        var array = new List<int>() { 1, 2, 3, 4, 5, 6 };
        foreach(var item in array)
        {
            Console.WriteLine($"Return Item: {item}");
            yield return item;
        }
    }
    public static void Main(string[] args)
    {
        foreach(var item in GetList())
        {
            Console.WriteLine($"Processing item: {item}");
        }
    }
}
