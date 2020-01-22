using ProcessoSeletivo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTest.Models
{
    public class WeatherData
    {
        [Ignore]
        public List<Weather> Weather { get; set; }
        [Ignore]
        public MainWeatherData Main { get; set; }
        [Ignore]
        public Wind Wind { get; set; }
        [Ignore]
        public Clouds Clouds { get; set; }
        [Ignore]
        public Rain Rain { get; set; }
        [Ignore]
        public Sys Sys { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public long Dt { get; set; }
    }
}
