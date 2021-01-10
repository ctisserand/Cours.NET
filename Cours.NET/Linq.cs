using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Article
{
    public int Id { get; set; }
    public float Price { get; set; }
    public float Taxe { get; set; }
    public String Name { get; set; }
}


class LinqClass
{
    public static void Main()
    {
        var list = new List<Article>() {
            new Article { Id = 10, Price = 9.90F, Taxe = 19F, Name = "Item1"},
            new Article { Id = 245, Price = 29.90F, Taxe = 10F, Name = "Item2"},
            new Article { Id = 32, Price = 115.20F, Taxe = 25F, Name = "Item3"},
            new Article { Id = 124, Price = 0.00F, Taxe = 0F, Name = "Item4"},
            new Article { Id = 784, Price = 29.90F, Taxe = 2F, Name = "Item5"}
        };


        // Retourne un nouveau tableau ou la fonction passée en paramètre a été appliquée a chaque élément
        list.Select(article => article.Price * article.Taxe);

        list.Where(article => article.Price > 0) // On ne veut pas calculer le prix des object qui sont egal a 0
            .Prepend(new() { Id = 0, Price = 5F, Taxe = 25F, Name = "Assurance" }) // On ajoute l'assurance
            .OrderByDescending(article => article.Price) // on ordone la facture par ordre decroissant de prix
            .ThenBy(article => article.Id); // et si 2 objet on le même prix, alors par Id

        // Montant total de la facture
        var total = list.Sum(article => article.Price * article.Taxe / 100F);
        // Liste des noms des objets achetés trier par ordre de (prix x taxe) decroissant auquel on a ajouter l'assurance
        var nameList = list.Select(article => article.Name);

        list.First();
        list.Last();

        list.Max(article => article.Price * article.Taxe / 100F);
        list.Min(article => article.Price * article.Taxe / 100F);

        // Retourne uniquement le premier élément d'une Collection, si le retour contient plusieur élément, une exception est levée
        list.SingleOrDefault(x => x.Id == 10);

        list.Select(article => new { article.Id, article.Name }).Where(article => article.Id > 0);

        list.Select(article => new { Myid = article.Id * 100, YourName = article.Name }).Where(article => article.YourName == "Item1");
    }
}
