using System;
using static System.Math;
using CustomName = System.Math;
using AnotherName = System;


namespace CourDotNET
{
    class NamespaceClass
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            // grace a using System;
            Console.WriteLine("Hello World!");

            System.Math.Max(0, 1);
            Math.Max(0, 1);
            Max(1, 0);

            AnotherName.Math.Max(0, 1);

            CustomName.Max(0, 1);
        }
    }
}
