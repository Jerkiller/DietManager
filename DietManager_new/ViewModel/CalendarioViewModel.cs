using DietManager_new.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows;

namespace DietManager_new.ViewModel
{
    public class CalendarioViewModel: INotifyPropertyChanged
    {
        private Database db;
        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        private string dataCorrente;
        public string DataCorrente
        {
            get
            {
                return dataCorrente;
            }
            set { 
                if (value != this.dataCorrente) {
                    dataCorrente = value;
                    NotifyPropertyChanged("DataCorrente");
                    }
            }

        }

        private int _anno;
        public int Anno
        {
            get
            {
                return this._anno;
            }
            set
            {
                if (value != this._anno)
                {
                    _anno = value;
                    NotifyPropertyChanged("Anno");
                }
            }
        }

        private ObservableCollection<Giornata> _giorniAttuali;
        public ObservableCollection<Giornata> GiorniAttuali {
            get {
                return this._giorniAttuali;
            }

            set {
                if (value != this._giorniAttuali) {
                    this._giorniAttuali = value;
                    NotifyPropertyChanged("GiorniAttuali");
                }
            }
        
        }

        private int _mese;
        public int Mese {
            get {
                return _mese;
            }
            set {
                if (value != _mese) {
                    _mese = value;
                    NotifyPropertyChanged("Mese");
                }
            }
        }

        public CalendarioViewModel() {
            this.db = new Database(App.PathDB);
            this.db.LoadCollectionsFromDatabase();
            DateTime d = (DateTime)appSettings["DataCorrente"];

            this._anno = d.Year;
            this._mese = d.Month;
            _giorniAttuali = this.db.GiornateDelMese(this._mese, this._anno);
            calcolaStringaData();
        }

        public void calcolaStringaData() {

            string a = "";

            string[] mesi = { "Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre" };


            a += " " + mesi[this._mese - 1];
            a += " " + this._anno;

            DataCorrente = a;

            
        }

        public void ProssimoMese() { 
            DateTime d=DateTime.Today;
            if (this._anno != d.Year || this._mese != d.Month) {
                if (this._mese == 12)
                {
                    this._mese = 1;
                    this._anno += 1;
                }
                else {
                    this._mese += 1;
                }
                calcolaStringaData();
                GiorniAttuali = this.db.GiornateDelMese(this._mese, this._anno);

            }
        
        }

        public void MesePrecedente()
        {

                if (this._mese == 1)
                {
                    this._mese = 12;
                    this._anno -= 1;
                }
                else
                {
                    this._mese -= 1;
                }

                calcolaStringaData();
                GiorniAttuali = this.db.GiornateDelMese(this._mese, this._anno);
                

        }

        public void SettaGiorno(int giorno) {
            DateTime d = new DateTime(this._anno, this._mese, giorno);
                appSettings.Remove("DataCorrente");
                appSettings.Add("DataCorrente", d);
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
