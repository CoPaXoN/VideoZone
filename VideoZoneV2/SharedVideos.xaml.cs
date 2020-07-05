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
using VideoZoneV2.InsertDataSrv;

namespace VideoZoneV2
{
    public partial class SharedVideos : UserControl
    {
        InsertClient insrt = new InsertClient();
        public SharedVideos()
        {
            InitializeComponent();
            insrt.SelectSharedVideosCompleted += insrt_SelectSharedVideosCompleted;
            insrt.SelectSharedVideosAsync(App.Current.Resources["User"].ToString());
        }

        void insrt_SelectSharedVideosCompleted(object sender, SelectSharedVideosCompletedEventArgs e)
        {
            dgSharedVideos.ItemsSource = e.Result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new WatchVideo(((TextBlock)dgSharedVideos.Columns[3].GetCellContent(dgSharedVideos.SelectedItem)).Text, ((TextBlock)dgSharedVideos.Columns[2].GetCellContent(dgSharedVideos.SelectedItem)).Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new Index();
        }
    }
}