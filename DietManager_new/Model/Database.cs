using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Linq;

namespace DietManager_new.Model
{
    public class Database : DataContext, INotifyPropertyChanged, INotifyPropertyChanging
    {
        public Table<Prodotto> Prodotti;
        public Table<Utente> TabellaUtenti;
        public Table<Categoria> Categorie;
        public Table<Pasto> Pasti;
        private ObservableCollection<Pasto> pastiGiornata;
        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        private double valCalorie;
        public double ValCalorie {
            get { return this.valCalorie; }
        }


        private double maxQntaCalorie;
        public double MaxQntaCalorie { get { return this.maxQntaCalorie; } }

        private double minQntaCalorie ;
        public double MinQntaCalorie { get { return this.minQntaCalorie; } }

        private double maxQntaCarboidrati;
        public double MaxQntaCarboidrati { get { return this.maxQntaCarboidrati; } }

        
        private double minQntaCarboidrati ;
        public double MinQntaCarboidrati { get { return this.minQntaCarboidrati; } }

        
        private double maxQntaProteine ;
        public double MaxQntaProteine { get { return this.maxQntaProteine; } }

        
        private double minQntaProteine ;
        public double MinQntaProteine { get { return this.minQntaProteine; } }

        
        private double maxQntaGrassi;
        public double MaxQntaGrassi { get { return this.maxQntaGrassi; } }


        private double minQntaGrassi;
        public double MinQntaGrassi { get { return this.minQntaGrassi; } }


        private ObservableCollection<Prodotto> prodottiTotali;
        public ObservableCollection<Prodotto> ProdottiTotali
        {

            get { return this.prodottiTotali; }

            set
            {

                if (prodottiTotali != value)
                {
                    NotifyPropertyChanging("ProdottiTotali");

                    prodottiTotali = value;

                    NotifyPropertyChanged("ProdottiTotali");
                }
            }
        }

        private ObservableCollection<Prodotto> categoriaCereali;
        public ObservableCollection<Prodotto> CategoriaCereali
        {

            get { return this.categoriaCereali; }

            set
            {
                if (categoriaCereali != value)
                {
                    NotifyPropertyChanging("CategoriaCereali");
                    categoriaCereali = value;

                    NotifyPropertyChanged("CategoriaCereali");
                }
            }
        }

        private ObservableCollection<Prodotto> categoriaBevande;
        public ObservableCollection<Prodotto> CategoriaBevande
        {
            get { return this.categoriaBevande; }
            set
            {
                if (categoriaBevande != value)
                {
                    NotifyPropertyChanging("CategoriaBevande");
                    categoriaBevande = value;
                    NotifyPropertyChanged("CategoriaBevande");
                }
            }
        }

        private ObservableCollection<Prodotto> categoriaPesce;
        public ObservableCollection<Prodotto> CategoriaPesce
        {
            get { return this.categoriaPesce; }
            set
            {
                if (this.categoriaPesce != value)
                {
                    this.categoriaPesce = value;
                    NotifyPropertyChanged("CategoriaPesce");
                }
            }
        }

        private ObservableCollection<Prodotto> categoriaLatticini;
        public ObservableCollection<Prodotto> CategoriaLatticini
        {
            get { return this.categoriaLatticini; }
            set
            {
                if (this.categoriaLatticini != value)
                {
                    this.categoriaLatticini = value;
                    NotifyPropertyChanged("CategoriaLatticini");
                }
            }
        }

        private ObservableCollection<Prodotto> categoriaFastFood;
        public ObservableCollection<Prodotto> CategoriaFastFood
        {
            get { return this.categoriaFastFood; }
            set
            {
                if (this.categoriaFastFood != value)
                {
                    this.categoriaFastFood = value;
                    NotifyPropertyChanged("CategoriaFastFood");
                }
            }
        }

        private ObservableCollection<Prodotto> categoriaVarie;
        public ObservableCollection<Prodotto> CategoriaVarie
        {
            get { return this.categoriaVarie; }
            set
            {
                if (categoriaVarie != value)
                {
                    NotifyPropertyChanging("CategoriaVarie");
                    categoriaVarie = value;
                    NotifyPropertyChanged("CategoriaVarie");
                }
            }
        }
        private ObservableCollection<Prodotto> categoriaFrutta;
        public ObservableCollection<Prodotto> CategoriaFrutta
        {
            get { return this.categoriaFrutta; }
            set
            {
                if (categoriaFrutta != value)
                {
                    NotifyPropertyChanging("CategoriaFrutta");
                    categoriaFrutta = value;
                    NotifyPropertyChanged("CategoriaFrutta");
                }
            }
        }

        private ObservableCollection<Prodotto> categoriaVerdura;
        public ObservableCollection<Prodotto> CategoriaVerdura
        {
            get { return this.categoriaVerdura; }
            set
            {
                if (categoriaVerdura != value)
                {
                    NotifyPropertyChanging("CategoriaVerdura");
                    categoriaVerdura = value;
                    NotifyPropertyChanged("CategoriaVerdura");
                }
            }
        }

        private ObservableCollection<Prodotto> categoriaCarne;
        public ObservableCollection<Prodotto> CategoriaCarne
        {
            get { return this.categoriaCarne; }
            set
            {
                if (categoriaCarne != value)
                {
                    NotifyPropertyChanging("CategoriaCarne");
                    categoriaCarne = value;
                    NotifyPropertyChanged("CategoriaCarne");
                }
            }
        }

        private ObservableCollection<Prodotto> categoriaDolci;
        public ObservableCollection<Prodotto> CategoriaDolci
        {
            get { return this.categoriaDolci; }
            set
            {
                if (categoriaDolci != value)
                {
                    NotifyPropertyChanging("CategoriaDolci");
                    categoriaDolci = value;
                    NotifyPropertyChanged("CategoriaDolci");
                }
            }
        }

        private ObservableCollection<Pasto> pastiTotali;
        public ObservableCollection<Pasto> PastiTotali
        {

            get { return this.pastiTotali; }

            set
            {
                if (pastiTotali != value)
                {
                    NotifyPropertyChanging("PastiTotali");

                    pastiTotali = value;

                    NotifyPropertyChanged("PastiTotali");
                }
            }
        }

        private Utente utenteAttuale;
        public Utente UtenteAttuale {
            get {
                return utenteAttuale;
            }
            set {
                if (value != utenteAttuale)
                {
                    utenteAttuale = value;
                    NotifyPropertyChanged("UtenteAttuale");
                }
            }
        }




        //COSTRUTTORE Pass the connection string to the base class.
        public Database() : base(App.PathDB)
        {   
            
        }
       
        
        //METODO carica le collezioni dal database
        public void LoadCollectionsFromDatabase()
        {
            var utente = from Utente ut in this.TabellaUtenti
                                where ut.IdUtente == App.idUtenteAttuale
                                select ut;

            utenteAttuale = (Utente)(utente.Single());

            maxQntaCalorie = utenteAttuale.MaxCalorieUtente;
            minQntaCalorie = utenteAttuale.MinCalorieUtente;


            maxQntaCarboidrati = utenteAttuale.MaxCarboidratiUtente;
            minQntaCarboidrati = utenteAttuale.MinCarboidratiUtente;

            maxQntaProteine = utenteAttuale.MaxProteineUtente;
            minQntaProteine = utenteAttuale.MinProteineUtente;

            maxQntaGrassi = utenteAttuale.MaxGrassiUtente;
            minQntaGrassi = utenteAttuale.MinGrassiUtente;

            
            var prodottiInDB = from Prodotto prod in this.Prodotti 
                                select prod;

            
            this.prodottiTotali = new ObservableCollection<Prodotto>(prodottiInDB);

            var pastiInDB = from Pasto pa in this.Pasti
                            where pa.UtenteFKInternal == App.idUtenteAttuale
                               select pa;



            this.pastiTotali = new ObservableCollection<Pasto>(pastiInDB);


            var categorieInDB = from Categoria cat in this.Categorie
                                     select cat;


            // Query the database and load all associated items to their respective collections.
            foreach (Categoria cat in categorieInDB)
            {
    
                switch (cat.NomeCategoria)
                {   
                    case "Cereali":
                        this.categoriaCereali = new ObservableCollection<Prodotto>(cat.ProdottiFK);
                        break;
                    case "Bevande":
                        this.categoriaBevande = new ObservableCollection<Prodotto>(cat.ProdottiFK);
                        break;
                    case "Varie":
                        this.categoriaVarie = new ObservableCollection<Prodotto>(cat.ProdottiFK);
                        break;
                    case "Dolci":
                        this.categoriaDolci = new ObservableCollection<Prodotto>(cat.ProdottiFK);
                        break;
                    case "Verdura":
                        this.categoriaVerdura = new ObservableCollection<Prodotto>(cat.ProdottiFK);
                        break;
                    case "Carne":
                        this.categoriaCarne = new ObservableCollection<Prodotto>(cat.ProdottiFK);
                        break;
                    case "Pesce":
                        this.categoriaPesce = new ObservableCollection<Prodotto>(cat.ProdottiFK);
                        break;
                    case "Latticini":
                        this.categoriaLatticini = new ObservableCollection<Prodotto>(cat.ProdottiFK);
                        break;
                    case "Fast Food":
                        this.categoriaFastFood = new ObservableCollection<Prodotto>(cat.ProdottiFK);
                        break;
                    case "Frutta":
                        this.categoriaFrutta = new ObservableCollection<Prodotto>(cat.ProdottiFK);
                        break;
                    default: break;
                }
            }


            this.PastiDelGiorno((DateTime)appSettings["DataCorrente"]);
        }

        //METODO ritorna il prodotto con determinato id
        public Prodotto RitornaProdotto(int id) {

            foreach (Prodotto p in this.prodottiTotali) {

                if (p.ProdottoId == id)
                     return p;         
            }
            return null;
        
        }

        //METODO ritorna la lista di pasti data una data
        public ObservableCollection<Pasto> PastiDelGiorno(DateTime data)
        {
            this.pastiGiornata = new ObservableCollection<Pasto>();

            foreach (Pasto p in pastiTotali)
            {
                if ((p.Data).Equals(data))
                {
                    pastiGiornata.Add(p);
                }
            }
            return pastiGiornata;

        }

        //METODO ritorna le calorie totali di un giorno
        public double CalorieDelGiorno(DateTime data)
        {

            double calorieTot = 0;
            if (PastiDelGiorno(data).Count == 0) return 0;

            foreach (Pasto p in pastiGiornata)
            {

                calorieTot += p.Calorie;
            }
            return calorieTot;
        }

        //METODO ritorna i grassi totali di un giorno
        public double GrassiDelGiorno(DateTime data)
        {

            double grassiTot = 0;
            if (PastiDelGiorno(data).Count == 0) return 0;

            foreach (Pasto p in pastiGiornata)
            {
                grassiTot += p.Grassi;
            }
            return grassiTot;
        }

        //METODO ritorna le proteine totali di un giorno
        public double ProteineDelGiorno(DateTime data)
        {

            double proteineTot = 0;
            if (PastiDelGiorno(data).Count == 0) return 0;

            foreach (Pasto p in pastiGiornata)
            {
                proteineTot += p.Proteine;
            }
            return proteineTot;
        }

        //METODO ritorna i carboidrati totali di un giorno
        public double CarboidratiDelGiorno(DateTime data)
        {
            double carboidratiTot = 0;
            if (PastiDelGiorno(data).Count == 0) return 0;

            foreach (Pasto p in pastiGiornata)
            {
                carboidratiTot += p.Carboidrati;
            }
            return carboidratiTot;
        }

        //METODO ritorna una lista di giorni dato un mese ed un anno
        public ObservableCollection<Giornata> GiornateDelMese(int mese, int anno)
        {
            int numGiorniDelMese = System.DateTime.DaysInMonth(anno, mese);

            ObservableCollection<Giornata> giorni = new ObservableCollection<Giornata>();

            DateTime data;

            double tempGrassi = 0;
            double tempCalorie = 0;
            double tempProteine = 0;
            double tempCarboidrati = 0;

            for (int i = 1; i <= numGiorniDelMese; i++)
            {

                data = new DateTime(anno, mese, i);

              PastiDelGiorno(data);
                tempCalorie = CalorieDelGiorno(data);
                if (data == DateTime.Today)
                    giorni.Add(new Giornata(anno, mese, i, "Blue"));
                else
                {
                    if (tempCalorie == 0)
                        giorni.Add(new Giornata(anno, mese, i, "Black"));
                    else
                    {
                        tempGrassi = GrassiDelGiorno(data);
                        tempCarboidrati = CarboidratiDelGiorno(data);
                        tempProteine = ProteineDelGiorno(data);
                        if (Dietologo.RISPETTALADIETA(tempCalorie, tempCarboidrati, tempGrassi, tempProteine))
                            giorni.Add(new Giornata(anno, mese, i, "Green"));
                        else
                            giorni.Add(new Giornata(anno, mese, i, "Red"));
                    }

                }
            }
            return giorni;

        }



        //METODO aggiunge un pasto nuovo
        public void aggiungiPasto(Pasto p)
        {
            int index = 0;
            foreach (Pasto pa in pastiTotali)
            {
                if (pa.CompareTo(p) < 0)
                    index++;
                else { pastiTotali.Insert(index, p); break; }
            }
            if(!pastiTotali.Contains(p))
                this.pastiTotali.Add(p);
            this.Pasti.InsertOnSubmit(p);
            this.SubmitChanges();
        }

        //METODO elimina un pasto esistente
        public void rimuoviPasto(Pasto p)
        {
            this.pastiTotali.Remove(p);
            this.Pasti.DeleteOnSubmit(p);
            this.SubmitChanges();
        }

        

        //METODO ritorna tutti i prodotti che nel nome contengono una certa stringa
        public ObservableCollection<Prodotto> cercaProdotto(string nome) {

            ObservableCollection<Prodotto> trovati = new ObservableCollection<Prodotto>();

            foreach (Prodotto p in this.prodottiTotali) {

                if (p.NomeProdotto.IndexOf(nome,StringComparison.OrdinalIgnoreCase)>=0)
                    trovati.Add(p);
            }
            return trovati;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify Silverlight that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify that a property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion


    }
}
