using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace DietManager_new.Model
{
    public class Database : DataContext
    {


        public Table<Prodotto> Prodotti;

        public Table<Categoria> Categorie;
        public Table<Pasto> Pasti;


        // Pass the connection string to the base class.
        public Database(string dbconnection) : base(dbconnection)
        {
                if (this.DatabaseExists() == false)
                {
                    // Create the local database.
             
            
                    this.CreateDatabase();

                    Categoria catPanini = new Categoria { NomeCategoria = "Panini" };
                    Categoria catBevande = new Categoria { NomeCategoria = "Bevande" };
                    Categoria catPanificati = new Categoria { NomeCategoria = "Panificati" };

                    // Prepopulate the categories.
                    this.Categorie.InsertOnSubmit(catPanini);
                    this.Categorie.InsertOnSubmit(catBevande);
                    this.Categorie.InsertOnSubmit(catPanificati);
                    /*
                    // Create a new to-do item.
                    this.Prodotti.InsertOnSubmit(new Prodotto
                    {
                        NomeProdotto = "panin col prossiuto",
                        CategoriaFK = catPanini,
                        Quantita = 100,
                        Carboidrati = 70,
                        Grassi = 20,
                        Proteine = 10,
                        Calorie = 150,
                        Media = 100,
                        Piccola = 50,
                        Grande = 150

                    }
                        );

                    this.Prodotti.InsertOnSubmit(new Prodotto
                    {
                        NomeProdotto = "coca coea",
                        CategoriaFK = catBevande,
                        Quantita = 69,
                        Carboidrati = 10,
                        Grassi = 10,
                        Proteine = 11,
                        Calorie = 200,
                        Media = 250,
                        Piccola = 500,
                        Grande = 1000
                    }
                       );*/

                    this.SubmitChanges();
                }
            }

        
        
        }


    

    }



