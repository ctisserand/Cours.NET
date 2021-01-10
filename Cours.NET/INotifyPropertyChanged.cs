using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

class PropertyChangedClass : INotifyPropertyChanged
{
    private int indice;

    public int Indice
    {
        get
        {
            return indice;
        }

        set
        {
            if (value != indice)
            {
                indice = value;
                NotifyPropertyChanged();
            }
        }
    }
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public static void Main()
    {
        var pcc = new PropertyChangedClass();
        pcc.PropertyChanged += Pcc_PropertyChanged;
        pcc.Indice = 10;
    }

    private static void Pcc_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        Console.Out.WriteLine($"New value for Property {e.PropertyName}");
        switch (sender)
        {
            case PropertyChangedClass c:
                Console.Out.WriteLine($"New value for Property Indice (Reflexion access): {c.GetType().GetProperty(e.PropertyName).GetValue(c)}");
                Console.Out.WriteLine($"New value for Property Indice (direct access): {c.Indice}");
                break;
            default:
                throw new NotSupportedException();
        }
    }
}
