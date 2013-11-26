using DietManager_new.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DietManager_new.ViewModel
{
    public class CategoriaViewModel
    {

       private DBManager db = App.dbManager;
       
       private ObservableCollection<Prodotto> _categoriaBevande;
       public ObservableCollection<Prodotto> CategoriaBevande {

           get { return this._categoriaBevande; }
           
       }

       private ObservableCollection<Prodotto> _categoriaPanini;
       public ObservableCollection<Prodotto> CategoriaPanini
       {

           get { return this._categoriaPanini; }

       }

       public CategoriaViewModel() {

           this._categoriaBevande = db.CategoriaBevande;
           this._categoriaPanini = db.CategoriaPanini;
        
       }
    }
}
