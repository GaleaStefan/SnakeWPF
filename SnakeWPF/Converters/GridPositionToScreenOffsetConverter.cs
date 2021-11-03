using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SnakeWPF.Converters
{
    public class GridPositionToScreenOffsetConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
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
