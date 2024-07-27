using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MyApp.Converters
{
    public class EnumToBooleanConverter : IValueConverter
    {
        public Type EnumType { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is string enumString)
            {
                if (Enum.IsDefined(EnumType, value))
                {
                    var enumValue = Enum.Parse(EnumType, enumString);

                    return enumValue.Equals(value);
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is string enumString)
            {
                return Enum.Parse(EnumType, enumString);
            }

            return null;
        }
    }



    public class OnLineConverter : IValueConverter
    {
        public Type EnumType { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string data)
            {
                if (data=="在线")
                {
                    return Brushes.Green;
                }
                else if (data == "离线")
                {
                    return Brushes.Red;
                }
                else
                {
                    return Brushes.Red;
                }
            }

            return   Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           

            return null;
        }
    }


}
