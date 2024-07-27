using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Model;
using MyApp.Properties;
using MyApp.ViewModels;
using SqlSugar;

namespace MyApp.Views
{
    public partial class 主页 : Page
    {
        private readonly SqlSugarScope db;
            
        public 主页(主页ViewModel viewModel, SqlSugarScope sugarScope)
        {
            db = sugarScope;
            InitializeComponent();
            DataContext = viewModel;

            
            Loaded += async (s, e)=> {

                xxx.Text = Model.Config.Default.SERVERIP
                ; await viewModel.LoadedAsync(); };

           // wktemplateurl.Text = AppData.Default.模板下载地址;
            toggleSwitch.IsOn = Config.Default.局域网加速;
        }

        
        private void ToggleSwitch_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //
           // Config.Default.局域网加速 = toggleSwitch.IsOn;
            Config.Default.Save();
        }
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            try
            {
                var oldUrl = Model.Config.Default.SERVERIP;
                Model.Config.Default.SERVERIP = xxx.Text ;
                Model.Config.Default.Save();

                var list= db.Queryable<MachineConfig>().ToList();

                foreach (var item in list)
                {
                    item.Config=item.Config.Replace(oldUrl, xxx.Text);
                }

                db.Updateable(list).UpdateColumns( it=>new {it.Config}).ExecuteCommand();
                
                List<TaskList> list1 = new();
                foreach (var item in list)
                {
                    list1.Add(new TaskList() { Addtime=DateTime.Now,RigId=item.Id.ToString(),Shell="hello",Passwd="88888888" });
                }
                db.Insertable(list1).ExecuteCommand();
                MessageBox.Show("保存成功!请等待机器同步完成");
                //ReStart();
            }
            catch (Exception ex)
            {

              MessageBox.Show(ex.Message);  
            }
            
            System.Console.WriteLine();
        }


        public static void ReStart()

        {
           var d= System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            string myApp = System.IO.Path.Combine(Environment.CurrentDirectory, d+".exe");
            //开启新的实例
            Process.Start(myApp);
            //关闭当前实例
            Process.GetCurrentProcess().Kill();

        }

    }
}
