using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Maui.Controls;

namespace InventoriaMauiApp.Converters
{
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<string> list)
            {
                return string.Join(", ", list);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value as string;
            if (!string.IsNullOrEmpty(str))
            {
                return str.Split(',').Select(s => s.Trim()).ToList();
            }
            return new List<string>();
        }
    }
}
