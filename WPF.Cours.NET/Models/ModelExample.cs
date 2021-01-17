using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

#pragma warning disable CS0067

namespace WPF.Cours.NET.Models
{
    public class ExampleModel : INotifyPropertyChanged
    {
        public ExampleModel()
        {
            IncreaseValueCommand = new RelayCommand(o => IncreaseValue(), o => true);
            ToogleIncreaseValueCommand = new RelayCommand(o => ButtonEnabled = !ButtonEnabled, o => true);
        }
        public String DataExample { get; set; } = "Test";
        public float TextExample { get; set; } = 123.3f;
        public bool ButtonEnabled { get; set; } = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand IncreaseValueCommand { get; set; }
        public ICommand ToogleIncreaseValueCommand { get; set; }
        public void IncreaseValue()
        {
            TextExample += 1;
        }
    }
}

#pragma warning restore CS0067