using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml.Linq;

namespace DietManager_new.Model
{
    public static class ProductLoader
    {

        private static XDocument doc = XDocument.Load("Prodotti.xml");

        public static List<Prodotto> caricaProdotti(Categoria cat)
        {

            List<Prodotto> prodotti = new List<Prodotto>();
            
            var categoriacorrente = from query in doc.Descendants("Categoria")
                                    where query.Attribute("id").Value == cat.NomeCategoria
                                    select query;
            var prod = from query2 in categoriacorrente.Descendants("Prodotto")
                       select query2;

            List<XElement> i = prod.ToList();
            for (int j = 0; j < i.Count; j++)
            {

                //seleziono il testo della domanda
                var nome = from query in i[j].Descendants("Nome")
                           select query;
                var pathFoto = from query in i[j].Descendants("PathFoto")
                               select query;
                var unitaDiMisura = from query in i[j].Descendants("UnitaDiMisura")
                                    select query;
                var quantita = from query in i[j].Descendants("Quantita")
                               select query;
                var calorie = from query in i[j].Descendants("Calorie")
                              select query;
                var carboidrati = from query in i[j].Descendants("Carboidrati")
                                  select query;
                var grassi = from query in i[j].Descendants("Grassi")
                             select query;
                var proteine = from query in i[j].Descendants("Proteine")
                               select query;
                var piccola = from query in i[j].Descendants("Piccola")
                              select query;
                var media = from query in i[j].Descendants("Media")
                            select query;
                var grande = from query in i[j].Descendants("Grande")
                             select query;
                
                prodotti.Add(new Prodotto
                    {
                        NomeProdotto = nome.ToList()[0].Value,
                        CategoriaFK = cat,
                        Quantita = Convert.ToInt32(quantita.ToList()[0].Value),
                        PathFoto = pathFoto.ToList()[0].Value,
                        UnitaDiMisura = unitaDiMisura.ToList()[0].Value,
                        Carboidrati = Convert.ToDouble(carboidrati.ToList()[0].Value),
                        Grassi = Convert.ToDouble(grassi.ToList()[0].Value),
                        Proteine = Convert.ToDouble(proteine.ToList()[0].Value),
                        Calorie = Convert.ToDouble(calorie.ToList()[0].Value),
                        Piccola = Convert.ToDouble(piccola.ToList()[0].Value),
                        Media = Convert.ToDouble(media.ToList()[0].Value),
                        Grande = Convert.ToDouble(grande.ToList()[0].Value),
                    });
            }
            return prodotti;
        }

        public static List<Categoria> caricaCategorie()
        {
            List<Categoria> categorie = new List<Categoria>();
            var cats = from query in doc.Descendants("Categoria")
                      select query;
            List<XElement> i = cats.ToList();
            for (int j = 0; j < i.Count; j++)
            {
                var nome = i[j].Attribute("id").Value;
                categorie.Add(new Categoria { NomeCategoria = nome.ToString() });
            }
            return categorie;


        }
    }
}
