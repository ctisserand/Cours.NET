using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExceptionClass : Exception
{
    public static void Raise()
    {
        throw new ExceptionClass();
    }
    public static void RaiseNotImplemented()
    {
        throw new NotImplementedException();
    }
    public static void Main()
    {
        try
        {
            ExceptionClass.Raise();
        }
        catch(ExceptionClass e)
        {
            Console.Out.WriteLine("Excpected Exception");
            Console.Out.WriteLine(e);
        }
        var firstCatch = true;
        try
        {
            ExceptionClass.RaiseNotImplemented();
        }
        catch (NotImplementedException e) when(firstCatch)
        {
            Console.Out.WriteLine("Excpected Exception");
            Console.Out.WriteLine(e);
        }
        catch (NotImplementedException e)
        {
            // Rethorw the exception as it
            throw;
        }
        finally
        {

        }
    }
}
