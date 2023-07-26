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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VistasBiblioteca.ViewModels;
using VistasBiblioteca.Views;



namespace VistasBiblioteca
{
    public partial class MenuLibros : Page
    {
        private MenuLibrosViewModel viewModel;
        public MenuLibros()
        {
            InitializeComponent();
            viewModel = new MenuLibrosViewModel();
            //los datos de MenuLibros se obtienen de MenuLibrosViewModel
            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Abre el formulario para agregar un nuevo libro
            AgregarLibroForm agregarLibroForm = new AgregarLibroForm(viewModel);
            agregarLibroForm.ShowDialog();

            // Actualiza la lista de libros después de la creación
            viewModel.LoadLibros();
        }
        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
