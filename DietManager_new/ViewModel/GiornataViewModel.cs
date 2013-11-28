using DietManager_new.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace DietManager_new.ViewModel
{
    public class GiornataViewModel: PreviewGiornataVM, INotifyPropertyChanged
    {
        ObservableCollection<Pasto> _pastiGiorno;

        private string _data;
        public string Data {

            get { return this._data; }
            set {
                if (this._data != value) {

                    this._data = value;
                    NotifyPropertyChanged("Data");
                
                }
            
            }
        }

        public ObservableCollection<Pasto> PastiGiorno {
            get {
                return this._pastiGiorno;
            }

            set {
                if (value != this._pastiGiorno) {
                    _pastiGiorno = value;
                    NotifyPropertyChanged("PastiGiorno");
                }
            }
        
        }
       
        //COSTRUTTORE
        public GiornataViewModel():base() {
            _pastiGiorno = base.Db.PastiDelGiorno(base.DataCorrente);
            DateTime d = base.DataCorrente;
            string a = "";

            string[] mesi = {"Gennaio","Febbraio","Marzo","Aprile","Maggio","Giugno","Luglio","Agosto","Settembre","Ottobre","Novembre","Dicembre"};

            switch (d.DayOfWeek.ToString()) {


                case "Monday": a += "Lunedì"; break;

                case "Tuesday": a += "Martedì"; break;

                case "Wednesday": a += "Mercoledì"; break;

                case "Thursday": a += "Giovedì"; break;

                case "Friday": a += "Venerdì"; break;

                case "Saturday": a += "Sabato"; break;

                case "Sunday": a += "Domenica"; break;

                default:
                    break;
            }

             a +=" "+ d.Day;
            a+= " "+mesi[d.Month-1];
            a+= " "+d.Year;

            this._data = a;
        }

        //METODO rimuove un pasto dato un id
        public void RimuoviPasto(int id) {
            Pasto p = null;
            foreach (Pasto pa in this._pastiGiorno){
                if(pa.IdPasto==id){
                    p=pa;
                    break;
                }
                        
            }
            base.CalorieGiornata = CalorieGiornata - p.Calorie;
            base.CarboidratiGiornata = CarboidratiGiornata - p.Carboidrati;
            base.GrassiGiornata = GrassiGiornata - p.Grassi;
            base.ProteineGiornata = ProteineGiornata - p.Proteine;
            base.Db.rimuoviPasto(p);
            _pastiGiorno.Remove(p);

            MessageBox.Show("Prodotto rimosso correttamente");

            NotifyAll();
            
            

        }

        //METODO notifica tutte le proprietà al cambiamento di qualcosa
        public void NotifyAll()
        {
            NotifyPropertyChanged("PastiGiorno");
            NotifyPropertyChanged("CalorieGiornata");
            NotifyPropertyChanged("CaloriePreviewPercentuale");
            NotifyPropertyChanged("GrassiGiornata");
            NotifyPropertyChanged("GrassiPreviewPercentuale");
            NotifyPropertyChanged("CarboidratiGiornata");
            NotifyPropertyChanged("CarboidratiPreviewPercentuale");
            NotifyPropertyChanged("ProteineGiornata");
            NotifyPropertyChanged("ProteinePreviewPercentuale");
            NotifyPropertyChanged("StatoCalorie");
            NotifyPropertyChanged("StatoCarboidrati");
            NotifyPropertyChanged("StatoGrassi");
            NotifyPropertyChanged("StatoProteine");

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
    }
}
