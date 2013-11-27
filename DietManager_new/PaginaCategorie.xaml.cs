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

        private void VaiAProdotto(string tagProd)
        {

            //string tagProd = ((Button)sender).Tag.ToString();
          
        }

        private void lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

          //string tagProd=((Prodotto)listaPanini.SelectedItem).ProdottoId.ToString();
            string tagProd = ((Prodotto)(((ListBox)sender).SelectedItem)).ProdottoId.ToString();

            NavigationService.Navigate(new Uri("/PaginaProdotto.xaml?id=" + tagProd, UriKind.Relative));

          /*  if (((ListBoxItem)sender).Tag == null)
                MessageBox.Show("ciao null");
            else
                MessageBox.Show("dio");*/

           // string str= ((ListBoxItem)sender).Tag.ToString();
            
            //VaiAProdotto(lbi.Tag.ToString());



        }




    }
}