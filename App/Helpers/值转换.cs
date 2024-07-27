using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MyApp.Models;

namespace MyApp.Helpers
{
    internal class 值转换
    {
    }
    [ValueConversion(typeof(int), typeof(int))]
    public class MyConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter is List<QBModel> list)
            {

            }
            int d = (int)value;
            return d;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value==null)
            {
                return 1;
            }
            int d = (int)value;
            return d;
        }

        #endregion

    }
}
