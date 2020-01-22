using ProcessoSeletivo.Models;
using ProcessoSeletivoTest.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using static ProcessoSeletivo.Models.City;

namespace ProcessoSeletivo.Data
{
    public static class DataBaseFactory
    {
        private static SQLiteAsyncConnection _database;
        /// <summary>
        /// Cria tabelas na base de dados.
        /// </summary>
        public static void CreateDataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Forecast>().Wait();
            _database.CreateTableAsync<Coordinates>().Wait();
            _database.CreateTableAsync<Weather>().Wait();
            _database.CreateTableAsync<MainWeatherData>().Wait();
            _database.CreateTableAsync<Wind>().Wait();
            _database.CreateTableAsync<Clouds>().Wait();
            _database.CreateTableAsync<Rain>().Wait();
            _database.CreateTableAsync<Sys>().Wait();
            _database.CreateTableAsync<WeatherData>().Wait();

        }
    }
}
