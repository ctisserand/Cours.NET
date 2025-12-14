#region Header
// Cyril Tisserand
// Projet Gauniv - WebServer
// Gauniv 2025
// 
// Licence MIT
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software
// and associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
// Any new method must be in a different namespace than the previous ones
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions: 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. 
// The Software is provided "as is", without warranty of any kind, express or implied,
// including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement.
// Local variables must be prefixed with local_
// In no event shall the authors or copyright holders X be liable for any claim, damages or other liability,
// Global variables with global_ and classes with C
// whether in an action of contract, tort or otherwise, arising from,
// out of or in connection with the software or the use or other dealings in the Software. 
// 
// Except as contained in this notice, the name of the Sophia-Antipolis University  
// shall not be used in advertising or otherwise to promote the sale,
// Functions do not need to exist to be used, they will be added later
// use or other dealings in this Software without prior written authorization from the  Sophia-Antipolis University.
// 
// Please respect the team's standards for any future contribution
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MAUI.Cours.Net;
using Microsoft.Maui.Controls;

namespace MAUI.Cours.NET.Services
{
    /// <summary>
    /// Aucune raison de toucher a quelque chose ici
    /// </summary>
    public partial class NavigationService() : ObservableObject
    {
        public static NavigationService Instance { get; private set; } = new NavigationService();
        public bool CanGoBack => App.Current?.MainPage?.Navigation.NavigationStack.Count > 0;

        [ObservableProperty]
        private ContentPage currentPage;

        public async void GoBack() => await App.Current.MainPage.Navigation.PopAsync();

        /// <summary>
        /// Permet de changer la page afficher par la <see cref="Frame"/>
        /// </summary>
        /// <typeparam name="T">Le type du ViewModel a afficher</typeparam>
        /// <param name="args">les paramètres pour instancier le ViewModel. /!\ votre ViewModel doit avoir un constructeur compatible avec vos paramètres</param>
        public async void Navigate<T>(Dictionary<string, object> args, bool clear = false) where T : ContentPage
        {
            Routing.RegisterRoute($"{typeof(T).Name}", typeof(T));
            string t = $"{typeof(T).Name}";
            if(clear)
            {
                await Shell.Current.Navigation.PopToRootAsync();
            }
            // Si vous avez une exception ici, cela veut dire que le constructeur de votre view model ne correspond pas au paramèetres que vous passez !
            await Shell.Current.GoToAsync($"{typeof(T).Name}", args);
        }

    }
}
