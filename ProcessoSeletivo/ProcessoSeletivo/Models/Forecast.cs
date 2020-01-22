using ProcessoSeletivo.Models;
using ProcessoSeletivoTest.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivo.Models
{
    public class Forecast
    {
        [Ignore]
        public City City { get; set; }
        public int Cnt { get; set; }

        [Ignore]
        public List<WeatherData> List { get; set; }
    }
}
