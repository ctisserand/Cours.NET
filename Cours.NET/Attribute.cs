using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

[Serializable]
class AttributeClass
{
    [Obsolete]
    public void TestMethod() { }

    [DefaultValue("")]
    public String TestProperty { get; set; }

    [NonSerialized()]
    public String notSerializableField = "";

    public static int Main()
    {
        var attr = new AttributeClass();
        attr.TestMethod();

        return 1;
    }
}




[AttributeUsage(AttributeTargets.Class)]
public class MySpecialAttribute : Attribute
{
}
