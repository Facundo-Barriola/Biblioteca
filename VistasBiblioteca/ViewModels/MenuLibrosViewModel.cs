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

namespace VistasBiblioteca.ViewModels
{
    public class MenuLibrosViewModel : INotifyPropertyChanged
    {

        private Libro _libroModel;
        public Libro LibroModel
        {
            get { return _libroModel; }
            set
            {
                _libroModel = value;
                OnPropertyChanged("LibroModel");
            }
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

        public ICommand AddLibroCommand { get; set; }
        public ICommand EditLibroCommand { get; set; }
        public ICommand DeleteLibroCommand { get; set; }


        public MenuLibrosViewModel()
        {
            LoadLibros();
            AddLibroCommand = new RelayCommand(AddLibro, CanAddLibro);
            EditLibroCommand = new RelayCommand(EditLibro, CanEditLibro);
            DeleteLibroCommand = new RelayCommand(DeleteLibro, CanDeleteLibro);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void AddLibro()
        {
            try
            {
                HttpClient client = new HttpClient();
                var libro = new Libro
                {
                    Titulo = LibroModel.Titulo,
                    Sinopsis = LibroModel.Sinopsis,
                    PuntajeCritica = LibroModel.PuntajeCritica,
                    Estado = LibroModel.Estado,
                    Disponibilidad = LibroModel.Disponibilidad,
                    IdSeccion = LibroModel.IdSeccion
                };
                var jsonString = JsonConvert.SerializeObject(libro,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7053/add-libro", content);
                LibroModel.Titulo = string.Empty;
                LibroModel.Sinopsis = string.Empty;
                LibroModel.PuntajeCritica = 0;
                LibroModel.Estado = 0;
                LibroModel.Disponibilidad = false;
                LibroModel.IdSeccion = 0;
                LoadLibros();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el libro: {ex.Message}");
            }
        }

        private bool CanAddLibro()
        {
            return LibroModel != null;
        }

        private async void EditLibro()
        {
            try
            {
                HttpClient client = new HttpClient();
                var libro = new Libro
                {
                    IdLibro = SelectedLibro.IdLibro,
                    Titulo = SelectedLibro.Titulo,
                    Sinopsis = SelectedLibro.Sinopsis,
                    PuntajeCritica = SelectedLibro.PuntajeCritica,
                    Estado = SelectedLibro.Estado,
                    Disponibilidad = SelectedLibro.Disponibilidad,
                    IdSeccion = SelectedLibro.IdSeccion
                };
                var jsonString = JsonConvert.SerializeObject(libro,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                await client.PutAsync($"https://localhost:7053/edit-libro/{SelectedLibro.IdLibro}", content);
                SelectedLibro.Titulo = string.Empty;
                SelectedLibro.Sinopsis = string.Empty;
                SelectedLibro.PuntajeCritica = 0;
                SelectedLibro.Estado = 0;
                SelectedLibro.Disponibilidad = false;
                SelectedLibro.IdSeccion = 0;
                LoadLibros();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el libro: {ex.Message}");
            }
        }

        private bool CanEditLibro()
        {
            return SelectedLibro != null;
        }

        private async void DeleteLibro()
        {
            try
            {
                HttpClient client = new HttpClient();
                await client.DeleteAsync($"https://localhost:7053/delete-libro/{SelectedLibro.IdLibro}");
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

        public async void LoadLibros()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://localhost:7053/api/Libros");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    Libros = JsonConvert.DeserializeObject<ObservableCollection<Libro>>(jsonString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar los libros: {ex.Message}");
            }
        }

        public List<string> Estados { get; } = new List<string> { "Nuevo", "Deteriorado", "Muy deteriorado" };


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