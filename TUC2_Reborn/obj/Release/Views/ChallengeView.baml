   M S B A M L   `   `   `  ���� F  BTUC2_Reborn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TUC2_Reborn.ViewsTUC2_Reborn.Views  ?$clr-namespace:TUC2_Reborn.ViewModelsTUC2_Reborn.ViewModels  %    TUC2_Reborn.Views.ChallengeView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:TUC2_Reborn.Views     :	viewModel$clr-namespace:TUC2_Reborn.ViewModels     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .���   � ColumnDefinitions  �� $��100px��$��1* ��� $��2* � � RowDefinitions �� $
��45px ��� �� $
��65px �.+��� $!��Список завдань��$��0��$��0�� #  MaterialDesignHeadlineTextBlock#��[  $
��Wrap=�
���   �$
��22px(�$��Center=�$��Center=��� $C��=Інформація про виділене завдання��$��0��$��1��#��[  $
��Wrap=�
���   �$
��22px(�$��Center=�$��Center=��� -    ��Name$ ChallengeNamesList��$��1��$��0��$��5q����� .R��� ����  �� Path$
 Name��� -    ��Name$ AddNewChallenge��$��Додати��$��2��$��0��$
��18px(�$��SemiBold"�$
��45px��$��10q�$��Stretch=�$��Stretch=�]� $��1��$��1��.+��� ��. $��Disabled=�.���� -    ��Name$ ItemsControl������ .R��� .+���  ��Name$ ChallengeName��$	��Top=� ( $MaterialDesignFilledTextFieldTextBox#��[ $��10, 7, 10, 0q�$��18(�
���   �)  #MaterialDesignThemes.Wpf.HintAssist   Hint$! Назва завдання������ $
 Name��� $ ChallengeDescription��$	��Top=� * &MaterialDesignOutlinedTextFieldTextBox#��[ $��10, 7, 5, 0q�$	��160�� �� AcceptsReturn . 	 �� TextWrapping$
	 Wrap=�$��18(�
���   �"
 �� VerticalScrollBarVisibility$

 Auto=�$ Опис завдання������ $ Description��� $B��<Приклади вводу і виводу програми��$	��Top=� % !MaterialDesignSubheadingTextBlock#��[ $��10, 7, 5, 0q�$��Center=�
���   �$��SemiBold"�$
��15px(�� $��
0, 7, 0, 0q�  �� ��  �� �� .+�&   System.Windows.Controls.DataGrid    Name$ DataGridExamples��$��2��$	��5 5q�   AutoGenerateColumns .     CanUserSortColumns .    CanUserAddRows .    CanUserDeleteRows .    
IsReadOnly .  ���� $ Examples� �� Mode$ TwoWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Вхідні дані��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� $ Input�   ElementStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value$
 Wrap=�   EditingElementStyle �� " �� 0 ,MaterialDesignDataGridTextColumnEditingStyle �� BasedOn# [ .���  �@��TextWrapping$
 Wrap=���  �@��AcceptsReturn .   $ Вихідні дані��$ 1*  �� $ Output� �� " ��.���  � ��$
 Wrap=� �� " ��# [ .���  �@��TextWrapping$
 Wrap=���  �@��AcceptsReturn . �� $ 	EditTests��-   $%��Редагувати тести��$��1��$��0��$��2��$
��45px��$��5, 10q�$
��22px(�� $��2��$��1��  �� �� .+��� -   $
 Save��$��Зберегти��$��0��$
��18px(�$��SemiBold"�$
��45px��$��10q�$��Stretch=��� -   $ Remove��$��Видалити��$��1��$
��18px(�$��SemiBold"�$
��45px��$��10q�$��Stretch=�