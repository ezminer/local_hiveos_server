   M S B A M L   `   `   `  ����D  @WPFTemple, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WPFTemple.ControlsWPFTemple.Controls  5      %    WPFTemple.Controls.导航控件   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:WPFTemple.Controls     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f<	controls1,http://metro.mahapps.com/winfx/xaml/controls  5      
�������.��5
      �   � ColumnDefinitions  5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5   
   �� -   5         ��Name$ Loading��5      $y�	Collapsed=�6"    K� ZIndex$ 999999��6:   ���	#1fFFFFFF$��2��5      ._�5      )  #MahApps.Metro.Controls.ProgressRing     AccentColorBrush#���   6%   $	��100��6U    J� Opacity$ 1Q�5         IsActive$
 True��6   $|�False��6.   5      �� 5   
   -   5         ��Name$ _ItemsControl��5        MahApps.Brushes.Gray1#��[ 6/   ��5      �� 5      .R�5      �� -   5        $��	15,2,20,0q�5   6   ��5   !   �� *	Content+
 � Tag 5   !   �� *PageFullName+��5      �� 5   "    �� 
TargetType" ��6(    # MahApps.Styles.Button.Hamburger �� BasedOn# [ 6<   .�5   &   �� 	 �� Property	 � ��  LargeFontSize
 �� Value#
 [ 6A   �� 5    &   	 � ��

 �����6C   �� 5!   &   	 � ��$

 Left=�6S   �� 5"   &   	 � ��$
 40��6?   5#   #   5&      5'      5)      �� 5*      -   5         ��Name$ _TabControl��5*      $��1��6.   $��0q�5+      ��5-      �� 5.      " ��6   .�5/      �� 	 � y�$
 	Collapsed=�67   �� 50      	 � ��$
 0q�6<   51      5:      5<      5>      