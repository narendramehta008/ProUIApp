   M S B A M L   `   `   `  ����T  PCefSharp.Wpf, Version=63.0.3.0, Culture=neutral, PublicKeyToken=40c4b6fc221f4138A0clr-namespace:CefSharp.Wpf;assembly=CefSharp.WpfCefSharp.Wpf  5   	   C ?ProUIApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ProUIApp.View.TwtViewProUIApp.View.TwtView 5   	   .   (ProUIApp.View.TwtView.TwtEmbeddedBrowser   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @cef0clr-namespace:CefSharp.Wpf;assembly=CefSharp.Wpf     5   	   5local#clr-namespace:ProUIApp.View.TwtView     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ TwtEmbeddedBrowser��5   	   $	��600��6$   $
��1000��61    � 	Resources 5         TwitterPage �� Orientation'  !MaterialDesignThemes.Wpf.PackIcon�  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind  IpCheck  BrushStyle_Twt �� 
StartPoint �� EndPoint � Color � Offset  BrushStyle_Twt2  ButtonStyle_1	 �� 
TargetType
 �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value �� 
TargetName  TextBoxStyle_1 ��Name��%�  &	        &	 �     &	     &	 0    &	 ^    7  7  &	 �    �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5        $ Twitter=�6   $��32��6.   $��32��69   �� 5      $��Open Twitter��6   $��0,0,2,0q�6/   
�������$��	ExtraBold"�6S   $��Center=�6j   5      5      �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5        $ 	MapMarker=�6   $��0,0,0,0q�6/   $��32��6@   $��32��6K   �� 5      $��Check IP��6   $��0,0,2,0q�6+   
�������$��13(�6O   $��SemiBold"�6]   $��Center=�6s   5      5      �� 5   
   $ 0.5,0&�65   $ 0.5,1&�6H   .��5      � $ #0084b4��6   $ 0Q�6+   � 5      $ #00aced��6   $ 1Q�6+   � 5      $ #1dcaff��6   $ 0.509Q�6+   � 5      $ #48b1bf��6   $ 0.542Q�6+   � 5       $ #36d1dc��6   $ 0.542Q�6+   5!      �� 5#   
   $ 0.5,0&�66   $ 0.5,1&�6I   .��5$      � $ #1fcaff��6   $ 0Q�6+   � 5%      $ #00cced��6   $ 1Q�6+   � 5&      $ #1fcaff��6   $ 0.509Q�6+   � 5'      $ #49b1bf��6   $ 0.542Q�6+   � 5(      $ #38d1dc��6   $ 0.542Q�6+   5)      �� 5,   
   "	 ��6&   .�5-      �� 
 � ��$ 	ExtraBold"�6+   �� 5.      
 � ��
 �����6+   �� 5/      
 � ��$	 5,2q�6'   �� 50      
 � �� 51      �� 52      " ��6&   .R�53      �� $��Border��6!   $��1,1,1,0q�6/   $ 10��6J   8��  ._�54      �� $��Center=�6/   $��Center=�6J   55       56      P� 57       � �� . . �58   "   �� $ Border��6)   8  
 � ��6S   �� 59   "   
 � ��$ 14(�6>   �� 5:   "   
 � ��
 �����6?   �� 5;   "   
 � ��$ SemiBold"�6?   5<      5>      5@      5A      �� 5C   
   "	 ��6'   .�5D      �� 
 � ��
 �� ��6+   �� 5E      
 � ��$ Consolas)�6+   �� 5F      
 � ��$	 5,2q�6'   �� 5G      
 � �� 5H      �� 5I      " ��6&   .R�5J      �� $��Border��6!   $��1q�6/   $ 10��6D   
����������	#FF93B1F3._�5K      �� $ PART_ContentHost��6+   $��Center=�6E   $
��Left=�6`   5L      5M      5O      5P      5Q      .��5S      �  � RowDefinitions 5T   
   �� 5U      $��* �6   �� 5V      $	��10* �6   .+�5X   
   � $��0��6   $��40��6    � ColumnDefinitions 5Y      �� 5Z      $	��30* �6#   �� 5[      $
��Auto �6#   .+�5^      �� $��0��6   $ 
Horizontal=�6)   $��0,2,0,2q�6B   .+�5`      � $��10,0,0,0q�6   .+�5a      �� -   5         ��Name$ UrlBar��5a   s    �� 
IsReadOnly . $	��600��60   $��25��6?   #��[ 6K   $�� ��6�   5b      5d      �� 5f      $��1��6   $ 
Horizontal=�6)   $��Right=�6B   $��0,2,5,2q�6^   .+�5g      �� -   5        $��btnTwitterLogin��5g   *   $��5,0,0,0q�6   $	��120��6B   $��Center=�6N   #��[  6k   ���#206BA6 � Cursor$
 Hand��6�   ���#206BA6$��0q�6�   #��[ 6  �� 5h      -   5        $��
btnCheckIP��5h      $��5,0,20,0q�6+   $	��120��6=   $��Center=�6J   #��[ 6g   #��[ 6�   $
 Hand��6�   ���#206BA6$��0q�6�   6�   5i      5k      � 5l   
   $��0,10,0,0q�6   $��1��6!   .+�5n      %   CefSharp.Wpf.ChromiumWebBrowser  -   5          Name$ Browser��5n   %      Address$ https://twitter.com/login��66   5o      5p      5q      