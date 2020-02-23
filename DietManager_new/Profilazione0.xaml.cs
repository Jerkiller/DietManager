using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace DietManager_new
{
    public partial class Profilazione0 : PhoneApplicationPage
    {
        public Profilazione0()
        {
            InitializeComponent();
            this.DataContext = App.dvm;
        }

        //METODO: riabilita la appbar dopo l inserimento della quantita del prodotto
        private void AbilitaAppBar(object sender, RoutedEventArgs e)
        {
            ApplicationBar.IsVisible = true;
        }

        //METODO: disabilita l appbar durante l inserimento della quantita del prodotto
        private void DisabilitaAppBar(object sender, RoutedEventArgs e)
        {

            ApplicationBar.IsVisible = false;
        }
    }
}