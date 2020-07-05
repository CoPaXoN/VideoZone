using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using VideoZoneV2;

namespace Modal
{
    public class ModalControl
    {
        class ModalHost : UserControl
        {
            Canvas _oLayoutRoot;
            UserControl _oUserCtrl;
            Size _oHostSize;

            public UserControl ChildControl { get { return _oUserCtrl; } }

            public ModalHost(UserControl oControl)
            {
                _oUserCtrl = oControl;

                _oLayoutRoot = new Canvas();
                _oLayoutRoot.Background = new SolidColorBrush(Color.FromArgb(50, 0, 0, 0));

                _oLayoutRoot.Children.Add(_oUserCtrl);

                Content = _oLayoutRoot;

                Application.Current.Host.Content.Resized += OnHostResized;

                Loaded += OnHostLoaded;
            }

            public void Close()
            {
                Application.Current.Host.Content.Resized -= OnHostResized;
                Loaded -= OnHostLoaded;
                _oUserCtrl.MouseLeftButtonDown -= OnMouseLeftButtonDown;
                _oUserCtrl.MouseLeftButtonUp -= OnMouseLeftButtonUp;
                _oUserCtrl.MouseMove -= OnMouseMove;


                _oLayoutRoot.Children.Clear();
            }

            void OnHostLoaded(object sender, RoutedEventArgs e)
            {
                _oUserCtrl.MouseLeftButtonDown += OnMouseLeftButtonDown;
                _oUserCtrl.MouseLeftButtonUp += OnMouseLeftButtonUp;
                _oUserCtrl.MouseMove += OnMouseMove;

                _oUserCtrl.Focus();
                _oUserCtrl.TabNavigation = KeyboardNavigationMode.Cycle;

                OnHostResized(null, EventArgs.Empty);
                CentreWindow();
            }

            void OnHostResized(object sender, EventArgs e)
            {
                _oHostSize.Width = Application.Current.Host.Content.ActualWidth;
                _oHostSize.Height = Application.Current.Host.Content.ActualHeight;

                // Resize background canvas
                // ----------------------------------------
                _oLayoutRoot.Width = _oHostSize.Width;
                _oLayoutRoot.Height = _oHostSize.Height;

                CentreWindow();
            }

            private void CentreWindow()
            {
                if (_oUserCtrl != null && !double.IsNaN(_oUserCtrl.Width) && !double.IsNaN(_oLayoutRoot.Width))
                    _oUserCtrl.SetValue(Canvas.LeftProperty, (_oLayoutRoot.Width - _oUserCtrl.Width) / 2);

                if (_oUserCtrl != null && !double.IsNaN(_oUserCtrl.Height) && !double.IsNaN(_oLayoutRoot.Height))
                    _oUserCtrl.SetValue(Canvas.TopProperty, (_oLayoutRoot.Height - _oUserCtrl.Height) / 2);
            }

            #region Dragging code

            bool _bMouseCapturing = false;
            Point _oLastMousePos = new Point();

            void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                _bMouseCapturing = _oUserCtrl.CaptureMouse();
                _oLastMousePos = e.GetPosition(null);
            }

            void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                _oUserCtrl.ReleaseMouseCapture();
                _oLastMousePos = new Point();
                _bMouseCapturing = false;
            }

            void OnMouseMove(object sender, MouseEventArgs e)
            {
                if (_bMouseCapturing)
                {
                    Point oCurrentMousePos = e.GetPosition(null);

                    double dblX = (double)_oUserCtrl.GetValue(Canvas.LeftProperty)
                        + oCurrentMousePos.X - _oLastMousePos.X;

                    double dblY = (double)_oUserCtrl.GetValue(Canvas.TopProperty)
                        + oCurrentMousePos.Y - _oLastMousePos.Y;

                    if (dblX > 0 && dblX + _oUserCtrl.ActualWidth < _oHostSize.Width)
                        _oUserCtrl.SetValue(Canvas.LeftProperty, dblX);

                    if (dblY > 0 && dblY + _oUserCtrl.ActualHeight < _oHostSize.Height)
                        _oUserCtrl.SetValue(Canvas.TopProperty, dblY);

                    _oLastMousePos = oCurrentMousePos;
                }
            }
            #endregion
        }


        #region Modal handlers
        Popup _oPopup = null;
        ModalHost _oHost;


        public void ShowModal(UserControl oCtrl)
        {
            _oHost = new ModalHost(oCtrl);

            _oPopup = new Popup();
            _oPopup.Child = _oHost;
            _oPopup.IsOpen = true;
        }

        public void ShowModalForComboBox(UserControl oCtrl)
        {
            _oHost = new ModalHost(oCtrl);

            _oPopup = new Popup();

            _oPopup.Child = _oHost;

            _oPopup.IsOpen = true;

            PopupExtensions.AttachPopupToVisualTree(_oPopup);

        }

        public UserControl HideModal()
        {
            if (_oPopup != null)
            {
                _oPopup.IsOpen = false;
                _oPopup.Child = null;
                _oPopup = null;
            }

            if (_oHost != null)
            {
                UserControl oRet = _oHost.ChildControl;
                _oHost.Close();
                return oRet;
            }
            else
                return null;
        }
        #endregion
    }
}
