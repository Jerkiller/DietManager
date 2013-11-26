using DietManager_new.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;

namespace DietManager_new.Model
{
    public class DBManager : INotifyPropertyChanged
    {

        private Database db;

        private ObservableCollection<Pasto> pastiGiornata;

        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        private ObservableCollection<Prodotto> prodotti;
        public ObservableCollection<Prodotto> Prodotti
        {

            get { return this.prodotti; }

            set {
                if (prodotti != value) {

                    prodotti = value;

                    NotifyPropertyChanged("Prodotti");
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

                    categoriaBevande = value;

                    NotifyPropertyChanged("CategoriaBevande");
                }
            }
        }

        private ObservableCollection<Pasto> pasti;
        public ObservableCollection<Pasto> Pasti
        {

            get { return this.pasti; }

            set
            {
                if (pasti != value)
                {

                    pasti = value;

                    NotifyPropertyChanged("Pasti");
                }
            }
        }
        
        //COSTRUTTORE
        public DBManager(Database dbase) {

            this.db = dbase;

            this.LoadCollectionsFromDatabase();
        

        }

        //METODO Query database and load the collections and list used by the pivot pages.
        public void LoadCollectionsFromDatabase()
        {

            
            var prodottiInDB = from Prodotto prod in db.Prodotti
                                select prod;

            
            this.prodotti = new ObservableCollection<Prodotto>(prodottiInDB);

            
            var categorieInDB = from Categoria cat in db.Categorie
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

        //METODO ritorna la lista di pasti data una data
        public ObservableCollection<Pasto> PastiDelGiorno(DateTime data)
        {

            this.pastiGiornata = new ObservableCollection<Pasto>();

            foreach (Pasto p in pasti) {

                if ((p.Data).Equals(data)) {

                    pastiGiornata.Add(p);
                   }
                }
            return pastiGiornata;
        
        }

        //METODO ritorna le calorie totali di un giorno
        public double CalorieDelGiorno() {

            double calorieTot = 0;
                        
            foreach (Pasto p in pastiGiornata) {

                calorieTot += p.Calorie;
            }
            return calorieTot;
        }
        
        //METODO ritorna i grassi totali di un giorno
        public double GrassiDelGiorno()
        {

            double grassiTot = 0;

            foreach (Pasto p in pastiGiornata)
            {

                grassiTot += p.Calorie;
            }
            return grassiTot;
        }

        //METODO ritorna le proteine totali di un giorno
        public double ProteineDelGiorno()
        {

            double proteineTot = 0;

            foreach (Pasto p in pastiGiornata)
            {

                proteineTot += p.Calorie;
            }
            return proteineTot;
        }

        //METODO ritorna i carboidrati totali di un giorno
        public double CarboidratiDelGiorno()
        {

            double carboidratiTot = 0;

            foreach (Pasto p in pastiGiornata)
            {

                carboidratiTot += p.Calorie;
            }
            return carboidratiTot;
        }

        //METODO ritorna una lista di giorni dato un mese ed un anno
        public ObservableCollection<Giornata> GiornateDelMese(int mese, int anno){

            int numGiorniDelMese = System.DateTime.DaysInMonth(anno, mese);

            ObservableCollection<Giornata> giorni = new ObservableCollection<Giornata>();

            DateTime data;

            double tempGrassi = 0;
            double tempCalorie = 0;
            double tempProteine = 0;
            double tempCarboidrati = 0;
            
            for (int i = 1; i <= numGiorniDelMese; i++) {
                
                data=new DateTime(anno,mese,i);

                PastiDelGiorno(data);
                tempCalorie=CalorieDelGiorno();
                if (tempCalorie == 0)
                    giorni.Add(new Giornata(anno, mese, i, "White"));
                else
                  {
                    tempGrassi = GrassiDelGiorno();
                    tempCarboidrati = CarboidratiDelGiorno();
                    tempProteine = ProteineDelGiorno();
                    if(RISPETTALADIETA(tempCalorie,tempCarboidrati,tempGrassi,tempProteine))
                        giorni.Add(new Giornata(anno,mese,i,"Green"));
                    else
                        giorni.Add(new Giornata(anno,mese,i,"Red"));
                }
                
            }
            return giorni;
    
        }

        //METODO controlla se il valore passato e entro i limiti 
        private bool RISPETTALADIETA(double qntaCalorie, double qntaCarboidrati, double qntaGrassi, double qntaProteine ) { 
            
           double valCalorie = (double)(appSettings["Calorie"]);
           double valCarboidrati = (double)(appSettings["Carboidrati"]);
           double valProteine = (double)(appSettings["Proteine"]);
           double valGrassi = (double)(appSettings["Grassi"]);

           double maxQntaCalorie = valCalorie + (valCalorie * 0.5);
           double minQntaCalorie = valCalorie - (valCalorie * 0.5);

           double maxQntaCarboidrati = valCarboidrati + (valCarboidrati * 0.5);
           double minQntaCarboidrati = valCarboidrati - (valCarboidrati * 0.5);

           double maxQntaProteine = valProteine + (valProteine * 0.5);
           double minQntaProteine = valProteine - (valProteine * 0.5);

           double maxQntaGrassi = valGrassi + (valGrassi * 0.5);
           double minQntaGrassi = valGrassi - (valGrassi * 0.5);


           if ((qntaCalorie >= minQntaCalorie && qntaCalorie <= maxQntaCalorie) && (qntaCarboidrati >= minQntaCarboidrati && qntaCarboidrati <= maxQntaCarboidrati) &&  (qntaProteine >= minQntaProteine && qntaProteine <= maxQntaProteine) && (qntaGrassi >= minQntaGrassi && qntaGrassi <= maxQntaGrassi))
                       
               return true;

           return false;
        
        }

        //METODO aggiunge un pasto nuovo
        private void aggiungiPasto(Pasto p) {

            this.pasti.Add(p);

            db.Pasti.InsertOnSubmit(p);

            db.SubmitChanges();
        
        }

        //METODO elimina un pasto esistente
        private void rimuoviPasto(Pasto p)
        {

            this.pasti.Remove(p);

            db.Pasti.DeleteOnSubmit(p);

            db.SubmitChanges();

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

    }
}
