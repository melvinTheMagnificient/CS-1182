   M S B A M L   `   `   `  ����H  DDeliverable 5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Deliverable_5Deliverable_5  5   	       Deliverable_5.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Deliverable_5     5   	   -   5          � Title$  
MainWindow��5   	   $	��500��6   $	��500��6)   .��5	      � -   5         �Name$ grdMain��5	       � RowDefinitions 5
   
   �� 5      $��4* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � -   5        $ grdMap��5      $��3��6   $��0,0,164.333,93.667q�63   $��2��6O   5      � 5   
   -   5        $ 
grdSideBar��5      $��2��6$    5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      �� -   5         ��Name$ 	tbMonster��5      $
��Wrap=�6+   $)��#Maximum Hit Points on a Monster is:��6?   $��0��6j    �� TextAlignment$ Center=�6w   �� 5      -   5        $ tbWeapon��5      $
��Wrap=�6*   $&�� Minimum Damage from a Weapon is:��6>   $��1��6f   $ Center=�6s   �� 5      -   5        $ 	tbPotions��5      $
��Wrap=�6+   $*��$Average Healing from all Potions is:��6?   $��2��6k   $ Center=�6x   5      � 5    
   -   5        $ grdDirections��5       $��1��6(   $��1��65   $��1��6E    5!      �� 5"      $��* �6    �� 5#      $��* �6    �� 5$      $��* �6    .+�5&      �� -	   5         ��Name$ btnUp��5&      $��Move Hero Up��6$   $��0��6;   $��1��6I   $y�Hidden=�6n   �� 5'      -
   5        $ btnDown��5'      $��Move Hero Down��6&   $��2��6?   $��1��6M   $y�Hidden=�6t   � 5(      $��1��6   $��1��6#    5)      �� 5*      �� 5+      .+�5-      �� -   5        $ btnLeft��5-      $
��Left��6*   $��0��69   $��0��6G   $��1��6X   $��0,0,0,-0.333q�6i   $y�Hidden=�6�   �� 5.      -   5        $ btnRight��5.      $��Right��6+   $��0��6;   $��1��6I   $��1��6Y   $y�Hidden=�6�   5/      50      �� 51   
   -   5        $ btnStart��51      $��Start/Reset Map��6#   $��1��6=   $��0��6J   6Z   �� 52   
   -   5        $ tbHeroStats��52      $
��Wrap=�6)   $��Name: ---
X: --- Y: ---��6=   $��2��6a   $��1��6q   $ Center=�6~   53      54      