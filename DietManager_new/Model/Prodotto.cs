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
    public class Prodotto : INotifyPropertyChanged, INotifyPropertyChanging
    {


        private int _prodottoId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false)]
        public int ProdottoId
        {
            get { return _prodottoId; }
            set
            {
                if (_prodottoId != value)
                {
                    NotifyPropertyChanging("ProdottoId");
                    _prodottoId = value;
                    NotifyPropertyChanged("ProdottoId");
                }
            }
        }

        private string _nomeProdotto;
        [Column]
        public string NomeProdotto
        {
            get { return _nomeProdotto; }
            set
            {
                if (_nomeProdotto != value)
                {
                    NotifyPropertyChanging("NomeProdotto");
                    _nomeProdotto = value;
                    NotifyPropertyChanged("NomeProdotto");
                }
            }
        }

        private string pathFoto;
        [Column]
        public string PathFoto {

            get { return this.pathFoto; }
            set {
                NotifyPropertyChanging("PathFoto");
                if (this.pathFoto != value)
                    this.pathFoto = value;
                NotifyPropertyChanged("PathFoto");
            }
        }

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;

        private string _unitaDiMisura;
        [Column]
        public string UnitaDiMisura {

            get { return this._unitaDiMisura; }
            set {
                NotifyPropertyChanging("UnitaDiMisura");
                if (this._unitaDiMisura != value)
                    this._unitaDiMisura = value;
                NotifyPropertyChanged("UnitaDiMisura");
            }
        }

        // Quantita del prodotto
        private int _quantita;
        [Column]
        public int Quantita
        {

            get { return this._quantita; }

            set { this._quantita = value; }

        }


        // Carboidrati del prodotto
        private double _carboidrati;
        [Column]
        public double Carboidrati
        {

            get { return this._carboidrati; }

            set { this._carboidrati = value; }

        }

        // Grassi del prodotto
        private double _grassi;
        [Column]
        public double Grassi
        {

            get { return this._grassi; }

            set { this._grassi = value; }

        }


        // Proteine del prodotto
        private double _proteine;
        [Column]
        public double Proteine
        {

            get { return this._proteine; }

            set { this._proteine = value; }
        }


        // Calorie del prodotto
        private double _calorie;
        [Column]
        public double Calorie
        {
            get { return this._calorie; }

            set { this._calorie = value; }

        }



        // Porzione media del prodotto
        private double _media;
        [Column]
        public double Media
        {

            get { return this._media; }

            set { this._media = value; }

        }


        // Porzione small del prodotto
        private double _piccola;
        [Column]
        public double Piccola
        {

            get { return this._piccola; }

            set { this._piccola = value; }
        }


        // Porzione big del prodotto
        
        private double _grande;
        [Column]
        public double Grande
        {

            get { return this._grande; }

            set { this._grande = value; }

        }


        
        // Internal column for the associated ToDoCategory ID value
        [Column]
        private int _categoriaFKInternal;
        public int CategoriaFKInternal
        { get { return this._categoriaFKInternal; }
            set { this._categoriaFKInternal = value; }
        }

        

        // Entity reference, to identify the ToDoCategory "storage" table
        private EntityRef<Categoria> _categoriaFK;

       

        // Association, to describe the relationship between this key and that "storage" table
        [Association(Storage = "_categoriaFK", ThisKey = "_categoriaFKInternal", OtherKey = "IdCategoria", IsForeignKey = true)]
        public Categoria CategoriaFK
        {
            get { return _categoriaFK.Entity; }
            set
            {
                NotifyPropertyChanging("CategoriaFK");
                _categoriaFK.Entity = value;

                if (value != null)
                {
                    _categoriaFKInternal = value.IdCategoria;
                }

                NotifyPropertyChanged("CategoriaFK");
            }
        }

      

        //FOREIGN KEY
        private EntitySet<Pasto> _pastiFK;

        [Association(Storage = "_pastiFK", OtherKey = "ProdottoFKInternal", ThisKey = "ProdottoId")]
        public EntitySet<Pasto> PastiFK
        {
            get { return this._pastiFK; }
            set { this._pastiFK.Assign(value); }
        }

        //COSTRUTTORE
        public Prodotto() { this._pastiFK = new EntitySet<Pasto>(); }


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
