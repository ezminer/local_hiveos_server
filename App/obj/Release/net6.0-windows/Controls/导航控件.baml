   M S B A M L   `   `   `  ���� E  AAPP_Window, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFTemple.ControlsWPFTemple.Controls  %    WPFTemple.Controls.导航控件   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:WPFTemple.Controls     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f<	controls1,http://metro.mahapps.com/winfx/xaml/controls  
�������.���   � ColumnDefinitions  �� $
��auto ��� $��* �.+��� -    ��Name$ Loading��$y�	Collapsed=� K� ZIndex$ 999999�����	#1fFFFFFF$��2��._�)  #MahApps.Metro.Controls.ProgressRing     AccentColorBrush#���   $	��100�� J� Opacity$ 1Q�   IsActive$
 True��$|�False���� -    ��Name$ _ItemsControl��  MahApps.Brushes.Gray1#��[ ���� .R��� -   $��	15,2,20,0q����� *	Content+
 � Tag �� *PageFullName+����  �� 
TargetType" �� # MahApps.Styles.Button.Hamburger �� BasedOn# [ .��� 	 �� Property	 � ��  LargeFontSize
 �� Value#
 [ �� 	 � ��

 ������� 	 � ��$

 Left=��� 	 � ��$
 40���� -    ��Name$ _TabControl��$��1��$��0q����� " ��.��� 	 � y�$
 	Collapsed=��� 	 � ��$
 0q�