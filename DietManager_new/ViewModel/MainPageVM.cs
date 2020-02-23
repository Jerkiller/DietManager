using DietManager_new.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DietManager_new.ViewModel
{
    public class MainPageVM : INotifyPropertyChanged
    {
        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        private ICommand _inizia;
        public ICommand Inizia {
            get {
                return _inizia;
            }
        }

        private ICommand _tutorial;
        public ICommand Tutorial
        {
            get
            {
                return _tutorial;
            }
        }

        private ICommand _info;
        public ICommand Info
        {
            get
            {
                return _info;
            }
        }

        private ICommand _selezionaUtente;
        public ICommand SelezionaUtente
        {
            get
            {
                return _selezionaUtente;
            }
        }

        private ICommand _gestione;
        public ICommand Gestione
        {
            get
            {
                return _gestione;
            }
        }

        private ObservableCollection<Utente> utenti;
        public ObservableCollection<Utente> Utenti
        {
            get
            {
                return utenti;
            }

            set {
                if (value != utenti) {
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

        public MainPageVM() {
            _inizia = new DelegateCommand(inizia);
            _tutorial = new DelegateCommand(tutorial);

            _info = new DelegateCommand(info);

            _selezionaUtente = new DelegateCommand(selezionaUtente);
            _gestione = new DelegateCommand(gestione);
            this.db = new SimpleDatabase();

            this.db.LoadCollectionsFromDatabase();
            Utenti = db.Utenti;
            }


        public void inizia(object o)
        {                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Profilazione0.xaml", UriKind.Relative));
        }

        public void tutorial(object o)
        {
            var rootFrame = (App.Current as App).RootFrame;
            rootFrame.Navigate(new Uri("/Tutorial.xaml", UriKind.Relative));
        }

        public void info(object o)
        {
            var rootFrame = (App.Current as App).RootFrame;
            rootFrame.Navigate(new Uri("/Info.xaml", UriKind.Relative));
        }

        public void gestione(object o)
        {
            if (Utenti.Count() > 0)
            {
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/GestioneUtenti.xaml", UriKind.Relative));
            }
            else MessageBox.Show("Non ci sono utenti!");
        }

        public void selezionaUtente(object o)
        {
            Utente u = (Utente)o;
            var rootFrame = (App.Current as App).RootFrame;
            App.idUtenteAttuale = u.IdUtente;
            App.utenteAttuale = u;
            rootFrame.Navigate(new Uri("/PaginaGiornata.xaml", UriKind.Relative));
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
