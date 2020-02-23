using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows;

namespace DietManager_new.Model
{
    public static class Dietologo
    {

        //DA METHOD controlla se il valore passato e entro i limiti 
        public static bool RISPETTALADIETA(double qntaCalorie, double qntaCarboidrati, double qntaGrassi, double qntaProteine)
        {
           


            double minQntaCalorie = App.utenteAttuale.MinCalorieUtente;
            double maxQntaCalorie = App.utenteAttuale.MaxCalorieUtente;

            double minQntaCarboidrati = App.utenteAttuale.MinCarboidratiUtente;
            double maxQntaCarboidrati = App.utenteAttuale.MaxCarboidratiUtente;

            double minQntaProteine = App.utenteAttuale.MinProteineUtente;
            double maxQntaProteine = App.utenteAttuale.MaxProteineUtente;

            double minQntaGrassi = App.utenteAttuale.MinGrassiUtente;
            double maxQntaGrassi = App.utenteAttuale.MaxGrassiUtente;



            int cont = 4;

            if (qntaCalorie < minQntaCalorie || qntaCalorie > maxQntaCalorie)
                cont--;

            if (qntaCarboidrati < minQntaCarboidrati || qntaCarboidrati > maxQntaCarboidrati)
                cont--;

            if (qntaProteine < minQntaProteine || qntaProteine > maxQntaProteine)
                cont--;

            if (qntaGrassi < minQntaGrassi || qntaGrassi > maxQntaGrassi)
                cont--;
          
            if (cont >= 3)
                return true;
            else
                return false;

        }


        /// Profilo personale
        /// <param name="uomo">True se è uomo, False se è donna</param>
        /// <param name="peso">Peso persona espresso in kg. Max = 200 kg oppure il metodo restituisce -1.0</param>
        /// <param name="altezza">Altezza persona espresso in cm. Max=250cm oppure il metodo restituisce -2.0</param>
        /// <param name="eta">Età persona espressa in anni. Max=150anni oppure il metodo restituisce -3.0</param>
        ///
        /// Le ore non epresse saranno considerate di inattività es. guardare la tv, star seduti a leggere, mangiare, ecc.
        /// <param name="sonno">Ore di sonno giornaliere</param>
        /// <param name="attLeggera">Ore settimanali di attività leggere (lavoro casalingo, in ufficio, ecc.)</param>
        /// <param name="attMedia">Ore settimanali di attività medie (lavoro casalingo, in ufficio, ecc.)</param>
        /// <param name="attMediaPesante">Ore settimanali di attività mediopesanti (lavoro casalingo, in ufficio, ecc.)</param>
        /// <param name="attPesante">Ore settimanali di attività pesanti (lavoro casalingo, in ufficio, ecc.)</param>
        /// 
        /// <returns>KCal consumate al giorno. Se l'utente ha inserito troppe ore settimanali ritorna -4.0</returns>
        public static double Tdee(bool uomo, double peso, double altezza, int eta, double sonno, double attLeggera, double attMedia, double attMediaPesante, double attPesante)
        {
            double MB, tdeeSettimanale;
            if (uomo) { MB = (66.4 + 13.7 * peso + 5 * altezza - 6.8 * eta) / 24; }
            else MB = (65.5 + 9.6 * peso + 1.8 * altezza - 4.7 * eta) / 24;

           

            double oreSonno = sonno * 7;
            double oreVitaDaBradipo = 168 - oreSonno - attLeggera - attMedia - attMediaPesante - attPesante;
            if (oreVitaDaBradipo < 0) return -4.0;

            if (uomo)
            {
                tdeeSettimanale = MB * (oreSonno + (1.5 * oreVitaDaBradipo) + (1.6 * attLeggera) + (2.25 * attMedia) + (3 * attMediaPesante) + (3.8 * attPesante));
            }
            else
            {
                tdeeSettimanale = MB * (oreSonno + (1.5 * oreVitaDaBradipo) + (1.6 * attLeggera) + (1.9 * attMedia) + (2.3 * attMediaPesante) + (2.8 * attPesante));
            }
            return Math.Round((tdeeSettimanale / 7),1);
        }

        public static double maxCalorie(double calorie)
        {
            return Math.Round((calorie * 105 / 100), 1);
        }

        public static double minCalorie(double calorie)
        {
            return Math.Round((calorie * 95 / 100), 1);
        }
        
        public static double maxProteine(double calorie) {
            return calorie * 20 / 100 / 3.1;
        }

        public static double minProteine(double calorie)
        {
            return calorie * 15 / 100 / 3.1;
        }

        public static double maxCarboidrati(double calorie)
        {
            return calorie * 55 / 100 / 3.8;
        }

        public static double minCarboidrati(double calorie)
        {
            return calorie*45/100/3.8;
        }

        public static double maxGrassi(double calorie)
        {
            return calorie * 30 / 100 / 9.3;
        }

        public static double minGrassi(double calorie)
        {
            return calorie * 25 / 100 / 9.3;
        }
    }
}
