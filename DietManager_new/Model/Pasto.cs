﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace DietManager_new.Model
{
    [Table]
    public class Pasto : INotifyPropertyChanged, INotifyPropertyChanging,IComparable<Pasto>
    {
        public int CompareTo(Pasto p) {
            if (p.IdPasto < IdPasto)
                return 1;
            else return -1;
        }




        //VAR: id
        private int _idPasto;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false)]
        public int IdPasto
        {
            get { return _idPasto; }

            set
            {
                if (this._idPasto != value)
                {
                    NotifyPropertyChanging("IdPasto");
                    this._idPasto = value;
                    NotifyPropertyChanged("IdPasto");
                }
            }

        }

        //VAR: (performance)
       /* [Column(IsVersion = true)]
        private Binary _version;*/

        //VAR: data
        private DateTime _data;
        [Column]
        public DateTime Data
        {
            get { return _data; }

            set { this._data = value; }
        }


        //VAR: Quantita del prodotto del pasto (perchè l'item ha una quantità?????)
        private double _quantita;
        [Column]
        public double Quantita
        {

            get { return this._quantita; }

            set
            {
                this._quantita = value;
                NotifyPropertyChanged("Quantita");
                /*Calorie = Math.Round(((_quantita * ProdottoFK.Calorie) / ProdottoFK.Quantita), 2);
                Grassi = Math.Round(((_quantita * ProdottoFK.Grassi) / ProdottoFK.Quantita), 2);
                Carboidrati = Math.Round(((_quantita * ProdottoFK.Carboidrati) / ProdottoFK.Quantita), 2);
                Proteine = Math.Round(((_quantita * ProdottoFK.Proteine) / ProdottoFK.Quantita), 2);*/

            }
        }


        //VAR:Carboidrati totali del pasto
        private double _carboidrati;
        [Column]
        public double Carboidrati
        {

            get{return this._carboidrati;}

            set{this._carboidrati = value;}

        }

        //VAR: grassi totali del pasto
        private double _grassi;
        [Column]
        public double Grassi
        {

            get {return this._grassi;}

            set {this._grassi = value;}

        }


        //VAR: proteine totali del pasto
        private double _proteine;
        [Column]
        public double Proteine
        {

            get { return this._proteine;}

            set { this._proteine = value; }
        }


        //VAR: calorie totali del pasto
        private double _calorie;
        [Column]
        public double Calorie
        {

            get { return this._calorie; }

            set { this._calorie = value; }

        }

        

        // Internal column for the associated ToDoCategory ID value
       
        private int _prodottoFKInternal;
        [Column]
        public int ProdottoFKInternal
        {
            get { return this._prodottoFKInternal; }
            set { this._prodottoFKInternal = value; }
        }



        // Entity reference, to identify the ToDoCategory "storage" table
        private EntityRef<Prodotto> _prodottoFK;



        // Association, to describe the relationship between this key and that "storage" table
        [Association(Storage = "_prodottoFK", ThisKey = "ProdottoFKInternal", OtherKey = "ProdottoId", IsForeignKey = true)]
        public Prodotto ProdottoFK
        {
            get { return _prodottoFK.Entity; }
            set
            {
                NotifyPropertyChanging("ProdottoFK");
                _prodottoFK.Entity = value;

                if (value != null)
                {
                    _prodottoFKInternal = value.ProdottoId;
                }

                NotifyPropertyChanged("ProdottoFK");
            }
        }

        // Internal column for the associated ToDoCategory ID value

        private int _utenteFKInternal;
        [Column]
        public int UtenteFKInternal
        {
            get { return this._utenteFKInternal; }
            set { this._utenteFKInternal = value; }
        }


        // Entity reference, to identify the ToDoCategory "storage" table
        private EntityRef<Utente> _utenteFK;



        // Association, to describe the relationship between this key and that "storage" table
        [Association(Storage = "_utenteFK", ThisKey = "UtenteFKInternal", OtherKey = "IdUtente", IsForeignKey = true, DeleteRule="Cascade", DeleteOnNull=true)]
        public Utente UtenteFK
        {
            get { return _utenteFK.Entity; }
            set
            {
                NotifyPropertyChanging("UtenteFK");
                _utenteFK.Entity = value;

                if (value != null)
                {
                    _prodottoFKInternal = value.IdUtente;
                }

                NotifyPropertyChanged("UtenteFK");
            }
        }



        public string NomeProdotto {
            get { return ProdottoFK.NomeProdotto; }
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
