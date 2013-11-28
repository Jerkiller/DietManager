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
using System.Windows.Navigation;
using DietManager_new.ViewModel;




namespace DietManager_new
{
    public partial class PaginaProdotto : PhoneApplicationPage
    {

        //COSTRUTTORE
        public PaginaProdotto()
        {
            InitializeComponent();
            
        }

        



        /// METODO: durante il passaggio alla pagina con id x caricami i dati del livello con id x e setta il DataContext
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string idProd = string.Empty;

            /// IF: riesco a prendere il livello sul quale sto navigando
            if (NavigationContext.QueryString.TryGetValue("id", out idProd))
            {
                /// converti la stringa dell id del livello in intero
                int prod = Convert.ToInt32(idProd);

                /// crea un nuovo DataContext con il LivelloVM(id) per il binding
                this.DataContext = new ProdottoViewModel(prod);
            }


        }

        //METODO setta i campi ai valori dell alimento in porzione piccola
        private void Small_Click(object sender, RoutedEventArgs e)
        {
            ((ProdottoViewModel)this.DataContext).Piccola();
        }

        //METODO setta i campi ai valori dell alimento in porzione media
        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            ((ProdottoViewModel)this.DataContext).Media();
        }

        //METODO setta i campi ai valori dell alimento in porzione grande
        private void Big_Click(object sender, RoutedEventArgs e)
        {
            ((ProdottoViewModel)this.DataContext).Grande();
        }

        //METODO setta la cella a 0 se si cancella il valore
        private void controllaVuota(object sender, TextChangedEventArgs e)
        {
            if(((TextBox)sender).Text =="")
                ((TextBox)sender).Text="0";
        }

       

        private void aggiungiPasto(object sender, EventArgs e)
        {

             ((ProdottoViewModel)this.DataContext).AggiungiPasto();
            MessageBox.Show("Pasto inserito correttamente");
            NavigationService.Navigate(new Uri("/PaginaGiornata.xaml?Refresh=true", UriKind.Relative));
        
        }

        //METODO Premendo il Back button voglio tornare alla main page e non nella pagina prima
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show(NavigationService.Source.ToString() + "&Refresh=true");

            NavigationService.Navigate(new Uri("/PaginaRicerca.xaml?Refresh=true", UriKind.Relative));
            e.Cancel = true;

        }


        }


    }
