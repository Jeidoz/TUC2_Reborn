   M S B A M L   `   `   `  ���� F  BTUC2_Reborn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TUC2_Reborn.ViewsTUC2_Reborn.Views  +    %TUC2_Reborn.Views.ChallengeSolverView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:TUC2_Reborn.Views     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .���   � ColumnDefinitions  �� $��100px��$��1* ��� $��2* � � RowDefinitions �� $
��45px ��� �� $��165px �.+��� $!��Список завдань��$��0��$��0�� #  MaterialDesignHeadlineTextBlock#��[  $
��Wrap=�
���   �$
��22px(�$��Center=�$��Center=��� $C��=Інформація про виділене завдання��$��0��$��1��#��[  $
��Wrap=�
���   �$
��22px(�$��Center=�$��Center=��� -    ��Name$ ChallengeList��$��1��$��0��$��2��$��5q����� .R��� ����  �� Path$
 Name�]� $��1��$��1��.+��� ��. $��Disabled=�.���� -    ��Name$ ItemsControl������ .R��� .+���  ��Name$ ChallengeName��$	��Top=� �� 
IsReadOnly .  ( $MaterialDesignFilledTextFieldTextBox#��[ $��10, 7, 10, 0q�$��18(�
���   �)  #MaterialDesignThemes.Wpf.HintAssist   Hint$! Назва завдання������ $
 Name��� $ ChallengeDescription��$	��Top=� .  * &MaterialDesignOutlinedTextFieldTextBox#��[ $��10, 7, 5, 0q�$	��160�� �� AcceptsReturn . 	 �� TextWrapping$
	 Wrap=�$��18(�
���   �"
 �� VerticalScrollBarVisibility$

 Auto=�$ Опис завдання������ $ Description��� $B��<Приклади вводу і виводу програми��$	��Top=� % !MaterialDesignSubheadingTextBlock#��[ $��10, 7, 5, 0q�$��Center=�
���   �$��SemiBold"�$
��15px(�� $��
0, 7, 0, 0q�  �� ��  �� �� .+�&   System.Windows.Controls.DataGrid    Name$ DataGridExamples��$��2��$	��5 5q�   AutoGenerateColumns .     CanUserSortColumns .    CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . ���� $ Examples� �� Mode$ TwoWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Вхідні дані��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� $ Input�   ElementStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value$
 Wrap=�   EditingElementStyle �� " �� 0 ,MaterialDesignDataGridTextColumnEditingStyle �� BasedOn# [ .���  �@��TextWrapping$
 Wrap=���  �@��AcceptsReturn .   $ Вихідні дані��$ 1*  �� $ Output� �� " ��.���  � ��$
 Wrap=� �� " ��# [ .���  �@��TextWrapping$
 Wrap=���  �@��AcceptsReturn . � $��2��$��1��  �� ��  �� �� �� .+�� $��0��$��0��$��2��  �� $��2* ��� $��1* �.+��� -   $ CodeFileName��$��0��#��[  . $
��5, 0q�$
��80px��$
��14px(�
���   �$/ )Файл із кодом програми���� -    ��Name$ SelectCodeFile��$��1��$
��5, 0q�$
��55px��.���� $
��Wrap=�$��Вибрати файл��$
��18px(��� -   $ CheckSolution��$I��CРозпочати тестування вашого рішення��$��1��$��0��$��2��$
��18px(�$��SemiBold"�$
��40px��$��250px��$��5q�{�.  $��Center=�� $��2��$��0��$��2��  �� �� �� .+��� -   $ PreviusChallenge��$��0��$
��18px(�$��SemiBold"�$��5q�$
��40px��$��
Назад���� -    ��Name$ ChallengeNumber��$��0 / 0��$��1��#��[ $
��40px��
���   �$��Center=�$��Center=�$��10q�$
��25px(�$��SemiBold"�$ № завдання���� -   $ NextChallenge��$��2��$
��18px(�$��SemiBold"�$��5q�$
��40px��$��Вперед��