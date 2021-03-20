using System;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;

namespace CornUI.Utility
{
    class BrushAndColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is SolidColorBrush)
            {
                return ((SolidColorBrush)value).Color;
            } 
            return Colors.Purple;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Color)
            {
                return new SolidColorBrush((Color)value);
            }
            return new SolidColorBrush(Colors.Purple);
        }
    }
}
