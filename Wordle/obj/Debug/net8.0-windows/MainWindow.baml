   M S B A M L   `   `   `  ����A  =Wordle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WordleWordle  5   	       Wordle.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Wordle     5   	     � Title$  Wordle��5   	   $	��450��6   $	��800��6%   
������� � 	Resources 5	         ModernButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value��%�  &	        �� 5
   
   " ��6%   .�5      ��  � �� �#007ACC6+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � �� �#007ACC6,   �� 5       � ��$ 2q�60   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 5��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5       5      P� 5        �@J�IsMouseOver$
	 True��61   . �5!      ��  � �� �#005A9E63   �� 5"       � �� �#005A9E64   5#      5%      5&      .��5(      � 
 � RowDefinitions
 5)   
   �� 5*      $
��Auto �6   �� 5+      $��* �6   .+�5.   
   �� $��0��6   $��Center=�6"   $��Center=�6?   $��10q�6Z   .+�5/      �� $��Resources/wordle.png��6   $	��100��62   $	��100��6>   $��10q�6K   �� 50      $��WORDLE��6   $��36(�6&   $
��Bold"�64   ���#333$��Center=�6X   $��10q�6u   �� 51       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��10q�6O   .+�52      �� -   5        $��	3 Letters��52      $	��100��6-   $��40��69   $��5q�6E   #��[  6q   �� 53      -   5        $��	4 Letters��53      $	��100��6-   $��40��69   $��5q�6E   #��[  6p   �� 54      -   5        $��	5 Letters��54      $	��100��6-   $��40��69   $��5q�6E   #��[  6p   �� 55      -   5        $��	6 Letters��55      $	��100��6-   $��40��69   $��5q�6E   #��[  6o   56      57      �� 59   
   -   5        $��How to play��59      $��1��6'   $	��200��64   $��40��6@   $��Center=�6L   $	��Top=�6i   $��10q�6�   #��[  6�   5:      5;      