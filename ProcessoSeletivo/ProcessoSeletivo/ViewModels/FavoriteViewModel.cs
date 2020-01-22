using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProcessoSeletivo.Business;
using ProcessoSeletivo.Models;
using ProcessoSeletivo.Services;
using ProcessoSeletivo.Views;
using ProcessoSeletivoTest.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProcessoSeletivo.ViewModels
{
    public class FavoriteViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public ObservableCollection<Models.Data> Cities { get; set; } = new ObservableCollection<Models.Data>();
        public ICommand BtnClickCommand { get; private set; }

        Models.Data _selectedItem;
        public Models.Data SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                _selectedItem = value;
                RaisePropertyChanged("SelectedItem");

            }
        }
        private WeatherData _weatherData;
        public WeatherData WeatherData
        {
            get
            {
                return _weatherData;
            }
            set
            {
                _weatherData = value;
                if (value != null)
                {
                    AddItemDb(_weatherData);
                }
            }
        }
        private async void GetWeather(ProcessoSeletivoService service, string city) => WeatherData = await service.GetWeatherForCityAsync(city);
        private async Task AddItemDb(WeatherData entity)
        {
            await DependencyService.Get<IWeatherDataBusiness>().Insert(entity);
            await Application.Current.MainPage.DisplayAlert("Sucesso", "Adicionado com sucesso", "OK");
        }
        private void AddFavorite()
        {
            string city = SelectedItem.name;
            var service = new ProcessoSeletivoService();
            service.SetCredentials();
            GetWeather(service, city);
        }
        public FavoriteViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Home";
            _navigationService = navigationService;
            AddItensToJson();
            BtnClickCommand = new Command(() =>
            {
                AddFavorite();
            });
        }

        private void AddItensToJson()
        {
            var assembly = typeof(HomeView).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
            {
                if (res.Contains("city.list.json"))
                {
                    Stream stream = assembly.GetManifestResourceStream(res);

                    using (var reader = new StreamReader(stream))
                    {
                        string json = "";
                        json = reader.ReadToEnd();

                        var listItens = JsonConvert.DeserializeObject<RootObject>(json);

                        foreach (var item in listItens.data)
                        {
                            Cities.Add(item);
                        }
                    }
                }
            }
        }
    }
}
