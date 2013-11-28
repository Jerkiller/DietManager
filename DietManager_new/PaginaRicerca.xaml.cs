using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DietManager_new.Model;

namespace DietManager_new
{
    public partial class PaginaRicerca : PhoneApplicationPage
    {
        public PaginaRicerca()
        {
            InitializeComponent();

            this.DataContext = App.categoriaVM;
        }



         //METODO Premendo il Back button voglio tornare alla main page e non nella pagina prima
         protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
         {
          MessageBox.Show(NavigationService.Source.ToString() + "&Refresh=true");

            NavigationService.Navigate(new Uri("/PaginaCategorie.xaml?Refresh=true", UriKind.Relative));

         }



         private void lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {

             MessageBox.Show(((Prodotto)(((ListBox)sender).SelectedItem)).ProdottoId.ToString());

             string tagProd = ((Prodotto)(((ListBox)sender).SelectedItem)).ProdottoId.ToString();

             NavigationService.Navigate(new Uri("/PaginaProdotto.xaml?id=" + tagProd, UriKind.Relative));


         }


    }
}