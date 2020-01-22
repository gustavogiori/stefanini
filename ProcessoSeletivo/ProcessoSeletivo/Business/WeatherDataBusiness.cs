using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProcessoSeletivo.Data;
using ProcessoSeletivoTest.Models;
using Xamarin.Forms;

namespace ProcessoSeletivo.Business
{
    public class WeatherDataBusiness : IWeatherDataBusiness
    {
        public Task Insert(WeatherData entity)
        {
            if (entity.Clouds != null)
                entity.Clouds.IdWeather = entity.Id;
            DependencyService.Get<ICloudsDataBase>().Insert(entity.Clouds);
            if (entity.Main != null)
                entity.Main.IdWeather = entity.Id;
            DependencyService.Get<IMainWeatherDataBase>().Insert(entity.Main);

            if (entity.Rain != null)
                entity.Rain.IdWeather = entity.Id;
            DependencyService.Get<IRainDataBase>().Insert(entity.Rain);

            if (entity.Sys != null)
                entity.Sys.IdWeather = entity.Id;
            DependencyService.Get<ISysDataBase>().Insert(entity.Sys);

            if (entity.Weather[0] != null)
                entity.Weather[0].IdWeather = entity.Id;
            DependencyService.Get<IWeatherModelDataBase>().Insert(entity.Weather[0]);

            if (entity.Wind != null)
                entity.Wind.IdWeather = entity.Id;
            DependencyService.Get<IWindDataBase>().Insert(entity.Wind);

            return DependencyService.Get<IWeatherDataBase>().Insert(entity);
        }

        public async Task<WeatherData> Find(Expression<Func<WeatherData, bool>> predicate)
        {
            var data = await DependencyService.Get<IWeatherDataBase>().Find(predicate);
            data = await SetEntity(data);
            return data;
        }

        private async Task<WeatherData> SetEntity(WeatherData data)
        {
            data.Clouds = await DependencyService.Get<ICloudsDataBase>().Find(x => x.IdWeather == data.Id);
            data.Main = await DependencyService.Get<IMainWeatherDataBase>().Find(x => x.IdWeather == data.Id);
            data.Rain = await DependencyService.Get<IRainDataBase>().Find(x => x.IdWeather == data.Id);
            data.Sys = await DependencyService.Get<ISysDataBase>().Find(x => x.IdWeather == data.Id);
            var weather = await DependencyService.Get<IWeatherModelDataBase>().Find(x => x.IdWeather == data.Id);
            data.Weather = new List<Weather>() { weather };
            data.Wind = await DependencyService.Get<IWindDataBase>().Find(x => x.IdWeather == data.Id);
            return data;
        }

        public async Task<List<WeatherData>> Get()
        {
            List<WeatherData> list = new List<WeatherData>();
            var data = await DependencyService.Get<IWeatherDataBase>().Get();
            foreach (var item in data)
            {
                var entity = await SetEntity(item);
                list.Add(entity);
            }
            return list;
        }
    }
}
