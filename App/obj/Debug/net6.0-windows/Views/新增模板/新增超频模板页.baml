   M S B A M L   `   `   `  ����A  =foxikg, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyApp.PropertiesMyApp.Properties  5      3clr-namespace:MyApp.ViewModelsMyApp.ViewModels  67   '    !MyApp.Views.新增超频模板页   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.45.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5
propertiesclr-namespace:MyApp.Properties     5      5
viewmodelsclr-namespace:MyApp.ViewModels     67   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      -   5        $��x��5
         MahApps.Styles.Page#���   5      .��5      �   � RowDefinitions  5   
   �� 5      $��48 �6   �� 5      $��* �6   .+�5   
   ��   PageTitleStyle#��[ 5        MediumLeftMargin#��[ 5          MyApp.Properties.Resources#   新增超频模板页_标题#��Z 5      �� 5   
   $��返回��6     Button.返回样式#���  68   ��6   �� *返回命令+68   � 5   
   $��1��5        MediumLeftRightMargin#��[ 5        MahApps.Brushes.Gray10#���  5      .+�5      �� .��5      �� .+�5      �� $��模板名称:��6     MediumLeftTopRightMargin#��[ 6-   �� 5      *  $MahApps.Metro.Controls.TextBoxHelper   SelectAllOnFocus$
 True��5         	Watermark$ 请输入模板名称��5       #��[ 5!      ��5      �� *Model.OcName+5!      �� 5"      $��N核心频率:��6   #��[ 6-   �� 5#      $
 True��5$      $ N核心频率��5%      #��[ 5&      ��5#      �� *Model.Clock+5&      �� 5'      $��N显存频率:��6   #��[ 6-   �� 5(      $
 True��5)      $ 请输入N显存频率��5*      #��[ 5+      ��5(      �� *	Model.Mem+5+      �� 5,      $��N功耗限制:��6   #��[ 6-   �� 5-      $
 True��5.      $" 请输入核心N功耗限制��5/      #��[ 50      ��5-      �� *Model.Plimit+50      �� 51      $��N风扇转速:��6   #��[ 6-   �� 52      $
 True��53      $ 请输入N风扇转速: ��54      #��[ 55      ��52      �� *
Model.Nfan+55      �� 56      $��A核心频率:��6   #��[ 6-   �� 57      $
 True��58      $ 请输入A核心频率��59      #��[ 5:      ��57      �� *Model.CoreClock+5:      �� 5;      $��A核心状态:��6   #��[ 6-   �� 5<      $
 True��5=      $ 请输入A核心状态��5>      #��[ 5?      ��5<      �� *Model.CoreState+5?      �� 5@      $��A核心电压:��6   #��[ 6-   �� 5A      $
 True��5B      $ 请输入A核心电压��5C      #��[ 5D      ��5A      �� *Model.CoreVddc+5D      �� 5E      $��A显存频率:��6   #��[ 6-   �� 5F      $
 True��5G      $ 请输入A显存频率��5H      #��[ 5I      ��5F      �� *Model.MemClock+5I      �� 5J      $��A风扇转速:��6   #��[ 6-   �� 5K      $
 True��5L      $ 请输入A风扇转速��5M      #��[ 5N      ��5K      �� *
Model.Afan+5N      �� 5O      $��40��6   $��
23,23,0,10q�6)   $��添加��6>   ��5P      �� *添加命令+68   5R      5S      5U      5V      5W      