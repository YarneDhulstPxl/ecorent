   M S B A M L   `   `   `  ����B  >EcoRent, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null+clr-namespace:EcoRent.ViewEcoRent.View  5   	   5clr-namespace:EcoRent.ViewModelEcoRent.ViewModel  5   	   $    EcoRent.View.BeheerReservaties   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:EcoRent.View     5   	   5	viewmodelclr-namespace:EcoRent.ViewModel     5   	     � Title$  Beheer reservaties��5	   	   $	��450��6$   $	��800��61    � Icon$ /Resources/icon.png��6=    � 	Resources 5      +   %EcoRent.ViewModel.ReservatieViewModel   ReservatieViewModel��%   &	          5   
   6(   5      .��5      �  � DataContext# [  6    � RowDefinitions 5   
   �� 5      $
��177* �6   �� 5      $
��200* �6    � ColumnDefinitions 5   
   �� 5      $	��550 �6   �� 5      $	��100 �6   �� 5      $
��100* �6   .+�5   
   �� $��0��6    �� SelectionMode$ Single=�5      $��
0,0,10.4,0q�5   >   $��2��6R   ��5      �� *Reservaties+ �� SelectedItem 5      �� *CurrentReservatie+ �� View 5       �� 5!      .P�5"      �� 	 �� Width$		 100��6%   $��ReservatieID��5#   %   
 ^� ToolTip$
 Reservatie Id��5$   T    �� DisplayMemberBinding 6%   �� *ReservatieID+6T   �� 5%      $		 120��6%   $��
BeginDatum��5&   %   $
 Begin datum��5'   Q    6%   �� *
BeginDatum+6Q   �� 5(      $		 120��6%   $��	EindDatum��5)   %   $
 
Eind datum��5*   P    6%   �� *	EindDatum+6P   �� 5+      $		 100��6%   $��AutoID��5,   %   $
 Auto Id��5-   M    6%   �� *AutoID+6M   �� 5.      $		 100��6%   $��ChauffeurID��5/   %   $
 Chauffeur Id��50   R    6%   �� *ChauffeurID+6R   52      54      �� 55   
   $��1��6   $��10,0,-0.4,0q�6%   $��2��6:   .+�56      �� $��10,20,10,10q�6   $	��Id:��6-   $
 Id��68   �� 57      $��
10,5,10,11q�6   $��BeginDatum:��6,   $
 Begin datum��6?   �� 58      $��
10,8,10,11q�6   $��
EindDatum:��6,   $
 
Eind datum��6>   �� 59      $��
10,2,10,11q�6   $��AutoID:��6,   $
 Auto Id��6;   �� 5:      $��10,2,9.667,11q�6   $��ChauffeurID:��6/   $
 Chauffeur Id��6C    J� RenderTransformOrigin$ 
0.465,1.26&�6m   5;      �� 5<   
   $��2��6   $��2��6&   .+�5=      �� $��10,20,10,10q�6   $
 Id��5>   x   ��6   �� * CurrentReservatie.ReservatieID+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6x   (  "System.Windows.Controls.DatePicker  5?      $��
10,0,10,10q�6   $
 Begin datum��5@   v      Text 6   �� *CurrentReservatie.BeginDatum+$ TwoWay=�$ PropertyChanged=�6v     5A      $��
10,0,10,10q�6   $
 
Eind datum��5B   u    6   �� *CurrentReservatie.EindDatum+$ TwoWay=�$ PropertyChanged=�6u   �� 5C      $��
10,0,10,10q�6   $
 Auto Id��5D   r   ��6   �� *CurrentReservatie.AutoID+$ TwoWay=�$ PropertyChanged=�6r   �� 5E      $��	10,0,10,5q�6   $
 Login��5F   x   ��6   �� *CurrentReservatie.ChauffeurID+$ TwoWay=�$ PropertyChanged=�6x   �� 5G      $��10,20,9.8,10q�6   $��Wijzigen��6+   ���#63625D���#F1FF9C$��30��5H   9   $
 Wijzigen��6F   ��6   �� *WijzigenCommand+6F   �� 5I      -   5        $��verwijderButton��5I      $��10,12,10,10q�6,   $��Verwijderen��6A   ���#63625D���#FF423A$��30��5J   <   $
 Verwijderen��6H   ��6   �� *VerwijderenCommand+6H   5K      5L      5M      