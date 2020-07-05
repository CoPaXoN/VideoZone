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
using VideoZoneV2.Validations;
using VideoZoneV2.InsertDataSrv;

namespace VideoZoneV2
{
    public partial class ResetPassword : UserControl
    {
        InsertClient insrt = new InsertClient();
        BindingModel bm;
        string ans;
        public ResetPassword()
        {
            InitializeComponent();
            bm = new Validations.BindingModel();
            LayoutRoot.DataContext = bm;
            txtAns.Visibility = System.Windows.Visibility.Collapsed;
            lblSq.Visibility = System.Windows.Visibility.Collapsed;
            Next.Visibility = System.Windows.Visibility.Collapsed;
            nxt.Visibility = System.Windows.Visibility.Collapsed;
            reset.Visibility = System.Windows.Visibility.Collapsed;
            newPass.Visibility = System.Windows.Visibility.Collapsed;
            pls.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MainPage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vldSum.Errors.Clear();
            bm.ValidateAll();
            if (vldSum.Errors.Count == 0)
            {
                try
                {
                    nxt.Visibility = System.Windows.Visibility.Collapsed;
                    txtEmail.IsEnabled = false;
                }
                catch { }
                insrt.SelectAnswerCompleted += insrt_SelectAnswerCompleted;
                insrt.SelectAnswerAsync(txtEmail.Text);
            }
        }

        void insrt_SelectAnswerCompleted(object sender, SelectAnswerCompletedEventArgs e)
        {
            string result = e.Result;
            txtAns.Visibility = System.Windows.Visibility.Visible;
            lblSq.Visibility = System.Windows.Visibility.Visible;
            Next.Visibility = System.Windows.Visibility.Visible;
            ans = result.Substring(0, result.IndexOf(','));
            result = result.Remove(0, result.IndexOf(',')+1);
            lblSq.Content = result;
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ans == txtAns.Text)
            {
                pls.Visibility = System.Windows.Visibility.Visible;
                reset.Visibility = System.Windows.Visibility.Visible;
                newPass.Visibility = System.Windows.Visibility.Visible;
                try
                {
                    txtAns.IsEnabled = false;
                    lblSq.IsEnabled = false;
                    Next.Visibility = System.Windows.Visibility.Collapsed;
                }
                catch { }
            }
            else
            {
            }
        }

        void insrt_ResetPasswordCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Content = new MainPage();
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            insrt.ResetPasswordCompleted +=insrt_ResetPasswordCompleted;
            insrt.ResetPasswordAsync(txtEmail.Text, newPass.Text);
           
        }
    }
}
