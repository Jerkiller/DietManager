﻿#pragma checksum "C:\Users\Francesco\Documents\GitHub\DietManager\DietManager_new\PaginaGiornata.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6D07E3F5242CFBD4BD17FA31412ABCAA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
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
    
    
    public partial class PaginaGiornata : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid Add;
        
        internal System.Windows.Controls.ListBox FirstListBox;
        
        internal System.Windows.Controls.Grid Situazione;
        
        internal System.Windows.Controls.Button Calendario;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/DietManager_new;component/PaginaGiornata.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Add = ((System.Windows.Controls.Grid)(this.FindName("Add")));
            this.FirstListBox = ((System.Windows.Controls.ListBox)(this.FindName("FirstListBox")));
            this.Situazione = ((System.Windows.Controls.Grid)(this.FindName("Situazione")));
            this.Calendario = ((System.Windows.Controls.Button)(this.FindName("Calendario")));
        }
    }
}

