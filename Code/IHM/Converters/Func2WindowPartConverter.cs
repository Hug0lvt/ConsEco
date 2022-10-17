using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace IHM.Converters
{
    public class Func2WindowPartConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Func<UserControl>? windowPartCreator = value as Func<UserControl>;
            if (windowPartCreator == null)
            {
                return null;
            }
            return windowPartCreator();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
