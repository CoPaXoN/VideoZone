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
    public partial class Update : UserControl
    {
        BindingModel bm;
        public Update()
        {
            InitializeComponent();
            
            bm = new Validations.BindingModel();
            LayoutRoot.DataContext = bm;
            for (int i = 1; i <= 12; i++)
            {
                cbMM.Items.Add(i);
            }
            for (int i = 1900; i <= 2014; i++)
            {
                cbYYYY.Items.Add(i);
            }
            for (int i = 1; i <= 31; i++)
            {
                cbDD.Items.Add(i);
            }

            cbPrefix.Items.Add("050");
            cbPrefix.Items.Add("052");
            cbPrefix.Items.Add("053");
            cbPrefix.Items.Add("054");
            cbPrefix.Items.Add("057");

            string details = App.Current.Resources["Details"].ToString();
            txtUser.Text = details.Substring(0, details.IndexOf(",")).Trim();
            details = details.Remove(0, details.IndexOf(",") + 1);
            
            txtEmail.Text = details.Substring(0, details.IndexOf(","));
            details = details.Remove(0, details.IndexOf(",") + 1);

            txtPass.Password = details.Substring(0, details.IndexOf(",")).Trim();
            details = details.Remove(0, details.IndexOf(",") + 1);

            cbDD.SelectedValue = int.Parse(details.Substring(0, details.IndexOf("/")).ToString());
            details = details.Remove(0, details.IndexOf("/") + 1);

            cbMM.SelectedValue = int.Parse(details.Substring(0, details.IndexOf("/")).ToString());
            details = details.Remove(0, details.IndexOf("/") + 1);

            cbYYYY.SelectedValue = int.Parse(details.Substring(0, details.IndexOf(",")).ToString());
            details = details.Remove(0, details.IndexOf(",") + 1);

            txtAddress.Text = details.Substring(0, details.IndexOf(","));
            details = details.Remove(0, details.IndexOf(",") + 1);

            cbPrefix.SelectedValue = details.Substring(0, details.IndexOf("-")).ToString();
            details = details.Remove(0, details.IndexOf("-") + 1);

            txtPN.Text = details.Substring(0, details.Length);
            
        }
 
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
        }

        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtEmail.Text = txtEmail.Text.TrimEnd();

            LayoutRoot.DataContext = bm;
        }

        void WebService_UpdateDataCompleted(object sender, InsertDataSrv.UpdDataCompletedEventArgs e)
        {
            System.Windows.MessageBox.Show("Updated Succesfuly");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            vldSum.Errors.Clear();
            bm.ValidateAll();
            if (vldSum.Errors.Count == 0)
            {
                InsertDataSrv.InsertClient webService = new InsertDataSrv.InsertClient();
                webService.UpdDataCompleted += new EventHandler<InsertDataSrv.UpdDataCompletedEventArgs>(WebService_UpdateDataCompleted);
                webService.UpdDataAsync(txtEmail.Text, txtUser.Text, txtPass.Password, cbDD.SelectedValue + "/" + cbMM.SelectedValue + "/"
                    + cbYYYY.SelectedValue, txtAddress.Text, cbPrefix.SelectedValue + txtPN.Text);
                App.Current.Resources.Remove("Details");
                App.Current.Resources.Add("Details", txtUser.Text + "," + txtEmail.Text + "," + txtPass.Password + "," + cbDD.SelectedValue + "/" + cbMM.SelectedValue + "/"
                    + cbYYYY.SelectedValue + "," + txtAddress.Text + "," + cbPrefix.SelectedValue + txtPN.Text);
                App.Current.Resources.Remove("User");
                App.Current.Resources.Add("User", txtUser.Text);
                App.Current.Resources.Remove("Email");
                App.Current.Resources.Add("Email", txtEmail.Text);
            }
            else
            {
                
            }
     
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
        }

        private void txtPN_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new Index();
        }
    }
}
