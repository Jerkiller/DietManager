using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace DietManager_new.Model
{
    [Table]
    public class Utente : INotifyPropertyChanged, INotifyPropertyChanging
    {
        //VAR: id
        private int _idUtente;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false)]
        public int IdUtente
        {
            get { return _idUtente; }

            set
            {
                if (this._idUtente != value)
                {
                    NotifyPropertyChanging("IdUtente");
                    this._idUtente = value;
                    NotifyPropertyChanged("IdUtente");
                }
            }

        }

        //VAR: Quantita del prodotto del pasto (perchè l'item ha una quantità?????)
        private string _nome;
        [Column]
        public string Nome
        {

            get { return this._nome; }

            set
            {
                this._nome = value;
                NotifyPropertyChanged("Nome");


            }
        }

        private bool sesso;
        [Column]
        public bool Sesso
        {
            get
            {
                return sesso;
            }
            set
            {
                this.sesso = value;
                NotifyPropertyChanged("Sesso");


            }
        }

        private double minCalorie;
        [Column]
        public double MinCalorieUtente
        {
            get
            {
                return minCalorie;
            }

            set
            {
                this.minCalorie = value;
                NotifyPropertyChanged("MinCalorieUtente");


            }
        }

        private double maxCalorie;
        [Column]
        public double MaxCalorieUtente
        {
            get
            {
                return maxCalorie;
            }
            set
            {
                this.maxCalorie = value;
                NotifyPropertyChanged("MaxCalorieUtente");


            }
        }

        private double minCarboidrati;
        [Column]
        public double MinCarboidratiUtente
        {
            get
            {
                return minCarboidrati;
            }
            set
            {
                this.minCarboidrati = value;
                NotifyPropertyChanged("MinCarboidratiUtente");


            }
        }

        private double maxCarboidrati;
        [Column]
        public double MaxCarboidratiUtente
        {
            get
            {
                return maxCarboidrati;
            }
            set
            {
                this.maxCarboidrati = value;
                NotifyPropertyChanged("MaxCarboidratiUtente");


            }
        }

        private double minGrassi;
        [Column]
        public double MinGrassiUtente
        {
            get
            {
                return minGrassi;
            }
            set
            {
                this.minGrassi = value;
                NotifyPropertyChanged("MinGrassiUtente");


            }
        }

        private double maxGrassi;
        [Column]
        public double MaxGrassiUtente
        {
            get
            {
                return maxGrassi;
            }
            set
            {
                this.maxGrassi = value;
                NotifyPropertyChanged("MaxGrassiUtente");


            }
        }

        private double minProteine;
        [Column]
        public double MinProteineUtente
        {
            get
            {
                return minProteine;
            }
            set
            {
                this.minProteine = value;
                NotifyPropertyChanged("MinProteineUtente");


            }
        }

        private double maxProteine;
        [Column]
        public double MaxProteineUtente
        {
            get
            {
                return maxProteine;
            }
            set
            {
                this.maxProteine = value;
                NotifyPropertyChanged("MaxProteineUtente");


            }
        }

 //FOREIGN KEY
        private EntitySet<Pasto> _pastiFK;

        [Association(Storage = "_pastiFK", OtherKey = "UtenteFKInternal", ThisKey = "IdUtente", DeleteRule = "Set Null")]
        public EntitySet<Pasto> PastiFK
        {
            get { return this._pastiFK; }
            set { this._pastiFK.Assign(value); }
        }
       
        //COSTRUTTORE
        public Utente() { this._pastiFK = new EntitySet<Pasto>(); }


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
