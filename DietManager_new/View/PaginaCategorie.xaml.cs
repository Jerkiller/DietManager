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

namespace DietManager_new.View
{
    public partial class PaginaCategorie : PhoneApplicationPage
    {
        public PaginaCategorie()
        {
            InitializeComponent();
            this.DataContext = new CategoriaViewModel();
        
        }
    }
}