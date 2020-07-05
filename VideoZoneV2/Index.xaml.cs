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
    public partial class Index : UserControl
    {
        
        public Index()
        {
            InitializeComponent();
            tbWelcome.Text = App.Current.Resources["User"].ToString(); 
            InsertDataSrv.InsertClient insrt = new InsertDataSrv.InsertClient();
            insrt.CountUnreadedMsgsCompleted += insrt_CountUnreadedMsgsCompleted;
            insrt.CountUnreadedMsgsAsync(App.Current.Resources["User"].ToString());
            SearchCb.Items.Add("Videos");
            SearchCb.Items.Add("Users");
            SearchCb.SelectedItem = "Videos";
            tbWelcome.MouseEnter += tbWelcome_MouseEnter;
            tbWelcome.MouseLeave += tbWelcome_MouseLeave;
            tbWelcome.Foreground = new SolidColorBrush(Colors.Blue);
            tbWelcome.MouseLeftButtonUp += tbWelcome_MouseLeftButtonUp;
            SearchBtn.MouseEnter += SearchBtn_MouseEnter;
            SearchBtn.MouseLeave += SearchBtn_MouseLeave;
            SearchBtn.MouseLeftButtonUp += SearchBtn_MouseLeftButtonUp;
            LogOut.MouseEnter += LogOut_MouseEnter;
            LogOut.MouseLeave += LogOut_MouseLeave;
            LogOut.MouseLeftButtonUp += LogOut_MouseLeftButtonUp;
            UploadVid.MouseLeftButtonUp += UploadVid_MouseLeftButtonUp;
            SharedVid.MouseLeftButtonUp += SharedVid_MouseLeftButtonUp;
            MyVideos.MouseLeftButtonUp += MyVideos_MouseLeftButtonUp;
        }

        void MyVideos_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Content = new MyVideos();
        }

        void SharedVid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Content = new SharedVideos();
        }

        void UploadVid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Content = new UploadVideo();
            
        }

        void LogOut_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Content = new MainPage();
        }

        void LogOut_MouseLeave(object sender, MouseEventArgs e)
        {
            SearchBtn.Source = new BitmapImage(new Uri("Images/LogOut.png", UriKind.Relative));
        }

        void LogOut_MouseEnter(object sender, MouseEventArgs e)
        {
            SearchBtn.Source = new BitmapImage(new Uri("Images/LogOutMouseOver.png", UriKind.Relative));
        }

        void SearchBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Content = new Search(txtSearch.Text, SearchCb.SelectedItem.ToString());
        }

        void SearchBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            SearchBtn.Source = new BitmapImage(new Uri("Images/Search.png", UriKind.Relative));
        }

        void SearchBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            SearchBtn.Source = new BitmapImage(new Uri("Images/SearchMouseOver.png", UriKind.Relative));
        }

        void tbWelcome_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Content = new Profile(tbWelcome.Text);
        }

        void tbWelcome_MouseLeave(object sender, MouseEventArgs e)
        {
            tbWelcome.TextDecorations = null;
        }

        void tbWelcome_MouseEnter(object sender, MouseEventArgs e)
        {
            tbWelcome.TextDecorations = TextDecorations.Underline;
            
            tbWelcome.Cursor = Cursors.Hand;
        }

        void insrt_CountUnreadedMsgsCompleted(object sender, CountUnreadedMsgsCompletedEventArgs e)
        {
            btnMsgs.Content += "(" + e.Result + ")";
            
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.Content = new Update();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Content =new MyVideos();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new UploadVideo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Messages();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            App.Current.Resources.Remove("User");
            App.Current.Resources.Remove("Email");
            App.Current.Resources.Remove("Details");
            this.Content = new MainPage();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Content = new Search(txtSearch.Text, SearchCb.SelectedItem.ToString());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Content = new SharedVideos();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
