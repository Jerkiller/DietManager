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
using DietManager_new.ViewModel;

namespace DietManager_new
{
    public partial class PaginaGiornata : PhoneApplicationPage
    {
        public PaginaGiornata()
        {
            InitializeComponent();
            this.DataContext = new GiornataViewModel();
        }

        //METODO  manda alla scelta del prodotto
        private void scegliProdotto(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PaginaCategorie.xaml", UriKind.Relative));
        }

        //METODO rimuove il pasto consumato
        private void rimuoviPasto(object sender, RoutedEventArgs e)
        {
            string cod=((Button)sender).Tag.ToString();
            int id = Convert.ToInt32(cod);
            ((GiornataViewModel)this.DataContext).RimuoviPasto(id);
        }
    }
}