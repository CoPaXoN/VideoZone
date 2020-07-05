using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace VideoZoneV2
{
    public static class PopupExtensions
    {
        public static void AttachPopupToVisualTree(this Popup popup)
        {
            UIElement rootVisual = Application.Current.RootVisual;
            if (rootVisual != null)
            {
                int childrenCount = VisualTreeHelper.GetChildrenCount(rootVisual);
                for (int i = 0; i < childrenCount; i++)
                {
                    Panel child = VisualTreeHelper.GetChild(rootVisual, 0) as Panel;
                    if (child != null)
                    {
                        child.Children.Add(popup);
                        return;
                    }
                }
            }
        }

        public static void RemovePopupFromVisualTree(this Popup popup)
        {
            UIElement rootVisual = Application.Current.RootVisual;
            if (rootVisual != null)
            {
                int childrenCount = VisualTreeHelper.GetChildrenCount(rootVisual);
                for (int i = 0; i < childrenCount; i++)
                {
                    Panel child = VisualTreeHelper.GetChild(rootVisual, 0) as Panel;
                    if ((child != null) && child.Children.Contains(popup))
                    {
                        child.Children.Remove(popup);
                        return;
                    }
                }
            }
        }
    }
}
