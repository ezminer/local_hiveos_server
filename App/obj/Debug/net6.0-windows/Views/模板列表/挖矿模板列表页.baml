   M S B A M L   `   `   `  ����A  =foxikg, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyApp.PropertiesMyApp.Properties  5      3clr-namespace:MyApp.ViewModelsMyApp.ViewModels  67   '    !MyApp.Views.挖矿模板列表页   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.45.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5
propertiesclr-namespace:MyApp.Properties     5      5
viewmodelsclr-namespace:MyApp.ViewModels     67   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5	         MahApps.Styles.Page#���   5      -  'System.Windows.Input.KeyboardNavigation    TabNavigation$
  None=�5
       � 	Resources 5        itemContextMenu � DataContext �� RelativeSource �� AncestorType �� Mode �� Path m� Command  itemContextMenu2��%�  &	       &	 O    �� 5   
   $	��150��6.    5   %   ��  ��  Page$ FindAncestor=�$ DataContext�.@�5      m� $��新增模板��6    6&   �� *添加命令+�� 5      m� 5      $��保存修改��6    6&   �� *修改命令+m� 5      $��删除模板��6    6&   �� *删除命令+5      �� 5   
   $	��150��6/    5   %   ��  ��  Page$ FindAncestor=�$ DataContext�.@�5       m� $��新增模板��6    6&   �� *添加命令+�� 5!      m� 5"      $��保存修改��6    6&   �� *修改命令2+m� 5#      $��删除模板��6    6&   �� *删除命令2+5)      5*      .��5+      �  � RowDefinitions 5,   
   �� 5-      $��48 �6   �� 5.      $��* �6   .+�50   
   ��   PageTitleStyle#��[ 51        MediumLeftMargin#��[ 52          MyApp.Properties.Resources	   WKTemplatePageTitle#��Z	 53      � 54   
   $��1��55        MediumLeftRightMargin#��[ 56        MahApps.Brushes.Gray10#���  57      .+�5;      �� .@�5<      �� $��默认模板列表��6   .��5>      �� .+�5?      �� $��40��6%   
 �� Orientation$
 
Horizontal=�61   $	��Top=�6J   .+�5@      �� $��新增��6&   $	��2,5q�63   $��50��5A      $��20��6)   ��5B      �� *添加命令+�� 5E      $��删除��6%   $	��2,5q�63   $��50��6@   $��20��6K   ��5F      �� *删除命令+5G      &   System.Windows.Controls.DataGrid  5I      -   5           SelectionMode$ Single=�5I   @      CanUserAddRows$ False��5J         CanUserDeleteRows$ False��6.      AutoGenerateColumns$ False��5M      ��5I   #   �� *List+ �� SelectedItem 5K      �� *SelectedItem+   Columns 5N      0  *System.Windows.Controls.DataGridTextColumn  5O   "   ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��65      Header$ 模板名称��6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *
MiningName+ �� UpdateSourceTrigger$ PropertyChanged=�6�     5P   "   $
 True��65   $ 币种名称��6�    6G   �� *
CoinName+$ PropertyChanged=�6�     5Q   "   $
 True��65   $ 核心名称��6�    6G   �� *MinerverName+$ PropertyChanged=�6�     5R   "   $ 矿池名称��6x    66   �� *
PoolName+$ PropertyChanged=�6x     5S   "   $ 矿池地址��6z    66   �� *
PoolAddr+$ PropertyChanged=�6z     5T   "   $ 钱包地址��6z    66   �� *
WalletAddr+$ PropertyChanged=�6z     5U   "      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 66   $ 自定义参数��6�    6@   �� *
UserConfig+$ PropertyChanged=�6�      RowStyle 5j      �� 5k   "    �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6(     MahApps.Styles.DataGridRow �� BasedOn# [ 6A   .�5l   &   ��  �� Property �@�ContextMenu �� Value# [ 6D   5o   #   5q      5r      5t      �� 5u      $��自定义模板列表��6   .��5v      �� .+�5w      �� $��40��6%   $
 
Horizontal=�61   $	��Top=�6J   .+�5x      �� $��新增��6&   $	��2,5q�63   $��50��5y      $��20��6)   ��5z      �� *添加命令+�� 5}      $��删除��6%   $	��2,5q�63   $��50��6@   $��20��6K   ��5~      �� *删除命令2+5        5�      -   5        $ Single=�5�   F   $ False��5�      $ False��6.   $ False��5�      ��5�   #   �� *
CustomList+ 5�      �� *SelectedCustomItem+ 5�        5�   "   $ 模板名称��6y    66   �� *
MiningName+$ PropertyChanged=�6y     5�   "   $ 币种名称��6x    66   �� *
CoinName+$ PropertyChanged=�6x     5�   "   $ 矿池名称��6x    66   �� *
PoolName+$ PropertyChanged=�6x     5�   "   $ 矿池地址��6z    66   �� *
PoolAddr+$ PropertyChanged=�6z     5�   "   $ 钱包地址��6z    66   �� *
WalletAddr+$ PropertyChanged=�6z     5�   "   $ 核心名称��6|    66   �� *MinerverName+$ PropertyChanged=�6|     5�   "   $ 挖矿软件名称��6v    66   �� *挖矿软件名称+$ PropertyChanged=�6v     5�   "   $ 核心下载地址��6|    66   �� *MinerverName+$ PropertyChanged=�6|     5�   "   $ 密码��6x    66   �� *
password+$ PropertyChanged=�6x     5�   "   $ 加密算法��6t    66   �� *加密算法+$ PropertyChanged=�6t     5�   "   $ * 66   $ 自定义参数��6�    6@   �� *
UserConfig+$ PropertyChanged=�6�    5�      �� 5�   "   "  6(   # [ 6A   .�5�   &   ��  �@�ContextMenu# [ 6D   5�   #   5�      5�      5�      5�      5�      5�      5�      