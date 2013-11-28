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
    public class ProdottoViewModel : PreviewGiornataVM, INotifyPropertyChanged
    {


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

        public double CaloriePreview {

            get { return base.CalorieGiornata + (this._quantita * this._prodotto.Calorie)/this._prodotto.Quantita; }
        }
        new public double CaloriePreviewPercentuale {
            get { return (CaloriePreview * 100) / base.Db.ValCalorie; }
        }

        public double GrassiPreview
        {

            get { return base.GrassiGiornata + (this._quantita * this._prodotto.Grassi) / this._prodotto.Quantita; }
        }
        new public double GrassiPreviewPercentuale
        {
            get { return (GrassiPreview * 100) / base.Db.ValGrassi; }
        }

        public double ProteinePreview
        {

            get { return base.ProteineGiornata + (this._quantita * this._prodotto.Proteine) / this._prodotto.Quantita; }
        }
        new public double ProteinePreviewPercentuale
        {
            get { return (ProteinePreview * 100) / base.Db.ValProteine; }
        }

        public double CarboidratiPreview
        {

            get { return base.CarboidratiGiornata + (this._quantita * this._prodotto.Carboidrati) / this._prodotto.Quantita; }
        }
        new public double CarboidratiPreviewPercentuale
        {
            get { return (CarboidratiPreview * 100) / base.Db.ValCarboidrati; }
        }

        new public string StatoCalorie { 
           
            get {
                if (CaloriePreview >= base.Db.ValCalorie)
                {
                    if (CaloriePreview >= base.Db.MaxQntaCalorie)
                        return "Red";
                    else return "Yellow";

                }
                else
                    return "Green";
            }

        }

       
        new public string StatoCarboidrati
        {

            get
            {
                if (CarboidratiPreview >= base.Db.ValCarboidrati)
                {
                    if (CarboidratiPreview >= base.Db.MaxQntaCarboidrati)
                        return "Red";
                    else return "Yellow";
                }
                else
                    return "Green";
            }

        }

       new public string StatoGrassi
        {

            get
            {
                if (GrassiPreview >= base.Db.ValGrassi)
                {
                    if (GrassiPreview >= base.Db.MaxQntaGrassi)
                        return "Red";
                    else return "Yellow";
                }
                else
                    return "Green";
            }

        }

       new public string StatoProteine
       {

           get
           {
               if (ProteinePreview >= base.Db.ValProteine)
               {
                   if (ProteinePreview >= base.Db.MaxQntaProteine)
                       return "Red";
                   else return "Yellow";
               }
               else
                   return "Green";
           }

       }



        //COSTRUTTORE
        public ProdottoViewModel(int id) : base() {

            this._prodotto = base.Db.RitornaProdotto(id);



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

        public void AggiungiPasto()
        {
            Pasto p = new Pasto
            {
                ProdottoFK = _prodotto,
                Quantita = _quantita,
                Calorie = Math.Round(((_quantita * _prodotto.Calorie) / _prodotto.Quantita), 2),  // quantità media prodotto : calorie prodotto = quantità assunta : calorie assunte
                Grassi = Math.Round(((_quantita * _prodotto.Grassi) / _prodotto.Quantita), 2),
                Carboidrati = Math.Round(((_quantita * _prodotto.Carboidrati) / _prodotto.Quantita), 2),
                Proteine = Math.Round(((_quantita * _prodotto.Proteine) / _prodotto.Quantita), 2),
                Data = base.DataCorrente

            };
            base.Db.aggiungiPasto(p);
            NotifyPropertyChanged("PastiGiorno");
            
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
