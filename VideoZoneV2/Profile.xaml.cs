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
    public partial class Profile : UserControl
    {
        InsertClient insrt = new InsertClient();
        public Profile(string username)
        {
            InitializeComponent();
            lblProfile.Content = username;
            insrt.SelectByUsernameCompleted += insrt_SelectByUsernameCompleted;
            insrt.SelectByUsernameAsync(username);
        }

        void insrt_SelectByUsernameCompleted(object sender, SelectByUsernameCompletedEventArgs e)
        {
            string result = e.Result;
            result = result.Remove(0, result.IndexOf(",") + 1);
            tbEmail.Text = result.Substring(0, result.IndexOf(","));
            result = result.Remove(0, result.IndexOf(",") + 1);
            result = result.Remove(0, result.IndexOf(",") + 1);
            tbDob.Text = result.Substring(0, result.IndexOf(","));
            result = result.Remove(0, result.IndexOf(",") + 1);
            tbAdress.Text = result.Substring(0, result.IndexOf(","));
            result = result.Remove(0, result.IndexOf(",") + 1);
            tbPN.Text = result.Substring(0, result.Length);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Index();
        }

        private void Back_Copy1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Content = new Message(lblProfile.Content);
        }


    }
}
