using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace MyApp.Converters.KJListConvert
{
 
      public class 接受率转换 : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //try
            //{
            //    if (value.ToString().Length < 20) return "00%";
            //    var s = JsonConvert.DeserializeObject<Miner_stats>(value.ToString());
            //    if (s == null||s.ar.Count==0) return  "00%";
            //    List<double> list=new List<double>();

            //    for (int i = 0; i < s.ar.Count; i++)
            //    {
            //        if (i == 3) break;
            //        list.Add(double.Parse(s.ar[i]));
            //    }
                
            //    if (list.Sum() == 0) { return "00%"; }
            //    else
            //    {
            //        return string.Format("{0:00}%", list[0] / list.Sum()*100);
            //    }
            

            //}
            //catch
            //{
            //    Console.WriteLine("接受率转换");

            //}
            return "00%";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {


            return null;
        }
    }


}
