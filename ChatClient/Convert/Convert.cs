using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Convert
{
    public class BooleanToVisibilityHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool visibility)
            {
                if (parameter != null && Boolean.TryParse(parameter.ToString(), out bool invert) && invert)
                    return visibility ? Visibility.Hidden : Visibility.Visible;
                else
                    return visibility ? Visibility.Visible : Visibility.Hidden;
            }
            else
                return Visibility.Collapsed;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
                if (parameter != null && Boolean.TryParse(parameter.ToString(), out bool invert) && invert)
                    return visibility != Visibility.Visible;
                else
                    return visibility == Visibility.Visible;
            else
                return false;
        }
    }
}
