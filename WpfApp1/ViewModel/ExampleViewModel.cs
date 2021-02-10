using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WPF.Cours.NET;

namespace WpfApp1.ViewModel
{
    class ExampleViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String nom;
        public String Nom { 
            get
            {
                return nom;
            }
            set
            {
                nom = value;

                NotifyPropertyChanged();
            }
        }

        public void OnClick()
        {
            Service.Instance.SetName(nom);
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ObservableCollection<Book> books { get; set; } = new ObservableCollection<Book>();

        private int i = 0;
        private Task serviceTask;
        public ExampleViewModel()
        {
            //serviceTask = Service.Instance.Run();
            Service.Instance.BookChanged += Instance_BookChanged;

            ClickCommand = new RelayCommand((x) =>
            {
                NotifyPropertyChanged();
                //PropertyChanged?.Invoke(nameof(Nom));
                books.Add(new Book() { Titre =$"Test {i++}" });
                Nom = "123456";
                //MessageBox.Show("Click");
            }, (x) => { return true; });
        }

        public ICommand ClickCommand { get; set; }

        private void Instance_BookChanged(Book obj)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                books.Add(obj);
            });
        }

        public void Dispose()
        {
            Service.Instance.cts.Cancel();
            serviceTask.Wait();
        }
    }
    public class Book
    {
        public String Titre { get; set; }
    }
    class Service
    {
        private static Service instance;
        public static Service Instance
        {
            get
            {
                if (instance == null)
                    instance = new Service();
                return instance;
            }
        }

        public CancellationTokenSource cts { get; } = new CancellationTokenSource();
        public event Action<Book> BookChanged;
        public async Task Run()
        {

            await Task.Run(() =>
            {
                int i = 0;
                while (true)
                {
                    var book = new Book() { Titre = $"Test {i}" };
                    BookChanged?.Invoke(book);
                    i++;
                    Thread.Sleep(1000);
                }
            }, cts.Token);
        }

        public void SetName(String nom)
        {

        }
    }


}


