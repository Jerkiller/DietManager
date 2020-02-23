using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DietManager_new.ViewModel;

namespace DietManager_new
{
    public partial class GestioneUtenti : PhoneApplicationPage
    {
        public GestioneUtenti()
        {
            InitializeComponent();
            this.DataContext = new UtentiVM();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            NavigationService.Navigate(new Uri("/MainPage.xaml?Refresh=True", UriKind.Relative));
        }
    }
}