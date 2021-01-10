using System;
using System.Reflection.Metadata.Ecma335;

public delegate bool MyDelegate(int x, int y);
class DelegateClass
{

    public void Function(MyDelegate func) { func(1, 2); }

    public bool DelegateFunction(int x, int y) { return x == y; }

    public static void Main()
    {
        DelegateClass delegateClass = new DelegateClass();

        // Creating a delegate before using
        MyDelegate myDelegate = delegateClass.DelegateFunction;
        delegateClass.Function(myDelegate);

        // Shorter version
        delegateClass.Function(delegateClass.DelegateFunction);
    }
}

class DelegateFuncClass
{
    public void Function(Func<int, int, bool> func) { func(1, 2); }

    public bool DelegateFunction(int x, int y) { return x == y; }

    public static void Main()
    {
        DelegateFuncClass delegateClass = new DelegateFuncClass();

        // Creating a delegate before using
        Func<int, int, bool> myDelegate = delegateClass.DelegateFunction;
        delegateClass.Function(myDelegate);

        // Shorter version
        delegateClass.Function(delegateClass.DelegateFunction);
    }
}
