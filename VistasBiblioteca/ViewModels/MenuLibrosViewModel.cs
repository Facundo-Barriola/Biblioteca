using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Input;
using System.Text;
using System;
using System.Threading.Tasks;
using System.Windows.Markup;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using VistasBiblioteca.Models;
using VistasBiblioteca.Views;

namespace VistasBiblioteca.ViewModels
{
    public class MenuLibrosViewModel : INotifyPropertyChanged
    {
        public ICommand DeleteLibroCommand { get; set; }
        public ICommand OpenEditFormCommand { get; set; }
        public MenuLibrosViewModel()
        {
            LoadLibros();
            DeleteLibroCommand = new RelayCommand(DeleteLibro, CanDeleteLibro);
            OpenEditFormCommand = new RelayCommand(OpenEditForm, CanOpenEditForm);
        }

        private ObservableCollection<Libro> libros;
        public ObservableCollection<Libro> Libros
        {
            get { return libros; }
            set
            {
                libros = value;
                OnPropertyChanged("Libros");
            }
        }

        private Libro _selectedLibro;
        public Libro SelectedLibro
        {
            get { return _selectedLibro; }
            set
            {
                _selectedLibro = value;
                OnPropertyChanged("SelectedLibro");
            }
        }
        // Propiedad privada para evitar la llamada recursiva
        private ObservableCollection<Libro> _loadedLibros;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public async void LoadLibros()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7053/api/Libros");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                _loadedLibros = JsonConvert.DeserializeObject<ObservableCollection<Libro>>(jsonString);
                Libros = JsonConvert.DeserializeObject<ObservableCollection<Libro>>(jsonString);
            }
        }
        private async void DeleteLibro()
        {
            try
            {
                HttpClient client = new HttpClient();
                await client.DeleteAsync($"https://localhost:7053/api/Libros/{SelectedLibro.IdLibro}");
                LoadLibros();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el libro: {ex.Message}");
            }
        }
        private bool CanDeleteLibro()
        {
            return SelectedLibro != null;
        }
        private void OpenEditForm() 
        {
            if (SelectedLibro != null) 
            {
                var form = new LibroForm(SelectedLibro);
                form.Closed += (s, eventArgs) =>
                {
                    LoadLibros();
                };
                form.ShowDialog();
            }
        }
        private bool CanOpenEditForm() 
        {
            return SelectedLibro != null;
        }
        public class RelayCommand : ICommand
        {
            private Action _execute;
            private Func<bool> _canExecute;

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public RelayCommand(Action execute, Func<bool> canExecute)
            {
                _execute = execute;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute();
            }

            public void Execute(object parameter)
            {
                _execute();
            }
        }
    }
}