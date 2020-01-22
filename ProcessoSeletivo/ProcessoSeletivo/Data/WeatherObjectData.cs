using Newtonsoft.Json;
using ProcessoSeletivo.Models;
using ProcessoSeletivo.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ProcessoSeletivo.Data
{
    public class WeatherObjectData : IWeatherObjectData
    {
        public WeatherObject GetCitiesJson()
        {
            var assembly = typeof(HomeView).GetTypeInfo().Assembly;
            WeatherObject listItens = new WeatherObject();

            foreach (var res in assembly.GetManifestResourceNames())
            {
                if (res.Contains("city.list.json"))
                {
                    Stream stream = assembly.GetManifestResourceStream(res);

                    using (var reader = new StreamReader(stream))
                    {
                        string json = "";
                        json = reader.ReadToEnd();

                        listItens = JsonConvert.DeserializeObject<WeatherObject>(json);
                        return listItens;
                    }
                }
            }
            return listItens;
        }
    }
}
