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
using VistasBiblioteca.Models;

namespace VistasBiblioteca.ViewModels
{
    public class MenuLibrosViewModel : INotifyPropertyChanged
    {

        private string _libroModel;
        public string LibroModel
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
                    Titulo = Titulo,
                    Sinopsis = Sinopsis,
                    PuntajeCritica = PuntajeCritica,
                    Estado = Estado,
                    Disponibilidad = Disponibilidad,
                    IdSeccion = IdSeccion
                };
                var jsonString = JsonConvert.SerializeObject(libro,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7053/add-libro", content);
                Titulo = string.Empty;
                Sinopsis = string.Empty;
                PuntajeCritica = 0;
                Estado = 0;
                Disponibilidad = false;
                IdSeccion = 0;
                LoadLibros();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el libro: {ex.Message}");
            }
        }

        private bool CanAddLibro()
        {
            return !string.IsNullOrWhiteSpace(LibroModel);
        }

        private async void EditLibro()
        {
            try
            {
                HttpClient client = new HttpClient();
                var libro = new Libro
                {
                    IdLibro = SelectedLibro.IdLibro,
                    Titulo = Titulo,
                    Sinopsis = Sinopsis,
                    PuntajeCritica = PuntajeCritica,
                    Estado = Estado,
                    Disponibilidad = Disponibilidad,
                    IdSeccion = IdSeccion
                };
                var jsonString = JsonConvert.SerializeObject(libro,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                await client.PutAsync($"https://localhost:7053/edit-libro/{SelectedLibro.IdLibro}", content);
                Titulo = string.Empty;
                Sinopsis = string.Empty;
                PuntajeCritica = 0;
                Estado = 0;
                Disponibilidad = false;
                IdSeccion = 0;
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

        private async void LoadLibros()
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