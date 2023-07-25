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
using Biblioteca.Models;
using Biblioteca.MenuLibrosViewModels;


namespace VistasBiblioteca
{
    public partial class MenuLibros : Page
    {
        public MenuLibros()
        {
            InitializeComponent();
            //los datos se obtienen de MenuLibrosViewModel
            this.DataContext = new MenuLibrosViewModel();
        }

        private void refresh() 
        {
            //List<Biblioteca.Models.Libro> listaLibros = new list<Biblioteca.Models.Libro>
            //using(Biblioteca.Models.WPFCrudEntities db = new )

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
