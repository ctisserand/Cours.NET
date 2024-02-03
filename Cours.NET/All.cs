using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class All
{
    public static void Main(string[] args)
    {
        var t = Assembly.GetExecutingAssembly().GetTypes()
            .Where(c => c.GetMethod("Main", BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic) is not null)
            .Union(Assembly.GetExecutingAssembly().GetTypes().Where(c =>
                c.GetMethod("Main", BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, new Type[] { typeof(string[]) }) is not null)
            )
            .Where(c => c.Name != "All");
        Parallel.ForEach(t, t =>
        {
            Console.WriteLine(t.Name);
        });

        t = Assembly.GetExecutingAssembly().GetTypes()
            .Where(c => 
                c.GetMethod("Main", BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic) is not null ||
                c.GetMethod("Main", BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, new Type[] { typeof(string[]) }) is not null
            )
            .Where(c => c.Name != "All");

        foreach (var c in t)
        {
            Console.WriteLine($@"---------------------------------------------------------------------
{c.FullName}
---------------------------------------------------------------------");
            var mainWArgs = c.GetMethod("Main", BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic, new Type[] { typeof(string[]) });
            if (mainWArgs is not null)
            {
                mainWArgs.Invoke(null, [args]);
                continue;
            }
            var main = c.GetMethod("Main", BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
            if (main is not null)
                main.Invoke(null, null);
        }
        var s = t.Where(c => c.Name == "Start");
    }
}
