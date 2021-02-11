using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.Reader.Model;

namespace WPF.Reader.ViewModel
{
    class ListBookViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }

        // To replace with your own data !!!!!!!!!!!!!!
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>() { new Book() };

        public ListBookViewModel()
        {
            ItemSelectedCommand = new RelayCommand(obj =>
            {
                var item = obj as Book;
                Navigator.Instance.CurrentPage = PageEnum.DETAIL;
            });
        }
    }
}
