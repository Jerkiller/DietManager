using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace DietManager_new.Model
{
    public class Giornata
    {

        private DateTime _data;
        public DateTime Data { get; set; }

        private string _stato;
        public string Stato {
            get {
                return _stato;
            }
            
            }

        private int _numero;
        public int Numero {
            get { return this._numero; }
        }

        private bool _avaiable;
        public bool Avaiable {
            get { return this._avaiable; }
        }

 

        //COSTRUTTORE
        public Giornata(int an, int mes, int num, string stat) {

            this._data = new DateTime(an, mes, num);
            this._stato = stat;
            _numero = num;
            if (this._data.CompareTo(DateTime.Today) <= 0)
                _avaiable = true;
            else _avaiable = false;

        
        }
    }
}
