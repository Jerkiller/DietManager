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
        public Table<Categoria> Categorie;
        public Table<Pasto> Pasti;

        private ObservableCollection<Pasto> pastiGiornata;

        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        private double valCalorie;
        public double ValCalorie {
            get { return this.valCalorie; }
        }

        private double valCarboidrati;
        public double ValCarboidrati
        {
            get { return this.valCarboidrati; }
        }

        private double valProteine;
        public double ValProteine
        {
            get { return this.valProteine; }
        }

        private double valGrassi;
        public double ValGrassi
        {
            get { return this.valGrassi; }
        }


        private double maxQntaCalorie;
        public double MaxQntaCalorie { get { return this.maxQntaCalorie; } }

        private double minQntaCalorie ;
        public double MinxQntaCalorie { get { return this.minQntaCalorie; } }

        private double maxQntaCarboidrati;
        public double MaxQntaCarboidrati { get { return this.maxQntaCarboidrati; } }

        
        private double minQntaCarboidrati ;
        public double MinQntaCarboidrati { get { return this.MinQntaCarboidrati; } }

        
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

        private ObservableCollection<Prodotto> categoriaPanini;
        public ObservableCollection<Prodotto> CategoriaPanini
        {

            get { return this.categoriaPanini; }

            set
            {
                if (categoriaPanini != value)
                {
                    NotifyPropertyChanging("CategoriaPanini");
                    categoriaPanini = value;

                    NotifyPropertyChanged("CategoriaPanini");
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




        //COSTRUTTORE Pass the connection string to the base class.
        public Database(string dbconnection) : base(dbconnection)
        {
             valCalorie = Double.Parse((appSettings["Calorie"].ToString()));
            valCarboidrati = Double.Parse((appSettings["Carboidrati"].ToString()));
            valProteine = Double.Parse((appSettings["Proteine"].ToString()));
            valGrassi = Double.Parse((appSettings["Grassi"].ToString()));

            maxQntaCalorie = valCalorie + (valCalorie * 0.05);
            minQntaCalorie = valCalorie - (valCalorie * 0.05);

            maxQntaCarboidrati = valCarboidrati + (valCarboidrati * 0.05);
            minQntaCarboidrati = valCarboidrati - (valCarboidrati * 0.05);

            maxQntaProteine = valProteine + (valProteine * 0.05);
            minQntaProteine = valProteine - (valProteine * 0.05);

            maxQntaGrassi = valGrassi + (valGrassi * 0.05);
            minQntaGrassi = valGrassi - (valGrassi * 0.05);


         
        }
       
        
        //METODO carica le collezioni dal database
        public void LoadCollectionsFromDatabase()
        {

            
            var prodottiInDB = from Prodotto prod in this.Prodotti
                                select prod;

            
            this.prodottiTotali = new ObservableCollection<Prodotto>(prodottiInDB);

            var pastiInDB = from Pasto pa in this.Pasti
                               select pa;


            this.pastiTotali = new ObservableCollection<Pasto>(pastiInDB);


            var categorieInDB = from Categoria cat in this.Categorie
                                     select cat;


            // Query the database and load all associated items to their respective collections.
            foreach (Categoria cat in categorieInDB)
            {
    
                switch (cat.NomeCategoria)
                {   
                    case "Panini":
                        this.categoriaPanini = new ObservableCollection<Prodotto>(cat.ProdottiFK);
                        break;

                    case "Bevande":
                        this.categoriaBevande = new ObservableCollection<Prodotto>(cat.ProdottiFK);
                        break;

                    default:
                        break;
                }
            }

           
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

            this.PastiDelGiorno(data);

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

            this.PastiDelGiorno(data);

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

            this.PastiDelGiorno(data);

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

            this.PastiDelGiorno(data);

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
                if (tempCalorie == 0)
                    giorni.Add(new Giornata(anno, mese, i, "White"));
                else
                {
                    tempGrassi = GrassiDelGiorno(data);
                    tempCarboidrati = CarboidratiDelGiorno(data);
                    tempProteine = ProteineDelGiorno(data);
                    if (RISPETTALADIETA(tempCalorie, tempCarboidrati, tempGrassi, tempProteine))
                        giorni.Add(new Giornata(anno, mese, i, "Green"));
                    else
                        giorni.Add(new Giornata(anno, mese, i, "Red"));
                }

            }
            return giorni;

        }

        //DA METHOD controlla se il valore passato e entro i limiti 
        private bool RISPETTALADIETA(double qntaCalorie, double qntaCarboidrati, double qntaGrassi, double qntaProteine)
        {

           
            if ((qntaCalorie >= minQntaCalorie && qntaCalorie <= maxQntaCalorie) && (qntaCarboidrati >= minQntaCarboidrati && qntaCarboidrati <= maxQntaCarboidrati) && (qntaProteine >= minQntaProteine && qntaProteine <= maxQntaProteine) && (qntaGrassi >= minQntaGrassi && qntaGrassi <= maxQntaGrassi))

                return true;

            return false;

        }

        //METODO aggiunge un pasto nuovo
        public void aggiungiPasto(Pasto p)
        {

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

                if (p.NomeProdotto.Contains(nome))
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


    

    



