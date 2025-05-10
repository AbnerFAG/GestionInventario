using CapaEntidad;
using System;
using System.Windows;

namespace GestionInventario
{
    public partial class ProductoForm : Window
    {
        public Product Producto { get; private set; }
        private readonly bool esEdicion;

        public ProductoForm(Product producto)
        {
            InitializeComponent();
            esEdicion = producto != null;

            if (esEdicion)
            {
                Title = "Editar Producto";
                txtNombre.Text = producto.Name;
                txtPrecio.Text = producto.Price.ToString("0.00");
                txtStock.Text = producto.Stock.ToString();
                Producto = producto;
            }
            else
            {
                Title = "Nuevo Producto";
                Producto = new Product();
            }
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                !decimal.TryParse(txtPrecio.Text, out decimal precio) ||
                !int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Verifica los campos ingresados.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Producto.Name = txtNombre.Text.Trim();
            Producto.Price = precio;
            Producto.Stock = stock;

            DialogResult = true;
            Close();
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
