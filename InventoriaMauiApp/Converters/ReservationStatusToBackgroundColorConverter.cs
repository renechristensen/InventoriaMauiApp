using Microsoft.Maui.Graphics;
using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using InventoriaMauiApp.Models;

namespace InventoriaMauiApp.Converters
{
    public class ReservationStatusToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var unit = value as RackUnitFlatDTO;
            if (unit == null) return Colors.Transparent;

            if (!string.IsNullOrWhiteSpace(unit.EquipmentName) || !string.IsNullOrWhiteSpace(unit.EquipmentModel) || !string.IsNullOrWhiteSpace(unit.EquipmentType))
            {
                return Colors.Red.MultiplyAlpha((float)0.3);  // Light red for units with equipment
            }
            else if (!string.IsNullOrWhiteSpace(unit.DisplayName))
            {
                return Colors.Blue.MultiplyAlpha((float)0.3);  // Light blue for reserved units
            }
            else
            {
                return Colors.Green.MultiplyAlpha((float)0.3);  // Light green for free units
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
