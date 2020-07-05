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
using System.Windows.Data;

namespace VideoZoneV2.Validations
{
    public class UpdateSource
    {
        public static readonly DependencyProperty UpdateSourceTriggerProperty =
            DependencyProperty.RegisterAttached("UpdateSourceTrigger", typeof(bool), typeof(UpdateSource),
                                                new PropertyMetadata(false, OnUpdateSourceTriggerChanged));

        public static bool GetUpdateSourceTrigger(DependencyObject d)
        {
            return (bool)d.GetValue(UpdateSourceTriggerProperty);
        }

        public static void SetUpdateSourceTrigger(DependencyObject d, bool value)
        {
            d.SetValue(UpdateSourceTriggerProperty, value);
        }

        private static void OnUpdateSourceTriggerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool && d is TextBox)
            {
                TextBox textBox = d as TextBox;
                textBox.TextChanged -= PassportBoxPasswordChanged;

                if ((bool)e.NewValue)
                    textBox.TextChanged += PassportBoxPasswordChanged;
            }
        }

        private static void PassportBoxPasswordChanged(object sender, RoutedEventArgs e)
        {
            var frameworkElement = sender as TextBox;
            if (frameworkElement != null)
            {
                BindingExpression bindingExpression = frameworkElement.GetBindingExpression(TextBox.TextProperty);
                if (bindingExpression != null)
                    bindingExpression.UpdateSource();
            }
        }
    }
}
