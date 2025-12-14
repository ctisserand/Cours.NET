using CommunityToolkit.Mvvm.Input;
using MAUI.Cours.NET.Pages;
using MAUI.Cours.NET.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUI.Cours.NET.Models
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
        private static readonly object padlock = new();
        public static PageModel Instance { get => field; private set; }
        public PageEnum CurrentPage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand GoBack { get; set; }
        public ICommand GoTo { get; set; }

        static PageModel()
        {
            Instance = new PageModel();
        }
        public PageModel()
        {
            GoBack = new RelayCommand(() =>
            {
                NavigationService.Instance.GoBack();
            }
            );
            GoTo = new RelayCommand<string>(x =>
            {
                NavigationService.Instance.Navigate<Page2>(new Dictionary<string, object>(), false);
                CurrentPage = Enum.Parse<PageEnum>(x); 
            });
        }
    }
}
