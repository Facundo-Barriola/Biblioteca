   M S B A M L   `   `   `  ����K  GVistasBiblioteca, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:VistasBiblioteca.ViewsVistasBiblioteca.Views  5   	   &     VistasBiblioteca.Views.LibroForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:VistasBiblioteca.Views     5   	     � Title$  	LibroForm��5   	   $	��450��6   $	��800��6(   .��5	      � $��10q�6    � ColumnDefinitions 5
   
   �� 5      $	��100 �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Titulo:��6   $��Center=�6#   �� 5   
   $��0��6   $��1��6   $��20q�6/   ��6;   �� *LibroModelTitulo+�� 5   
   $��1��6   $��	Sinopsis:��6!   $��Center=�62   �� 5   
   $��1��6   $��1��6   $��20q�6/   ��6;   �� *LibroModelSinopsis+�� 5   
   $��2��6   $��Puntaje Crítica:��6!   $��Center=�69   �� 5   
   $��2��6   $��1��6   $��20q�6/   ��6;   �� *LibroModelPuntaje+�� 5!   
   $��3��6   $��Estado:��6!   $��Center=�60   �� 5"   
   $��3��6   $��1��6   $��20q�6/   ��6;   �� *LibroModelEstado+�� 5$   
   $��4��6   $��Disponibilidad:��6!   $��Center=�68   �� 5%   
   $��4��6   $��1��6    $��10q�60    d� 	IsChecked 6<   �� *LibroModelDisponibilidad+�� 5'   
   $��5��6   $��Seccion:��6!   $��Center=�61   �� 5(   
   $��5��6   $��1��6   $��20q�6/   ��6;   �� *LibroModelSeccion+�� 5*   
   $��6��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��20q�6h   .+�5+      �� $��Guardar��6   ��6'   �� *SaveLibroCommand+�� 5,      $��Cancelar��6   ��6(   �� *CancelCommand+5-      50      51      