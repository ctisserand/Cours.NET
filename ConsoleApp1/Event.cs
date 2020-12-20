using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EventClass
{
    public event Action<int> Progress;
    public event Action<int> ProgressAccessor
    {
        add { Progress += value; }
        remove { Progress -= value; }
    }
    public void call()
    {
        Progress?.Invoke(0);
        System.Threading.Thread.Sleep(1);
    }

    public static void Main()
    {
        EventClass eventClass = new();
        eventClass.Progress += params1 => Console.WriteLine($"{params1}");
        eventClass.ProgressAccessor += params1 => Console.WriteLine($"{params1}");
        eventClass.call();
    }
}
