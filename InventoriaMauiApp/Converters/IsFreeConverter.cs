using Microsoft.Maui.Controls;
using System;
using System.Globalization;
using InventoriaMauiApp.Models;

namespace InventoriaMauiApp.Converters
{
    public class IsFreeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var unit = value as RackUnitFlatDTO;
            if (unit == null) return false;

            // Assuming that the presence of a display name indicates a reservation,
            // and the absence of both display name and equipment indicates it is free.
            bool isFree = string.IsNullOrWhiteSpace(unit.DisplayName) &&
                          string.IsNullOrWhiteSpace(unit.EquipmentName) &&
                          string.IsNullOrWhiteSpace(unit.EquipmentModel) &&
                          string.IsNullOrWhiteSpace(unit.EquipmentType);

            return isFree;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Converting back is not supported.");
        }
    }
}