using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;

namespace DietManager_new
{
    public partial class MainPage : PhoneApplicationPage
    {


        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            appSettings["Calorie"] = 2000;
            appSettings["Carboidrati"] = 2000;
            appSettings["Grassi"] = 2000;
            appSettings["Proteine"] = 2000;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PaginaCategorie.xaml", UriKind.Relative));


        }
    }
}