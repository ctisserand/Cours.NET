using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class AnyClassToInspect
{
    public static int StaticMethod(int params1) => params1;
    public float Method(float params2) => params2;
    public static String StaticProperty { get; set; }
    public long Property { get; set; }

    private double PrivateMethod(double params3)
    {
        Console.Out.WriteLine("Call private method"); 
        return params3;
    }
}

class Reflexion
{
    public static void Main()
    {
        Type className = typeof(AnyClassToInspect);
        var publicMethod = typeof(AnyClassToInspect).GetMethods();
        var publicProperties = typeof(AnyClassToInspect).GetProperties();

        AnyClassToInspect cl = new AnyClassToInspect();

        var privateMethod = cl.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        privateMethod.Single(x => x.Name == "PrivateMethod").Invoke(cl, new object[] { 0.5d });


        var pm = cl.GetType().GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
        pm.Invoke(cl, new object[] { 0.5d });

        Console.Out.WriteLine(className);
    }
}
