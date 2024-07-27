using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace MyApp.Converters.KJListConvers
{
   

    public class Total_khsConverter : IValueConverter
    {
        public Type EnumType { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string data)
            {
                int i = 0;
                int.TryParse(data,out i);
                if (i >= 1000 * 1000 * 1000)
                {
                    return string.Format("{0:0.000} G", i/(1000*1000*1000.0));
                }
                if (i >= 1000 * 1000)
                {
                    return string.Format("{0:0.000} M", i / ( 1000 * 1000.0));
                }
                if (i >= 1000)
                {
                    return string.Format("{0:0.000} K", i / (1000.0));
                }

            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return null;
        }
    }
    public class TempToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

         
            try
            {
              

                return (int)value > 75?Brushes.Red:Brushes.Black;
        }
            catch (Exception)
            {

                return Brushes.Black;
            }


        }




        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {


            return null;
        }
    }
}
