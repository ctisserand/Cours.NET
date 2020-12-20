using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DynamicClass : DynamicObject
{
    public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
    {
        result = "You call dynamicClass()";
        return true;
    }
    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    {
        if(binder.Name == "test")
        {
            result = "You call new dynamicClass.test()";
            return true;
        }
        return base.TryInvokeMember(binder, args, out result);
    }
    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        if (binder.Name == "test")
        {
            result = "You call dynamicClass.test";
            return true;
        }
        return base.TryGetMember(binder, out result);
    }

    public static void Call()
    {
        dynamic dynamicClass = new DynamicClass();
        Console.WriteLine(dynamicClass());
        Console.WriteLine(dynamicClass.test());
        Console.WriteLine(dynamicClass.test);
    }
}
