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
using Modal;
using System.Threading;
using System.Windows.Media.Imaging;

namespace VideoZoneV2
{
    public enum MsgBoxButtons
    {
        OK,
        YesNo
    }

    public enum MsgBoxIcon
    {
        Information,
        Warning,
        Error
    }

    public enum DialogExit
    {
        Cancel,
        OK
    }

    public delegate bool DialogClose(object sender, DialogExit e);

    public partial class MessageBox : UserControl
    {
        #region static functions
        public static MessageBox ShowInformation(string Title, string Message, DialogClose oCallback)
        {
            return Show(Title, Message, MsgBoxButtons.OK, MsgBoxIcon.Information, oCallback);
        }

        public static MessageBox ShowWarning(string Title, string Message, DialogClose oCallback)
        {
            return Show(Title, Message, MsgBoxButtons.OK, MsgBoxIcon.Warning, oCallback);
        }

        public static MessageBox ShowError(string Title, string Message, DialogClose oCallback)
        {
            return Show(Title, Message, MsgBoxButtons.OK, MsgBoxIcon.Error, oCallback);
        }

        public static MessageBox Show(string Title, string Message, MsgBoxButtons Buttons, MsgBoxIcon Icon, DialogClose oCallback)
        {
            MessageBox oBox = new MessageBox(Title, Message, Buttons, Icon, oCallback);

            oBox.ModalHost.ShowModal(oBox);

            return oBox;
        }
        #endregion

        // --------------------------------------------------------------------

        ModalControl ModalHost;
        DialogClose _oCallback;

        public MessageBox(string Title, string Message, MsgBoxButtons Buttons, MsgBoxIcon Icon, DialogClose oCallback)
        {
            InitializeComponent();

            ModalHost = new ModalControl();
            _oCallback = oCallback;

            btOne.Click += OneClick;
            btTwo.Click += OneClick;
            btCross.Click += OneClick;

            //if (string.IsNullOrEmpty(Title))
            //    txtTitle.Text = "Error";
          //  else
                txtTitle.Text = Title;

            txtMessage.Text = Message;

            if (Buttons == MsgBoxButtons.YesNo)
            {
                btOne.Content = "Yes";
                btOne.Tag = DialogExit.OK;

                btTwo.Content = "No";
                btTwo.Tag = DialogExit.Cancel;
            }
            else
            {
                btOne.Visibility = Visibility.Collapsed;
                btTwo.Content = "OK";
                btTwo.Tag = DialogExit.Cancel;
            }

            btCross.Tag = DialogExit.Cancel;

            _lblIcon.Text = Icon.ToString();


            //string sImagePath = @"Resources\error_img.png";

            //if (Icon == MsgBoxIcon.Warning)
            //    sImagePath = "/images/warning.png";
            //else if (Icon == MsgBoxIcon.Error)
            //    sImagePath = "/images/error.png";

            //BitmapImage oImage = new BitmapImage();
            //oImage.UriSource = new Uri(sImagePath);
            ////oImage.SetSource(Application.GetResourceStream(new Uri(sImagePath)).Stream);
            //_imgIcon.Source = oImage;    
        }

        void OneClick(object sender, RoutedEventArgs e)
        {
            Button obt = (Button)sender;

            if (_oCallback == null)
                ModalHost.HideModal();
            else
            {
                if (_oCallback(this, (DialogExit)obt.Tag))
                    ModalHost.HideModal();
            }
        }
    }
}
