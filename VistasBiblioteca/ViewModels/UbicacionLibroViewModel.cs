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
using System.Windows.Markup;
using VistasBiblioteca.Models;

namespace VistasBiblioteca.ViewModels
{
    public class UbicacionLibroViewModel : INotifyPropertyChanged
    {
        private string _ubicacionLibroModel;

        public string ubicacionLibroModel 
        {
            get { return _ubicacionLibroModel; }
            set 
            {
                _ubicacionLibroModel = value;
                OnPropertyChanged("ubicacionLibroModel");
            }
        }

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
            LoadModels();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private async void LoadModels() 
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7053/api/Libros/ubicacion");
            if (response.IsSuccessStatusCode) 
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                UbicacionLibros = JsonConvert.DeserializeObject<ObservableCollection<UbicacionLibro>>(jsonString); 
            }
        }
    }
}
