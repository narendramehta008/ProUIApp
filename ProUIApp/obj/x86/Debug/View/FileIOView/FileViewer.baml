   M S B A M L   `   `   `  ����C  ?ProUIApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ProUIApp.View.FileIOViewProUIApp.View.FileIOView  5      A =BaseUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO4clr-namespace:BaseUI.FileIOViewModel;assembly=BaseUIBaseUI.FileIOViewModel 5      )    #ProUIApp.View.FileIOView.FileViewer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:ProUIApp.View.FileIOView     5      IfileView4clr-namespace:BaseUI.FileIOViewModel;assembly=BaseUI     5      .��5
      �   � RowDefinitions  5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��TextBoxFilePath��5         TextBoxStyle_1#��[  6-    �� 
IsReadOnly . $	��250��6�   ��6U   �� *
FilePath+6�   �� 5      -   5        $��ButtonBrowse��5      $��Browse��6)     ButtonGradientStyle_1#��[ 6:   6j   �� 5      -   5        $��LabelVisitedFoldersCount��5      $��Visited Folders��64   $
��Bold"�6N   $��	10,2,10,2q�6`   $��Center=�6s   �� 5      -   5        $��TextBoxVisitedFolderCount��5      #��[  6�   $	��100��6�    . ��67   �� *FoldersVisitedCount+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      -   5        $��LabelVisitedFilesCount��5      $��Visited Files��62   $
��Bold"�6J   $��	10,2,10,2q�6\   $��Center=�6o   �� 5      -   5        $��TextBoxVisitedFilesCount��5      #��[  6   $	��100��6�    . ��66   �� *FilesVisitedCount+$ PropertyChanged=�6�   �� 5      -   5        $��
ButtonStop��5      $
��Stop��6'   #��[ 66   6�   5      �� 5   
   $ 
Horizontal=�6   $��1��6.   .+�5      �� -   5        $��ComboBoxDrive��5      $��Center=�6N   ��6,   �� *	DriveList+6N   �� 5      -	   5        $��LabelSearchFileName��5      $��Search File��6/   $
��Bold"�6E   $��	10,2,10,2q�6W   $��Center=�6j   �� 5      -
   5        $��TextBoxSearchFile��5      #��[  6/   $	��250��6x   ��6W   �� *SearchFileName+6x   �� 5       -   5        $��ButtonSearchFile��5       $��Search File��6-   #��[ 6C   6s   �� 5!      -   5        $��TextBoxSearchFileFullPath��5!      #��[  67    . $	��350��6�   ��6_   �� *SearchFileFullPath+6�   �� 5"      -   5        $��TextBlockSearchFileStatus��5"      ��69   �� *SearchFileStatus+6^   �� 5#      -   5        $"��TextBoxSearchFileElaspedTime��5#      #��[  6:    . $	��150��6�   ��6b   �� *SearchFileElaspedTime+6�   5%      � 5'   
   $��2��6   $��10q�6    � ColumnDefinitions 5(      �� 5)      $��* �6#   �� 5*      $��* �6#   .+�5-      � .+�5=      R� -   5        $��
trvFolders��5=      $��10q�6-    � 	Resources 5>       �� DataType$  BaseUI.FileIOViewModel.Folders �� ItemsSource%  BaseUI.FileIOViewModel.FileData��%t  (��       5A   3   *, +)(�� 2    5L   '   *, +)�� 5A      "  63    6X   �� *	ListFiles+.R�5B      �� $ 
Horizontal=�6)   .+�5D   "   �� ��6,   �� *
FolderPath+�� 5E   "   $�� [��6,   
����  �66   �� 5F   "   
����  ���6,   �� *ListFiles.Count+6M   �� 5G   "   $��]��6,   
����  �65   5H      5I      �� 5L      "  6'   .R�5M      �� $ 
Horizontal=�6)   .+�5O   "   �� ��6,   �� *
FileName+�� 5P   "   $�� (��6,   
��� � �66   �� 5Q   "   
��� � ���6,   �� *
FileSize+6F   �� 5R   "   $
�� Kb)��6,   
��� � �68   5S      5T      5U      5V      5W      � 5Y      $��1��6   .+�5Z      R� $��10q�6>   ��6   �� *
FolderView+��5[      �� 5\      .R�5]      Q� ��6+   �� *FolderLabel+5^      5`      5a      5b      5c      5d      