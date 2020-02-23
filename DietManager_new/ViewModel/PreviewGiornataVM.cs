using DietManager_new.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows;

namespace DietManager_new.ViewModel
{
    public abstract class PreviewGiornataVM: INotifyPropertyChanged
    {
        private Database db;
        protected Database Db{
            get { return this.db; }
    }

        private DateTime dataCorrente;
        public DateTime DataCorrente {
            get {
                return dataCorrente;
            }

        }

        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        private double _calorieGiornata;
        public double CalorieGiornata
        {
            get
            {
                return Math.Round(this._calorieGiornata,1);
            }
            set
            {
                if (value != this._calorieGiornata)
                {
                    if (value >= 0)
                        this._calorieGiornata = value;
                    else this._calorieGiornata = 0;
                }
            }
        }


        private double _carboidratiGiornata;
        public double CarboidratiGiornata {
            get {
                return Math.Round(this._carboidratiGiornata, 1);
            }
            set {
                if (value != this._proteineGiornata)
                {
                    if (value >= 0)
                        this._carboidratiGiornata = value;
                    else this._carboidratiGiornata = 0;
                }
                
                
            }
        }



        private double _grassiGiornata;
        public double GrassiGiornata
        {
            get
            {
                return Math.Round(this._grassiGiornata, 1);
            }
            set
            {
                if (value != this._proteineGiornata)
                {
                    if (value >= 0)
                        this._grassiGiornata = value;
                    else this._grassiGiornata = 0;
                }
                
            }
        }


        private double _proteineGiornata;
        public double ProteineGiornata
        {
            get
            {
                return Math.Round(this._proteineGiornata,1);
            }
            set
            {
                if (value != this._proteineGiornata)
                {
                    if (value >= 0)
                        this._proteineGiornata = value;
                    else this._proteineGiornata = 0;
                }
            }
        }


        public string StatoProteine
        {

            get
            {
                if (ProteineGiornata < this.db.MinQntaProteine)
                {
                    return "Blue";
                }
                else if (ProteineGiornata > this.db.MaxQntaProteine)
                    return "Red";
                else return "Green";
                    
            }

        }

        public string StatoCalorie
        {

            get
            {
                if (CalorieGiornata < this.db.MinQntaCalorie)
                {
                    return "Blue";
                }
                else if (CalorieGiornata > this.db.MaxQntaCalorie)
                    return "Red";
                else return "Green";
            }

        }

        public string StatoCarboidrati
        {

            get
            {
                if (CarboidratiGiornata < this.db.MinQntaCarboidrati)
                {
                    return "Blue";
                }
                else if (CarboidratiGiornata > this.db.MaxQntaCarboidrati)
                    return "Red";
                else return "Green";
            }

        }        

        public string StatoGrassi
        {

            get
            {
                if (GrassiGiornata < this.db.MinQntaGrassi)
                {
                    return "Blue";
                }
                else if (GrassiGiornata > this.db.MaxQntaGrassi)
                    return "Red";
                else return "Green";
            }

        }

        private double maxQntaCalorie;
        public double MaxQntaCalorie { get { return Math.Round(this.maxQntaCalorie, 1); } }

        private double minQntaCalorie;
        public double MinQntaCalorie { get { return Math.Round(this.minQntaCalorie, 1); } }

        private double maxQntaCarboidrati;
        public double MaxQntaCarboidrati { get { return Math.Round(this.maxQntaCarboidrati, 1); } }

        private double minQntaCarboidrati;
        public double MinQntaCarboidrati { get { return Math.Round(this.minQntaCarboidrati, 1); } }


        private double maxQntaProteine;
        public double MaxQntaProteine { get { return Math.Round(this.maxQntaProteine, 1); } }

        private double minQntaProteine;
        public double MinQntaProteine { get { return Math.Round(this.minQntaProteine, 1); } }


        private double maxQntaGrassi;
        public double MaxQntaGrassi { get { return Math.Round(this.maxQntaGrassi, 1); } }

        private double minQntaGrassi;
        public double MinQntaGrassi { get { return Math.Round(this.minQntaGrassi, 1); } }


        //COSTRUTTORE
        public PreviewGiornataVM() {
            this.db = new Database();

            this.db.LoadCollectionsFromDatabase();

            this.dataCorrente = (DateTime)appSettings["DataCorrente"];

            this._calorieGiornata = this.db.CalorieDelGiorno(dataCorrente);
            maxQntaCalorie = this.db.MaxQntaCalorie;
            maxQntaCarboidrati = this.db.MaxQntaCarboidrati;
            maxQntaGrassi = this.db.MaxQntaGrassi;
            maxQntaProteine = this.db.MaxQntaProteine;

            minQntaCalorie = this.db.MinQntaCalorie;
            minQntaCarboidrati = this.db.MinQntaCarboidrati;
            minQntaGrassi = this.db.MinQntaGrassi;
            minQntaProteine = this.db.MinQntaProteine;


            this._grassiGiornata = this.db.GrassiDelGiorno(dataCorrente);

            this._proteineGiornata = this.db.ProteineDelGiorno(dataCorrente);

            this._carboidratiGiornata = this.db.CarboidratiDelGiorno(dataCorrente);
        
        }



        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify that a property changed
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion


    }
}
