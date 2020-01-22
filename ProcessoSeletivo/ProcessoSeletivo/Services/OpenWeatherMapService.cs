using Newtonsoft.Json;
using ProcessoSeletivo.Models;
using ProcessoSeletivoTest.Models;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Services
{
    public class ProcessoSeletivoService
    {
      

        /// <summary>
        /// Setting the server uri, apikey for the service.
        /// </summary>
 
        public void SetCredentials()
        {
            SettingsService.Uri = "http://api.ProcessoSeletivo.org/data/2.5/";
            SettingsService.ApiKey = "2bac87e0cb16557bff7d4ebcbaa89d2f";
            SettingsService.Units = "metric";
        }

        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                // Ignoring null values and missing members from response
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                // Getting the response
                var response = await client.GetAsync(uri);

                // Reading response as string
                var json = await response.Content.ReadAsStringAsync();

                // Deserializing to the appropriate object
                T result = JsonConvert.DeserializeObject<T>(json, settings);
                return result;
            }
        }

        /// <summary>
        /// Getting the current weather
        /// </summary>
        /// <param name="query">Name of the city</param>
        /// <returns></returns>
        public async Task<WeatherData> GetWeatherForCityAsync(string query)
        {
            return await GetAsync<WeatherData>(new Uri(SettingsService.Uri + $"weather?q={query}&units={SettingsService.Units}&APPID={SettingsService.ApiKey}"));
        }
    }
}
