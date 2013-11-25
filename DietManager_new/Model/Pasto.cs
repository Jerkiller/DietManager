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
    public class Pasto : INotifyPropertyChanged, INotifyPropertyChanging
    {
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
        [Column(IsVersion = true)]
        private Binary _version;

        //VAR: data
        private DateTime _data;
        [Column]
        public DateTime Data
        {
            get { return _data; }

            set { this._data = value; }
        }


        //VAR: Quantita del prodotto del pasto (perchè l'item ha una quantità?????)
        private int _quantita;
        [Column]
        public int Quantita
        {

            get { return this._quantita; }

            set { this._quantita = value; }

        }


        //VAR:Carboidrati totali del pasto
        private double _carboidrati;
        [Column]
        public double Carboidrati
        {

            get
            {

                return this._carboidrati;
            }

            set
            {
                this._carboidrati = value;
            }

        }

        //VAR: grassi totali del pasto
        private double _grassi;
        [Column]
        public double Grassi
        {

            get
            {

                return this._grassi;
            }

            set
            {
                this._grassi = value;
            }

        }


        //VAR: proteine totali del pasto
        private double _proteine;
        [Column]
        public double Proteine
        {

            get
            {

                return this._proteine;
            }

            set
            {
                this._proteine = value;
            }
        }


        //VAR: calorie totali del pasto
        private double _calorie;
        [Column]
        public double Calorie
        {

            get
            {

                return this._calorie;
            }

            set
            {
                this._calorie = value;
            }

        }



        // Internal column for the associated ToDoCategory ID value
        [Column]
        private int _categoriaFKInternal;
        public int CategoriaFKInternal
        {
            get { return this._categoriaFKInternal; }
            set { this._categoriaFKInternal = value; }
        }



        // Entity reference, to identify the ToDoCategory "storage" table
        private EntityRef<Prodotto> _categoriaFK;



        // Association, to describe the relationship between this key and that "storage" table
        [Association(Storage = "_categoriaFK", ThisKey = "CategoriaFKInternal", OtherKey = "ProdottoId", IsForeignKey = true)]
        public Prodotto CategoriaFK
        {
            get { return _categoriaFK.Entity; }
            set
            {
                NotifyPropertyChanging("CategoriaFK");
                _categoriaFK.Entity = value;

                if (value != null)
                {
                    _categoriaFKInternal = value.ProdottoId;
                }

                NotifyPropertyChanged("CategoriaFK");
            }
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
