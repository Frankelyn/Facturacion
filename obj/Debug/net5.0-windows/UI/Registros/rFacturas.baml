   M S B A M L   `   `   `  ����D  @VentasWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:VentasWPF.UI.RegistrosVentasWPF.UI.Registros  5   	   &     VentasWPF.UI.Registros.rFacturas   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:VentasWPF.UI.Registros     5   	     � Title$  Facturas��5   	   $	��530��6   $	��570��6'    � WindowStartupLocation$ CenterScreen=�63    � 
ResizeMode$ NoResize=�6X   .��5	      � .+�5
   
   �� .+�5      �� $��Center=�6   .+�5      �� $��Facturacion��6   $��Comic Sans MS)�6.   $��24(�6I   $��Center=�6W   �� 5       �� Orientation$ 
Horizontal=�6   $��0,10,0,0q�66   .+�5      �� $��	FacturaId��6   $��Comic Sans MS)�60   $��12(�6K   �� 5      $��Fecha��6   $��Comic Sans MS)�6,   $��12(�6G   $��	300,0,0,0q�6U   5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ FacturaIdTextbox��5      $��25��6S   $��80��6_   $��Comic Sans MS)�6k   $��12(�6�   ��68   �� *	FacturaId+6�   �� 5      -   5         ��Name$ BuscarButton��5      $��10,0,0,0q�63   .��5      �� $ 
Horizontal=�6%   .+�5      �� $$��/Resources/search-icon (2).png��6$   $��25��6L   5      5      (  "System.Windows.Controls.DatePicker  5      -   5        $��FechaDatePicker��5   !   $��	250,0,0,0q�6^      SelectedDateFormat$ Short=�6q   $��Comic Sans MS)�6�      SelectedDate 68   �� *FechaFactura+6�   5      �� 5      $ 
Horizontal=�6   $��0,10,0,0q�66   .+�5      �� $��Cliente��6   $��Comic Sans MS)�6.   �� 5      -   5        $ NombreClienteTextbox��5      $��Comic Sans MS)�6[   $	��173��6v   ��6<   �� *NombreCliente+6v   �� 5!      $��Cantidad de Productos��6   $��Comic Sans MS)�6<   �� 5"      -   5        $ CantidadTextbox��5"      $��Comic Sans MS)�67   $��50��6R   �� 5$      -   5        $ ImprimirButton��5$      $	��102��66   $��10,0,0,0q�6B   $��30��6T   .��5%      �� $ 
Horizontal=�6%   .+�5&      �� $��/Resources/print-icon.png��6$   $��25��6G   �� 5'      $��Imprimir��6$   $��Comic Sans MS)�67   $��14(�6R   5(      5)      5*      �� 5,      $ 
Horizontal=�6   .+�5-      &   System.Windows.Controls.DataGrid  -   5          Name$ DetalleDatagrid��5-      $	��250��6X   $��Comic Sans MS)�6f   	   AutoGenerateColumns$	 False��6�   $��0,10,0,0q�6�   $	��407��6�   ��68   �� *	Detalle+
   Columns
 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ 
ProductoId��61      
IsReadOnly$
 True��6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Producto.ProductoId+6m     51      $ Nombre��61   $
 True��6e    6A   �� *Producto.Nombre+6e     52      $ Marca��61   $
 True��6c    6@   �� *Producto.Marca+6c     53      $ Cantidad��61    6C   �� *
Unidades+  54      $ Precio��61   $
 True��6v    6A   �� *Producto.Precio+ �� StringFormat$ N2��6v     55      $ Itbis��61   $
 True��6k    6@   �� *ITBIS+$ N2��6k     56      $ Total��61   $
 True��6k    6@   �� *Monto+$ N2��6k   59      �� 5;      $ Vertical=�6!   $��	10,10,0,0q�68   .+�5<      �� -   5        $ AgregarProductoButton��5<   !   $��40��6d   .��5=      �� $ 
Horizontal=�6)   .+�5>   "   �� $$��/Resources/Alarm-Plus-icon.png��6(   $��30��6P   �� 5?   "   $��Producto��6(   $��Comic Sans MS)�6;   $��14(�6V   5@      5A      �� 5B      -	   5        $ QuitarProductoButton��5B   !   $��0,10,0,0q�6b   $��40��6t   .��5C      �� $ 
Horizontal=�6)   .+�5D   "   �� $%��/Resources/Alarm-Minus-icon.png��6(   $��30��6Q   �� 5E   "   $��Producto��6(   $��Comic Sans MS)�6;   $��14(�6V   5F      5G      �� 5I      -
   5        $ NuevoButton��5I   !   $��0,35,0,0q�6P   $	��100��6b   $��35��6n   .��5J      �� $ 
Horizontal=�6)   $��97��6B   .+�5K   "   �� $��/Resources/new-icon.png��6(   $��30��6I   �� 5L   "   $��Nuevo��6(   $��Comic Sans MS)�68   $��14(�6S   5M      5N      �� 5P      -   5        $ GuardarButton��5P   !   $��0,10,0,0q�6T   $	��100��6f   $��35��6r   .��5Q      �� $ 
Horizontal=�6)   .+�5R   "   �� $"��/Resources/save-icon (1).png��6(   $��25��6N   �� 5S   "   $��Guardar��6(   $��Comic Sans MS)�6:   $��14(�6U   5T      5U      �� 5W      -   5        $ EliminarButton��5W   !   $��0,10,0,0q�6V   $	��100��6h   $��35��6t   .��5X      �� $ 
Horizontal=�6)   .+�5Y   "   �� $.��(/Resources/Actions-window-close-icon.png��6(   $��25��6Z   �� 5Z   "   $��Eliminar��6(   $��Comic Sans MS)�6;   $��14(�6V   5[      5\      5_      5`      �� 5b      $��0,10,0,0q�6   .+�5c      �� $��Total:��6   $��Comic Sans MS)�6-   $��16(�6H   
���  ��$
��Bold"�6g   $��Center=�6y   �� 5d      -   5         ��Name$ MontoTotalLabel��5d      $��Comic Sans MS)�6e   $��24(�6�   
����+��$
��Bold"�6�   $��Center=�6�   ��65   �� *
MontoTotal+$ N2��6�   5e      5f      5g      5h      5i      