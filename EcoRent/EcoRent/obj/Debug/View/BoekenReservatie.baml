   M S B A M L   `   `   `  ����B  >EcoRent, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null+clr-namespace:EcoRent.ViewEcoRent.View  5   	   5clr-namespace:EcoRent.ViewModelEcoRent.ViewModel  5   	   #    EcoRent.View.BoekenReservatie   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:EcoRent.View     5   	   5	viewmodelclr-namespace:EcoRent.ViewModel     5   	     � Title$  Boeken reservatie��5	   	   $	��450��6#   $	��800��60    � Icon$ /Resources/icon.png��6<    � 	Resources 5      %   EcoRent.ViewModel.AutoViewModel   AutoViewModel��%   &	          5   
   6"   5      .��5      �  � DataContext# [  6    � RowDefinitions 5   
   �� 5      �� 5      $��6* �6    � ColumnDefinitions 5   
   �� 5      $
��563* �6   �� 5      $
��230* �6   .+�5   
   �� -   5        $��reservatieList��5      $��0��5      $��1��5       �� SelectionMode$ Single=�5      $��	0,3,3.2,0q�5   8   ��5      �� *Autos+ �� SelectedItem 5      �� *CurrentAuto+ �� View 5       �� 5!      .P�5"      �� 	 �� Width$	 60��6%   $
��Auto��5#   %   
 ^� ToolTip$

 Auto��5$   K    �� DisplayMemberBinding 6%   �� *Naam+6K   �� 5%      $	 60��6%   $��Bouwjaar��5&   %   $
 Bouwjaar��5'   O    6%   �� *
Bouwjaar+6O   �� 5(      $	 60��6%   $
��Merk��5)   %   $

 Merk��5*   K    6%   �� *Merk+6K   �� 5+      $	 70��6%   $��Vermogen��5,   %   $
 Vermogen��5-   O    6%   �� *
Vermogen+6O   �� 5.      $		 110��6%   $��Beschrijving��5/   %   $
 Beschrijving��50   S    6%   �� *Beschrijving+6S   51      53      �� 54   
   $
��Left=�6   $��191,10,0,10q�6/   $
��Wrap=�6D   $-��'Selecter een auto en boek je reservatie��6X   $��Center=�6�   $��40��6�   $	��309��6�   $��16(�6�   �� 55   
   $��..\Resources\ecorent.png��6   $��44,10,411.2,11q�62   �� 56   
   -   5        $��maakReservatie��56      $��Maak reservatie��6'   $��1��6A   $
��Left=�6Q   $��49.8,51,0,0q�6l   $��1��6�   $	��Top=�6�   $	��123��6�   ���#63625D���#48FF93$��30��6�   $
 Maak reservatie��6  �� 57   
   -   5        $��bekijkReservatie��57      $��Bekijk reservaties��6)   $��1��6F   $
��Left=�6V   $��49.8,105,0,0q�6q   $��1��6�   $	��Top=�6�   $	��123��6�   ���#63625D���#F1FF9C$��30��6  $
 Bekijk reservaties��6  �� 58   
   -   5        $��
backButton��58   *   
������ $��Right=�6<   $��46��6X   $��-2,-2,519.2,2q�6|   .��59      �� .+�5:      �� $"��../Resources/back_button.png��6   $��44��6>   $��40��6I    J� RenderTransformOrigin$ 	0.536,0.5&�6U   5;      5<      5@      5A      