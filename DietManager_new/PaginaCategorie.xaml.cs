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
using System.Windows.Navigation;

namespace DietManager_new
{
    public partial class PaginaCategorie : PhoneApplicationPage
    {
        public PaginaCategorie()
        {
            InitializeComponent();
            this.DataContext = new CategoriaViewModel();
        }

        /// METODO: risolve il problema lasagne NP completo =) hahaha
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            listaCereali.SelectedIndex = -1;
            listaBevande.SelectedIndex = -1;
            listaFrutta.SelectedIndex = -1;
            listaVerdura.SelectedIndex = -1;
            listaCarne.SelectedIndex = -1;
            listaDolci.SelectedIndex = -1;
            listaVarie.SelectedIndex = -1;
            listaFastFood.SelectedIndex = -1;
            listaLatticini.SelectedIndex = -1;
            listaPesce.SelectedIndex = -1;
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            NavigationService.Navigate(new Uri("/PaginaGiornata.xaml", UriKind.Relative));
        }

    }
}