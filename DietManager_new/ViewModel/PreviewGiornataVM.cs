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
                return this._calorieGiornata;
            }
            set
            {
                if (value != this._calorieGiornata)
                {
                    this._calorieGiornata = value;
                }
            }
        }
        public double CaloriePreviewPercentuale
        {
            get { return (_calorieGiornata * 100) / this.db.ValCalorie; }
        }

        private double _carboidratiGiornata;
        public double CarboidratiGiornata {
            get {
                return this._carboidratiGiornata;
            }
            set {
                if (value != this._carboidratiGiornata) {
                    this._carboidratiGiornata = value;
                }
            }
        }
        public double CarboidratiPreviewPercentuale
        {
            get { return (_carboidratiGiornata * 100) / this.db.ValCarboidrati; }
        }

        private double _grassiGiornata;
        public double GrassiGiornata
        {
            get
            {
                return this._grassiGiornata;
            }
            set
            {
                if (value != this._grassiGiornata)
                {
                    this._grassiGiornata = value;
                }
            }
        }
        public double GrassiPreviewPercentuale
        {
            get { return (_grassiGiornata * 100) / this.db.ValGrassi; }
        }

        private double _proteineGiornata;
        public double ProteineGiornata
        {
            get
            {
                return this._proteineGiornata;
            }
            set
            {
                if (value != this._proteineGiornata)
                {
                    this._proteineGiornata = value;
                }
            }
        }
        public double ProteinePreviewPercentuale
        {
            get { return (_proteineGiornata * 100) / this.db.ValProteine; }
        }


       

        public string StatoProteine
        {

            get
            {
                if (ProteineGiornata >= this.db.ValProteine)
                {
                    if (ProteineGiornata >= this.db.MaxQntaProteine)
                        return "Red";
                    else return "Yellow";
                }
                else
                    return "Green";
            }

        }

        public string StatoCalorie
        {

            get
            {
                if (CalorieGiornata >= this.db.ValCalorie)
                {
                    if (CalorieGiornata >= this.db.MaxQntaCalorie)
                        return "Red";
                    else return "Yellow";

                }
                else
                    return "Green";
            }

        }


        public string StatoCarboidrati
        {

            get
            {
                if (CarboidratiGiornata >= this.db.ValCarboidrati)
                {
                    if (CarboidratiGiornata >= this.db.MaxQntaCarboidrati)
                        return "Red";
                    else return "Yellow";
                }
                else
                    return "Green";
            }

        }

        

        public string StatoGrassi
        {

            get
            {
                if (GrassiGiornata >= this.db.ValGrassi)
                {
                    if (GrassiGiornata >= this.db.MaxQntaGrassi)
                        return "Red";
                    else return "Yellow";
                }
                else
                    return "Green";
            }

        }



        public PreviewGiornataVM() {
            this.db = new Database(App.PathDB);

            this.db.LoadCollectionsFromDatabase();

            this.dataCorrente = (DateTime)appSettings["DataCorrente"];

            this._calorieGiornata = this.db.CalorieDelGiorno(dataCorrente);


            this._grassiGiornata = this.db.GrassiDelGiorno(dataCorrente);

            this._proteineGiornata = this.db.ProteineDelGiorno(dataCorrente);

            this._carboidratiGiornata = this.db.CarboidratiDelGiorno(dataCorrente);
        
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
