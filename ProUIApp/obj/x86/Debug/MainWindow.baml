   M S B A M L   `   `   `  ����C  ?ProUIApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProUIAppProUIApp  5   	   E'clr-namespace:ProUIApp.View.ContentViewProUIApp.View.ContentView  5	   	       ProUIApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ProUIApp     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   E ADragablz, Version=0.0.3.203, Culture=neutral, PublicKeyToken=null6dragablz'http://dragablz.net/winfx/xaml/dragablz  5   	   8
contentTab'clr-namespace:ProUIApp.View.ContentView  5	   	   -   5        $	��600��5      $
��1000��6*     � WindowStartupLocation$  CenterScreen=�68    � 	Resources 5         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%�  &	        &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 70Q�63     5      $ 0:0:0.5��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 200Q�63     5      $ 0:0:0.5��6'   $ 70Q�69   5      5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5      �� #��[  6   5      :� 5   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5       �� #��[ 6   5!      .��5$      � 
�������	 � RowDefinitions	 5%   
   �� 5'      $��* �6   �� 5(      $��40 �6   .+�5F   
   � 
 � ColumnDefinitions
 5G      �� 5H      $
��Auto �6#   �� 5I      $��* �6#   .+�5M      � $��60��6   $	��Top=�6   
������� J� Effect 5N      3  -System.Windows.Media.Effects.DropShadowEffect  5O         
BlurRadius$ 1Q�6'      ShadowDepth$ 1Q�66      Color$ 	#FFACACAC��6F   5]      � 5^      -   5         �Name$ GridMenu��5^      $��70��6%   $
��Left=�60   ���	#FF6E236E 5_        5`      $ 2Q�6'   $ 1Q�66   $ 	#FFAEAEAE��6F   .+�5b      �� .+�5c      � $	��150��6   
������� J� RenderTransformOrigin$ 0.5,0.5&�6;   z�5d      V� 5e      .~�5f   "   �� �� 5g   "   �� 5h   "   T� 5i   "   5j      .+�5l      �� -   5         ��Name$ ButtonOpenMenu��5l   !   $��60��69   $��60��6E   $��5q�6P   $��Right=�6[   $	��Top=�6w    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5m      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.0.1044, Culture=neutral, PublicKeyToken=null]]   Kind$
 Menu=�66   $��25��6B   $��25��6M   5n      �� 5o      -   5        $ ButtonCloseMenu��5o   !   $y�	Collapsed=�6:   $��60��6Q   $��60��6]   $��5q�6h   $��Right=�6s   $	��Top=�6�   #��[ 6�   ���	#FF31577E��6�   Z� ��6  Z� .��5p        $ 	ArrowLeft=�66   $��25��6G   $��25��6R   5q      �� 5s      $��80��6    $��Bottom=�6,   5t      �� 5u      -   5         ��Name$ ListViewMenu��5u      
�������$��Disabled=�6H   .@�5w      �� -   5         ��Name$ AllAccountTab��5w   '   $��60��6>   .��5x      ��  �� Orientation$ 
Horizontal=�6)   .+�5y   "     $ Account=�6:   $��40��6I   $��40��6U   �� 5z   "   $��	ExtraBold"�6,   $��All Account��6C   $��Center=�6V   $
��20 0q�6q   5{      5|      �� 5�      -   5        $ FacebookTab��5�   '   $��60��6<   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ Facebook=�6:   ���	#FF2574B9$��40��6a   $��40��6m   �� 5�   "   $��	ExtraBold"�6,   $��Facebook��6C   $��Center=�6S   $
��20 0q�6n   5�      5�      �� 5�      -   5        $ 	FileIOTab��5�   '   $��60��6:   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ Folder=�6:     BrushStyle_Folder#��[ 6H   $��40��6x   $��40��6�   �� 5�   "   $��	ExtraBold"�6,   $��File IO��6C   $��Center=�6R   $
��20 0q�6n   5�      5�      �� 5�      -	   5        $ DemoTab��5�   '   $��60��68   .��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ Verified=�6:   
�������  BrushStyle_Verify#��[ 6]   $��40��6�   $��40��6�   �� 5�   "   $��	ExtraBold"�6,   $��Demo Tab��6C   $��Center=�6S   $
��20 0q�6o   5�      5�      5�      5�      5�      � 5�      -
   5        $ GridMain��5�      $��1��6%   $
��10,5q�65   .+�5�      >� ��6   �� *
CurrentTab+5�      5�      �� 5�   
   -   5        $ ListViewInfoLogger��5�      $��1��6/   5�      5�      