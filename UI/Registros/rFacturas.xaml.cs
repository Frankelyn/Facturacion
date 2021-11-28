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
using VentasWPF.UI.Consultas;

using System.Windows.Navigation;

//using System.Windows.Forms;

using iTextSharp.text.pdf.collection;
using iTextSharp.text.pdf.interfaces;
using iTextSharp.text.pdf.intern;




using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;

namespace VentasWPF.UI.Registros
{
    /// <summary>
    /// Interaction logic for rFacturas.xaml
    /// </summary>
    public partial class rFacturas : Window
    {
        private Facturas Factura = new Facturas();
        public rFacturas()
        {
            InitializeComponent();
            this.DataContext = Factura;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Factura;
        }

        private void Limpiar()
        {
            this.Factura = new Facturas();
            this.DataContext = Factura;
        }

        private bool validar()
        {
            bool esValido = true;

            if (DetalleDatagrid.Items.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Debe agregar un producto para facturar", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var factura = FacturasBLL.Buscar(Factura.FacturaId);

            if (factura != null)
            {
                this.Factura = factura;
                this.DataContext = Factura;
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Cargar();
        }

        private void AgregarProductoButton_Click(object sender, RoutedEventArgs e)
        {

            if (CantidadTextbox.Text.Length > 0)
            {
                cProductos cProductos = new cProductos();
                cProductos.ShowDialog();

                if (Utilidades.Toint(CantidadTextbox.Text) < ClaseCompartida.productoBuscado.Cantidad)
                {
                    var detalle = new FacturasDetalle
                    {
                        FacturaId = this.Factura.FacturaId,
                        Producto = ClaseCompartida.productoBuscado,
                        Unidades = Utilidades.Toint(CantidadTextbox.Text),
                        ITBIS = ClaseCompartida.productoBuscado.Precio * Utilidades.Toint(CantidadTextbox.Text) * 0.18f,
                        Monto = ClaseCompartida.productoBuscado.Precio * Utilidades.Toint(CantidadTextbox.Text)

                    };

                    Factura.MontoTotal += detalle.Monto + detalle.ITBIS;
                    MontoTotalLabel.Content = Factura.MontoTotal.ToString("N2");

                    Factura.Detalle.Add(detalle);
                    Cargar();
                }
                else
                {
                    MessageBox.Show("La cantidad de productos es mayor a la existencia", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Agregue la cantidad de productos a facturar", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void QuitarProductoButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDatagrid.Items.Count >= 1 && DetalleDatagrid.SelectedIndex <= DetalleDatagrid.Items.Count - 1)
            {
                var detalle = (FacturasDetalle)DetalleDatagrid.SelectedItem;

                Factura.MontoTotal -= detalle.Monto - detalle.ITBIS;

                Factura.Detalle.RemoveAt(DetalleDatagrid.SelectedIndex);

                Cargar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!validar())
                return;

            var paso = FacturasBLL.Guardar(Factura);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transaccion Fallida!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (FacturasBLL.Eliminar(Factura.FacturaId))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ImprimirButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog guardar = new Microsoft.Win32.SaveFileDialog();
            guardar.FileName = "Factura" + DateTime.Now.ToString(" dd-M-yyyy") + ".pdf";
            guardar.ShowDialog();

            //string paginaHTML = "<table><tr><td>HOLA MUNDO</td></tr></table>";

            if (guardar.ShowDialog() == DialogResult.HasValue && guardar.ShowDialog() == DialogResult.Value)
            {
                using FileStream stream = new FileStream(guardar.FileName, FileMode.Create);

                //PdfDocument pdfFactura = new PdfDocument();

            }

        }
    }
}
