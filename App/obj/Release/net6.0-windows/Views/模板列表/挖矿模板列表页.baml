   M S B A M L   `   `   `  ���� A  =foxikg, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MyApp.PropertiesMyApp.Properties  3clr-namespace:MyApp.ViewModelsMyApp.ViewModels  '    !MyApp.Views.挖矿模板列表页   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.45.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5
propertiesclr-namespace:MyApp.Properties     5
viewmodelsclr-namespace:MyApp.ViewModels     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls     MahApps.Styles.Page#���   -  'System.Windows.Input.KeyboardNavigation    TabNavigation$
  None=� � 	Resources   itemContextMenu � DataContext �� RelativeSource �� AncestorType �� Mode �� Path m� Command  itemContextMenu2��%�  &	       &	 �     �� $	��150�� ��  ��  Page$ FindAncestor=�$ DataContext�.@�m� $��新增模板�� �� *添加命令+�� m� $��保存修改�� �� *修改命令+m� $��删除模板�� �� *删除命令+�� $	��150�� ��  ��  Page$ FindAncestor=�$ DataContext�.@�m� $��新增模板�� �� *添加命令+�� m� $��保存修改�� �� *修改命令2+m� $��删除模板�� �� *删除命令2+.���  � RowDefinitions �� $��48 ��� $��* �.+���   PageTitleStyle#��[   MediumLeftMargin#��[     MyApp.Properties.Resources	   WKTemplatePageTitle#��Z	 � $��1��  MediumLeftRightMargin#��[   MahApps.Brushes.Gray10#���  .+��� .@��� $��默认模板列表��.���� .+��� $��40��
 �� Orientation$
 
Horizontal=�$	��Top=�.+��� $��新增��$	��2,5q�$��50��$��20������ *添加命令+�� $��删除��$	��2,5q�$��50��$��20������ *删除命令+&   System.Windows.Controls.DataGrid  -      SelectionMode$ Single=�   CanUserAddRows$ False��   CanUserDeleteRows$ False��   AutoGenerateColumns$ False������ *List+ �� SelectedItem �� *SelectedItem+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��   Header$ 模板名称��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
MiningName+ �� UpdateSourceTrigger$ PropertyChanged=�  $
 True��$ 币种名称�� �� *
CoinName+$ PropertyChanged=�  $
 True��$ 核心名称�� �� *MinerverName+$ PropertyChanged=�  $ 矿池名称�� �� *
PoolName+$ PropertyChanged=�  $ 矿池地址�� �� *
PoolAddr+$ PropertyChanged=�  $ 钱包地址�� �� *
WalletAddr+$ PropertyChanged=�     Width5  /System.Windows.Controls.DataGridLengthConverter$ * $ 自定义参数�� �� *
UserConfig+$ PropertyChanged=�   RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"    MahApps.Styles.DataGridRow �� BasedOn# [ .���  �� Property �@�ContextMenu �� Value# [ �� $��自定义模板列表��.���� .+��� $��40��$
 
Horizontal=�$	��Top=�.+��� $��新增��$	��2,5q�$��50��$��20������ *添加命令+�� $��删除��$	��2,5q�$��50��$��20������ *删除命令2+  -   $ Single=�$ False��$ False��$ False������ *
CustomList+ �� *SelectedCustomItem+   $ 模板名称�� �� *
MiningName+$ PropertyChanged=�  $ 币种名称�� �� *
CoinName+$ PropertyChanged=�  $ 矿池名称�� �� *
PoolName+$ PropertyChanged=�  $ 矿池地址�� �� *
PoolAddr+$ PropertyChanged=�  $ 钱包地址�� �� *
WalletAddr+$ PropertyChanged=�  $ 核心名称�� �� *MinerverName+$ PropertyChanged=�  $ 挖矿软件名称�� �� *挖矿软件名称+$ PropertyChanged=�  $ 核心下载地址�� �� *MinerverName+$ PropertyChanged=�  $ 密码�� �� *
password+$ PropertyChanged=�  $ 加密算法�� �� *加密算法+$ PropertyChanged=�  $ * $ 自定义参数�� �� *
UserConfig+$ PropertyChanged=� �� "  # [ .���  �@�ContextMenu# [ 