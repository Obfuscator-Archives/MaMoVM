   M S B A M L   `   `   `  ����E  AConfuserEx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ConfuserEx
ConfuserEx  5   	       ConfuserEx.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *localclr-namespace:ConfuserEx     5   	   $	��800��5   !   $	��600��6-      
DarkWindow#��[  6:     � Title  6	   �� *Title+.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   c� $��0��6   $��2��6    `� IsLocked .  c� OverflowMode$ Never=�6O   -  'System.Windows.Input.KeyboardNavigation   TabNavigation$ Continue=�5      .@�5      �� ��6   �� *
NewProject+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      ��   New#��[ 6   $��0,0,4,0q�6:   �� 5      $��New project��6    $��Center=�63   5      5      �� 5      ��6   �� *OpenProject+.��5      �� $ 
Horizontal=�6   .+�5      ��   Open#��[ 6   $��0,0,4,0q�6;   �� 5      $��Open project��6    $��Center=�64   5      5      �� 5      ��6   �� *SaveProject+.��5      �� $ 
Horizontal=�6   .+�5      ��   Save#��[ 6   $��0,0,4,0q�6;   �� 5      $��Save project��6    $��Center=�64   5      5      �� 5      -   5         �� 	IsEnabled .  .��5       �� $ 
Horizontal=�6   .+�5!      ��  	 Tools#��[ 6   $��0,0,4,0q�6<   �� 5"      $��Tools��6    $��Center=�6-   F� 5#      "���� �  	= Ѡ.c  	= ��g5 @T� 	  
Foreground#��[ 6<   $��4,0,0,0q�6_   $��Center=�5$      5%       � ContextMenu 5&      �� 5'       � DataContext 5(      �� *PlacementTarget.DataContext+	 �� RelativeSource	 �� *Self+.@�5)      m� $��Stack Trace Decoder��6#   
 m� Command
 6@   �� *Decode+ m� Icon 5*      �� 5+   "    
 Decode#��[ 6(   5-      5.      50      51      �� 52   
   $��1��6   $��2��6"   $��10q�66   $��5q�6_    �� SelectedIndex$ 0��53      ��52   B   �� *Tabs+   ConfuserEx.Skin   TabsDisabled 53   '   �� *NavigationDisabled+��54      �� 55       �� 
TargetType" ��6    �� BasedOn# [B��66   .�56      ��  �� Property � �� �� Value$ 80��6.   �� 57       � �� 6/   �� *Header+58      5:      5;      5<      