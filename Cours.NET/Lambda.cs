using System;

class LambdaDelegateClass
{
    public delegate bool MyDelegate(int x, int y);

    public void Function(MyDelegate func)
    {
        func(1, 2);
    }

    public static void Main()
    {
        LambdaDelegateClass lambdaDelegate = new LambdaDelegateClass();

        // Deprected call
        bool MyLocalFunc(int x, int y)
        {
            return x == y;
        }
        lambdaDelegate.Function(MyLocalFunc);

        // Creation of the delegate and call
        MyDelegate myDelegate = (x, y) => x == y;
        lambdaDelegate.Function(myDelegate);

        // Shorter version
        lambdaDelegate.Function((x, y) => x == y);
    }
}
class LambdaFuncClass
{
    public void Function(Func<int, bool> func) { func(1); }

    public static void Main()
    {
        LambdaFuncClass lambdaDelegate = new LambdaFuncClass();

        // Deprected call
        bool MyLocalFunc(int x)
        {
            return x % 2 == 0;
        }
        lambdaDelegate.Function(MyLocalFunc);

        // Creation of the delegate and call
        Func<int, bool> myDelegate = x => x % 2 == 0;
        lambdaDelegate.Function(myDelegate);

        // Shorter version
        lambdaDelegate.Function(x => x % 2 == 0);
    }
}
