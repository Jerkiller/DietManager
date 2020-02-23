using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DietManager_new.ViewModel;

namespace DietManager_new
{
    public partial class Profilazione5 : PhoneApplicationPage
    {
        public Profilazione5()
        {
            InitializeComponent();
            this.DataContext = App.dvm;
        }




        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            ((DietologoViewModel)this.DataContext).Prev.Execute(null);
        }

    }
}