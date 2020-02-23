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
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using DietManager_new.ViewModel;


namespace DietManager_new
{
    public partial class MainPage : PhoneApplicationPage
    {


        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = new MainPageVM();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult conferma = MessageBox.Show("Sei sicuro di voler uscire?", "Uscire?", MessageBoxButton.OKCancel);
            if (conferma == MessageBoxResult.OK)
            {
                while (NavigationService.CanGoBack)
                {
                    NavigationService.RemoveBackEntry();
                }
                base.OnBackKeyPress(e);
                e.Cancel = false;
            }
            else { e.Cancel = true; }
        }
        
    }
}