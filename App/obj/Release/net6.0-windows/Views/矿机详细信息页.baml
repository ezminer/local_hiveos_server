   M S B A M L   `   `   `  ���� A  =foxikg, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyApp.PropertiesMyApp.Properties  C ?WpfChart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:WpfChart;assembly=WpfChartWpfChart 3clr-namespace:MyApp.ViewModelsMyApp.ViewModels  O,clr-namespace:MyApp.Converters.KJListConvertMyApp.Converters.KJListConvert  '    !MyApp.Views.矿机详细信息页   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.45.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5
propertiesclr-namespace:MyApp.Properties     T	 PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls 	 4chart(clr-namespace:WpfChart;assembly=WpfChart 	 /
viewmodelsclr-namespace:MyApp.ViewModels 	 7conv,clr-namespace:MyApp.Converters.KJListConvert 	    MahApps.Styles.Page#���     � 	Resources  7   1MyApp.Converters.KJListConvert.状态颜色转换  onlineColor��%   &	         .���  � RowDefinitions �� $��48 ��� $��* ��� $��48 �.+���   PageTitleStyle#��[   MediumLeftMargin#��[     MyApp.Properties.Resources"   矿机详细信息PageTitle#��Z �� $��返回��  Button.返回样式#��[ ���� *导航到列表页命令+� -    �Name$
 view��$��1��  MediumLeftRightMargin#��[   MahApps.Brushes.Gray10#���  .+��� $
��Auto=�! �� IsDeferredScrollingEnabled$ False��$��False��.���� -   $
��True��.+��� $��5q�  LargeFontSize#��[ �� $�机器名称:      �� �� ��� *Machine_info.主机名+���� *Machine_info.状态+ �� 	Converter# [  �� $�      状态:�� �� #��[ ���� *Machine_info.状态+# [ ��� *Machine_info.状态+ �� $�      总算力:�� �� 
���  ����� *Machine_info2.总算力+ �� Mode$ OneWay=� �� $�      总功耗:�� �� 
���  ����� *Machine_info2.总功耗+�� $��	控制台��2 	 ,MahApps.Metro.Controls.HeaderedControlHelper   HeaderFontWeight$
 Bold"�   HeaderFontSize# [ .���� 	 �� Orientation$	 
Horizontal=�.+��� $��设置��$	��200��$|�False��$	��5 0q�#��[ $��0q����� *导航到设置页命令+�� $��重启核心��$	��200��$��1��$|�False��$	��5 0q�#��[ $��0q����� *矿机命令+�� $��重启矿机��$	��200��$��0��$|�False��$	��5 0q�#��[ $��0q����� *矿机命令+�� $��暂停矿机��$	��200��$��3��$|�False��$	��5 0q�#��[ $��0q����� *矿机命令+�� $��关闭矿机��$	��200��$��8��$|�False��$	��5 0q�#��[ $��0q����� *矿机命令+�� $y�	Collapsed=�$��切换系统��$	��200��$��2��$|�False��$	��5 0q�#��[ $��0q����� *矿机命令+�� $��功耗信息��$|�False��$
 Bold"�$	��200��# [ .���� ._��� $
��True��$��Visible=����� 
 �� RelativeSource
 ��  �� Mode$ FindAncestor=� �� AncestorType
 Border �� Path$ ActualWidth�.����  �� SelectionMode$ Single=�$��Disabled=����� *Machine_info2.显卡信息+ �� View �� P��� $��实时功耗�� �� DisplayMemberBinding �� *实时功耗+�� $��算力�� �� *算力+�� $��显卡温度�� �� *显卡温度+�� $��显存温度�� �� *显存温度+�� $��风扇�� �� *风扇+�� $��显卡型号�� �� *显卡型号+�� $��品牌�� �� *品牌+�� $��显存大小�� �� *显存大小+�� $��颗粒�� �� *颗粒+�� $��最小功耗�� �� *最小功耗+�� $��默认功耗�� �� *默认功耗+�� $��挖矿核心信息��$
 Bold"�# [ .���� .+��    �� 
TargetType  MahApps.Styles.Label �� BasedOn �� Property �� Value��%c   '��       7  7  �� " ��8   .���  � ��$ 1q���  � ��
 �������  � ��8   � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $��* � �� �� �� �� �� �� �� �� �� �� .+��� $��0��$��1��$��挖矿时长             ���� $��1��$��1������ *Machine_info2.挖矿时长+�� $��2��$��1��$��挖矿模板             ���� $��3��$��1������ *Machine_info2.挖矿模板+�� $��0��$��2��$��币种���� $��1��$��2������ *Machine_info2.币种+�� $��2��$��2��$��延迟���� $��3��$��2������ *Machine_info2.延迟+�� $��0��$��3��$��核心版本���� $��1��$��3������ *Machine_info2.核心版本+�� $��2��$��3��$��	有效率���� $��3��$��3������ *Machine_info2.有效率+�� $��0��$��4��$��矿池���� $��1��$��4������ *Mining.PoolAddr+�� $��2��$��4��$��钱包���� $��3��$��4������ *Mining.WalletAddr+�   ��%c   '��       7  7  �� " ��8   .���  � ��$ 1q���  � ��
 �������  � ��8   �� $��1* ��� $��3* � �� $
��auto ��� $
��auto ��� $��挖矿信息��$|�False��$
 Bold"�# [ .���� -   ����  	 MahApps.Styles.ListBoxItem# [	 " ��.��� ' 	 !MahApps.Metro.Controls.ItemHelper �@ HoverBackgroundBrush
 ���� ��  �@ HoverForegroundBrush
 �  ���� $ �@ HoverSelectedBackgroundBrush
 ���� �� $ �@ HoverSelectedForegroundBrush
 �  ����  �@ SelectedBackgroundBrush
 ���� ��  �@ SelectedForegroundBrush
 �   ��� & �@ ActiveSelectionBackgroundBrush
 ���� �� & �@ ActiveSelectionForegroundBrush
 �  ��.@��� .���  �� $
��auto ��� $
��auto ��� $
��auto ��� $��* � �� �� �� �� �� �� �� �� �� �� .+��� $��0��#��[ 
�������$��1q�$��在线时长���� $��1��#��[ 
�������$��1q����� *Machine_info2.在线时长+$ OneWay=��� $��2��#��[ 
�������$��1q�$��内网IP���� $��3��#��[ 
�������$��1q����� *Machine_info2.内网IP+�� $��0��$��1��#��[ 
�������$��1q�$��内核版本���� $��1��$��1��#��[ 
�������$��1q����� *Machine_info2.内核版本+�� $��2��$��1��#��[ 
�������$��1q�$��固件版本���� $��3��$��1��#��[ 
�������$��1q����� *Machine_info2.固件版本+�� $��0��$��2��#��[ 
�������$��1q�$��
A卡驱动���� $��1��$��2��#��[ 
�������$��1q����� *Machine_info2.A卡驱动+�� $��2��$��2��#��[ 
�������$��1q�$��
N卡驱动���� $��3��$��2��#��[ 
�������$��1q����� *Machine_info2.N卡驱动+�� $��0��$��3��#��[ 
�������$��1q�$��	cpu型号���� $��1��$��3��#��[ 
�������$��1q����� *Machine_info2.cpu型号+�� $��2��$��3��#��[ 
�������$��1q�$��CPU核心数���� $��3��$��3��#��[ 
�������$��1q����� *Machine_info2.CPU核心数+�� $��0��$��4��#��[ 
�������$��1q�$��主板厂家���� $��1��$��4��#��[ 
�������$��1q����� *Machine_info2.主板厂家+�� $��2��$��4��#��[ 
�������$��1q�$��主板型号���� $��3��$��4��#��[ 
�������$��1q����� *Machine_info2.主板型号+�� $��0��$��5��#��[ 
�������$��1q�$��本地磁盘���� $��1��$��5��#��[ 
�������$��1q����� *Machine_info2.本地磁盘+�� $��2��$��5��#��[ 
�������$��1q�$��	Mac地址���� $��3��$��5��#��[ 
�������$��1q����� *Machine_info2.Mac地址+�� $��2��$��6��#��[ 
�������$��1q�$��内存大小���� $��3��$��6��#��[ 
�������$��1q����� *Machine_info2.内存大小+�� $��0��$��6��#��[ 
�������$��1q�$��可用内存���� $��1��$��6��#��[ 
�������$��1q����� *Machine_info2.可用内存+�� $��0��$��7��#��[ 
�������$��1q�$��cpu使用率[温度]���� $��1��$��7��$��4��#��[ 
�������$��1q����� *Machine_info2.cpu使用率+�� $��历史曲线��$
��True��$
 Bold"�# [ .���� .+��� -   $��加载历史曲线��$	��200��$
��Left=�$��8��$|�False��$	��5 0q�#��[ $��0q�
 � Tag �� *Machine_info2.rig_id+  WpfChart.ChartControl  -     Name$ chart���� $��矿机调试��$
 Bold"�# [ .���  �� $��50 ��� $��* �.+�A�  A� Columns$ 4��.+��� $��	提取Log��$
|�True��+ 	 %MahApps.Metro.Controls.ControlsHelper   CornerRadius$ 0��   FocusBorderThickness$ 1q�#��[ $��1q�
�������$��40������ *提取log命令+�� $��	刷新Log��$
{�True��$|�False��$ 0��$ 1q�#��[ $��1q�
�������$��40������ *刷新命令+�� $��	删除Log��$
{�True��$|�False��$ 0��$ 1q�#��[ $��1q�
�������$��40������ *清除log命令+�� $��自定义命令��$
{�True��$|�False��$ 0��$ 1q�#��[ $��1q�
�������$��40������ *自定义命令+&   System.Windows.Controls.DataGrid  -   $��1��   CanUserAddRows$ False��   CanUserDeleteRows$ False��   AutoGenerateColumns$ False��$��80��$
��True��$��Disabled=�   
IsReadOnly$
 True������ *	TaskDones+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn  	  MinWidth$	  100Q�! 	  Header$! 	log时间��1
  +System.Windows.Controls.DataGridBoundColumn" 
  Binding" �� *	Addtime+  $	  100Q�$! 命令内容��" �� *Data+  $! 返回数据��# 	  Width5  /System.Windows.Controls.DataGridLengthConverter$
# auto " �� *	Payload+�� #��[ $ �� TextAlignment$$ Center=�#��[ $��2��#���  ���� *刷新时间+