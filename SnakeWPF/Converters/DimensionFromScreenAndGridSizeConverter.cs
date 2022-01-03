using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace SnakeWPF.Converters
{
    public class DimensionFromScreenAndGridSizeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Any(x => x == DependencyProperty.UnsetValue)
                ? DependencyProperty.UnsetValue
                : System.Convert.ToDouble(values[0]) / System.Convert.ToDouble((int)values[1]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
