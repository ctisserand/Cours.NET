using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PropertyClass
{
    private int _myProperty;

    /// <summary>
    /// Propriété automatique, créer la variable sous jacente automatiquement. Equivalent a la définition de <para>MyProperty</para>
    /// </summary>
    public int AutoProperty { get; set; }

    /// <summary>
    /// Propriété automatique, créer la variable sous jacente automatiquement. Equivalent a la définition de <para>ReadOnlyProperty_Private</para>
    /// </summary>
    public int ReadOnlyAutoProperty { get; private set; }

    /// <summary>
    /// Propriété classique, tous le monde peut lire ou écrire cette propriété
    /// </summary>
    public int MyProperty
    {
        get => _myProperty;
        set => _myProperty = value;
    }
    /// <summary>
    /// Propriété classique, tous le monde peut lire ou écrire cette propriété
    /// </summary>
    public int MyProperty2
    {
        get { return _myProperty; }
        set { _myProperty = value; }
    }

    /// <summary>
    /// Personne ne peut modifier cette propriété
    /// </summary>
public int ReadOnlyProperty
{
    get => _myProperty;
}

    /// <summary>
    /// Cette propriété ne peut être modifié que par la class elle même
    /// </summary>
    public int ReadOnlyProperty_Private
    {
        get => _myProperty;
        private set => _myProperty = value;
    }

    /// <summary>
    /// Cette propriété ne peut être modifié que lors de l'instantiation
    /// </summary>
    public int ReadOnlyProperty_Init
    {
        get => _myProperty;
        init => _myProperty = value;
    }

    public PropertyClass()
    {

    }

    public PropertyClass(string param1)
    {

    }

    public static void Main()
    {
        var mc = new PropertyClass() { MyProperty = 5 };
        var mc2 = new PropertyClass("stringParam") { MyProperty = 5 };

        mc.AutoProperty = 3;
        var result = mc.AutoProperty;

        mc.MyProperty = 3;
        result = mc.MyProperty;

        mc.MyProperty2 = 3;
        result = mc.MyProperty2;

        mc.ReadOnlyProperty_Private = 3;
        result = mc.ReadOnlyProperty_Private;

        // Pas autorisé
        // mc.ReadOnlyProperty_Init = 3;
        result = mc.ReadOnlyProperty_Init;
    }
}


class ExternalProperty
{
    public static void Main()
    {
        var mc = new PropertyClass() { MyProperty = 5 };
        mc = new PropertyClass() { ReadOnlyProperty_Init = 5 };

        // Pas autorisé
        // mc.ReadOnlyProperty_Private = 3;

    }
}