   M S B A M L   `   `   `  ����F  BTUC2_Reborn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TUC2_Reborn.ViewsTUC2_Reborn.Views  5      ?$clr-namespace:TUC2_Reborn.ViewModelsTUC2_Reborn.ViewModels  5      %    TUC2_Reborn.Views.ChallengeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:TUC2_Reborn.Views     5      :	viewModel$clr-namespace:TUC2_Reborn.ViewModels     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      �   � ColumnDefinitions  5   
   �� 5      $��100px��6   $��1* �60   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $
��45px �6   �� 5      �� 5      $
��65px �6   .+�5   
   �� $!��Список завдань��6   $��0��5      $��0��6!    #  MaterialDesignHeadlineTextBlock#��[  5      $
��Wrap=�5      
���   �$
��22px(�5   '   $��Center=�5      $��Center=�61   �� 5   
   $C��=Інформація про виділене завдання��6   $��0��5      $��1��6!   #��[  5      $
��Wrap=�5      
���   �$
��22px(�5    '   $��Center=�5!      $��Center=�61   �� 5#   
   -   5         ��Name$ ChallengeNamesList��5#      $��1��5$      $��0��6    $��5q�5%      ��5'      �� 5(      .R�5)      �� ��6    ��  �� Path$
 Name�5*      5,      �� 5-   
   -   5         ��Name$ AddNewChallenge��5-      $��Додати��6*   $��2��5.      $��0��6   $
��18px(�5/      $��SemiBold"�6!   $
��45px��50      $��10q�51      $��Stretch=�52      $��Stretch=�6/   53      ]� 55   
   $��1��6   $��1��6!   .+�56      �� ��. $��Disabled=�57      .��58      �� -   5         ��Name$ ItemsControl��58      ��59      �� 5:      .R�5;      �� .+�5<   "   ��  ��Name$ ChallengeName��6*   $	��Top=�5>   *    ( $MaterialDesignFilledTextFieldTextBox#��[ 5?   *   $��10, 7, 10, 0q�5@   *   $��18(�5A   *   
���   �)  #MaterialDesignThemes.Wpf.HintAssist   Hint$! Назва завдання��5B   *   ��5=   *   �� $
 Name�5B   *   �� 5C   "   $ ChallengeDescription��6*   $	��Top=�5E   *    * &MaterialDesignOutlinedTextFieldTextBox#��[ 5F   *   $��10, 7, 5, 0q�5G   *   $	��160��5H   *    �� AcceptsReturn . 	 �� TextWrapping$
	 Wrap=�5J   *   $��18(�5K   *   
���   �"
 �� VerticalScrollBarVisibility$

 Auto=�5L   *   $ Опис завдання��5M   *   ��5D   *   �� $ Description�5M   *   �� 5N   "   $B��<Приклади вводу і виводу програми��6,   $	��Top=�5O   ,    % !MaterialDesignSubheadingTextBlock#��[ 5P   ,   $��10, 7, 5, 0q�5Q   ,   $��Center=�5R   ,   
���   �$��SemiBold"�5S   ?   $
��15px(�5T   ,   � 5U   "   $��
0, 7, 0, 0q�6'     5V   &   �� 5W   *   �� 5X   *    5Z   &   �� 5[   *   �� 5\   *   .+�5^   &   &   System.Windows.Controls.DataGrid    Name$ DataGridExamples��6/   $��2��5_   /   $	��5 5q�5a   /      AutoGenerateColumns .     CanUserSortColumns .    CanUserAddRows .    CanUserDeleteRows .    
IsReadOnly .  ��5`   /   �� $ Examples� �� Mode$ TwoWay=�   Columns 5g   *   0  *System.Windows.Controls.DataGridTextColumn  5h   .   ,  &System.Windows.Controls.DataGridColumn   Header$ Вхідні дані��5i   A      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 5j   A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5h   A   �� $ Input�   ElementStyle 5k   2   �� 5l   6    �� 
TargetType" ��6<   .�5m   :   ��  �� Property � �� �� Value$
 Wrap=�6Y   5n   7      EditingElementStyle 5p   2   �� 5q   6   " ��6<    0 ,MaterialDesignDataGridTextColumnEditingStyle �� BasedOn# [ 6Q   .�5r   :   ��  �@��TextWrapping$
 Wrap=�6Y   �� 5s   :    �@��AcceptsReturn . 6Z   5t   7   5v   /     5w   .   $ Вихідні дані��5x   A   $ 1* 5y   A    5w   A   �� $ Output� 5z   2   �� 5{   6   " ��6<   .�5|   :   ��  � ��$
 Wrap=�6Y   5}   7    5   2   �� 5�   6   " ��6<   # [ 6Q   .�5�   :   ��  �@��TextWrapping$
 Wrap=�6Y   �� 5�   :    �@��AcceptsReturn . 6Z   5�   7   5�   /   5�   '   �� 5�   &   $ 	EditTests��6-   -   5        $%��Редагувати тести��5�   @   $��1��5�   -   $��0��6:   $��2��6J   $
��45px��5�   -   $��5, 10q�6;   $
��22px(�5�   -   5�   -   5�   #   5�      5�      5�      5�      5�      � 5�   
   $��2��6   $��1��6     5�      �� 5�      �� 5�      .+�5�      �� -   5        $
 Save��5�      $��Зберегти��6#   $��0��5�      $
��18px(�5�      $��SemiBold"�6%   $
��45px��5�      $��10q�6&   $��Stretch=�5�      5�      �� 5�      -   5        $ Remove��5�      $��Видалити��6%   $��1��5�      $
��18px(�5�      $��SemiBold"�6%   $
��45px��5�      $��10q�6&   $��Stretch=�5�      5�      5�      5�      5�      