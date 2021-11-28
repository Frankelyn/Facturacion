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

namespace VentasWPF.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cProductos.xaml
    /// </summary>
    public partial class cProductos : Window
    {
        public cProductos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Productos>();
            if(CriterioTextbox.Text.Trim().Length > 0)
            {
                switch (FiltroCombobox.SelectedIndex)
                {
                    case 0:
                        {
                            if(DesdeDatePicker.SelectedDate != null)
                            {
                                listado = ProductosBLL.GetList(x => x.FechaIngreso.Date >= DesdeDatePicker.SelectedDate &&
                                                               x.FechaIngreso < HastaDatePicker.SelectedDate &&
                                                               x.ProductoId == Utilidades.Toint(CriterioTextbox.Text));
                            }
                            else
                            {
                                listado = ProductosBLL.GetList(x => x.ProductoId == Utilidades.Toint(CriterioTextbox.Text));
                            }
                            break;
                        }
                    case 1:
                        {
                            if (DesdeDatePicker.SelectedDate != null)
                            {
                                listado = ProductosBLL.GetList(x => x.FechaIngreso.Date >= DesdeDatePicker.SelectedDate &&
                                                               x.FechaIngreso < HastaDatePicker.SelectedDate &&
                                                               x.Nombre.ToLower().Contains(CriterioTextbox.Text.ToLower()));
                            }
                            else
                            {
                                listado = ProductosBLL.GetList(x => x.Nombre.ToLower().Contains(CriterioTextbox.Text.ToLower()));
                            }
                            break;
                        }
                    case 2:
                        {
                            if (DesdeDatePicker.SelectedDate != null)
                            {
                                listado = ProductosBLL.GetList(x => x.FechaIngreso.Date >= DesdeDatePicker.SelectedDate &&
                                                               x.FechaIngreso < HastaDatePicker.SelectedDate &&
                                                               x.Marca.ToLower().Contains(CriterioTextbox.Text.ToLower()));
                            }
                            else
                            {
                                listado = ProductosBLL.GetList(x => x.Marca.ToLower().Contains(CriterioTextbox.Text.ToLower()));
                            }
                            break;
                        }
                    case 3:
                        {
                            if (DesdeDatePicker.SelectedDate != null)
                            {
                                listado = ProductosBLL.GetList(x => x.FechaIngreso.Date >= DesdeDatePicker.SelectedDate &&
                                                               x.FechaIngreso < HastaDatePicker.SelectedDate &&
                                                               x.Precio == Utilidades.ToFloat(CriterioTextbox.Text));
                            }
                            else
                            {
                                listado = ProductosBLL.GetList(x => x.Precio == Utilidades.ToFloat(CriterioTextbox.Text));
                            }
                            break;
                        }
                    case 4:
                        {
                            if (DesdeDatePicker.SelectedDate != null)
                            {
                                listado = ProductosBLL.GetList(x => x.FechaIngreso.Date >= DesdeDatePicker.SelectedDate &&
                                                               x.FechaIngreso < HastaDatePicker.SelectedDate &&
                                                               x.Cantidad == Utilidades.Toint(CriterioTextbox.Text));
                            }
                            else
                            {
                                listado = ProductosBLL.GetList(x => x.Cantidad == Utilidades.Toint(CriterioTextbox.Text));
                            }
                            break;
                        }

                }
            }
            else
            {
                if(DesdeDatePicker.SelectedDate != null)
                {
                    listado = ProductosBLL.GetList(x => x.FechaIngreso >= DesdeDatePicker.SelectedDate);
                }

                if(HastaDatePicker.SelectedDate != null)
                {
                    listado = ProductosBLL.GetList(x => x.FechaIngreso <= HastaDatePicker.SelectedDate);
                }

                if(DesdeDatePicker.SelectedDate == null && HastaDatePicker.SelectedDate == null)
                {
                    listado = ProductosBLL.GetList(x => true);
                }
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

            var conteo = listado.Count;
            ConteoTextbox.Text = conteo.ToString();
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            if(DatosDataGrid.SelectedItem != null)
            {
                ClaseCompartida.productoBuscado = (Productos)DatosDataGrid.SelectedItem;
                Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto","Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }   
            
        }
    }
}
