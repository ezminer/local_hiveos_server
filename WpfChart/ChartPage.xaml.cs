using ScottPlot;
using ScottPlot.Plottable;
using ScottPlot.Renderable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ChartPage : Page
    {
        public ChartPage()
        {
            InitializeComponent();

         
            ReadFile();
            init2();
        }

        public ChartPage(string id)
        {
            StringBuilder stringBuilder = new StringBuilder();

            string[] dates = {
                DateTime.Now.AddDays(-3).ToString("M"),
                DateTime.Now.AddDays(-2).ToString("M"),
                DateTime.Now.AddDays(-1).ToString("M"),
                DateTime.Now.AddDays(-0).ToString("M"),
            };
            foreach (var path in dates)
            {

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + $"算力记录//{path}_{id}.txt"))
                {

                
                var arr = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + $"算力记录//{path}_{id}.txt").Replace("°C", "$");

                var str = arr.Split('$');

                foreach (var item in str)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }
                    var data = item.Split('>');

                    var 时间 = DateTime.Parse(data[0]);


                    var 温度 = double.Parse(data[2]);
                    温度集合.Add(时间, 温度);

                    var 算力s = data[1].Split('|');




                    var unit = 算力s[0][^3..];
                    var 算力1 = double.Parse(算力s[0][0..^3]);
                    switch (unit)
                    {
                        case "Mhs":
                            算力1 *= Math.Pow(1000, 1); break;
                        case "Ghs":
                            算力1 *= Math.Pow(1000, 2); break;
                        case "Ths":
                            算力1 *= Math.Pow(1000, 3); break;
                        case "Phs":
                            算力1 *= Math.Pow(1000, 4); break;
                    }
                    算力1集合.Add(时间, 算力1);

                    if (算力s.Length == 2)
                    {

                        unit = 算力s[1][^3..];
                        var 算力2 = double.Parse(算力s[1][0..^3]);
                        switch (unit)
                        {
                            case "Mhs":
                                算力2 *= Math.Pow(1000, 1); break;
                            case "Ghs":
                                算力2 *= Math.Pow(1000, 2); break;
                            case "Ths":
                                算力2 *= Math.Pow(1000, 3); break;
                            case "Phs":
                                算力2 *= Math.Pow(1000, 4); break;
                        }
                        算力2集合.Add(时间, 算力2);



                    }
                    else
                    {
                        if (算力2集合.Count > 0)
                        {
                            算力2集合.Add(时间, 0);
                        }

                    }





                }
                }
            
            
            }


            init2();




        }
      

        private  ScottPlot.Plottable.ScatterPlot MyScatterPlot;
        private  ScottPlot.Plottable.MarkerPlot HighlightedPoint;
        private int LastHighlightedIndex = -1;




        private void init2()
        {


           
            double[] xs = new double[算力1集合.Keys.Count];
            double[] ys = 算力1集合.Values.ToArray();
            for (int i = 0; i < 算力1集合.Keys.Count; i++)
            {

            }
            
            xs = 算力1集合.Keys.Select(x => x.ToOADate()).ToArray();
            // ys = DataGen.Random(rand, myDates.Length, 10000);

            //时间格式
            WpfPlot1.Plot.XAxis.DateTimeFormat(true);

            WpfPlot1.Plot.SetOuterViewLimits(xMin: xs[0], xMax: xs.Last(), yMin: -100/*ys.Min(), yMax: ys.Max()*1.2*/);         
           MyScatterPlot = WpfPlot1.Plot.AddScatterLines(xs, ys,color:System.Drawing.Color.Green,lineStyle:LineStyle.Solid);

            if (算力2集合.Count>0)
            {
               WpfPlot1.Plot.AddScatterLines(xs, 算力2集合.Values.ToArray(), color: System.Drawing.Color.Black, lineStyle: LineStyle.Solid);
            }
             

            HighlightedPoint = WpfPlot1.Plot.AddPoint(0, 0);
            HighlightedPoint.Color = System.Drawing.Color.Red;
            HighlightedPoint.MarkerSize = 10;
            HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
            HighlightedPoint.IsVisible = false;



            WpfPlot1.Plot.XAxis.Label("日期");
            WpfPlot1.Plot.YAxis.Label("算力");
            WpfPlot1.Plot.YAxis.LabelStyle(color: System.Drawing.Color.Green);
            WpfPlot1.Plot.YAxis.TickLabelFormat(s =>
            {
                long data= (long)s;
               
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
                        return data+ " Khs";
                }
            });
            // WpfPlot1.Plot.YAxis.LabelStyle(rotation: 90);

            // plot another set of data using an additional axis

            //轴二
            var sigBig = WpfPlot1.Plot.AddScatterLines(xs,温度集合.Values.ToArray(), color: System.Drawing.Color.Red);
            var yAxis3 = WpfPlot1.Plot.AddAxis(Edge.Left, axisIndex: 2);
            yAxis3.TickLabelFormat(s =>string.Format("{0:}℃",s));
            yAxis3.Label("温度");
            yAxis3.LabelStyle(color: System.Drawing.Color.Red);
            sigBig.YAxisIndex = 2;
            WpfPlot1.Plot.SetOuterViewLimits(yAxisIndex: 2, xMin: xs[0], xMax: xs.Last(), yMin: 0/* yMax: 120ys.Min(), yMax: ys.Max()*1.2*/) ;

            WpfPlot1.Plot.Grid(false);
            //缩放到
            WpfPlot1.Plot.AxisZoom(1, 1, xs.Length - 1, 10);
            WpfPlot1.Refresh();
        }
        private void WpfPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            
            // determine point nearest the cursor
            (double mouseCoordX, double mouseCoordY) = WpfPlot1.GetMouseCoordinates();
            double xyRatio = WpfPlot1.Plot.XAxis.Dims.PxPerUnit / WpfPlot1.Plot.YAxis.Dims.PxPerUnit;
            (double pointX, double pointY, int pointIndex) = MyScatterPlot.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);

            // place the highlight over the point of interest
            HighlightedPoint.X = pointX;
            HighlightedPoint.Y = pointY;
            HighlightedPoint.IsVisible = true;

            // render if the highlighted point chnaged
            if (LastHighlightedIndex != pointIndex)
            {
                LastHighlightedIndex = pointIndex;
                WpfPlot1.Render();
            }

           ;
            // update the GUI to describe the highlighted point
           //  Textlabel.Text = $"Point index {pointIndex} at ({pointX:N2}, {pointY:N2})";




            string t = DateTime.FromOADate(MyScatterPlot.Xs[pointIndex]).ToString();
            string v = MyScatterPlot.Ys[pointIndex].ToString();
            Textlabel.Text = $"时间点: {t} 算力: {v}";
           
        }


      


        private void ReadFile()
        {
           var arr=  File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "算力记录//6月1日_4.txt").Replace("°C","$");
           
                var str = arr.Split('$');

            foreach (var item in str)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                var data= item.Split('>');
                
                var 时间 = DateTime.Parse(data[0]);
                
                
                var 温度 = double.Parse(data[2]);
                温度集合.Add(时间, 温度);

                var 算力s = data[1].Split('|');

             


                    var unit = 算力s[0][^3..];
                    var 算力1 = double.Parse(算力s[0][0..^3]);
                    switch (unit)
                    {
                        case "Mhs":
                            算力1 *= Math.Pow(1000, 1); break;
                        case "Ghs":
                            算力1 *= Math.Pow(1000, 2); break;
                        case "Ths":
                            算力1 *= Math.Pow(1000, 3); break;
                        case "Phs":
                            算力1 *= Math.Pow(1000, 4); break;
                    }
                    算力1集合.Add(时间, 算力1);

                 if (算力s.Length == 2) 
                {

                     unit = 算力s[1][^3..];
                    var 算力2 = double.Parse(算力s[1][0..^3]);
                    switch (unit)
                    {
                        case "Mhs":
                            算力2 *= Math.Pow(1000, 1); break;
                        case "Ghs":
                            算力2 *= Math.Pow(1000, 2); break;
                        case "Ths":
                            算力2 *= Math.Pow(1000, 3); break;
                        case "Phs":
                            算力2 *= Math.Pow(1000, 4); break;
                    }
                    算力2集合.Add(时间, 算力2);



                }
                else
                {
                    if (算力2集合.Count>0)
                    {
                        算力2集合.Add(时间, 0);
                    }
                    
                }



                

            }
                


                
               
            

        }

        Dictionary<DateTime,double> 算力1集合=new Dictionary<DateTime,double>();
        Dictionary<DateTime, double> 算力2集合 = new Dictionary<DateTime, double>();

        Dictionary<DateTime, double> 温度集合 = new Dictionary<DateTime, double>();

        private void HCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.WpfPlot1.Configuration.LockHorizontalAxis =true;
        }

       

        private void HCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.WpfPlot1.Configuration.LockHorizontalAxis = false;
           
        }

        private void VCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.WpfPlot1.Configuration.LockVerticalAxis = false;
        }

        private void VCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.WpfPlot1.Configuration.LockVerticalAxis = true;
        }

      

       
    }
}
