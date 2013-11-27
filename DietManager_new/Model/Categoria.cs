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

        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true, IsPrimaryKey = true)]
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

                 this._prodottiFK = new EntitySet<Prodotto>(
                new Action<Prodotto>(this.attach_ToDo),
                new Action<Prodotto>(this.detach_ToDo)
                );
        }

        // Called during an add operation
        private void attach_ToDo(Prodotto toDo)
        {
            NotifyPropertyChanging("Prodotto");
            toDo.CategoriaFK = this;
        }

        // Called during a remove operation
        private void detach_ToDo(Prodotto toDo)
        {
            NotifyPropertyChanging("Prodotto");
            toDo.CategoriaFK = null;
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

    

