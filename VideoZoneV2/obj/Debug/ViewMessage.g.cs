﻿#pragma checksum "C:\Users\Hi\Documents\Visual Studio 2012\Projects\VideoZoneV2\VideoZoneV2\ViewMessage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0EF92ADFE0B27C1AD01B0E177FF1910F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace VideoZoneV2 {
    
    
    public partial class ViewMessage : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox txtSentFrom;
        
        internal System.Windows.Controls.TextBox txtSubject;
        
        internal System.Windows.Controls.TextBox txtContent;
        
        internal System.Windows.Controls.Button btn;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/VideoZoneV2;component/ViewMessage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.txtSentFrom = ((System.Windows.Controls.TextBox)(this.FindName("txtSentFrom")));
            this.txtSubject = ((System.Windows.Controls.TextBox)(this.FindName("txtSubject")));
            this.txtContent = ((System.Windows.Controls.TextBox)(this.FindName("txtContent")));
            this.btn = ((System.Windows.Controls.Button)(this.FindName("btn")));
        }
    }
}

