﻿#pragma checksum "C:\Users\Hi\Documents\Visual Studio 2012\Projects\VideoZoneV2\VideoZoneV2\SharedVideos.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "05FCD276D98F83B8165E92717C3B3879"
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
    
    
    public partial class SharedVideos : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.DataGrid dgSharedVideos;
        
        internal System.Windows.Controls.Image subject;
        
        internal System.Windows.Controls.Image Watch;
        
        internal System.Windows.Controls.Image Back;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/VideoZoneV2;component/SharedVideos.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.dgSharedVideos = ((System.Windows.Controls.DataGrid)(this.FindName("dgSharedVideos")));
            this.subject = ((System.Windows.Controls.Image)(this.FindName("subject")));
            this.Watch = ((System.Windows.Controls.Image)(this.FindName("Watch")));
            this.Back = ((System.Windows.Controls.Image)(this.FindName("Back")));
        }
    }
}

