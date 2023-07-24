using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using VistasBiblioteca.Models;
using Newtonsoft.Json;
using System.Windows.Input;
using System.Text;
using System;
using Newtonsoft.Json.Serialization;

namespace VistasBiblioteca
{
    public class MenuLibrosViewModel : INotifyPropertyChanged
    {

        private string newModelName;
        public string NewModelName
        {
            get { return newModelName; }
            set
            {
                newModelName = value;
                OnPropertyChanged("NewModelName");
            }
        }

        private ObservableCollection<Libro> models;
        public ObservableCollection<Libro> Models
        {
            get { return models; }
            set
            {
                models = value;
                OnPropertyChanged("Models");
            }
        }

        public ICommand AddLibroCommand { get; set; }


        public MainWindowViewModel()
        {
            LoadModels();
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
            var model = new Model { Name = NewModelName };
            var jsonString = JsonConvert.SerializeObject(model,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await client.PostAsync("https://localhost:7053/add-libro", content);
            NewModelName = string.Empty;
            LoadModels();
        }

        private bool CanAddLibro()
        {
            return !string.IsNullOrWhiteSpace(NewModelName);
        }

        private async void LoadModels()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7053/api/Libros");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                Models = JsonConvert.DeserializeObject<ObservableCollection<Libro>>(jsonString);
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
