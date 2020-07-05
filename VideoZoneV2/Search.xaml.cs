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
    public partial class Search : UserControl
    {
        InsertClient insrt = new InsertClient();
        int flag = 0;

        public Search()
        {
            InitializeComponent();
            SearchCb.Items.Add("Videos");
            SearchCb.Items.Add("Users");
            SearchCb.SelectedItem = "Videos";
        }

        public Search(string txtSearch, string searchCb)
        {
            SearchCb.SelectedItem = searchCb;
            SearchTxt.Text = txtSearch;
            if (SearchCb.SelectedItem.ToString() == "Videos")
            {
                flag = 0; // video searched
                insrt.SearchVideosCompleted += insrt_SearchVideosCompleted;
                insrt.SearchVideosAsync(SearchTxt.Text);

            }
            else
            {
                flag = 1; // user searched
                insrt.SearchUsersCompleted += insrt_SearchUsersCompleted;
                insrt.SearchUsersAsync(SearchTxt.Text);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SearchCb.SelectedItem.ToString() == "Videos")
            {
                flag = 0; // video searched
                insrt.SearchVideosCompleted += insrt_SearchVideosCompleted;
                insrt.SearchVideosAsync(SearchTxt.Text);
                
            }
            else
            {
                flag = 1; // user searched
                insrt.SearchUsersCompleted += insrt_SearchUsersCompleted;
                insrt.SearchUsersAsync(SearchTxt.Text);
            }


        }

        void insrt_SearchUsersCompleted(object sender, SearchUsersCompletedEventArgs e)
        {
            dgResults.ItemsSource = e.Result;
        }

        void insrt_SearchVideosCompleted(object sender, SearchVideosCompletedEventArgs e)
        {
            dgResults.ItemsSource = e.Result;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (flag == 0)
            {
                this.Content = new WatchVideo(((TextBlock)dgResults.Columns[2].GetCellContent(dgResults.SelectedItem)).Text, ((TextBlock)dgResults.Columns[1].GetCellContent(dgResults.SelectedItem)).Text);
            }
            else
            {
                this.Content = new Profile(((TextBlock)dgResults.Columns[0].GetCellContent(dgResults.SelectedItem)).Text);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Content = new Index();
        }
    }
}
