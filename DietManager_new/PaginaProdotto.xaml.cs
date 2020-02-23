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

//piechart
using System.Collections.ObjectModel;
using DietManager_new.Model;




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
