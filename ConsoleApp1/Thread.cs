using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class ThreadClass
{
    public static void Main()
    {
        /*
        var t = new Thread(x =>
        {
            int loop = x as int? ?? 5;
            foreach(int i in Enumerable.Range(0, loop))
            {
                Console.WriteLine(" -- [1] This is print from another thread");
                Thread.Sleep(100);
            }
            
        });
        t.Start(10);

        foreach (int i in Enumerable.Range(0, 10))
        {
            Console.WriteLine("[1] This is print from the main thread");
            Thread.Sleep(100);
        }


        t.Join();


        var task = new Task(() =>
        {
            foreach (int i in Enumerable.Range(0, 10))
            {
                Console.WriteLine(" -- [2] This is print from another thread");
                Thread.Sleep(100);
            }
        });
        task.Start();

        foreach (int i in Enumerable.Range(0, 10))
        {
            Console.WriteLine("[2] This is print from the main thread");
            Thread.Sleep(100);
        }

        task.Wait();

        task = new Task(() =>
        {
            foreach (int i in Enumerable.Range(0, 5))
            {
                Console.WriteLine(" -- [3] This is print from another thread");
                Thread.Sleep(100);
            }
        });
        task.RunSynchronously();

        foreach (int i in Enumerable.Range(0, 10))
        {
            Console.WriteLine("[3] This is print from the main thread");
            Thread.Sleep(100);
        }

        var tasks = new List<Task>();
        tasks.Add(Task.Run(() =>
        {
            foreach (int i in Enumerable.Range(0, 5))
            {
                Console.WriteLine(" -- [4 ] This is print from another thread");
                Thread.Sleep(100);
            }
        }));
        tasks.Add(Task.Run(() =>
        {
            foreach (int i in Enumerable.Range(0, 5))
            {
                Console.WriteLine(" -- [ 5] This is print from another thread");
                Thread.Sleep(100);
            }
        }));

        Task.WaitAll(tasks.ToArray());
        */

        var mtask = AnyProcessing();


        foreach (int i in Enumerable.Range(0, 10))
        {
            Console.WriteLine("[ 9] This is print from the main thread");
            Thread.Sleep(100);
        }

        Console.WriteLine($"{mtask.Result}");

        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Parallel.ForEach(Enumerable.Range(0, 30), new ParallelOptions { MaxDegreeOfParallelism = 30 }, x =>
        {
            Console.WriteLine($" ** [{x}] This is print from the main thread");
            Thread.Sleep(1000);
        });
        stopwatch.Stop();
        Console.WriteLine($" Temps total pour 30 calcul de 1s : [{stopwatch.Elapsed}]");
    }

    public static async Task<int> AnyProcessing()
    {
        foreach (int i in Enumerable.Range(0, 10))
        {
            var index = await AnyProcessing2();
            Console.WriteLine($" -- [{index} ] This is print from another thread");
            // await ou Task.Run au choix sinon la methode est éxécuter de facon synchrone
            
        }
        return 1;
    }

    public static Task<int> AnyProcessing2()
    {
        return Task.Run(() => {
            Thread.Sleep(100);
            // await ou Task.Run au choix sinon la methode est éxécuter de facon synchrone
            return 1;
        });
    }
}