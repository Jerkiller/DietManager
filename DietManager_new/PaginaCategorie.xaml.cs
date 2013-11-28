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
using DietManager_new.Model;

namespace DietManager_new
{
    public partial class PaginaCategorie : PhoneApplicationPage
    {
        public PaginaCategorie()
        {
            InitializeComponent();
            this.DataContext = App.categoriaVM;
        }




        private void lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

          MessageBox.Show(((Prodotto)(((ListBox)sender).SelectedItem)).ProdottoId.ToString());

            string tagProd = ((Prodotto)(((ListBox)sender).SelectedItem)).ProdottoId.ToString();

            NavigationService.Navigate(new Uri("/PaginaProdotto.xaml?id=" + tagProd, UriKind.Relative));


        }

        private void vaiARicerca(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/PaginaRicerca.xaml", UriKind.Relative));
        }





    }
}