using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTest.Models
{
    public class MainWeatherData
    {
        public int IdWeather { get; set; }
        public float Temp { get; set; }
        public float Pressure { get; set; }
        public float Humidity { get; set; }
        public float TempMin { get; set; }
        public float TempMax { get; set; }
    }
}
