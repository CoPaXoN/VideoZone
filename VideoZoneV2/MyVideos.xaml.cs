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
    public partial class MyVideos : UserControl
    {
        InsertClient insrt = new InsertClient();
        public MyVideos()
        {
            InitializeComponent();
            insrt.SelectVideosCompleted += insrt_SelectVideosCompleted;
            insrt.SelectVideosAsync(App.Current.Resources["User"].ToString());
            dgMyVideos.SelectedIndex = 0;
            
        }

        void insrt_SelectVideosCompleted(object sender, SelectVideosCompletedEventArgs e)
        {
            this.dgMyVideos.ItemsSource = e.Result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new UploadVideo();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new WatchVideo(((TextBlock)dgMyVideos.Columns[3].GetCellContent(dgMyVideos.SelectedItem)).Text, ((TextBlock)dgMyVideos.Columns[2].GetCellContent(dgMyVideos.SelectedItem)).Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Content = new Index();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            insrt.DeleteVideoCompleted += insrt_DeleteVideoCompleted;
            insrt.DeleteVideoAsync(((TextBlock)dgMyVideos.Columns[3].GetCellContent(dgMyVideos.SelectedItem)).Text, ((TextBlock)dgMyVideos.Columns[2].GetCellContent(dgMyVideos.SelectedItem)).Text);
        }

        void insrt_DeleteVideoCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Content = new MyVideos();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Content = new UpdateVideo(((TextBlock)dgMyVideos.Columns[3].GetCellContent(dgMyVideos.SelectedItem)).Text);
        }
    }
}
