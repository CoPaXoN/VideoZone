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
    public partial class Registration : UserControl
    {
        BindingModel bm;
        ValidationSummaryItem usrVal = new ValidationSummaryItem("Username is already exist");
        ValidationSummaryItem emlVal = new ValidationSummaryItem("Email is already exist");
        int isUserExist = 0, isEmailExist = 0;
        InsertClient insrt = new InsertClient();
        public Registration()
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
            
             
            cbPrefix.Items.Add("050");
            cbPrefix.Items.Add("052");
            cbPrefix.Items.Add("053");
            cbPrefix.Items.Add("054");
            cbPrefix.Items.Add("057");

            cbSQ.Items.Add("where you have borned ?");
            cbSQ.Items.Add("what is the name of your favirate teacher ?");
            cbSQ.Items.Add("where your parnets borned ?");
            cbSQ.Items.Add("when you said your first words ?");
            usrVal.MessageHeader = "Username: ";
            emlVal.MessageHeader = "Email: ";

            cbDD.SelectedItem = 1;
            cbMM.SelectedItem = 1;
            cbYYYY.SelectedIndex = 0;
            cbPrefix.SelectedIndex = 0;
            cbSQ.SelectedIndex = 0;
     
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            vldSum.Errors.Clear();
            bm.ValidateAll();
            if (isUserExist > 0)
            {
                vldSum.Errors.Add(usrVal);
            }
            
            if (isEmailExist > 0)
            {
                vldSum.Errors.Add(emlVal);
            }

            if (vldSum.Errors.Count == 0)
            {

                insrt.InsertDataAsync(txtUser.Text, txtPass.Password, txtEmail.Text, cbDD.SelectedItem.ToString() + @"/"
                + cbMM.SelectedItem.ToString() + @"/" + cbYYYY.SelectedItem.ToString()
                , txtAddress.Text, cbPrefix.SelectedItem.ToString() + "-" + txtPN.Text, cbSQ.SelectedIndex, txtAnswer.Text); 
                System.Windows.MessageBox.Show("You Have Registed succefuly");

            }
        }


        void insrt_findUsernameCompleted(object sender, findUsernameCompletedEventArgs e)
        {
            isUserExist = e.Result;
            if (e.Result > 0)
            {
                vldSum.Errors.Clear();
                vldSum.Errors.Add(usrVal);
                if (isEmailExist > 0) { vldSum.Errors.Add(emlVal); }
            }
            else
            {
                vldSum.Errors.Clear();

                if (isEmailExist > 0) { vldSum.Errors.Add(emlVal); }
            }
        }

        void insrt_findEmailCompleted(object sender, findEmailCompletedEventArgs e)
        {

            isEmailExist = e.Result;
            if (e.Result > 0)
            {
                vldSum.Errors.Clear();
                vldSum.Errors.Add(emlVal);
                if (isUserExist > 0) { vldSum.Errors.Add(usrVal); }
            }
            else
            {
                vldSum.Errors.Clear();
                if (isUserExist > 0) { vldSum.Errors.Add(usrVal); }
            }
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
            insrt.findUsernameCompleted += new EventHandler<findUsernameCompletedEventArgs>(insrt_findUsernameCompleted);
            insrt.findUsernameAsync(txtUser.Text);
        }

        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
            insrt.findEmailCompleted += new EventHandler<findEmailCompletedEventArgs>(insrt_findEmailCompleted);
            insrt.findEmailAsync(txtEmail.Text);
        }

        private void cbMM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 1,3,5,7,8,12-31 2-28/29 4,6,10,11,-30
            if (cbMM.SelectedItem.ToString() == "1" || cbMM.SelectedItem.ToString() == "3"
             || cbMM.SelectedItem.ToString() == "5" || cbMM.SelectedItem.ToString() == "7"
             || cbMM.SelectedItem.ToString() == "8" || cbMM.SelectedItem.ToString() == "12")
            {
                while(cbDD.Items.Any())
                {
                    cbDD.Items.RemoveAt(0);
                }
                for (int i = 1; i <= 31; i++)
                {
                    cbDD.Items.Add(i);
                }
            }
            if (cbMM.SelectedItem.ToString() == "4" || cbMM.SelectedItem.ToString() == "6"
             || cbMM.SelectedItem.ToString() == "10" || cbMM.SelectedItem.ToString() == "11")
            {
                while (cbDD.Items.Any())
                {
                    cbDD.Items.RemoveAt(0);
                }
                for (int i = 1; i <= 30; i++)
                {
                    cbDD.Items.Add(i);
                }
            }
            if (cbMM.SelectedItem.ToString() == "2")
            {
                while (cbDD.Items.Any())
                {
                    cbDD.Items.RemoveAt(0);
                }
                if (int.Parse(cbYYYY.SelectedItem.ToString()) % 4 == 0)
                    for (int i = 1; i <= 29; i++)
                    {
                        cbDD.Items.Add(i);
                    }
                else
                {
                    for (int i = 1; i <= 28; i++)
                    {
                        cbDD.Items.Add(i);
                    }
                }
            }
        }

        private void cbYYYY_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbMM.SelectedItem.ToString() == "2")
            {
                while (cbDD.Items.Any())
                {
                    cbDD.Items.RemoveAt(0);
                }
                if (int.Parse(cbYYYY.SelectedItem.ToString()) % 4 == 0)
                    for (int i = 1; i <= 29; i++)
                    {
                        cbDD.Items.Add(i);
                    }
                else
                {
                    for (int i = 1; i <= 28; i++)
                    {
                        cbDD.Items.Add(i);
                    }
                }
            }
        }

        private void txtPN_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
        }

        private void vldSum_FocusingInvalidControl(object sender, FocusingInvalidControlEventArgs e)
        {

        }

        private void txtAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MainPage();
        }
    }
}