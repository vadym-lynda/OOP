   M S B A M L   `   `   `  ����  WpfApp1#    ArrayProcessingApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Array Processing��5   	   $	��450��6"   $	��800��6/   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0 0 0 10q�6;   .+�5      �� $H��BВведіть кількість елементів масиву:��6   $��Center=�6C   �� 5      -   5         ��Name$ 	InputSize��5      $	��100��6)   $��10 0 0 0q�65   �� 5      -   5        $'��!Згенерувати масив��5      $��10 0 0 0q�6M   5      �� 5   
   -   5        $ OutputArray��5      $��1��6'    �� TextWrapping$
 Wrap=�64   " �� VerticalScrollBarVisibility$
 Auto=�6H    �� 
IsReadOnly . $��50��6}   $��0 0 0 10q�6�   �� 5   
   $��2��6   .+�5      �� -   5        $Z��TОбчислити суму від’ємних з парними індексами��5      $��0 10 0 0q�6o   �� 5      -   5        $ NegativeSumOutput��5       . $��30��6C   $��0 10 0 0q�6O   �� 5      -   5        $?��9Сортувати непарні за спаданням��5      $��0 10 0 0q�6[   �� 5      -   5        $ SortedArrayOutput��5       . $��50��6C   $
 Wrap=�6O   $
 Auto=�6c   5      5      5      