   M S B A M L   `   `   `  ����C  ?ProUIApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProUIApp.View.FileIOViewProUIApp.View.FileIOView  5      )    #ProUIApp.View.FileIOView.RegexCheck   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:ProUIApp.View.FileIOView     5      .��5
      �   � RowDefinitions  5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $	��200 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Regex Expression��6   $	��100��60   $
��10,4q�6<   �� 5      -   5        $��TextBox_Regex��5      $	��300��6+   $
��10,4q�67      TextBoxStyle_1#��[  6F   ��6o   �� *RegexExpression+ �� Mode$ TwoWay=��� 5      -   5        $��TextBox_Group_1��5      $	��100��6-   $
��10,4q�69   #��[  6G   ��6o   �� *GroupNumber+�� 5      -   5        $��Button_Submit��5      $��Regex-1��6*   $
��10,4q�6Q     ButtonStyle_1#��[ 6_   $	��100��6�   �� 5      -   5        $��Button_Clear��5      $��
Clear List��6)   $
��10,4q�6Y   #��[ 6h   $	��100��6�   5      �� 5   
   $��1��6   $ 
Horizontal=�6#   .+�5      �� $
��File��6   $
��10,4q�6#   $	��100��62   $��Center=�6>   $��Center=�6[   �� 5      -   5        $��TextBoxFilePath��5      $	��300��6-   $
��10,4q�69   #��[  6G   ��6o   �� *
FilePath+�� 5      -   5        $
��Rows��5      $	��100��6"   $
��10,4q�6.   #��[  6<   �� 5      -   5        $��ButtonBrowseFile��5      $��	Browse...��6-   $
��10,4q�6`   #��[ 6o   $	��100��6�   �� 5      -   5        $��Button_ExportCSV��5      $��Export to CSV��6-   $
��10,4q�6d   #��[ 6s   $	��100��6�   5      �� 5!   
   -	   5        $��RichTextBox_Source��5!   �    �� TextWrapping$
 Wrap=�6   $��5q�6&    �� AcceptsReturn . $��2��6�   " �� VerticalScrollBarVisibility$ Visible=�6�   $��5q�6�   ��62   �� *
FileData+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6�   ��5"      �� 5#      .R�5$      ��  �� CornerRadius$ 20��6   
����������	#FF70B0F0$��2q�6Z   ._�5%      ��  ��Name$ PART_ContentHost��6'   6D   5&      5'      .��5(       5)      �� 5+   
   -
   5        $��ListBox_Result��5+   x   $��3��6_   $��5q�6l   ��6   �� *ListBoxResult+$ PropertyChanged=���5,      �� 5-      .R�5.      �� $ 20��6   ���	#FFD1D2D3���	#FF70B0F0$��2q�6^   ._�5/      �� $��0q�6(   |�.  .��50      �� $��2q�6)   	 K� IsItemsHost	 . 64   51      52      53      55      56      58      