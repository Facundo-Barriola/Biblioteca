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
using VistasBiblioteca.ViewModels;

namespace VistasBiblioteca.Views
{
    /// <summary>
    /// Lógica de interacción para AgregarLibroForm.xaml
    /// </summary>
    public partial class AgregarLibroForm : Window
    {
        private MenuLibrosViewModel viewModel;

        public AgregarLibroForm(MenuLibrosViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.DataContext = viewModel;
        }
    }
}
