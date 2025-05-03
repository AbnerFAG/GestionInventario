using CapaEntidad;
using CapaNegocio;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionInventario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NProduct nProduct = new NProduct();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombreProducto.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, ingrese un nombre para buscar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            List<Product> productos = nProduct.BuscarProductosPorNombre(nombre);

            if (productos.Count == 0)
            {
                MessageBox.Show("No se encontraron productos con ese nombre.", "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            dgProductos.ItemsSource = productos;
        }
    }
}