   M S B A M L   `   `   `  ����A  =foxikg, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyApp.PropertiesMyApp.Properties  5      3clr-namespace:MyApp.ViewModelsMyApp.ViewModels  5
   >   !    MyApp.Views.矿机设置页   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.45.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5
propertiesclr-namespace:MyApp.Properties     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5
      /
viewmodelsclr-namespace:MyApp.ViewModels  6>      MahApps.Styles.Page#���   5      .��5      �   � RowDefinitions  5   
   �� 5      $��48 �6   �� 5      $��* �6   .+�5   
   �� $��返回��6    K� ZIndex$ 5��6   $��80��6/   $��24��6:   $��Right=�6F   ��6b   �� *返回命令+6}   �� 5   
     PageTitleStyle#��[ 5        MediumLeftMargin#��[ 5          MyApp.Properties.Resources   BlankPageTitle#��Z 5      � 5   
   $��1��5        MediumLeftRightMargin#��[ 5        MahApps.Brushes.Gray10#���  5      .+�5      �� .��5      ��  �� CanVerticallyScroll$
 True��6   .+�5      �� $��挖矿模板:��6     MediumLeftTopRightMargin#��[ 6-   �� 5       �� SelectedValuePath$ Id��5        �� DisplayMemberPath$ 
MiningName��5!      #��[ 5"      ��5      �� *
MiningList+ �� SelectedValue 5      �� *Model.MiningId+ �� SelectedItem 5      �� *SelectMining+5$      �� 5%      $��
矿机名:��6   #��[ 6+   �� 5&       �� 
IsReadOnly$ False��6@   *  $MahApps.Metro.Controls.TextBoxHelper	   SelectAllOnFocus$
	 True��5'      
   	Watermark$
 请输入矿机名��5(      #��[ 5)      ��5&      �� *Model. RigName+5)      �� 5*      $��N核心频率:��6   #��[ 6-   �� 5+      $
	 True��5,      $
 N核心频率��5-      #��[ 5.      ��5+      �� *Model. Clock+5.      �� 5/      $��N显存频率:��6   #��[ 6-   �� 50      $
	 True��51      $
 请输入显存频率��52      #��[ 53      ��50      �� *	Model.Mem+53      �� 54      $��N功耗限制:��6   #��[ 6-   �� 55      $
	 True��56      $
 请输入N功耗限制��57      #��[ 58      ��55      �� *Model.Plimit+58      �� 59      $��N风扇转速:��6   #��[ 6-   �� 5:      $
	 True��5;      $
 请输入N风扇转速 ��5<      #��[ 5=      ��5:      �� *
Model.Nfan+5=      �� 5>      $��A核心频率:��6   #��[ 6-   �� 5?      $
	 True��5@      $
 请输入A核心频率��5A      #��[ 5B      ��5?      �� *Model.CoreClock+5B      �� 5C      $��A核心状态:��6   #��[ 6-   �� 5D      $
	 True��5E      $
 请输入A核心状态��5F      #��[ 5G      ��5D      �� *Model.CoreState+5G      �� 5H      $��A核心电压:��6   #��[ 6-   �� 5I      $
	 True��5J      $
 请输入A核心电压��5K      #��[ 5L      ��5I      �� *Model.CoreVddc+5L      �� 5M      $��A显存频率:��6   #��[ 6-   �� 5N      $
	 True��5O      $
 请输入A显存频率��5P      #��[ 5Q      ��5N      �� *Model.MemClock+5Q      �� 5R      $��A风扇转速:��6   #��[ 6-   �� 5S      $
	 True��5T      $
 请输入A风扇转速��5U      #��[ 5V      ��5S      �� *
Model.Afan+5V      �� 5X      $��备注:��6   #��[ 6*   �� 5Y      $
	 True��5Z      $
 请输入备注��5[      #��[ 5\      ��5Y      �� *Model.Other+5\      �� 5c      $��40��6   $��
23,23,0,10q�6)   $��保存��5d      ��5e      �� *添加命令+68   5g      5h      5i      5j      5k      