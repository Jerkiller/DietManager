using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DietManager_new.Model;
using DietManager_new.ViewModel;
using System.IO.IsolatedStorage;

namespace DietManager_new
{
    public partial class App : Application
    {

        public static string PathDB = "Data Source=isostore:/database.sdf";

        public static CategoriaViewModel categoriaVM;

        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;


        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Standard Silverlight initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application's PhoneApplicationService object to Disabled.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }


            appSettings.Add("Calorie", 2000);
            appSettings.Add("Carboidrati", 2000);
            appSettings.Add("Grassi", 2000);
            appSettings.Add("Proteine", 2000);
            appSettings.Add("DataCorrente", DateTime.Today);

          

           using(Database db = new Database(App.PathDB)){
               if (db.DatabaseExists() == false)
            {
                // Create the local database.
                db.CreateDatabase();

                Categoria catPanini = new Categoria { NomeCategoria = "Panini" };
                Categoria catBevande = new Categoria { NomeCategoria = "Bevande" };
                Categoria catPanificati = new Categoria { NomeCategoria = "Panificati" };



                // Prepopulate the categories.
                db.Categorie.InsertOnSubmit(catPanini);
                db.Categorie.InsertOnSubmit(catBevande);
                db.Categorie.InsertOnSubmit(catPanificati);




                // Create a new to-do item.
                db.Prodotti.InsertOnSubmit(new Prodotto
                {
                    NomeProdotto = "crispy",
                    CategoriaFK = catPanini,
                    PathFoto = "crispy.png",
                    Quantita = 1,
                    Carboidrati = 70,
                    UnitaDiMisura = "pz",
                    Grassi = 20,
                    Proteine = 10,
                    Calorie = 150,
                    Media = 1,
                    Piccola = 1,
                    Grande = 1

                }
                    );

                Prodotto p = new Prodotto
                {
                    NomeProdotto = "coca coea",
                    CategoriaFK = catBevande,
                    Quantita = 69,
                    PathFoto = "cocacoea.jpg",
                    UnitaDiMisura = "ml",
                    Carboidrati = 10,
                    Grassi = 10,
                    Proteine = 11,
                    Calorie = 200,
                    Media = 250,
                    Piccola = 500,
                    Grande = 1000
                };
                db.Prodotti.InsertOnSubmit(p);


                Prodotto p2 = new Prodotto
                {
                    NomeProdotto = "medoemedo",
                    CategoriaFK = catBevande,
                    Quantita = 100,
                    PathFoto = "cocacoea.jpg",
                    UnitaDiMisura = "ml",
                    Carboidrati = 10,
                    Grassi = 10,
                    Proteine = 11,
                    Calorie = 200,
                    Media = 250,
                    Piccola = 500,
                    Grande = 1000
                };

                db.Prodotti.InsertOnSubmit(p2);

                db.Pasti.InsertOnSubmit(new Pasto
                 {
                     ProdottoFK=p2,
                     Quantita=200,
                     Calorie = Math.Round(((200 * p2.Calorie) / p2.Quantita),2),  // quantità media prodotto : calorie prodotto = quantità assunta : calorie assunte
                     Grassi=Math.Round(((200*p2.Grassi)/p2.Quantita),2),
                     Carboidrati = Math.Round(((200 * p2.Carboidrati) / p2.Quantita),2),
                     Proteine = Math.Round(((200 * p2.Proteine) / p2.Quantita),2),
                     Data=DateTime.Today
                    });
         
                db.SubmitChanges();


                 }
        
        }

            categoriaVM = new CategoriaViewModel();

        
        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {


        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}