using DietManager_new.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DietManager_new.ViewModel
{
   public class UtentiVM: INotifyPropertyChanged
    {

        private ObservableCollection<Utente> utenti;
        public ObservableCollection<Utente> Utenti
        {
            get
            {
                return utenti;
            }

            set
            {
                if (value != utenti)
                {
                    utenti = value;
                    NotifyPropertyChanged("Utenti");
                }
            }
        }

        private SimpleDatabase db;
        protected SimpleDatabase Db
        {
            get { return this.db; }
        }

        private ICommand _cancellaUtente;
        public ICommand CancellaUtente
        {
            get { return this._cancellaUtente; }
        }

       public UtentiVM() {
            _cancellaUtente = new DelegateCommand(cancellaUtente);
            this.db = new SimpleDatabase();

            this.db.LoadCollectionsFromDatabase();
            Utenti = db.Utenti;
            }

       public void cancellaUtente(object o)
       {
           Utente u = (Utente)o;
           MessageBoxResult m = MessageBox.Show("Cancellare il profilo di "+u.Nome+"?", "Cancella", MessageBoxButton.OKCancel);
           if (m == MessageBoxResult.OK)
           {
               this.Db.rimuoviUtente(u);
               Utenti.Remove(u);
           }
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
