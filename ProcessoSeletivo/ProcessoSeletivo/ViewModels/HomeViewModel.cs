using ProcessoSeletivo.Business;
using ProcessoSeletivo.Models;
using ProcessoSeletivoTest.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProcessoSeletivo.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            ForecastList.Clear();
            GetWeather();
            base.OnNavigatedTo(parameters);
        }
        public ObservableCollection<WeatherData> ForecastList { get; set; } = new ObservableCollection<WeatherData>();
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Home";
            _navigationService = navigationService;
            BtnClickCommand = new Command(() => {
                _navigationService.NavigateAsync("FavoriteView", null);
            });
        }
        public ICommand BtnClickCommand { get; private set; }
        private async void GetWeather()
        {
            var weatherData = await DependencyService.Get<IWeatherDataBusiness>().Get();

            if(weatherData.Count==0)
                await Application.Current.MainPage.DisplayAlert("Alerta", "Nenhum item salvo nos favoritos.", "OK");

            foreach (var item in weatherData)
            {
                ForecastList.Add(item);
            }
        }
    }
}
