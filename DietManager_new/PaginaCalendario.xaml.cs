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
    public partial class PaginaCalendario : PhoneApplicationPage
    {
        public PaginaCalendario()
        {
            InitializeComponent();
            this.DataContext = new CalendarioViewModel();
        }

        private void MeseSuccessivo(object sender, RoutedEventArgs e)
        {
            ((CalendarioViewModel)this.DataContext).ProssimoMese();
        }

        private void MesePrecedente(object sender, RoutedEventArgs e)
        {
            ((CalendarioViewModel)this.DataContext).MesePrecedente();
        }

        private void SettaGiorno(object sender, RoutedEventArgs e)
        {
            string a = ((Button)sender).Content.ToString();
            int giorno = Convert.ToInt32(a);
            ((CalendarioViewModel)this.DataContext).SettaGiorno(giorno);
            NavigationService.Navigate(new Uri("/PaginaGiornata.xaml?Refresh=true", UriKind.Relative));
        }
    }
}