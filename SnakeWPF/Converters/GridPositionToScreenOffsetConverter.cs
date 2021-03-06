using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace SnakeWPF.Converters
{
    public class GridPositionToScreenOffsetConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(x => x == DependencyProperty.UnsetValue))
                return DependencyProperty.UnsetValue;

            var gridPosition = System.Convert.ToDouble(values[0]);
            var screenDimension = (double)values[1];
            var gridSize = System.Convert.ToDouble(values[2]);

            return gridPosition * (screenDimension / gridSize);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
