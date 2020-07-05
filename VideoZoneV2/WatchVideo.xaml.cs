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
using VideoZoneV2.UploadService;
using System.IO;

namespace VideoZoneV2
{
    public partial class WatchVideo : UserControl
    {
        InsertClient insrt = new InsertClient();

        VideoZoneV2.UploadService.UploadClient service = null;
        Int32 i32ChunkSize = 10 * 1024 * 1024;
        Int64 I64Offset = 0;
        string docName = String.Empty;
        bool IsFileToAppend = false;
        Int64 fileSize = 0;
        SaveFileDialog fileDialog = null;
        string filePath;
        bool isFirstCall = true;
        Stream fileStream = null;
        string videoFileName = "";
        public WatchVideo(string videoname, string username)
        {
            InitializeComponent();
            lblVideoname.Content = videoname;
            lblUser.Content = username;
            insrt.SelectVideoCompleted += insrt_SelectVideoCompleted;
            insrt.SelectVideoAsync(videoname, username);
            //positionSlider.ValueChanged +=positionSlider_ValueChanged;
            videoPosition.TextInputUpdate += videoPosition_TextInputUpdate;
            positionSlider.Maximum = VideoPlayer.NaturalDuration.TimeSpan.TotalSeconds;
        }

        void videoPosition_TextInputUpdate(object sender, TextCompositionEventArgs e)
        {
            
        }

        void insrt_SelectVideoCompleted(object sender, SelectVideoCompletedEventArgs e)
        {
            filePath = "http://localhost:50939" + e.Result.Substring(0, e.Result.IndexOf(",")).Trim();
            this.VideoPlayer.Source = new Uri(filePath);
            videoFileName = filePath;
            videoFileName = videoFileName.Remove(0, videoFileName.IndexOf("FileStore") + 1);
            videoFileName = videoFileName.Remove(0, videoFileName.IndexOf("/")+1);
            videoFileName = videoFileName.Remove(0, videoFileName.IndexOf("/")+1);
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            PauseBtn.Visibility = System.Windows.Visibility.Visible;
            PlayBtn.Visibility = System.Windows.Visibility.Collapsed;
            VideoPlayer.Play();
        }

        //private void Element_MediaEnded(object sender, EventArgs e)
        //{
        //    PlayBtn.Visibility = System.Windows.Visibility.Visible;
        //    PauseBtn.Visibility = System.Windows.Visibility.Collapsed;
        //    VideoPlayer.Stop();
        //    positionSlider.Value = positionSlider.Maximum;
        //}

        private void setTimeSpan(object sender, System.Windows.RoutedEventArgs e)
        {
            this.positionSlider.Maximum = this.VideoPlayer.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void setPostition(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            int a = Convert.ToInt32(this.positionSlider.Value);
            this.VideoPlayer.Position = new TimeSpan(0, 0, a);
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayBtn.Visibility = System.Windows.Visibility.Visible;
            PauseBtn.Visibility = System.Windows.Visibility.Collapsed;
            VideoPlayer.Stop();
            
        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayBtn.Visibility = System.Windows.Visibility.Visible;
            PauseBtn.Visibility = System.Windows.Visibility.Collapsed;
            VideoPlayer.Pause();
        }

        //private void positionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{


        //    int a = Convert.ToInt32(this.positionSlider.Value);
        //    this.VideoPlayer.Position = new TimeSpan(0,0, a);
            
        //}

        private void btnFullScreen_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DownloadBtn_Click(object sender, RoutedEventArgs e)
        {
            string docPath = App.TargetFolder + "//" + filePath;
            DownloadFile(docPath);
        }

        public void DownloadFile(string DocURL)
        {
            // first you should get the file size from the server side in bytes.
            fileSize = 825344;
            service = new UploadClient();
            service.InnerChannel.OperationTimeout = new TimeSpan(0, 30, 0);
            docName = DocURL;
            isFirstCall = true; 
            service.DownloadChunkCompleted += service_DownloadChunkCompleted;
            service.DownloadChunkAsync(DocURL, I64Offset, i32ChunkSize);
        }

        void service_DownloadChunkCompleted(object sender, DownloadChunkCompletedEventArgs e)
        {
            try
            {
                Byte[] byteArrayFile = (Byte[])e.Result;
                if (isFirstCall)
                {
                    MessageBox _oBox = MessageBox.Show("Download file in chunk", "Are you sure to download the file ?", MsgBoxButtons.YesNo, MsgBoxIcon.Error, OnDialogClosed);
                }
                isFirstCall = false;
                if (fileDialog != null)
                {
                    WriteIntoFile(fileDialog, byteArrayFile);
                    I64Offset = I64Offset + i32ChunkSize;
                    if (I64Offset < fileSize)
                    {
                        IsFileToAppend = true;
                        service.DownloadChunkAsync(docName, I64Offset, i32ChunkSize);
                    }
                    else
                    {
                        I64Offset = 0;
                        fileStream.Close();
                        System.Windows.MessageBox.Show("File downloaded succesfully.");
                    }
                }
                else
                    service.DownloadChunkAsync(docName, I64Offset, i32ChunkSize);
            }
            catch (Exception ex)
            {

            }
        }
        bool OnDialogClosed(object sender, DialogExit e)
        {
            if (e == DialogExit.OK)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Video Files (*.wmv *.mp4)|*.wmv; *.mp4; *.avi;";
                
                bool? dialogResult = dialog.ShowDialog();

                if (dialogResult == true)
                {
                    fileDialog = dialog;
                    fileStream = (Stream)dialog.OpenFile();
                }
            }
            else if (e == DialogExit.Cancel)
            {

            }
            return true;
        }

        /// <summary>
        /// Write bytes into file.
        /// </summary>
        /// <param name="dialog"></param>
        /// <param name="data"></param>
        public void WriteIntoFile(SaveFileDialog dialog, byte[] data)
        {
            try
            {
                if (fileStream != null)
                {
                    fileStream.Write(data, 0, data.Length);
                    //fileStream.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void positionSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Index();
        }   
    }
}
