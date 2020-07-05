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
using VideoZoneV2.Validations;

namespace VideoZoneV2
{
    public partial class UpdateVideo : UserControl
    {
        InsertClient insrt = new InsertClient();
        BindingModel bm;
        bool isVideoExist;
        public UpdateVideo(string videoname)
        {
            InitializeComponent();
            cbCategory.Items.Add("Entertainment");
            cbCategory.Items.Add("Music");
            cbCategory.Items.Add("Games");
            cbCategory.Items.Add("Sport");
            cbCategory.Items.Add("Health");
            cbCategory.Items.Add("Education");
            cbCategory.Items.Add("Science and Technology");
            cbCategory.Items.Add("Political");
            cbCategory.Items.Add("Economy");
            cbCategory.Items.Add("Other");
            
            bm = new Validations.BindingModel();
            LayoutRoot.DataContext = bm;
            insrt.SelectVideoCompleted += insrt_SelectVideoCompleted;
            insrt.SelectVideoAsync(videoname, App.Current.Resources["User"].ToString());
            txtVideoName.Text = videoname;
        }
        
        void insrt_SelectVideoCompleted(object sender, SelectVideoCompletedEventArgs e)
        {
            string result = e.Result;
            result = result.Remove(0, result.IndexOf(",") + 1);
            cbCategory.SelectedItem = result.Substring(0, result.IndexOf(","));
            result = result.Remove(0, result.IndexOf(",") + 1);

            if (result.Substring(0, result.Length) == "everyone")
            {
                try
                {
                    EveryoneCb.IsChecked = true;
                    ShareTxt.IsEnabled = false;
                }
                catch { }
            }
            else
            {
                try
                {
                    EveryoneCb.IsChecked = false;
                    ShareTxt.IsEnabled = true;
                    ShareTxt.Text = result.Substring(0, result.Length);
                }
                catch { }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MyVideos();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vldSum.Errors.Clear();
            bm.ValidateAll();
            if (vldSum.Errors.Count == 0)
            {
                insrt.UpdateVideoCompleted += insrt_UpdateVideoCompleted;
                if (EveryoneCb.IsChecked == true)
                    insrt.UpdateVideoAsync(txtVideoName.Text, App.Current.Resources["User"].ToString(), cbCategory.SelectedItem.ToString(), "everyone");
                else
                    insrt.UpdateVideoAsync(txtVideoName.Text, App.Current.Resources["User"].ToString(), cbCategory.SelectedItem.ToString(), ShareTxt.Text);
            }
        }

        void insrt_UpdateVideoCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            
        }
        private void EveryoneCb_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                ShareTxt.IsEnabled = false;
            }
            catch { }
        }

        private void EveryoneCb_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                ShareTxt.IsEnabled = true;
            }
            catch { }
        }

        private void txtVideoName_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
            insrt.findVideoCompleted += insrt_findVideoCompleted;
            insrt.findVideoAsync(txtVideoName.Text, App.Current.Resources["User"].ToString());
        }

        void insrt_findVideoCompleted(object sender, findVideoCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShareTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
            insrt.isUsernamesExistCompleted += insrt_isUsernamesExistCompleted;
            insrt.isUsernamesExistAsync(ShareTxt.Text);
        }
        string UsersNotExist = "";
        void insrt_isUsernamesExistCompleted(object sender, isUsernamesExistCompletedEventArgs e)
        {
            UsersNotExist = e.Result;

            if (UsersNotExist == "")
            {
                vldSum.Errors.Clear();
                bm.ValidateAll();
            }
            else
            {
                ValidationSummaryItem vsiUE = new ValidationSummaryItem("Users doesn't exist:" + UsersNotExist);
                vldSum.Errors.Clear();
                bm.ValidateAll();
                vldSum.Errors.Add(vsiUE);
            }

        }
    }
}
