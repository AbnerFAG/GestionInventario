using CapaEntidad;
using CapaNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GestionInventario
{
    public partial class MainWindow : Window
    {
        private readonly NProduct nProduct = new NProduct();
        private List<Product> productos = new List<Product>();

        public MainWindow()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            productos = nProduct.ObtenerProductosActivos();
            dgProductos.ItemsSource = productos;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombreProducto.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                CargarProductos();
                return;
            }

            List<Product> resultado = nProduct.BuscarProductosPorNombre(nombre);
            if (resultado.Count == 0)
            {
                MessageBox.Show("No se encontraron productos con ese nombre.", "Resultado", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            dgProductos.ItemsSource = resultado;
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            var form = new ProductoForm(new Product{});
            if (form.ShowDialog() == true)
            {
                if (nProduct.InsertarProducto(form.Producto))
                {
                    MessageBox.Show("Producto agregado exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarProductos();
                }
                else
                {
                    MessageBox.Show("Error al agregar el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            var producto = productos.FirstOrDefault(p => p.ProductId == id);
            if (producto == null) return;

            var form = new ProductoForm(new Product
            {
                ProductId = producto.ProductId,
                Name = producto.Name,
                Price = producto.Price,
                Stock = producto.Stock
            });

            if (form.ShowDialog() == true)
            {
                if (nProduct.ActualizarProducto(form.Producto))
                {
                    MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarProductos();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            var producto = productos.FirstOrDefault(p => p.ProductId == id);
            if (producto == null) return;

            var confirm = new EliminarConfirmacion(producto.Name);
            if (confirm.ShowDialog() == true)
            {
                if (nProduct.EliminarProducto(producto.ProductId))
                {
                    MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarProductos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
