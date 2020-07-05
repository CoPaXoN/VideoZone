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

namespace VideoZoneV2
{
    public partial class ViewMessage : UserControl
    {
        InsertClient insrt = new InsertClient();
        public ViewMessage(int msgID)
        {
            InitializeComponent();
            insrt.SelectMsgCompleted += new EventHandler<SelectMsgCompletedEventArgs>(insrt_SelectMsgCompleted);
            insrt.SelectMsgAsync(msgID);
            
        }
        
        void insrt_SelectMsgCompleted(object sender, SelectMsgCompletedEventArgs e)
        {
            string result = e.Result;
            txtSentFrom.Text = result.Substring(0, result.IndexOf(","));
            result = result.Remove(0, result.IndexOf(",") + 1);

            txtSubject.Text = result.Substring(0, result.IndexOf(","));
            result = result.Remove(0, result.IndexOf(",") + 1);

            txtContent.Text = result.Substring(0, result.Length);
            txtContent.IsEnabled = false;
            txtSentFrom.IsEnabled = false;
            txtSubject.IsEnabled = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Message(txtSentFrom.Text, txtSubject.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new Messages();
        }
    }
}
