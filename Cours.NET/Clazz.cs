using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ExampleClass
{
}

#region Partial
public partial class PartialClass
{
    public void MethodA() { }
}


public partial class PartialClass
{
    public void MethodB() { }
    void Main()
    {
        var partialClass = new PartialClass();
        partialClass.MethodA();
        partialClass.MethodB();
    }
}
#endregion

class BaseClass
{
    static BaseClass() { }

    public BaseClass() { }

    public BaseClass(String params1) { }

    ~BaseClass() { }
}

abstract class AbstractClazz : BaseClass {
    public int k { get; set; }
    public AbstractClazz(String params1) : base(params1) { }
    public abstract int MyMethod(int x, int y);
    public virtual void MyVirtualMethod() { Console.WriteLine("From AbstractClazz.MyVirtualMethod"); }
    public void MyNotVirtualMethod() { Console.WriteLine("From AbstractClazz.MyNotVirtualMethod"); }
}


interface IMyInterface
{
    public sealed void DoSomething() { }
    public int MyProperty { get; }
    string this[int index] {get;set; }
    string this[int index, int index2] { get; set; }
}

class ClazzDerived : AbstractClazz, IMyInterface
{
    public static void MyStaticMethod() { }
    public int MyProperty { get { return 0; } }
    public override void MyVirtualMethod() { Console.WriteLine("From ClazzDerived.MyVirtualMethod"); }
    public new void MyNotVirtualMethod() { Console.WriteLine("From ClazzDerived.MyNotVirtualMethod"); }

    public string this[int index, int index2] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public ClazzDerived() : base("default") { k = 1; }
    public ClazzDerived(string param1) : base(param1)
    {
    }

    public void DoSomething()
    {
        return;
    }

    public override int MyMethod(int x, int y) {
        return 0;
    }

    public static void Main()
    {
        ClazzDerived clazzDerived = new();
        clazzDerived.MyVirtualMethod(); // -> From ClazzDerived.MyVirtualMethod
        clazzDerived.MyNotVirtualMethod(); // -> From ClazzDerived.MyNotVirtualMethod

        AbstractClazz abstractClazz = (AbstractClazz)clazzDerived;
        abstractClazz.MyVirtualMethod(); // -> From ClazzDerived.MyVirtualMethod
        abstractClazz.MyNotVirtualMethod(); // -> From AbstractClazz.MyNotVirtualMethod

var list = new List<int>() { 1, 2, 3 };
new Dictionary<String, int>() { ["123"] = 0 };
List<ClazzDerived> myList = new();
myList.Add(new());

        var a = new { astring = "content" };
    }
}

sealed class ClazzSealed
{

}
// Pas autorisé a cause du sealed de ClazzSealed
// class ClazzSealed2 : ClazzSealed { }