   M S B A M L   `   `   `  ����C  ?ProUIApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ProUIApp.View.DemoViewProUIApp.View.DemoView  5      +    %ProUIApp.View.DemoView.SimpleMaterial   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:ProUIApp.View.DemoView     5      V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignPaper#���   5	        � 	Resources  5       �� Source�� 5   
   $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.PopupBox.xaml?�6   %    .��5      ]� .+�5   
   o� $	��Top=�6   .@�5      m� $��_Edit��6   .@�5      m� $
��_Cut��6    m� Command$	 Cut��6)    m� Icon 5      '  !MaterialDesignThemes.Wpf.PackIcon  5      �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$ 
ContentCut=�62   5      m� 5      $��_Copy��6   $
 Copy��6*    5        5      $ ContentCopy=�62   5      m� 5      $��_Paste��6   $ Paste��6+    5        5      $ ContentPaste=�62   5!      5"      5#      c� 5%   
   $	��Top=�6   .@�5&      c�   MaterialDesignToolBar#���  6   .@�5'      ��  � ToolTip$
 Save��6   .��5(        $ ContentSave=�6.   5)      �� 5*      �� 5+      $	��Cut��6   $	 Cut��6'    c� OverflowMode$ AsNeeded=�65   .��5,        $ 
ContentCut=�6.   5-      �� 5.      �� 5/      $
��Copy��6   $
 Copy��6(   $ AsNeeded=�67   .��50        $ ContentCopy=�6.   51      �� 52      �� 53      $��Paste��6   $ Paste��6)   $ AsNeeded=�69   .��54        $ ContentPaste=�6.   55      �� 56      57      58      � 5:   
   $	��Top=�6    � RowDefinitions 5;      �� 5<      $
��Auto �6    �� 5=      $��* �6    �� 5>      $
��Auto �6    �� 5?      $
��Auto �6     � ColumnDefinitions 5B      �� 5C      $
��Auto �6#   �� 5D      $
��Auto �6#   �� 5E      $��* �6#   �� 5F      $
��Auto �6#   .+�5I        $ Account=�6&   $��30��65   �� 5J      $��1��6   $��8,0,0,0q�6(   $��Center=�69   $
��Name��6T   �� 5K      $��2��6   $��8,0,0,0q�6&   $��Center=�67   �� 5L      -   5        $��ButtonSubmit��5L      $��3��6)   $��8,0,0,0q�69   .��6e   Submit6m   #  MaterialDesignThemes.Wpf.Card  5N      $��1��6"   $��4��6/   $	��150��6C   $��10q�6P   +  %MaterialDesignThemes.Wpf.ShadowAssist	   ShadowDepth$	 Depth3=�6\   .��5O      �� $��20q�6   
 �� Orientation$
 
Horizontal=�6)   .+�5P        $ 
TwitterBox=�6.   $��64��6@   $��64��6L   �� 5Q      $"��Please follow us on twitter.��6    (  "MaterialDesignThemes.Wpf.ColorZone  5S         Mode$ Light=�6/      CornerRadius$ 2��6<   $
��20,5q�6M   $	 Depth2=�6[   .��5T      �� $
 
Horizontal=�6%   $��16q�6>   .+�5U        $ Magnify=�66   $��Center=�6E   �� 5V      $��8,0,0,0q�6&   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Please search...��67   �� 5W      $��8,0,0,0q�6%   ��5Y   "   �� 5Z   &   .R�5[   *   �� $
 
Horizontal=�65   .+�5\   .   �� $	��140��65   $��Account��6A   $��Center=�6S   $��Segoe UI Semibold)�6n     5^   .   $ Account=�6F   $��30��6V   $��30��6a   $��Right=�6m   5_   +   5`   '   5b      5c      5d      5e      5f        5h      $��2��6'   $��2��64   $ PrimaryDark=�6H   $	��100��6[   $ 10��6h   .��5j      �� $
 
Horizontal=�6   $��20q�66   .+�5k        $ 
TwitterBox=�6.   $��64��6@   $��64��6L   �� 5l      $"��Please follow us on twitter.��6      5n      $ Light=�6/   $ 2��6<   $	 Depth2=�6M   .��5o      �� $
 
Horizontal=�6%   $��16q�6>   .+�5p        $ Magnify=�66   $��Center=�6E   �� 5q      $��8,0,0,0q�6&   $ Please search...��67   �� 5r      $��8,0,0,0q�6%     MaterialDesignToolButton#���  66   .��5s   "     $ 
Microphone=�6:   5t      5u      5v      5w      5x      � 5z      $	��Top=�6   $��3��6+   $��10q�68   .+�5|        $
 Dark=�6+   $ 2��67   $	 Depth2=�6H   .��5}      �� $
 
Horizontal=�6!   $��16q�6:   .+�5~        $ Magnify=�62   $��Center=�6A   �� 5      $��8,0,0,0q�6"   $ Please search...��63   '  !MaterialDesignThemes.Wpf.PopupBox  5�      $��8,0,0,0q�62    3 /MaterialDesignMultiFloatingActionAccentPopupBox#��[ 6C      PopupContent. 5�      �� .+�5�   "   �� -   5        $��ButtonAirplane��5�   )   .��5�   &     $ Airplane=�6>   5�   #   �� 5�   "   -   5        $��ButtonTrain��5�   *   .��5�   &     $ Train=�6>   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      