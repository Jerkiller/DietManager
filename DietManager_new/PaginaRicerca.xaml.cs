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
using DietManager_new.ViewModel;

namespace DietManager_new
{
    public partial class PaginaRicerca : PhoneApplicationPage
    {
        public PaginaRicerca()
        {
            InitializeComponent();

            this.DataContext = new CategoriaViewModel();
        }



         //METODO Premendo il Back button voglio tornare alla main page e non nella pagina prima
         protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
         {
            NavigationService.Navigate(new Uri("/PaginaCategorie.xaml?Refresh=true", UriKind.Relative));

         }



         private void lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {


             string tagProd = ((Prodotto)(((ListBox)sender).SelectedItem)).ProdottoId.ToString();

             NavigationService.Navigate(new Uri("/PaginaProdotto.xaml?id=" + tagProd, UriKind.Relative));


         }

         protected override void OnNavigatedTo(NavigationEventArgs e)
         {
             if (e.NavigationMode == NavigationMode.Back) {
                 this.DataContext = new CategoriaViewModel();
             }
         }

         private void TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
         {
             CategoriaViewModel c = (CategoriaViewModel)(this.DataContext);
             c.Ricerca.Execute(sender) ;
         }

         private void TextBox_GotFocus(object sender, RoutedEventArgs e)
         {
             ((TextBox)sender).Text = "";
             listaCerca.IsEnabled = false;
         }

         private void TextBox_LostFocus(object sender, RoutedEventArgs e)
         {
             listaCerca.IsEnabled = true;
         }


    }
}