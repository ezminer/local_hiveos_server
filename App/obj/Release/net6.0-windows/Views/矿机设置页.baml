   M S B A M L   `   `   `  ���� A  =foxikg, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyApp.PropertiesMyApp.Properties  3clr-namespace:MyApp.ViewModelsMyApp.ViewModels  !    MyApp.Views.矿机设置页   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.45.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5
propertiesclr-namespace:MyApp.Properties     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  /
viewmodelsclr-namespace:MyApp.ViewModels     MahApps.Styles.Page#���   .���   � RowDefinitions  �� $��48 ��� $��* �.+��� $��返回�� K� ZIndex$ 5��$��80��$��24��$��Right=����� *返回命令+��   PageTitleStyle#��[   MediumLeftMargin#��[     MyApp.Properties.Resources   BlankPageTitle#��Z � $��1��  MediumLeftRightMargin#��[   MahApps.Brushes.Gray10#���  .+��� .����  �� CanVerticallyScroll$
 True��.+��� $��挖矿模板:��  MediumLeftTopRightMargin#��[ ��  �� SelectedValuePath$ Id�� �� DisplayMemberPath$ 
MiningName��#��[ ���� *
MiningList+ �� SelectedValue �� *Model.MiningId+ �� SelectedItem �� *SelectMining+�� $��
矿机名:��#��[ ��  �� 
IsReadOnly$ False��*  $MahApps.Metro.Controls.TextBoxHelper	   SelectAllOnFocus$
	 True��
   	Watermark$
 请输入矿机名��#��[ ���� *Model. RigName+�� $��N核心频率:��#��[ �� $
	 True��$
 N核心频率��#��[ ���� *Model. Clock+�� $��N显存频率:��#��[ �� $
	 True��$
 请输入显存频率��#��[ ���� *	Model.Mem+�� $��N功耗限制:��#��[ �� $
	 True��$
 请输入N功耗限制��#��[ ���� *Model.Plimit+�� $��N风扇转速:��#��[ �� $
	 True��$
 请输入N风扇转速 ��#��[ ���� *
Model.Nfan+�� $��A核心频率:��#��[ �� $
	 True��$
 请输入A核心频率��#��[ ���� *Model.CoreClock+�� $��A核心状态:��#��[ �� $
	 True��$
 请输入A核心状态��#��[ ���� *Model.CoreState+�� $��A核心电压:��#��[ �� $
	 True��$
 请输入A核心电压��#��[ ���� *Model.CoreVddc+�� $��A显存频率:��#��[ �� $
	 True��$
 请输入A显存频率��#��[ ���� *Model.MemClock+�� $��A风扇转速:��#��[ �� $
	 True��$
 请输入A风扇转速��#��[ ���� *
Model.Afan+�� $��备注:��#��[ �� $
	 True��$
 请输入备注��#��[ ���� *Model.Other+�� $��40��$��
23,23,0,10q�$��保存������ *添加命令+