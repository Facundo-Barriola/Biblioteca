﻿using System;
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
using VistasBiblioteca.Models;
using VistasBiblioteca.ViewModels;

namespace VistasBiblioteca.Views
{
    /// <summary>
    /// Lógica de interacción para LibroForm.xaml
    /// </summary>
    public partial class LibroForm : Window
    {
        public LibroForm()
        {
            InitializeComponent();
            var viewModel = new LibroFormViewModel();
            this.DataContext = viewModel;
        }

        public LibroForm(Libro libro) 
        {
            InitializeComponent();
            var viewModel = new LibroFormViewModel(libro);
            this.DataContext = viewModel;
        }
    }
}
