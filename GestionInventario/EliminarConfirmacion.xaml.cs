using System.Windows;

namespace GestionInventario
{
    public partial class EliminarConfirmacion : Window
    {
        public EliminarConfirmacion(string nombreProducto)
        {
            InitializeComponent();
            txtMensaje.Text = $"¿Estás seguro de que deseas eliminar \"{nombreProducto}\"?";
        }

        private void BtnSi_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void BtnNo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
