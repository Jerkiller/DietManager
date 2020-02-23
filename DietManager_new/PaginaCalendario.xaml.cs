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
    public partial class PaginaCalendario : PhoneApplicationPage
    {
        public PaginaCalendario()
        {
            InitializeComponent();
            this.DataContext = new CalendarioViewModel();
        }

        //per tornare in dietro
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            NavigationService.Navigate(new Uri("/PaginaGiornata.xaml", UriKind.Relative));
        }

        //gesture handler
        private void GestureListener_Flick(object sender, FlickGestureEventArgs e)
        {
            if (e.Direction == System.Windows.Controls.Orientation.Horizontal)
            {
                if (e.HorizontalVelocity < 0)
                {
                    // flick right
                    ((CalendarioViewModel)this.DataContext).ProssimoMese.Execute(null);


                }
                else
                {
                    // flick left

                    ((CalendarioViewModel)this.DataContext).MesePrecedente.Execute(null);


                }
            }
            else
            {
                if (e.VerticalVelocity < 0)
                {
                    // flick up
                    

                }
                else
                {
                    // flick down
                   

                }
            }
        }
    }
}