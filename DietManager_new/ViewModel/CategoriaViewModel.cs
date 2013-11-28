using DietManager_new.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace DietManager_new.ViewModel
{
    public class CategoriaViewModel : INotifyPropertyChanged
    {

       private Database db;
       
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

       private ObservableCollection<Prodotto> _categoriaPanini;
       public ObservableCollection<Prodotto> CategoriaPanini
       {

           get { return this._categoriaPanini; }
           set {
                   
               if(this._categoriaPanini!=value){
               
                   this._categoriaPanini=value;
                   NotifyPropertyChanged("CategoriaPanini");
               
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

       private string _nomeProdottoCercato;
       public string NomeProdottoCercato {
           get { return this._nomeProdottoCercato; }
           set {

               if (this._nomeProdottoCercato != value) {

                   this._nomeProdottoCercato = value;

                   this.ProdottiTrovati = this.db.cercaProdotto(value);

                   NotifyPropertyChanged("NomeProdottoCercato");
                   NotifyPropertyChanged("ProdottiTrovati");
               
               }
           
           }
       }

      public CategoriaViewModel() {

          this.db = new Database(App.PathDB);

           this.db.LoadCollectionsFromDatabase();

           this._nomeProdottoCercato = "Cerca";

           this._prodottiTrovati = new ObservableCollection<Prodotto>();

           this._categoriaBevande = db.CategoriaBevande;

           this._categoriaPanini = db.CategoriaPanini;

       
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

