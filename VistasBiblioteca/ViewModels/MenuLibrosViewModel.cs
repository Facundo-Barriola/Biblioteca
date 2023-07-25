using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using VistasBiblioteca.Models;
using Newtonsoft.Json;
using System.Windows.Input;
using System.Text;
using System;
using System.Threading.Tasks;
using System.Windows.Markup;
using Newtonsoft.Json.Serialization;

namespace VistasBiblioteca.ViewLibros
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

        public ICommand AddLibroCommand { get; set; }


        public MenuLibrosViewModel()
        {
            LoadLibros();
            AddLibroCommand = new RelayCommand(AddLibro, CanAddLibro);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void AddLibro()
        {
            HttpClient client = new HttpClient();
            var libro = new Libro
            {
                Titulo = LibroModel,
                IdLibro = idLibro,
                Sinopsis = sinopsis,
                PuntajeCritica = puntajeCritica,
                Estado = estado,
                Disponibilidad = disponibilidad,
                IdSeccion = idSeccion
            };
            var jsonString = JsonConvert.SerializeObject(libro,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:7053/add-libro", content);
            LibroModel = string.Empty;
            LoadLibros();
        }

        private bool CanAddLibro()
        {
            return !string.IsNullOrWhiteSpace(LibroModel);
        }

        private async void LoadLibros()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7053/api/Libros");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                Libros = JsonConvert.DeserializeObject<ObservableCollection<Libro>>(jsonString);
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