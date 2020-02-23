using Microsoft.Phone.Controls;
using DietManager_new.ViewModel;
using System;
using System.Windows;
using Microsoft.Phone.Shell;

namespace DietManager_new
{
    public partial class PaginaGiornata : PhoneApplicationPage
    {
        public PaginaGiornata()
        {
            InitializeComponent();
            this.DataContext = new GiornataViewModel();

            

        }


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }


    }
}