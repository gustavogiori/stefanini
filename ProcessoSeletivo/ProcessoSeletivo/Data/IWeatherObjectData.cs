using ProcessoSeletivo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivo.Data
{
    public interface IWeatherObjectData
    {
        WeatherObject GetCitiesJson();
    }
}
