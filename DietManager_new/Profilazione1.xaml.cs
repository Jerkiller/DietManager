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
using DietManager_new.ViewModel;

namespace DietManager_new
{
    public partial class Profilazione1 : PhoneApplicationPage
    {
        public Profilazione1()
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