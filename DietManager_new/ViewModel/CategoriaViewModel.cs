using DietManager_new.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DietManager_new.ViewModel
{
    public class CategoriaViewModel : INotifyPropertyChanged
    {

       private Database db;

       private ICommand cerca;
       public ICommand Cerca { get { return this.cerca; } }

       private ICommand ricerca;
       public ICommand Ricerca { get { return this.ricerca; } }
       
       private ObservableCollection<Prodotto> _categoriaBevande;
       public ObservableCollection<Prodotto> CategoriaBevande {
           get { return this._categoriaBevande; }
           set {
               if(this._categoriaBevande!=value){
                   this._categoriaBevande=value;
                   NotifyPropertyChanged("CategoriaBevande");
               }
           }
       }

       private ObservableCollection<Prodotto> _categoriaDolci;
       public ObservableCollection<Prodotto> CategoriaDolci
       {
           get { return this._categoriaDolci; }
           set
           {
               if (this._categoriaDolci != value)
               {
                   this._categoriaDolci = value;
                   NotifyPropertyChanged("CategoriaDolci");
               }
           }
       }

       private ObservableCollection<Prodotto> _categoriaFrutta;
       public ObservableCollection<Prodotto> CategoriaFrutta
       {
           get { return this._categoriaFrutta; }
           set
           {
               if (this._categoriaFrutta != value)
               {
                   this._categoriaFrutta = value;
                   NotifyPropertyChanged("CategoriaFrutta");
               }
           }
       }

       private ObservableCollection<Prodotto> _categoriaCereali;
       public ObservableCollection<Prodotto> CategoriaCereali
       {

           get { return this._categoriaCereali; }
           set {
               if(this._categoriaCereali!=value){
                   this._categoriaCereali=value;
                   NotifyPropertyChanged("CategoriaCereali");
               }
            }
       }

       private ObservableCollection<Prodotto> _categoriaCarne;
       public ObservableCollection<Prodotto> CategoriaCarne
       {
           get { return this._categoriaCarne; }
           set
           {
               if (this._categoriaCarne != value)
               {
                   this._categoriaCarne = value;
                   NotifyPropertyChanged("CategoriaCarne");
               }
           }
       }

       private ObservableCollection<Prodotto> _categoriaPesce;
       public ObservableCollection<Prodotto> CategoriaPesce
       {
           get { return this._categoriaPesce; }
           set
           {
               if (this._categoriaPesce != value)
               {
                   this._categoriaPesce = value;
                   NotifyPropertyChanged("CategoriaPesce");
               }
           }
       }

       private ObservableCollection<Prodotto> _categoriaLatticini;
       public ObservableCollection<Prodotto> CategoriaLatticini
       {
           get { return this._categoriaLatticini; }
           set
           {
               if (this._categoriaLatticini != value)
               {
                   this._categoriaLatticini = value;
                   NotifyPropertyChanged("CategoriaLatticini");
               }
           }
       }

       private ObservableCollection<Prodotto> _categoriaFastFood;
       public ObservableCollection<Prodotto> CategoriaFastFood
       {
           get { return this._categoriaFastFood; }
           set
           {
               if (this._categoriaFastFood != value)
               {
                   this._categoriaFastFood = value;
                   NotifyPropertyChanged("CategoriaFastFood");
               }
           }
       }

       private ObservableCollection<Prodotto> _categoriaVerdura;
       public ObservableCollection<Prodotto> CategoriaVerdura
       {
           get { return this._categoriaVerdura; }
           set
           {
               if (this._categoriaVerdura != value)
               {
                   this._categoriaVerdura = value;
                   NotifyPropertyChanged("CategoriaVerdura");
               }
           }
       }

       private ObservableCollection<Prodotto> _categoriaVarie;
       public ObservableCollection<Prodotto> CategoriaVarie
       {
           get { return this._categoriaVarie; }
           set
           {
               if (this._categoriaVarie != value)
               {
                   this._categoriaVarie = value;
                   NotifyPropertyChanged("CategoriaVarie");
               }
           }
       }
       private ObservableCollection<Prodotto> _prodottiTrovati;
       public ObservableCollection<Prodotto> ProdottiTrovati {

           get { return this._prodottiTrovati; }
           set {
               if (this._prodottiTrovati != value) {
                   this._prodottiTrovati = value;
                   NotifyPropertyChanged("ProdottiTrovati");
               
               }
           }
       }

       private Prodotto _prodottoSelezionato;
       public Prodotto ProdottoSelezionato{
           get { return _prodottoSelezionato; }
           set {
               if (value != null)
               {
                   _prodottoSelezionato = value;
                   SelezionaProdotto();
               }
           }
       }

       private string _nomeProdottoCercato;
       public string NomeProdottoCercato {
           get { return this._nomeProdottoCercato; }
           set {

               if (!(this._nomeProdottoCercato).Equals(value)) {
                   if (!value.Equals(""))
                   {
                       this.ProdottiTrovati = this.db.cercaProdotto(value);
                       this._nomeProdottoCercato = value;

                   }
                   else {
                       _prodottiTrovati.Clear();
                       this._nomeProdottoCercato = "";

                       }
                   NotifyPropertyChanged("NomeProdottoCercato");
                   NotifyPropertyChanged("ProdottiTrovati");
               
               }
           
           }
       }

        //COSTRUTTORE
      public CategoriaViewModel() {

          this.db = new Database();

           this.db.LoadCollectionsFromDatabase();

           this._nomeProdottoCercato = "Cerca";

           this._prodottiTrovati = new ObservableCollection<Prodotto>();

           this._categoriaBevande = db.CategoriaBevande;
           this._categoriaVarie = db.CategoriaVarie;
           this._categoriaCereali = db.CategoriaCereali;
           this._categoriaFrutta = db.CategoriaFrutta;
           this._categoriaDolci = db.CategoriaDolci;
           this._categoriaVerdura = db.CategoriaVerdura;
           this._categoriaCarne = db.CategoriaCarne;
           this._categoriaPesce = db.CategoriaPesce;
           this._categoriaLatticini = db.CategoriaLatticini;
           this._categoriaFastFood = db.CategoriaFastFood;
           this.cerca = new DelegateCommand(_cerca);
           this.ricerca = new DelegateCommand(_ricerca);
   
       }

        //METODO: cerca il prodotto descritto
      public void _cerca(object o) {

          var rootFrame = (App.Current as App).RootFrame;
          rootFrame.Navigate(new Uri("/PaginaRicerca.xaml", UriKind.Relative));    
      
      }

      public void _ricerca(object o) {
          string s=((TextBox)o).Text;
            NomeProdottoCercato = s;
      }

      public void SelezionaProdotto() {
          string tagProd = _prodottoSelezionato.ProdottoId.ToString();
          var rootFrame = (App.Current as App).RootFrame;
          rootFrame.Navigate(new Uri("/PaginaProdotto.xaml?id=" + tagProd, UriKind.Relative));
      
      }
           
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
        
       }
    }

