   M S B A M L   `   `   `  ���� D  @WPFTemple, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPFTemple.PropertiesWPFTemple.Properties  ;"clr-namespace:WPFTemple.ViewModelsWPFTemple.ViewModels  (    "WPFTemple.Views.WKTemplateListPage   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9
properties"clr-namespace:WPFTemple.Properties     9
viewmodels"clr-namespace:WPFTemple.ViewModels     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls     MahApps.Styles.Page#���   .���   � RowDefinitions  �� $��48 ��� $��* �.+���   PageTitleStyle#��[   MediumLeftMargin#��[ $   WPFTemple.Properties.Resources   WKTemplatePageTitle#��Z � $��1��  MediumLeftRightMargin#��[   MahApps.Brushes.Gray10#���  .+��� .+��� $��40�� �� Orientation$ 
Horizontal=�.+��� $��新增��$	��2,5q�$��50��$��20���� $��删除��$	��2,5q�$��50��$��20��&   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��$��0,0,0,30q�$��Hidden=�   CanUserAddRows$ False��   CanUserDeleteRows$ False������ *挖矿模板列表+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��   MinWidth$	 100Q�	   Header$	 	模板名��
   CellTemplate
 �� .R��� ���� *模板名称+  $
 True��$	 100Q�$	 币种��
 �� .R��� ���� *币种+  $
 True��$	 100Q�$	 矿池��
 �� .R��� ���� *矿池+  $
 True��$	 100Q�$	 钱包��
 �� .R��� ���� *钱包+  $
 True��$	 100Q�$	 核心��
 �� .R��� ���� *核心+  $
 True��$	 100Q�$	 核心版本��
 �� .R��� ���� *核心版本+  $
 True��$	 100Q�$	 在线��
 �� .R��� ���� *在线+  $
 True��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * $	 功能��
 �� .R�� .+��� 
������ $��0q�+  %MahApps.Metro.Controls.ControlsHelper   FocusBorderThickness$ 0q�$��0q�$��编辑��$	��2,5q�$��50��$��30���� 
������ $��0q�$ 0q�$��0q�$��删除��$	��2,5q�$��50��$��30��