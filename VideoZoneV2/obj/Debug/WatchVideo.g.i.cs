﻿#pragma checksum "C:\Users\Hi\Documents\Visual Studio 2012\Projects\VideoZoneV2\VideoZoneV2\WatchVideo.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D78ED0687F1AADAAC568A8D128B794E5"
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
    
    
    public partial class WatchVideo : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Label lblVideoname;
        
        internal System.Windows.Controls.MediaElement VideoPlayer;
        
        internal System.Windows.Controls.Slider positionSlider;
        
        internal System.Windows.Controls.Slider soundSlider;
        
        internal System.Windows.Controls.TextBlock videoPosition;
        
        internal System.Windows.Controls.Image PlayBtn;
        
        internal System.Windows.Controls.Image PauseBtn;
        
        internal System.Windows.Controls.Image StopBtn;
        
        internal System.Windows.Controls.Image DownloadBtn;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/VideoZoneV2;component/WatchVideo.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.lblVideoname = ((System.Windows.Controls.Label)(this.FindName("lblVideoname")));
            this.VideoPlayer = ((System.Windows.Controls.MediaElement)(this.FindName("VideoPlayer")));
            this.positionSlider = ((System.Windows.Controls.Slider)(this.FindName("positionSlider")));
            this.soundSlider = ((System.Windows.Controls.Slider)(this.FindName("soundSlider")));
            this.videoPosition = ((System.Windows.Controls.TextBlock)(this.FindName("videoPosition")));
            this.PlayBtn = ((System.Windows.Controls.Image)(this.FindName("PlayBtn")));
            this.PauseBtn = ((System.Windows.Controls.Image)(this.FindName("PauseBtn")));
            this.StopBtn = ((System.Windows.Controls.Image)(this.FindName("StopBtn")));
            this.DownloadBtn = ((System.Windows.Controls.Image)(this.FindName("DownloadBtn")));
            this.Back = ((System.Windows.Controls.Image)(this.FindName("Back")));
        }
    }
}

