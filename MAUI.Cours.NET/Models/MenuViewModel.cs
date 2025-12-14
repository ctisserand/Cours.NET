using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI.Cours.NET.Pages;
using MAUI.Cours.NET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Cours.NET.Models
{
    public partial class MenuViewModel : ObservableObject
    {
        [RelayCommand]
        public void GoToProfile() => NavigationService.Instance.Navigate<Profile>([]);

        [ObservableProperty]
        private bool isConnected = NetworkService.Instance.Token != null;

        public MenuViewModel()
        {
            NetworkService.Instance.OnConnected += Instance_OnConnected;
        }

        private void Instance_OnConnected()
        {
            IsConnected = true;
        }
    }
}
