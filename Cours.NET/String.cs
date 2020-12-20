using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StringClass
{
    public void Main()
    {
        var name = "123";
Console.WriteLine($"Hello World {name}!");
Console.WriteLine($@"Hello ""World!"" {name} !");
Console.WriteLine($@"Hello 
This is a multiline text
data: {name} 
you cannot use \n
!");
    }
}
