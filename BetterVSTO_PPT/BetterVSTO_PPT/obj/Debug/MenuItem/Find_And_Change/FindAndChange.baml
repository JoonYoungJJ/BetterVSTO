   M S B A M L   `   `   `  ����J  FDokleysControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:DokleysControls;assembly=DokleysControlsDokleysControls  5      b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5      I EBetterVSTO_PPT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:BetterVSTO_PPT.MenuItem.Find_And_Change'BetterVSTO_PPT.MenuItem.Find_And_Change 5      ;   5BetterVSTO_PPT.MenuItem.Find_And_Change.FindAndChange   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      FDok6clr-namespace:DokleysControls;assembly=DokleysControls     5      ^ThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:BetterVSTO_PPT.MenuItem.Find_And_Change     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	      $	��450��5
      $	��600��5        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $I Cpack://application:,,,/DokleysControls;component/Styles/Styles.xaml?�6%   %    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��0 �6   �� 5      $��0 �6   �� 5      -   5         ��Name$ TextRow��5      $��70 �6-   �� 5      $��* �6   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $��40 �6   .+�5#   
   � $��1��6   .+�5$      �  5%      �� 5&      $��* �6'   �� 5'      $��* �6'   �� 5(      $��* �6'   5*      5+      � 5-   
   $��2��6    5.      �� 5/      $	��100 �6#   �� 50      $��6* �6#   �� 51      $��* �6#   �� 52      $��* �6#    54      �� 55      $��* �6    �� 56      -   5        $ 
ReplaceRow��56       $��* �64   .+�58      �� $��0��59      $��15,0,0,0q�5:      $��Center=�5;      
������ $��Search Word��5=       � Cursor$ Arrow��5>      |�.  $
��Bold"�5@      �� 5A      -   5         ��Name$ Target_String��5B      $��1��5C      $��	15,5,15,5q�5D      $��Center=�5E      $��Center=�5F      
������ $��	0,0,0,1.2q�5H      $��맑은 고딕)�5I       �� TextWrapping$
 Wrap=�5K      	 � ToolTip$)	 #찾을 텍스트를 입력하세요��5L      ��5J      �� *TargetString+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5L      !   DokleysControls.ImageButton  5M      -   5          Name$ 
b_FindText��5N      $��2��5O      $��20��5P      $��20��5Q      
   Pad$ 2��5S      $	 Start Searching��5T      �� 5U      $��1��5V      $��0��5W      $��15,0,0,0q�5X      $��Center=�5Y      
������ $��Replace Word��5[      $ Arrow��5\      |�.  $
��Bold"�5^      �� 5_      -   5        $ Replace_String��5`      $��1��5a      $��1��5b      $��	15,5,15,5q�5c      $��Center=�5d      $��Center=�5e      
������ $��	0,0,0,1.2q�5g      $��맑은 고딕)�5h      $
 Wrap=�5j      $*	 $바꿀 텍스트를 입력하세요.��5k      ��5i      �� *ReplaceString+$
 TwoWay=�$ PropertyChanged=�5k      5l      � 5o   
   $��3��6    5p      �� 5q      $��* �6    �� 5r      $��30 �6    .+�5�      �� $��1��5�      $��0,3,0,3q�5�      $��0,0,15,0q�5�      $��Right=�5�      $��Center=�5�      
������ $��
ExtraLight"�5�      
���������5�      �� *
ResultInfo+$
 TwoWay=�$ PropertyChanged=�5�      5�      � 5�   
   $��4��6    5�      �� 5�      $��3* �6#   .+�5�      �� $��0��5�      $��15,3,3,3q�5�      $��Bottom=�5�      $
��Left=�5�      
������ $��Format��5�      $ Arrow��5�      |�.  $
��Bold"�5�      5�      � 5�   
   $��5��6    5�      �� 5�      $��3* �6#   �� 5�      $��* �6#   .+�5�      � $��0��6    5�      �� 5�      $��15 �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5      $��* �6'   �� 5     $��* �6'   �� 5     $��15 �6'   .+�5     � $��1��6    5     �� 5     $��7 �6(   �� 5     $��* �6(   �� 5	     $��7 �6(   .+�5     '   !DokleysControls.RoundToggleButton  $��0��5     $��5,0,5,0q�5     {�5     �� *Format_Font_Background_En+$
 TwoWay=�$ PropertyChanged=�  5     -   5        $ b_Format_Font_Background��5     $��1��5     $ 5 0 5 0��5     {�5     �� *Format_Font_Background_En+$
 TwoWay=�$ PropertyChanged=�5     �� 5     $��2��5     $��5,0,5,0q�5     ��5     �� *Format_Font_Background+$
 TwoWay=�$ PropertyChanged=�5     � 5     $��2��6    5     �� 5     $��7 �6(   �� 5     $��* �6(   �� 5      $��7 �6(   .+�5"       $��0��5#     $��5,0,5,0q�5$     {�5%     �� *Format_Font_Foreground_En+$
 TwoWay=�$ PropertyChanged=�  5&     -   5        $ b_Format_Font_Foreground��5'     $��1��5(     $ 5 0 5 0��5+     {�5*     �� *Format_Font_Foreground_En+$
 TwoWay=�$ PropertyChanged=�5+     �� 5,     $��2��5-     $��5,0,5,0q�5.     ��5/     �� *Format_Font_Foreground+$
 TwoWay=�$ PropertyChanged=�50     � 52     $��3��6    53     �� 54     $��7 �6(   �� 55     $��* �6(   .+�57       $��0��58     $��5,0,5,0q�59     {�5:     �� *Format_Font_Size_En+$
 TwoWay=�$ PropertyChanged=�  5;     $��1��5<     $ 5 0 5 0��5>     {�5=     �� *Format_Font_Size_En+$
 TwoWay=�$ PropertyChanged=�5>     �� 5?     -   5        $ FontSizeTextBox��5@     $��1��5A     $��5,5,5,1q�5B     $��Center=�5C     $��Center=�5D     
���iii�$��10(�5F     {�5G     �� *Format_Font_Size_En+$
 TwoWay=�$ PropertyChanged=���5H     �� *Bind_AS_Font_Size+$
 TwoWay=�$ PropertyChanged=�5I     � 5K     $��4��6    5L     �� 5M     $��7 �6(   �� 5N     $��* �6(   .+�5P       $��0��5Q     $��5,0,5,0q�5R     {�5S     �� *Format_Font_Size_En+$
 TwoWay=�$ PropertyChanged=�  5T     $��1��5U     $ 5 0 5 0��5W     {�5V     �� *Format_Font_Size_En+$
 TwoWay=�$ PropertyChanged=�5W     5X     � 5Z     $��5��6    5[     �� 5\     $��7 �6(   �� 5]     $��* �6(   .+�5_       $��0��5`     $��5,0,5,0q�5a     {�5b     �� *Format_Font_Size_En+$
 TwoWay=�$ PropertyChanged=�  5c     $��1��5d     $ 5 0 5 0��5f     {�5e     �� *Format_Font_Size_En+$
 TwoWay=�$ PropertyChanged=�5f     5g     � 5i     $��6��6    5j     �� 5k     $��7 �6(   �� 5l     $��* �6(   .+�5n       $��0��5o     $��5,0,5,0q�5p     {�5q     �� *Format_Font_Size_En+$
 TwoWay=�$ PropertyChanged=�  5r     $��1��5s     $ 5 0 5 0��5u     {�5t     �� *Format_Font_Size_En+$
 TwoWay=�$ PropertyChanged=�5u     5v     � 5y     $��7��6    5z     �� 5{     $��7 �6(   �� 5|     $��* �6(   .+�5~       $��0��5     $��5,0,5,0q�5�     {�5�     �� *Format_Font_Size_En+$
 TwoWay=�$ PropertyChanged=�  5�     $��1��5�     $ 5 0 5 0��5�     {�5�     �� *Format_Font_Size_En+$
 TwoWay=�$ PropertyChanged=�5�     5�     5�     5�     � 5�  
   $��6��6    5�     �� 5�     $��* �6#   �� 5�     $��* �6#   �� 5�     $��* �6#   5�     5�     5�     