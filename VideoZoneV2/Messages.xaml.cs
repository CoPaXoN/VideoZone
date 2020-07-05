using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
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
    public partial class Messages : UserControl
    {
        InsertDataSrv.InsertClient insrt = new InsertDataSrv.InsertClient();
        string[] selectedMsgIds;
        public Messages()
        {
            InitializeComponent();
            
            insrt.SelectViewMsgsCompleted += new EventHandler<InsertDataSrv.SelectViewMsgsCompletedEventArgs>(WebService_SelectViewMsgsCompleted);
            insrt.SelectViewMsgsAsync(App.Current.Resources["User"].ToString());
            dgViewMsgs.CurrentCellChanged += dgViewMsgs_CurrentCellChanged;
            Delete.MouseLeftButtonUp += Delete_MouseLeftButtonUp;
            Delete.MouseEnter += Delete_MouseEnter;
            View.MouseLeftButtonUp += View_MouseLeftButtonUp;
            WriteMsg.MouseLeftButtonUp += Button_Click_1;
            Back.MouseLeftButtonUp += Button_Click_2;
        }

        void Delete_MouseEnter(object sender, MouseEventArgs e)
        {
            Delete.Source = new BitmapImage(new Uri("Images/DeleteMouseOver.png", UriKind.Relative));
        }

        void View_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Content = new ViewMessage(int.Parse(((TextBlock)dgViewMsgs.Columns[0].GetCellContent(dgViewMsgs.SelectedItem)).Text));
        }

        void Delete_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string s = "";
            insrt.DeleteMsgsCompleted += insrt_DeleteMsgsCompleted;
            for (int i = 0; i < dgViewMsgs.SelectedItems.Count; i++)
            {
                s += ((TextBlock)dgViewMsgs.Columns[0].GetCellContent(dgViewMsgs.SelectedItems[i])).Text + ",";
            }

            insrt.DeleteMsgsAsync(s);
        }

        void dgViewMsgs_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        void WebService_SelectViewMsgsCompleted(object sender, SelectViewMsgsCompletedEventArgs e)
        {
            dgViewMsgs.ItemsSource = e.Result;
            selectedMsgIds = new string[dgViewMsgs.SelectedItems.Count];
   
        }


        void insrt_DeleteMsgsCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Content = new Messages();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new ViewMessage();
        }

        private void dgViewMsgs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //selectedMsgIds[selectedCount] == 
            //selectedCount++;
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Content = new Index();
        }
    }
}
