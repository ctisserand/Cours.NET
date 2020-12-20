using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

class Overload
{
    public int X { get; set; }
    public new string ToString()
    {
        return base.ToString();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    /// <summary>
    /// operator overload
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public static Overload operator +(Overload p1, Overload p2)
    {
        var p3 = new Overload() { X = p1.X + p2.X };
        return p3;
    }
    public static Overload operator ++(Overload p1)
    {
        p1.X++;
        return p1;
    }

    /// <summary>
    /// implicit convertion
    /// </summary>
    /// <param name="p1"></param>
    public static implicit operator bool(Overload p1)
    {
        return true;
    }
    public static implicit operator ClazzDerived(Overload p1)
    {
        return new ClazzDerived();
    }
    public static explicit operator int(Overload p1)
    {
        return 0;
    }

    private Dictionary<string, float[]> dict = new (){ ["123"] = new float[10] };
    /// <summary>
    /// [] overload
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public float this[string i, int j] {
        get { return dict[i][j]; }
        set { dict[i][j] = value; }
    }
    public static void Main()
    {
        bool b = new Overload();
        int i = (int)new Overload();
    }
}