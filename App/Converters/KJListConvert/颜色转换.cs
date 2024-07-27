using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;


namespace MyApp.Converters.KJListConvert
{
    public class 状态颜色转换 : IValueConverter
    {
    

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is string data)
                {
                    if (data == "在线")
                    {
                        return Brushes.Green;
                    }
                    else
                    {
                        return Brushes.Red;
                    }
                }

              
            }
            catch 
            {
                Console.WriteLine("状态颜色转换");
              
            }
            return Brushes.Red;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {


            return null;
        }
    }
    public class 接受率颜色转换 : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //try
            //{
            //    if (value.ToString().Length < 20) return Brushes.Black;
            //    var s = JsonConvert.DeserializeObject<Miner_stats>(value.ToString());
            //    if (s == null || s.ar.Count == 0) return Brushes.Black;
            //    List<double> list = new List<double>();

            //    for (int i = 0; i < s.ar.Count; i++)
            //    {
            //        if (i == 3) break;
            //        list.Add(double.Parse(s.ar[i]));
            //    }
            //    if (list.Sum() == 0) { return Brushes.Black; }
            //    else
            //    {
            //        return list[0] / list.Sum() * 100 < 85 ? Brushes.Red : Brushes.Black;
            //    }
            //}
            //catch (Exception)
            //{

            //    Console.WriteLine("接受率颜色转换出错");
            //}
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {


            return null;
        }
    }
    public class 温度颜色转换 : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value.ToString().Length < 5) return Brushes.Black;
                var list = JsonConvert.DeserializeObject<List<int>>(value.ToString());
                if (list==null) return Brushes.Black;
                if (list.Count == 0) return Brushes.Black;
                if (list.Max() >= 75)
                {
                    return Brushes.Red;
                }
            }
            catch
            {

                Console.WriteLine("温度颜色转换");
            }

            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {


            return null;
        }
    }
    public class 温度转换 : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value.ToString().Length < 5) return 0;
                var list = JsonConvert.DeserializeObject<List<int>>(value.ToString());
                if (list == null) return Brushes.Black;
                if (list.Count == 0) return Brushes.Black;
               
                    return list.Max();
               
            }
            catch
            {

                Console.WriteLine("温度转换");
            }

           return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {


            return null;
        }
    }
    public class 挖矿时长转换 : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //try
            //{
                
            //       var p=  JsonConvert.DeserializeObject<Miner_stats>(value.ToString());

            //        if (p == null) return "00:00:00";
            //        var d0 = p.uptime / (3600 * 24);
            //        var d1 = p.uptime % (3600 * 24);
            //        var h0 = d1 / 3600;
            //        var h1 = d1 % 3600;
            //        var m0 = h1 / 60;
            //        return $"{d0:00}:{h0:00}:{m0:00}";
                
               
            //}
            //catch
            //{
            //    Console.WriteLine("挖矿时长转换");

            //}
            return "00:00:00";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {


            return null;
        }
    }
}
