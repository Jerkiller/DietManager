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
    public class ProdottoViewModel : PreviewGiornataVM, INotifyPropertyChanged
    {


        private Prodotto _prodotto;
        public Prodotto Prodotto
        {

            get { return this._prodotto; }
            set
            {

                if (this._prodotto != value)
                {
                    this._prodotto = value;
                    NotifyPropertyChanged("Prodotto");

                }


            }
        }

        private double _quantita;
        public string Quantita
        {

            get { return this._quantita.ToString(); }
            set
            {
                if (!this._quantita.ToString().Equals(value))
                {
                    if (!value.Equals(""))
                        this._quantita = Convert.ToDouble(value);
                    else this._quantita = 0;
                    NotifyAll();

                }

            }
        }

        public void NotifyAll()
        {
            NotifyPropertyChanged("Quantita");
            NotifyPropertyChanged("CaloriePreview");
            NotifyPropertyChanged("GrassiPreview");
            NotifyPropertyChanged("CarboidratiPreview");
            NotifyPropertyChanged("ProteinePreview");
            NotifyPropertyChanged("StatoCalorie");
            NotifyPropertyChanged("StatoCarboidrati");
            NotifyPropertyChanged("StatoGrassi");
            NotifyPropertyChanged("StatoProteine");
        }

        public double CaloriePreview
        {

            get { return Math.Round((this._quantita * this._prodotto.Calorie) / this._prodotto.Quantita, 2); }
        }


        public double GrassiPreview
        {

            get { return Math.Round((this._quantita * this._prodotto.Grassi) / this._prodotto.Quantita,2); }
        }


        public double ProteinePreview
        {

            get { return Math.Round((this._quantita * this._prodotto.Proteine) / this._prodotto.Quantita,2); }
        }


        public double CarboidratiPreview
        {

            get { return Math.Round((this._quantita * this._prodotto.Carboidrati) / this._prodotto.Quantita, 2); }
        }


        new public string StatoCalorie
        {

            get
            {
                if (CaloriePreview + base.CalorieGiornata < base.MinQntaCalorie)
                {
                    return "Blue";

                }
                else if (CaloriePreview + base.CalorieGiornata > base.MaxQntaCalorie)
                    return "Red";
                else return "Green";
            }

        }


        new public string StatoCarboidrati
        {

            get
            {
                if (CarboidratiPreview + base.CarboidratiGiornata < base.Db.MinQntaCarboidrati)
                    return "Blue";
                else if (CarboidratiPreview + base.CarboidratiGiornata > base.Db.MaxQntaCarboidrati)
                    return "Red";
                else return "Green";
            }

        }

        new public string StatoGrassi
        {

            get
            {
                if (GrassiPreview + base.GrassiGiornata < base.Db.MinQntaGrassi)
                {
                    return "Blue";
                }
                else if (GrassiPreview + base.GrassiGiornata > base.Db.MaxQntaGrassi)
                    return "Red";
                else return "Green";
            }

        }

        new public string StatoProteine
        {

            get
            {
                if (ProteinePreview + base.ProteineGiornata < base.Db.MinQntaProteine)
                {
                    return "Blue";
                }
                else if (ProteinePreview + base.ProteineGiornata > base.Db.MaxQntaProteine)
                    return "Red";
                else return "Green";
            }

        }

        private string pezzi;
        public string Pezzi {
            get {
                return pezzi;
            }
            set {
                if (pezzi != value) {
                    pezzi = value;
                }
            
            }
        }

        private string nonPezzi;
        public string NonPezzi
        {
            get
            {
                return nonPezzi;
            }
            set
            {
                if (nonPezzi != value)
                {
                    nonPezzi = value;
                }

            }
        }

        private ICommand piccola;
        public ICommand Piccola
        {
            get { return piccola; }
        }

        

        private ICommand media;
        public ICommand Media
        {
            get { return media; }
        }

        private ICommand grande;
        public ICommand Grande
        {
            get { return grande; }
        }

        private ICommand aggiungi;
        public ICommand Aggiungi
        {
            get { return aggiungi; }
        }

        private ObservableCollection<PData> datiGrafico;
        public ObservableCollection<PData> DatiGrafico {
            get {
                return datiGrafico;
            }
        }


        //COSTRUTTORE
        public ProdottoViewModel(int id)
            : base()
        {

            this._prodotto = base.Db.RitornaProdotto(id);
            cambiaPezzi(_prodotto.UnitaDiMisura);
            piccola = new DelegateCommand(_piccola);
            media = new DelegateCommand(_media);
            grande = new DelegateCommand(_grande);
            _quantita = 0;
            aggiungi = new DelegateCommand(_aggiungi);

            double prodCarboidrati = _prodotto.Carboidrati;
            double prodGrassi = _prodotto.Grassi;
            double prodProteine = _prodotto.Proteine;

            datiGrafico = new ObservableCollection<PData>()
        {
            new PData() { title = "Carboidrati: "+prodCarboidrati.ToString()+"gr", value = prodCarboidrati },
            new PData() { title = "Grassi: "+prodGrassi.ToString()+"gr", value = prodGrassi },
            new PData() { title = "Proteine: "+prodProteine.ToString()+"gr", value = prodProteine },
        };

        }

        private void cambiaPezzi(string val) {
            if (val.Equals("pz")){
                Pezzi = "Visible";
                NonPezzi="Collapsed";
            }
            else
            {
                NonPezzi = "Visible";
                Pezzi = "Collapsed";
            }
        }

        //METODO setta la quantita al valore piccolo del prodotto corrente
        public void _piccola(object o)
        {
            Quantita = this._prodotto.Piccola.ToString();
        }

        //METODO setta la quantita al valore medio del prodotto corrente
        public void _media(object o)
        {
            Quantita = this._prodotto.Media.ToString();
        }

        //METODO setta la quantita al valore grande del prodotto corrente
        public void _grande(object o)
        {
            Quantita = this._prodotto.Grande.ToString();
        }

        //METODO aggiunge il pasto creato in base al prodotto corrente
        public void _aggiungi(object o)
        {
            if (_quantita == 0)
                MessageBox.Show("Quantità cibo errata");
            else
            {
                Pasto p = new Pasto
                {
                    // quantità media prodotto : calorie prodotto = quantità assunta : calorie assunte
                    ProdottoFK = _prodotto,
                    Quantita = _quantita,
                    Calorie = CaloriePreview,
                    Grassi = GrassiPreview,
                    Carboidrati = CarboidratiPreview,
                    Proteine =ProteinePreview,
                    Data = base.DataCorrente,
                    UtenteFK=this.Db.UtenteAttuale

                };
                base.Db.aggiungiPasto(p);
                NotifyPropertyChanged("PastiGiorno");
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/PaginaGiornata.xaml?Refresh=true", UriKind.Relative));

            }
        }



    }
}
