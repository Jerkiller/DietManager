using DietManager_new.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DietManager_new.ViewModel
{
    public class GiornataViewModel: PreviewGiornataVM, INotifyPropertyChanged
    {
        ObservableCollection<Pasto> _pastiGiorno;
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
        public GiornataViewModel():base() {
            _pastiGiorno = base.Db.PastiDelGiorno(base.DataCorrente);
        }

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
            NotifyAll();
            
            

        }

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
