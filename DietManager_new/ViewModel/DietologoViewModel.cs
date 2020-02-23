using DietManager_new.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace DietManager_new.ViewModel
{
    public class DietologoViewModel: INotifyPropertyChanged
    {

        private SimpleDatabase db;
        protected SimpleDatabase Db
        {
            get { return this.db; }
        }
        
        private int currentPage;
        public int CurrentPage {
            set {
                if (currentPage != value)
                    currentPage = value;
            }
        }
        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
        private double maxcalorie;

        private double mincalorie;
        
        private double maxgrassi;
        
        private double mingrassi;
       
        private double maxcarboidrati;
       

        private double mincarboidrati;
       
        private double maxproteine;

        private double minproteine;


        private double calorie;
        public double Calorie 
        {
            get
            {
                return calorie;
            }
            set
            {
                if (value != calorie)
                {
                    calorie = value;
                    //valoriNutrizionali();
                    NotifyPropertyChanged("Calorie");
                    /*NotifyPropertyChanged("CalorieCambiate");*/
                   
                }
            }
        }

        private double calorieCalcolate;
        public double CalorieCalcolate
        {
            get
            {
                return calorieCalcolate;
            }
            set
            {
                if (value != calorieCalcolate)
                {
                    calorieCalcolate = value;
                    //valoriNutrizionali();
                    NotifyPropertyChanged("CalorieCalcolate");
                    NotifyPropertyChanged("CalorieCambiate");
                }
            }
        }

        private bool _sesso;
        public bool Sesso {
            get { return _sesso; }
            set {
                if (value)
                {
                    _sesso = true;
                    ColoreSesso="DodgerBlue";}
                else {_sesso = false; ColoreSesso="Purple";}
            }
        }

        public string coloreSesso;
        public string ColoreSesso
        {
            get
            {
                return coloreSesso;
            }
            set
            {
                if (value != coloreSesso) {
                    coloreSesso = value;
                    NotifyPropertyChanged("ColoreSesso");
                } 
            }
        } 

        private double _peso;
        public int Peso
        {
            get
            {
              
                return (int)_peso;

            }
            set
            {

                if (value != this._peso)
                {
                    this._peso = value;
                    NotifyPropertyChanged("Peso");
                }
                
            }
        }

        private double _altezza;
        public int Altezza
        {
            get
            {
                return (int)this._altezza;
            }
            set
            {
                if (value!=this._altezza)
                {
                    this._altezza = value;
                    NotifyPropertyChanged("Altezza");
                }
            }
        }

        private int _eta;
        public int Eta
        {
            get
            {
                return this._eta;
            }
            set
            {
                if (value!=_eta)
                {
                    _eta = value;
                    NotifyPropertyChanged("Eta");
                }
            }
        }

        private double _sonno;
        public int Sonno
        {
            get
            {
                return (int)_sonno;
            }
            set
            {
                if (value!=_sonno)
                {
                    _sonno = value;
                    NotifyPropertyChanged("Sonno");
                }
            }
        }

        private double _leggere;
        public int Leggere
        {
            get {
                return (int)_leggere;
            }
            set
            {
                if (value!=_leggere)
                {
                    _leggere = value;

                    NotifyPropertyChanged("Leggere");
                }
            }
        }

        private double _medie;
        public int Medie
        {
            get {
                return (int)_medie;
            }
            set
            {
                if (value != _medie)
                {
                    _medie = value;
                    NotifyPropertyChanged("Medie");
                }
            }
        }

        private double _medio_pesanti;
        public int Medio_pesanti
        {
            get
            {
                return (int)_medio_pesanti;
            }
            set
            {
                if (value!=_medio_pesanti)
                {
                    _medio_pesanti = value;
                    NotifyPropertyChanged("Medio_pesanti");
                }
            }
        }

        private double _pesanti;
        public int Pesanti
        {
            get
            {
                return (int)_pesanti;
            }
            set
            {
                if ( value!=_pesanti)
                {
                    _pesanti = value;
                    NotifyPropertyChanged("Pesanti");
                }
            }
        }

        private string nomeUtente;
        public string NomeUtente {
            get {
                return nomeUtente;
            }
            set {
                if (value != nomeUtente) {
                    nomeUtente = value;
                    NotifyPropertyChanged("NomeUtente");
                }
            }
        }

        private ICommand profilazione;
        public ICommand Profilazione
        {
            get
            {

                return profilazione;
            }
        }

        private ICommand confermaProfilo;
        public ICommand ConfermaProfilo
        {
            get
            {

                return confermaProfilo;
            }
        }

        public bool CalorieCambiate {
            get {
                if (CalorieCalcolate != Calorie)
                    return true;
                    else return false;
                }
        }

        private ICommand selezionaMaschio;
        public ICommand SelezionaMaschio
        {
            get
            {

                return selezionaMaschio;
            }
        }

        private ICommand selezionaFemmina;
        public ICommand SelezionaFemmina
        {
            get
            {

                return selezionaFemmina;
            }
        }

        private string maschio;
        public string Maschio {
            get {
                return maschio;
            }
            set {
                if (value != maschio) {
                    maschio = value;
                    NotifyPropertyChanged("Maschio");
                }
            }
        }

        private string femmina;
        public string Femmina
        {
            get
            {
                return femmina;
            }
            set
            {
                if (value != femmina)
                {
                    femmina = value;
                    NotifyPropertyChanged("Femmina");
                }
            }
        }


     


        private ICommand prev;
        public ICommand Prev { get { return prev; } }

        private ICommand tornaACalorieCalcolate;
        public ICommand TornaACalorieCalcolate { get { return tornaACalorieCalcolate; } }

        private ICommand next;
        public ICommand Next { get { return next; } }

        private ICommand aumentaCalorie;
        public ICommand AumentaCalorie { get { return aumentaCalorie; } }

        private ICommand diminuisciCalorie;
        public ICommand DiminuisciCalorie { get { return diminuisciCalorie; } }

        //COSTRUTTORE
        public DietologoViewModel() {
            Sesso = true;
            maschio = "Black";
            femmina = "White";
            _peso = 20;
            _eta = 5;
            _altezza = 100;
            _sonno = 0;
            _leggere = 0;
            _medie = 0;
            _medio_pesanti = 0;
            _pesanti = 0;
            calorie = calorieCalcolate;
            profilazione = new DelegateCommand(_profilazione);
            confermaProfilo = new DelegateCommand(_confermaProfilo);
            prev = new DelegateCommand(_prev);
            next = new DelegateCommand(_next);
            aumentaCalorie = new DelegateCommand(_aumenta);
            diminuisciCalorie = new DelegateCommand(_diminuisci);
            tornaACalorieCalcolate = new DelegateCommand(_tornaACalorieCalcolate);
            selezionaMaschio = new DelegateCommand(_selezionaMaschio);
            selezionaFemmina = new DelegateCommand(_selezionaFemmina);

            currentPage = 0;

            this.db = new SimpleDatabase();

            this.db.LoadCollectionsFromDatabase();

        }

        public void _tornaACalorieCalcolate(object o)
        {
            CalorieCalcolate = Calorie;
        }

        public void _selezionaMaschio(object o) {
            Maschio = "Black";
            Femmina = "White";
            Sesso = true;
        }

        public void _selezionaFemmina(object o)
        {
            Maschio = "White";
            Femmina = "Black";
            Sesso = false;
        }

        public void _prev(object o) {

                currentPage--;
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Profilazione"+(currentPage).ToString()+".xaml?", UriKind.Relative));

        }

        public void _next(object o)
        {
            string introMess = "Errori rilevati:\n\n";
            string messaggio = "";

            if (currentPage == 1)
            {
                if (_eta == 5)
                    messaggio += "- Eta non settata\n";
                if (_altezza == 100)
                    messaggio += "- Altezza non settata\n";
                if (_peso == 20)
                    messaggio += "- Peso non settato\n";
                if (_sonno == 0)
                    messaggio += "- Ore di sonno non settate\n";
                if (!messaggio.Equals(""))
                    MessageBox.Show(introMess + messaggio);
                else
                {
                    currentPage++;
                    var rootFrame = (App.Current as App).RootFrame;
                    rootFrame.Navigate(new Uri("/Profilazione"+currentPage+".xaml?", UriKind.Relative));
                }
            }
            else if (currentPage == 0)
            {

                if (nomeUtente.Equals("")||nomeUtente==null)
                    messaggio += "- Nome mancante\n";
                if (!messaggio.Equals(""))
                    MessageBox.Show(introMess + messaggio);
                else
                {
                    currentPage++;
                    var rootFrame = (App.Current as App).RootFrame;
                    rootFrame.Navigate(new Uri("/Profilazione"+currentPage+".xaml?", UriKind.Relative));
                }
            }
            else
            {
                currentPage = currentPage + 1; 
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Profilazione" + (currentPage).ToString() + ".xaml?", UriKind.Relative));
            }

        }



        public void _profilazione(object o) {
            string introMess = "Errori rilevati:\n\n";
            string messaggio = "";
            if (_sonno * 7 + _leggere + _medie + _medio_pesanti + _pesanti > 168)
                messaggio += "- La somma delle ore supera il massimo settimanale (" + (_sonno * 7 + _leggere + _medie + _medio_pesanti + _pesanti).ToString() + "/168)";
            if (!messaggio.Equals(""))
            {
                MessageBox.Show(introMess + messaggio);
                Leggere = 0;
                Medie = 0;
                Medio_pesanti = 0;
                Pesanti = 0;
                currentPage = 1;
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/Profilazione1.xaml?", UriKind.Relative));
            }
            else
            {
                Calorie = Dietologo.Tdee(_sesso, _peso, _altezza, _eta, _sonno, _leggere, _medie, _medio_pesanti, _pesanti);
                CalorieCalcolate = Calorie;
                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/PaginaDietologo.xaml?", UriKind.Relative));
            }
                    
        }


        public void valoriNutrizionali() {
            minproteine = Dietologo.minProteine(Calorie);
            maxproteine = Dietologo.maxProteine(Calorie);
            mincarboidrati = Dietologo.minCarboidrati(Calorie);
            maxcarboidrati = Dietologo.maxCarboidrati(Calorie);
            mingrassi = Dietologo.minGrassi(Calorie);
            maxgrassi = Dietologo.maxGrassi(Calorie);
            maxcalorie = Dietologo.maxCalorie(Calorie);
            mincalorie = Dietologo.minCalorie(Calorie);
        }

        public void _aumenta(object o) {
            CalorieCalcolate = Math.Round(CalorieCalcolate + 50,2);
        }
        public void _diminuisci(object o) {
            double aux = Math.Round(calorieCalcolate - 50,2);
            if (aux < 0)
                CalorieCalcolate = 0;
            else CalorieCalcolate = aux;
        }

        public void _confermaProfilo(object o) {
            if (CalorieCalcolate > 0)
            {
                Calorie = CalorieCalcolate;
                valoriNutrizionali();
                if (!appSettings.Contains("Calorie"))
                    appSettings.Add("Calorie", calorie);

                Utente ut = new Utente
                {

                    Nome = NomeUtente,
                    Sesso=_sesso,
                    MinCalorieUtente=mincalorie,
                    MaxCalorieUtente=maxcalorie,
                    MinCarboidratiUtente=mincarboidrati,
                    MaxCarboidratiUtente = maxcarboidrati,
                    MinGrassiUtente=mingrassi,
                    MaxGrassiUtente=maxgrassi,
                    MinProteineUtente=minproteine,
                    MaxProteineUtente=maxproteine
                };
                Db.aggiungiUtente(ut);

                App.idUtenteAttuale = ut.IdUtente;
                App.utenteAttuale = ut;
                App.creaDatabase();
                azzeraValori();

                var rootFrame = (App.Current as App).RootFrame;
                rootFrame.Navigate(new Uri("/PaginaGiornata.xaml?", UriKind.Relative));

            }
            else MessageBox.Show("Calorie errate");
        }

        private void azzeraValori(){
            NomeUtente="";
            CurrentPage=0;
            Eta=5;
            Altezza=100;
            Peso=20;
            Sonno=0;
            Leggere=0;
            Medie=0;
            Medio_pesanti=0;
            Pesanti=0;
            selezionaMaschio.Execute(null);
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
