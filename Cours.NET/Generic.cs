using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestClass
{
    public TestClass() { }
    public static void Main()
    {
        var cl = new GenericClass<TestClass>();
        (TestClass i, int j) = cl.MyMethod(new TestClass(), 3);

        Console.WriteLine($"typeof(List<String>) == typeof(List<int>) ? {typeof(List<String>) == typeof(List<int>)}");
        Console.WriteLine($"new List<String>().GetType() == new List<int>().GetType() ? {new List<String>().GetType() == new List<int>().GetType()}");
    }
}
class GenericClass<T> where T: class, new()
{
    public (T, V) MyMethod<V>(T t, V v) where V : struct
    {
        return (t, v);
    }
}