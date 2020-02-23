using DietManager_new.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DietManager_new.ViewModel
{
    public class GiornataViewModel: PreviewGiornataVM, INotifyPropertyChanged
    {
        ObservableCollection<Pasto> _pastiGiorno;

        private List<Pasto> _pastiSelezionati;

        public string nomeUtente;
        public string NomeUtente {
            get {
                return nomeUtente;
            }
        }

        private ICommand rimuovi;
        public ICommand Rimuovi
        {
            get
            {

                return rimuovi;
            }
        }

        private ICommand seleziona;
        public ICommand Seleziona {
            get {
  
                return seleziona;
            }
        }



        private string _data;
        public string Data {

            get { return this._data; }
            set {
                if (this._data != value) {

                    this._data = value;
                    NotifyPropertyChanged("Data");
                
                }
            
            }
        }

        public ObservableCollection<Pasto> PastiGiorno {
            get {
                return this._pastiGiorno;
            }

            set {
                if (value != this._pastiGiorno) {
                    _pastiGiorno = value;
                    NotifyPropertyChanged("PastiGiorno");
                }
            }
        
        }

        public string sesso;
        public string Sesso {
            get {
                return sesso;
            }
            set {
                sesso = value;
            }
        }

        private ICommand vediCalendario;
        public ICommand VediCalendario {
            get { return this.vediCalendario; }
        }

        private ICommand scegliProdotto;
        public ICommand ScegliProdotto
        {
            get { return this.scegliProdotto; }
        }


        private ObservableCollection<PData> datiGrafico;
        public ObservableCollection<PData> DatiGrafico
        {
            get
            {
                return datiGrafico;
            }

            set {
                if (value != datiGrafico) {
                    datiGrafico = value;
                    NotifyPropertyChanged("DatiGrafico");
                }
            }
        }

  

        //COSTRUTTORE
        public GiornataViewModel():base() {
            _pastiGiorno = base.Db.PastiDelGiorno(base.DataCorrente);
            DateTime d = base.DataCorrente;
            this.seleziona = new DelegateCommand(_seleziona);
            this.rimuovi = new DelegateCommand(_rimuovi);
            this.vediCalendario = new DelegateCommand(_vediCalendario);
            this.scegliProdotto = new DelegateCommand(_scegliProdotto);
            nomeUtente = App.utenteAttuale.Nome;
            bool s = App.utenteAttuale.Sesso;
            if (s)
                Sesso = "DodgerBlue";
            else Sesso = "Purple";


            _pastiSelezionati = new List<Pasto>();
            string a = "";

            string[] mesi = {"Gennaio","Febbraio","Marzo","Aprile","Maggio","Giugno","Luglio","Agosto","Settembre","Ottobre","Novembre","Dicembre"};

            switch (d.DayOfWeek.ToString()) {
                case "Monday": a += "Lunedì"; break;
                case "Tuesday": a += "Martedì"; break;
                case "Wednesday": a += "Mercoledì"; break;
                case "Thursday": a += "Giovedì"; break;
                case "Friday": a += "Venerdì"; break;
                case "Saturday": a += "Sabato"; break;
                case "Sunday": a += "Domenica"; break;
                default: break;
            }

             a +=" "+ d.Day;
            a+= " "+mesi[d.Month-1];
            a+= " "+d.Year;

            this._data = a;

            

            modificaGrafico();
        }

        //METODO sceglie il prodotto richiamato dal command
        public void _scegliProdotto(object o)
        {
 
            var rootFrame = (App.Current as App).RootFrame;
            rootFrame.Navigate(new Uri("/PaginaCategorie.xaml", UriKind.Relative));

        }   


        //METODO rimuove un pasto dato un id
        public void _seleziona(object o)
        {
          
            Pasto p = (Pasto)o;
            if (!_pastiSelezionati.Contains(p))
                _pastiSelezionati.Add(p);
            else _pastiSelezionati.Remove(p);

        }

        //METODO rimuove i pasti da selezionati
        public void _rimuovi(object o){
            if (_pastiSelezionati.Count == 0)
                MessageBox.Show("Nessun prodotto selezionato!");
            else
            {
                MessageBoxResult m = MessageBox.Show("Cancellare elementi selezionati?", "Cancella", MessageBoxButton.OKCancel);
                if (m == MessageBoxResult.OK)
                {
                    foreach (Pasto p in _pastiSelezionati)
                    {
                        base.CalorieGiornata = CalorieGiornata - p.Calorie;
                        base.CarboidratiGiornata = CarboidratiGiornata - p.Carboidrati;
                        base.GrassiGiornata = GrassiGiornata - p.Grassi;
                        base.ProteineGiornata = ProteineGiornata - p.Proteine;
                        base.Db.rimuoviPasto(p);
                        _pastiGiorno.Remove(p);
                    }
                    _pastiSelezionati.Clear();
                    if (PastiGiorno.Count() == 0) {
                        base.CalorieGiornata = 0;
                        base.CarboidratiGiornata = 0;
                        base.GrassiGiornata = 0;
                        base.ProteineGiornata = 0;
                    }
                    NotifyAll();
                    modificaGrafico();
                    
                }
            }
        }

        private void modificaGrafico() {
            double totCal = (CarboidratiGiornata * 3.8) + (GrassiGiornata * 9.3) + (ProteineGiornata * 3.1);
            if (totCal == 0)
                totCal = 1;
            DatiGrafico = new ObservableCollection<PData>()
        {
              new PData() { title = "Carboidrati "+ (Math.Round(((CarboidratiGiornata*3.8)*100/totCal),1)).ToString()+"%", value = (CarboidratiGiornata*3.8) },
            new PData() { title = "Grassi "+(Math.Round(((GrassiGiornata*9.3)*100/totCal),1)).ToString()+"%", value = (GrassiGiornata*9.3) },
            new PData() { title = "Proteine "+(Math.Round(((ProteineGiornata*3.1)*100/totCal),1)).ToString()+"%", value = (ProteineGiornata*3.1) },
        };
        }

        //METODO rimanda al calendario
        private void _vediCalendario(object o)
        {
            var rootFrame = (App.Current as App).RootFrame;
            rootFrame.Navigate(new Uri("/PaginaCalendario.xaml?Refresh=true", UriKind.Relative));

        }


        //METODO notifica tutte le proprietà al cambiamento di qualcosa
        public void NotifyAll()
        {
            NotifyPropertyChanged("PastiGiorno");
            NotifyPropertyChanged("CalorieGiornata");
            NotifyPropertyChanged("GrassiGiornata");
            NotifyPropertyChanged("CarboidratiGiornata");
            NotifyPropertyChanged("ProteineGiornata");
            NotifyPropertyChanged("StatoCalorie");
            NotifyPropertyChanged("StatoCarboidrati");
            NotifyPropertyChanged("StatoGrassi");
            NotifyPropertyChanged("StatoProteine");
        }

       
    }
}
