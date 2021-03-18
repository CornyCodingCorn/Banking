using System;
using System.Windows.Data;
using System.Windows;

namespace CornUI.Utility
{
    class ThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
            {
                double margin = (double)value;
                return new Thickness(margin, margin, margin, margin);
            }
            return new Thickness();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class MaximizePaddingConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
            {
                double margin = (double)value;
                return new Thickness(margin, margin, margin, 0);
            }
            return new Thickness();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
