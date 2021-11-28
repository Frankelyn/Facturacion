using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VentasWPF.BLL;
using VentasWPF.Entidades;

namespace VentasWPF.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProductos.xaml
    /// </summary>
    public partial class rProductos : Window
    {

        private Productos Producto = new();
        public rProductos()
        {
            InitializeComponent();
            this.DataContext = Producto;
        }


        private void Limpiar()
        {
            this.Producto = new Productos();
            this.DataContext = Producto;
        }

        private bool Validar()
        {
            bool esValido = true;
            if(NombreTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el nombre", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (MarcaTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta la marca", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (CostoTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el costo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (PrecioTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el precio", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (CantidadTextbox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta la cantidad", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var producto = ProductosBLL.Buscar(Producto.ProductoId);

            if(producto != null)
            {
                this.Producto = producto;
                this.DataContext = Producto;
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = ProductosBLL.Guardar(Producto);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductosBLL.Eliminar(Producto.ProductoId))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
