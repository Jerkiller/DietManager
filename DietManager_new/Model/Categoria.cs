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
    public class Categoria : INotifyPropertyChanging, INotifyPropertyChanged
    {
 
        
        private int _idCategoria;

        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true, IsPrimaryKey = true, AutoSync = AutoSync.OnInsert)]
        public int IdCategoria
        {
            get { return _idCategoria; }
            set
            {
                NotifyPropertyChanging("IdCategoria");
                _idCategoria = value;
                NotifyPropertyChanged("IdCategoria");
            }
        }

        
        private string _nomeCategoria;
        [Column]
        public string NomeCategoria
        {
            get { return _nomeCategoria; }
            set
            {
                NotifyPropertyChanging("NomeCategoria");
                _nomeCategoria = value;
                NotifyPropertyChanged("NomeCategoria");
            }
        }

        // Version column aids update performance.
        [Column(IsVersion = true)]
        private Binary _version;
        
        //FOREIGN KEY
        private EntitySet<Prodotto> _prodottiFK;

        [Association(Storage = "_prodottiFK", OtherKey = "CategoriaFKInternal", ThisKey = "IdCategoria")]
        public EntitySet<Prodotto> ProdottiFK
        {
            get { return this._prodottiFK; }
            set { this._prodottiFK.Assign(value); }
        }



        public Categoria() {

            this._prodottiFK = new EntitySet<Prodotto>();
        
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

