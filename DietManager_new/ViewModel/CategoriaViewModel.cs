﻿using DietManager_new.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace DietManager_new.ViewModel
{
    public class CategoriaViewModel : INotifyPropertyChanged
    {

       private DBManager db;
       
       private ObservableCollection<Prodotto> _categoriaBevande;
       public ObservableCollection<Prodotto> CategoriaBevande {

           get { return this._categoriaBevande; }

           set {
                   
               if(this._categoriaBevande!=value){
                    NotifyPropertyChanged("CategoriaBevande");
                   this._categoriaBevande=value;
               
               }
            
           }
           
       }

       private ObservableCollection<Prodotto> _categoriaPanini;
       public ObservableCollection<Prodotto> CategoriaPanini
       {

           get { return this._categoriaPanini; }
           set {
                   
               if(this._categoriaPanini!=value){
                    NotifyPropertyChanged("CategoriaPanini");
                   this._categoriaPanini=value;
               
               }
       }
       }

       public CategoriaViewModel() {
           this.db = App.dbManager;
           this._categoriaBevande = db.CategoriaBevande;
           this._categoriaPanini = db.CategoriaPanini;

           MessageBox.Show(_categoriaBevande.Count.ToString());
           MessageBox.Show(_categoriaPanini.Count.ToString());
       
       
       
       }

         //  MessageBox.Show(_categoriaBevande[0].NomeProdotto);
   //        MessageBox.Show(_categoriaBevande[1].NomeProdotto);


           
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

        
       }
    }

