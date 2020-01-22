using Prism;
using Prism.Ioc;
using ProcessoSeletivo.ViewModels;
using ProcessoSeletivo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using ProcessoSeletivo.Business;
using System.IO;
using System;
using ProcessoSeletivo.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProcessoSeletivo
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        public static string PathDataBase;
        protected override async void OnInitialized()
        {
            InitializeComponent();
            PathDataBase = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ProcessoSeletivo.db3");
            DataBaseFactory.CreateDataBase(PathDataBase);
            RegisterDependency();
            await NavigationService.NavigateAsync("NavigationPage/HomeView");
        }
        private void RegisterDependency()
        {
            DependencyService.Register<IWeatherDataBusiness, WeatherDataBusiness>();
            DependencyService.Register<IDataBaseForecast, DataBaseForecast>();
            DependencyService.Register<IMainWeatherDataBase, MainWeatherDataBase>();
            
            DependencyService.Register<ICoordinatesDataBase, CoordinatesDataBase>();
            DependencyService.Register<ICloudsDataBase, CloudsDataBase>();
            DependencyService.Register<IRainDataBase, RainDataBase>();
            DependencyService.Register<ISysDataBase, SysDataBase>();
            DependencyService.Register<IWeatherModelDataBase, WeatherModelDataBase>();
            DependencyService.Register<IWeatherDataBase, WeatherDataBase>();
            DependencyService.Register<IWindDataBase, WindDataBase>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomeView>();
            containerRegistry.RegisterForNavigation<FavoriteView>();
        }
    }
}
