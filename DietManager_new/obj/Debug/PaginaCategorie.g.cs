﻿#pragma checksum "C:\Users\pc\Documents\GitHub\DietManager\DietManager_new\PaginaCategorie.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C68316DA5604189B7E8820F8912822F9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.18051
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace DietManager_new {
    
    
    public partial class PaginaCategorie : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ListBox listaPanini;
        
        internal System.Windows.Controls.ListBox listaBevande;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton newTaskAppBarButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/DietManager_new;component/PaginaCategorie.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.listaPanini = ((System.Windows.Controls.ListBox)(this.FindName("listaPanini")));
            this.listaBevande = ((System.Windows.Controls.ListBox)(this.FindName("listaBevande")));
            this.newTaskAppBarButton = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("newTaskAppBarButton")));
        }
    }
}

