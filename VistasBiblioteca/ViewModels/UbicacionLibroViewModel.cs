using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;
using VistasBiblioteca.Models;

namespace VistasBiblioteca.ViewModels
{
    public class UbicacionLibroViewModel : INotifyPropertyChanged
    {
        public ICommand LoadLibrosCommand { get; }

        private ObservableCollection<UbicacionLibro> ubicacionLibros;
        public ObservableCollection<UbicacionLibro> UbicacionLibros 
        {
            get { return ubicacionLibros; }
            set 
            {
                ubicacionLibros = value;
                OnPropertyChanged("UbicacionLibros");
            }
        }

        public UbicacionLibroViewModel() 
        {
            LoadLibrosCommand = new Command(async () => await LoadLibros());
            LoadUbicaciones();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void LoadUbicaciones() 
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7053/api/Libros/ubicacion");
            if (response.IsSuccessStatusCode) 
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                UbicacionLibros = JsonConvert.DeserializeObject<ObservableCollection<UbicacionLibro>>(jsonString); 
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

        private ObservableCollection<Libro> _loadedLibros;
        private async Task LoadLibros()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7053/api/Libros");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                _loadedLibros = JsonConvert.DeserializeObject<ObservableCollection<Libro>>(jsonString);
                Libros = _loadedLibros;
            }
        }

        public class Command : ICommand
        {
            private Action _action;

            public Command(Action action)
            {
                _action = action;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                _action();
            }
        }
    }
}
