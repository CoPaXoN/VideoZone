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
using System.Windows.Navigation;
using System.IO;
using VideoZoneV2.InsertDataSrv;
using VideoZoneV2.Validations;
using System.Windows.Media.Imaging;

namespace VideoZoneV2
{
    public partial class MainPage : UserControl
    {
        InsertClient insrt = new InsertClient();
        BindingModel bm;
        public MainPage()
        {
            InitializeComponent();
            bm = new Validations.BindingModel();
            LayoutRoot.DataContext = bm;
            try
            {

            }
            catch { }

            txtEmail.Text = "jg@jg.bo";
            txtPass.Password = "jgh";
            tbSignUp.Foreground = new SolidColorBrush(Colors.Blue);
            tbSignUp.MouseLeftButtonUp += tbSignUp_MouseLeftButtonUp;
            tbSignUp.MouseEnter += tbSignUp_MouseEnter;
            SignInBtn.MouseLeftButtonUp += SignInBtn_MouseLeftButtonUp;
            SignInBtn.MouseEnter += SignInBtn_MouseEnter;
            SignInBtn.MouseLeave += SignInBtn_MouseLeave;
            Forgot.MouseLeftButtonUp += Forgot_MouseLeftButtonUp;
        }

        void Forgot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Content = new ResetPassword();
        }

        void SignInBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            SignInBtn.Source = new BitmapImage(new Uri("Images/SignIn.png", UriKind.Relative));
        }

        void SignInBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            SignInBtn.Source = new BitmapImage(new Uri("Images/SignInMouseOver.png", UriKind.Relative));
        }

        void SignInBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            InsertDataSrv.InsertClient webService = new InsertDataSrv.InsertClient();
            webService.SignInCompleted += new EventHandler<InsertDataSrv.SignInCompletedEventArgs>(WebService_SignIn);
            webService.SignInAsync(txtEmail.Text, txtPass.Password);
            bm.ValidateAll();
        }

        void tbSignUp_MouseEnter(object sender, MouseEventArgs e)
        {
            tbSignUp.TextDecorations = TextDecorations.Underline;
            tbSignUp.Cursor = Cursors.Hand;
        }

        void tbSignUp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Content = new Registration();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration r = new Registration();
            this.Content = r;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Registration r = new Registration();
            this.Content = r;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ResetPassword rp = new ResetPassword();
            this.Content = rp;
        }

        void WebService_SelectCompleted(object sender, InsertDataSrv.SelectCompletedEventArgs e)
        {
            string details = e.Result;
            App.Current.Resources.Add("Details", details);

            string detail = details.Substring(0, e.Result.IndexOf(","));
            App.Current.Resources.Add("User", detail);

            details.Remove(0, details.IndexOf(",") + 1);

            detail = details.Substring(0, details.IndexOf(","));
            App.Current.Resources.Add("Email", detail);
            Index i = new Index();
            this.Content = i;
        }

        void WebService_SignIn(object sender, InsertDataSrv.SignInCompletedEventArgs e)
        {
            if (e.Result == true)
            {
                InsertDataSrv.InsertClient webService = new InsertDataSrv.InsertClient();
                webService.SelectCompleted += new EventHandler<InsertDataSrv.SelectCompletedEventArgs>(WebService_SelectCompleted);
                webService.SelectAsync(txtEmail.Text);
            }
            else
            {
                System.Windows.MessageBox.Show("Wrong email or password");
            }            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            

        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Video v = new Video();
            this.Content = v;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }
    }
}
