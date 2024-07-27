using System;
using System.Collections.Generic;
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

namespace MyApp.Controls
{
    /// <summary>
    /// 基本消息.xaml 的交互逻辑
    /// </summary>
    public partial class 基本消息 : ListViewItem
    {
        public 基本消息(string 标题,string 内容)
        {
            InitializeComponent();
            _标题.Text = 标题;
            _内容.Text = 内容;
        }
        ~基本消息()
        {
            Console.WriteLine($"{this}被释放了");
        }
        public DateTime 创建时间=DateTime.Now;
    }
}
