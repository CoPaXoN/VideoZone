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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VideoZoneV2.InsertDataSrv;
using VideoZoneV2.Validations;

namespace VideoZoneV2
{
    public partial class Message : UserControl
    {
        InsertClient insrt = new InsertClient();
        BindingModel bm;
        ValidationSummaryItem usrVal = new ValidationSummaryItem("Username doesn't exist");
        int isUserExist = 0;
        private object p;
        public Message()
        {
            InitializeComponent();
            bm = new Validations.BindingModel();
            LayoutRoot.DataContext = bm;
            Back.MouseEnter += Back_MouseEnter;
            Back.MouseLeave += Back_MouseLeave;
            Back.MouseLeftButtonUp += Back_MouseLeftButtonUp;
            Send.MouseEnter += Send_MouseEnter;
            Send.MouseLeave += Send_MouseLeave;
            Send.MouseLeftButtonUp += Send_MouseLeftButtonUp;
        }

        void Send_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            vldSum.Errors.Clear();
            bm.ValidateAll();
            if (vldSum.Errors.Count == 0)
            {
                insrt.SendMsgAsync(txtSubject.Text, txtContent.Text, App.Current.Resources["User"].ToString(), txtSentTo.Text, DateTime.Now.ToString("dd/MM/yyyy H:mm:ss"));
            }
            else
            {

            }
        }

        void Send_MouseLeave(object sender, MouseEventArgs e)
        {
            Send.Source = new BitmapImage(new Uri("Images/Send.png", UriKind.Relative));
        }

        void Send_MouseEnter(object sender, MouseEventArgs e)
        {
            Send.Source = new BitmapImage(new Uri("Images/SendMouseOver.png", UriKind.Relative));
        }

        void Back_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Content = new Messages();
        }

        void Back_MouseLeave(object sender, MouseEventArgs e)
        {
            Back.Source = new BitmapImage(new Uri("Images/BackMouseOver.png", UriKind.Relative));
        }

        void Back_MouseEnter(object sender, MouseEventArgs e)
        {
            Back.Source = new BitmapImage(new Uri("Images/Back.png", UriKind.Relative));
        }

        public Message(string username, string subject)
        {
            InitializeComponent();
            bm = new Validations.BindingModel();
            LayoutRoot.DataContext = bm;

            txtSentTo.Text = username;
            txtSubject.Text = subject;
        }

        public Message(string SentTo)
        {
            txtSentTo.Text = SentTo;
            this.subject.Source = new BitmapImage(new Uri("Images/ReplayLogo.png", UriKind.Relative));

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vldSum.Errors.Clear();
            bm.ValidateAll();
            if (vldSum.Errors.Count == 0)
            {
                insrt.SendMsgAsync(txtSubject.Text, txtContent.Text, App.Current.Resources["User"].ToString(), txtSentTo.Text, DateTime.Now.ToString("dd/MM/yyyy H:mm:ss"));
            }
            else
            {

            }
        }

        private void txtSentTo_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
            insrt.findUsernameCompleted += new EventHandler<findUsernameCompletedEventArgs>(insrt_findUsernameCompleted);
            insrt.findUsernameAsync(txtSentTo.Text);
        }


        void insrt_findUsernameCompleted(object sender, findUsernameCompletedEventArgs e)
        {
            isUserExist = e.Result;
            if (e.Result == 0)
            {
                vldSum.Errors.Clear();
                vldSum.Errors.Add(usrVal);
            }
            else
            {
                vldSum.Errors.Clear();

            }
        }

        private void txtSubject_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
        }

        private void txtContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new Messages();
        }
    }
}
