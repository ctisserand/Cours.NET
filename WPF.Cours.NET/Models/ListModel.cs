using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable CS0067

namespace WPF.Cours.NET.Models
{
    public class Article : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public String Name { get; set; }
        public int Ammount { get; set; }
    }
    public class ListModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Article> Articles { get; set; } = new() { new Article() { Name = "Test1", Ammount = 1 }, new Article() { Name = "Test2", Ammount = 2 }, new Article() { Name = "Test3", Ammount = 3 } };
    }
}

#pragma warning restore CS0067