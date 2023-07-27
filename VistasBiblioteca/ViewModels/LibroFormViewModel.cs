using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VistasBiblioteca.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace VistasBiblioteca.ViewModels
{
    public class LibroFormViewModel : INotifyPropertyChanged
    {
        public ICommand EditLibroCommand { get; set; }
        public ICommand SaveLibroCommand { get; set; }
        public ICommand CancelLibroCommand { get; set; }
        public event EventHandler RequestClose;
        public Action CloseAction { get; set; }
        private void OnRequestClose()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
        public LibroFormViewModel() 
        {
            SaveLibroCommand = new RelayCommand(SaveLibro, CanSaveLibro);
            CancelLibroCommand = new RelayCommand(CancelLibro, () => true);
            RequestClose += (sender, e) => CloseAction?.Invoke();
            LoadSecciones();
        }

        public LibroFormViewModel(Libro libro) 
        {
            SaveLibroCommand = new RelayCommand(SaveLibro, CanSaveLibro);
            CancelLibroCommand = new RelayCommand(CancelLibro, () => true);
            RequestClose += (sender, e) => CloseAction?.Invoke();
            LoadSecciones();
            SelectedLibro = libro; // Correccion a la hora de editar libro
            LibroModelTitulo = libro.Titulo;
            LibroModelSinopsis = libro.Sinopsis;
            LibroModelPuntaje = libro.PuntajeCritica;
            LibroModelEstado = libro.Estado;
            LibroModelDisponibilidad = libro.Disponibilidad;
            LibroModelIdSeccion = libro.IdSeccion;
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

        private ObservableCollection<Seccion> _secciones;
        public ObservableCollection<Seccion> Secciones
        {
            get { return _secciones; }
            set
            {
                _secciones = value;
                OnPropertyChanged("Secciones");
            }
        }


        private string _libroModelTitulo;
        public string LibroModelTitulo
        {
            get { return _libroModelTitulo; }
            set
            {
                _libroModelTitulo = value;
                OnPropertyChanged("LibroModelTitulo");
            }
        }

        private string _libroModelSinopsis;
        public string LibroModelSinopsis
        {
            get { return _libroModelSinopsis; }
            set
            {
                _libroModelSinopsis = value;
                OnPropertyChanged("LibroModelSinopsis");
            }
        }

        private int _libroModelPuntaje;
        public int LibroModelPuntaje
        {
            get { return _libroModelPuntaje; }
            set
            {
                _libroModelPuntaje = value;
                OnPropertyChanged("LibroModelPuntaje");
            }
        }

        private int _libroModelEstado;
        public int LibroModelEstado
        {
            get { return _libroModelEstado; }
            set
            {
                _libroModelEstado = value;
                OnPropertyChanged("LibroModelEstado");
            }
        }

        private bool _libroModelDisponibilidad;
        public bool LibroModelDisponibilidad
        {
            get { return _libroModelDisponibilidad; }
            set
            {
                _libroModelDisponibilidad = value;
                OnPropertyChanged("LibroModelDisponibilidad");
            }
        }

        private int _libroModelIdSeccion;
        public int LibroModelIdSeccion
        {
            get { return _libroModelIdSeccion; }
            set
            {
                _libroModelIdSeccion = value;
                OnPropertyChanged("LibroModelIdSeccion");
            }
        }

        private Libro _selectedLibro;

        public event PropertyChangedEventHandler PropertyChanged;

        public Libro SelectedLibro
        {
            get { return _selectedLibro; }
            set
            {
                _selectedLibro = value;
                OnPropertyChanged("SelectedLibro");
            }
        }
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private async void SaveLibro() 
        {
            try
            {
                HttpClient client = new HttpClient();
                var libro = new Libro
                {
                    IdLibro = SelectedLibro?.IdLibro ?? 0,
                    Titulo = LibroModelTitulo,
                    Sinopsis = LibroModelSinopsis,
                    PuntajeCritica = LibroModelPuntaje,
                    Estado = LibroModelEstado,
                    Disponibilidad = LibroModelDisponibilidad,
                    IdSeccion = LibroModelIdSeccion
                };
                var jsonString = JsonConvert.SerializeObject(libro,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                if (libro.IdLibro > 0)
                {
                    await client.PutAsync($"https://localhost:7053/api/Libros/{SelectedLibro.IdLibro}", content);
                }
                else 
                {
                    await client.PostAsync("https://localhost:7053/api/Libros", content);
                }
                ClearLibroData();
                await LoadLibros();
                OnRequestClose();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error al guardar/editar el libro: {ex.Message}");
            }
        }

        private bool CanSaveLibro() 
        {
            return !string.IsNullOrEmpty(LibroModelTitulo);
        }



        private ObservableCollection<Libro> _loadedLibros;
        private async Task LoadLibros()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7053/api/Libros");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                _loadedLibros = JsonConvert.DeserializeObject<ObservableCollection<Libro>>(jsonString);
                Libros = _loadedLibros; ///CORRECCION
            }
        }

        private void ClearLibroData()
        {
            LibroModelTitulo = string.Empty;
            LibroModelSinopsis = string.Empty;
            LibroModelPuntaje = 0;
            LibroModelEstado = 0;
            LibroModelDisponibilidad = false;
            LibroModelIdSeccion = 0;
        }

        private void CancelLibro()
        {
            ClearLibroData(); // Limpia los datos del formulario
            OnRequestClose(); //Pide cerrar la ventana
        }

        private async Task LoadSecciones()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://localhost:7053/api/Secciones");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var secciones = JsonConvert.DeserializeObject<List<Seccion>>(jsonString);
                    Secciones = new ObservableCollection<Seccion>(secciones);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar las secciones: {ex.Message}");
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
}

