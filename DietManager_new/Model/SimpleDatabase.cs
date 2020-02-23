using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Linq;

namespace DietManager_new.Model
{
    public class SimpleDatabase : DataContext, INotifyPropertyChanged, INotifyPropertyChanging
    {
        public Table<Prodotto> Prodotti;
        public Table<Utente> TabellaUtenti;
        public Table<Categoria> Categorie;
        public Table<Pasto> Pasti;

        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;


        private ObservableCollection<Utente> utenti;
        public ObservableCollection<Utente> Utenti
        {

            get { return this.utenti; }

            set
            {
                if (utenti != value)
                {
                    NotifyPropertyChanging("Utenti");

                    utenti = value;

                    NotifyPropertyChanged("Utenti");
                }
            }
        }

        private int utente;
        public int Utente
        {
            get
            {
                return utente;
            }
            set
            {
                if (value != utente)
                {
                    utente = value;
                    NotifyPropertyChanged("Utente");
                }
            }
        }




        //COSTRUTTORE Pass the connection string to the base class.
        public SimpleDatabase()
            : base(App.PathDB)
        {
        }


        //METODO carica le collezioni dal database
        public void LoadCollectionsFromDatabase()
        {


            var utentiInDB = from Utente ut in this.TabellaUtenti
                               select ut;

           try
           {
               this.Utenti = new ObservableCollection<Utente>(utentiInDB);
           }
           catch (Exception e) {
               this.Utenti = new ObservableCollection<Utente>();
           }

            /*if (utentiInDB.Count()>0)
            {                
                this.Utenti = new ObservableCollection<Utente>(utentiInDB);
            }
            else this.Utenti = new ObservableCollection<Utente>();*/

        }

        



        //METODO aggiunge un pasto nuovo
        public void aggiungiUtente(Utente u)
        {
            if (!utenti.Contains(u))
            {
                this.utenti.Add(u);
                this.TabellaUtenti.InsertOnSubmit(u);
                this.SubmitChanges();
            }
        }

        //METODO elimina un pasto esistente
        public void rimuoviUtente(Utente u)
        {
            var utent = from Pasto pa in this.Pasti
                        where pa.UtenteFK==u
                             select pa;
            List<Pasto> pasti = utent.ToList();
            foreach (Pasto p in pasti)
            {
                this.Pasti.DeleteOnSubmit(p);
               
            }


            this.utenti.Remove(u);
            this.TabellaUtenti.DeleteOnSubmit(u);
            this.SubmitChanges();
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify Silverlight that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion


    }
}
