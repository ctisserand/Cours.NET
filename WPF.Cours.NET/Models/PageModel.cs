using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Cours.NET.Pages;

namespace WPF.Cours.NET.Models
{
    class PageModelInstance: INotifyPropertyChanged
    {
        private void PageModel_StaticPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Instance)));
        }

        public PageModel Instance { get => PageModel.Instance; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    enum PageEnum
    {
        WELCOME,
        OTHER
    }
    class PageModel : INotifyPropertyChanged
    {
        private static readonly object padlock = new object();
        private static PageModel instance;
        public static PageModel Instance { get => instance; }
        public PageEnum CurrentPage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand GoBack { get; set; }
        public ICommand GoTo { get; set; }

        static PageModel()
        {
            instance = new PageModel();
        }
        public PageModel()
        {
            GoBack = new RelayCommand(x => CurrentPage = PageEnum.WELCOME);
            GoTo = new RelayCommand(x => { CurrentPage = Enum.Parse<PageEnum>((String)x); });
        }
    }
}
