using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MyApp.Converters.KJListConvert
{
 
      public class 算力转换 : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {       
               
                //单位是k
                long data = long.Parse( value.ToString()); ;
                
                int n = (data.ToString().Length - 1) / 3;
                switch (n)
                {
                    case 1:
                        return String.Format("{0:0.0} Mhs", data / Math.Pow(1000, 1));
                    case 2:
                        return String.Format("{0:0.0} Ghs", data / Math.Pow(1000, 2));
                    case 3:
                        return String.Format("{0:0.0} Ths", data / Math.Pow(1000, 3));
                    case 4:
                        return String.Format("{0:0.0} Phs", data / Math.Pow(1000, 4));
                    default:
                        return data+" Khs";
                }

            }
            catch(Exception ex)
            {
                this.LogException(ex);
                
            }
            return "未知"; ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {


            return null;
        }
    }


}
