using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

#pragma warning disable CS0067

namespace MAUI.Cours.NET.Models
{
    public class ExampleModel : INotifyPropertyChanged
    {
        public ExampleModel()
        {
            IncreaseValueCommand = new RelayCommand(() => IncreaseValue(), () => true);
            ToogleIncreaseValueCommand = new RelayCommand(() => {
                ButtonEnabled = !ButtonEnabled;
                }
            , () => true);
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