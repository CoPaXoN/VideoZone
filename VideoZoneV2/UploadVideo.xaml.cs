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
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using VideoZoneV2.Validations;
using VideoZoneV2.UploadService;
using VideoZoneV2.InsertDataSrv;

namespace VideoZoneV2
{
    public partial class UploadVideo : UserControl
    {
        InsertClient insrt = new InsertClient();
        ObservableCollection<UploadFile> _files;
        ValidationSummaryItem vdVal = new ValidationSummaryItem("Video name is already exist");
        const int CHUNKSIZE = 30000; //30KB
        BindingModel bm;
        bool isVideoExist;
        
        public UploadVideo()
        {
            InitializeComponent();
            bm = new Validations.BindingModel();
            LayoutRoot.DataContext = bm;
            _files = new ObservableCollection<UploadFile>();
            lbl1.Content += " " + App.Current.Resources["User"].ToString(); ;
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
            cbCategory.SelectedItem = "Other";
            
            //EveryoneCb.IsEnabledChanged += EveryoneCb_IsEnabledChanged;
            txtVideoName.LostFocus += txtVideoName_LostFocus;

        }

        void txtVideoName_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void FileButton_Click(object sender, RoutedEventArgs e)
        {
            vldSum.Errors.Clear();
            bm.ValidateAll();
            if (isVideoExist == true)
            {
                vldSum.Errors.Clear();
                vldSum.Errors.Add(vdVal);
            }
            if (vldSum.Errors.Count == 0)
            {
                OpenFileDialog d = new OpenFileDialog();
                d.Filter = "Video (*.wmv, *.mp4, *.avi) |*.wmv;*.mp4;*.avi;";
                d.Multiselect = false;

                if (d.ShowDialog() == true)
                {
                    foreach (FileInfo f in d.Files)
                    {
                        UploadFile file = _files.SingleOrDefault(m => m.Name == f.Name);
                        if (file == null)
                        {
                            file = new UploadFile();
                            file.Name = f.Name;
                            Stream s = f.OpenRead();
                            file.Size = s.Length / 1000;
                            int chunkSize = (int)s.Length;
                            file.Contents = new List<byte[]>();
                            while (s.Position > -1 && s.Position < s.Length)
                            {
                                if (s.Length - s.Position >= CHUNKSIZE)
                                    chunkSize = CHUNKSIZE;
                                else
                                    chunkSize = (int)(s.Length - s.Position);

                                byte[] fileBytes = new byte[chunkSize];
                                int byteCount = s.Read(fileBytes, 0, chunkSize);
                                file.Contents.Add(fileBytes);
                            }
                            s.Close();
                            _files.Add(file);
                            SendFile(file, false);
                        }
                    }
                    FileList.ItemsSource = _files;
                    FileList.Visibility = Visibility.Visible;
                }
            } 
        }

        void insrt_findVideoCompleted(object sender, findVideoCompletedEventArgs e)
        {
            isVideoExist = e.Result;
            if (isVideoExist)
            {
                vldSum.Errors.Clear();
                vldSum.Errors.Add(vdVal);
            }
            
            
        }

        void SendFile(UploadFile file, bool append)
        {
            var fs = new UploadService.UploadClient();
            fs.DoUploadCompleted += new EventHandler<VideoZoneV2.UploadService.DoUploadCompletedEventArgs>(fs_DoUploadCompleted);
            if (EveryoneCb.IsChecked == true)
            {
                fs.DoUploadAsync(txtVideoName.Text, App.Current.Resources["User"].ToString(), file.Name, cbCategory.SelectedItem.ToString(), "everyone", file.Contents[0], append);
            }
            else
            {
                for (int i = 0; i < ShareTxt.Text.Count(f => f == ','); i++)
                {

                }
                fs.DoUploadAsync(txtVideoName.Text, App.Current.Resources["User"].ToString(), file.Name, cbCategory.SelectedItem.ToString(), ShareTxt.Text, file.Contents[0], append);
            }
           
        }

        void fs_DoUploadCompleted(object sender, UploadService.DoUploadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                UploadService.UploadFile fi = e.Result;
                UploadFile f = _files.Single(m => m.Name == fi.Name);
                if (f.Contents.Count > 0)
                {
                    f.Contents.RemoveAt(0);
                }
                if (f.Contents.Count == 0)
                {
                    f.UploadPercentage = 100;
                    f.Loaded = true;
                }
                else
                {
                    f.UploadPercentage = 100 - Convert.ToInt16(((f.Contents.Count - 1) * CHUNKSIZE + f.Contents[f.Contents.Count - 1].Length) * 0.1 / f.Size);
                    SendFile(f, true);
                }
                f.FileStoreUrl = fi.FileStoreUrl;
            }
            else
                System.Windows.MessageBox.Show(e.Error.Message);
        }


        private void EveryoneCb_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                ShareTxt.IsEnabled = false;
                LayoutRoot.DataContext = bm;
            }
            catch { }
        }

        private void EveryoneCb_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                ShareTxt.IsEnabled = true;
                LayoutRoot.DataContext = bm;
            }
            catch { }
        }

        void wc_OpenWriteCompleted(object sender, OpenWriteCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                UploadFile f = _files.SingleOrDefault(m => m.Name == e.UserState as string);
                if (f != null)
                {
                    Stream outputStream = e.Result;
                    outputStream.Write(f.FileContent, 0, f.FileContent.Length);
                    outputStream.Close();
                    f.FileContent = null;
                    f.FileStoreUrl = "/FileStore/" + f.Name;
                    f.UploadPercentage = 100;
                    f.Loaded = true;
                }
            }
        }

        private void txtVideoName_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
            insrt.findVideoCompleted+=insrt_findVideoCompleted;
            insrt.findVideoAsync(txtVideoName.Text, App.Current.Resources["User"].ToString());
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Index();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        
        private void ShareTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            LayoutRoot.DataContext = bm;
            insrt.isUsernamesExistCompleted += insrt_isUsernamesExistCompleted;
            insrt.isUsernamesExistAsync(ShareTxt.Text);
        }
        string UsersNotExist="";
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

    public class UploadFile : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public double Size { get; set; }
        int _UploadPercentage;
        public int UploadPercentage
        {
            get
            {
                return _UploadPercentage;
            }
            set
            {
                _UploadPercentage = value;
                NotifyChange("UploadPercentage");
            }
        }
        string _FileStoreUrl;
        public string FileStoreUrl
        {
            get { return _FileStoreUrl; }
            set
            {
                _FileStoreUrl = value;
                NotifyChange("FileStoreUrl");
            }
        }
        public byte[] FileContent { get; set; }

        public List<byte[]> Contents { get; set; }
        private bool _Loaded;
        public bool Loaded
        {
            get { return _Loaded; }
            set
            {
                _Loaded = value;
                NotifyChange("Loaded");
            }
        }
        protected void NotifyChange(params string[] properties)
        {
            if (PropertyChanged != null)
            {
                foreach (string p in properties)
                    PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
