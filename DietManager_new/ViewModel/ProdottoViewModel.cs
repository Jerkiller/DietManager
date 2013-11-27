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
    public class ProdottoViewModel : INotifyPropertyChanged
    {

        private Database db;

        private DateTime dataCorrente;

        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        private Prodotto _prodotto;
        public Prodotto Prodotto {

            get { return this._prodotto; }
            set {

                if (this._prodotto != value) {
                    this._prodotto=value;
                    NotifyPropertyChanged("Prodotto");
                
                }
                
            
            }
        }

        private double _quantita;
        public double Quantita {

            get { return this._quantita; }
            set {
                if (this._quantita != value) {
                        this._quantita = value;
                        NotifyPropertyChanged("Quantita");
                        NotifyPropertyChanged("CaloriePreview");
                        NotifyPropertyChanged("CaloriePreviewPercentuale");
                        NotifyPropertyChanged("GrassiPreview");
                        NotifyPropertyChanged("GrassiPreviewPercentuale");
                        NotifyPropertyChanged("CarboidratiPreview");
                        NotifyPropertyChanged("CarboidratiPreviewPercentuale");
                        NotifyPropertyChanged("ProteinePreview");
                        NotifyPropertyChanged("ProteinePreviewPercentuale");
                        NotifyPropertyChanged("StatoCalorie");
                        NotifyPropertyChanged("StatoCarboidrati");
                        NotifyPropertyChanged("StatoGrassi");
                        NotifyPropertyChanged("StatoProteine");
                    }
                    
            }
        }

        private double _calorieGiornata;
        public double CaloriePreview {

            get { return this._calorieGiornata + (this._quantita * this._prodotto.Calorie); }
        }
        public double CaloriePreviewPercentuale {
            get { return (CaloriePreview * 100) / this.db.ValCalorie; }
        }

        private double _grassiGiornata;
        public double GrassiPreview
        {

            get { return this._grassiGiornata + (this._quantita * this._prodotto.Grassi); }
        }
        public double GrassiPreviewPercentuale
        {
            get { return (GrassiPreview * 100) / this.db.ValGrassi; }
        }

        private double _proteineGiornata;
        public double ProteinePreview
        {

            get { return this._proteineGiornata + (this._quantita * this._prodotto.Proteine); }
        }
        public double ProteinePreviewPercentuale
        {
            get { return (ProteinePreview * 100) / this.db.ValProteine; }
        }

        private double _carboidratiGiornata;
        public double CarboidratiPreview
        {

            get { return this._carboidratiGiornata + (this._quantita * this._prodotto.Carboidrati); }
        }
        public double CarboidratiPreviewPercentuale
        {
            get { return (CarboidratiPreview * 100) / this.db.ValCarboidrati; }
        }

        public string StatoCalorie { 
           
            get {
                if (CaloriePreview >= this.db.MaxQntaCalorie)
                {
                    return "Red";
                }
                else
                    return "Green";
            }

        }

       
        public string StatoCarboidrati
        {

            get
            {
                if (CarboidratiPreview >= this.db.MaxQntaCarboidrati)
                {
                    return "Red";
                }
                else
                    return "Green";
            }

        }

       public string StatoGrassi
        {

            get
            {
                if (GrassiPreview >= this.db.MaxQntaGrassi)
                {
                    return "Red";
                }
                else
                    return "Green";
            }

        }

       public string StatoProteine
       {

           get
           {
               if (ProteinePreview >= this.db.MaxQntaProteine)
               {
                   return "Red";
               }
               else
                   return "Green";
           }

       }



        //COSTRUTTORE
        public ProdottoViewModel(int id) {
        
            this.db = new Database(App.PathDB);

            this.db.LoadCollectionsFromDatabase();

            this.dataCorrente = (DateTime)appSettings["DataCorrente"];

            this._prodotto = this.db.RitornaProdotto(id);

            this._calorieGiornata = this.db.CalorieDelGiorno(dataCorrente);


            this._grassiGiornata = this.db.GrassiDelGiorno(dataCorrente);

            this._proteineGiornata = this.db.ProteineDelGiorno(dataCorrente);

            this._carboidratiGiornata = this.db.CarboidratiDelGiorno(dataCorrente);

           

        }

        public void Piccola() {
            Quantita = this._prodotto.Piccola;
        }

        public void Media()
        {
            Quantita = this._prodotto.Media;
        }

        public void Grande()
        {
            Quantita = this._prodotto.Grande;
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
