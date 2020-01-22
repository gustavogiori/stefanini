using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivo.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Ignore]
        public Coordinates Coord { get; set; }
        public string Country { get; set; }


    }
    public class Coordinates
    {
        [JsonIgnore]
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [JsonIgnore]
        public int IdCity { get; set; }
        public float Lon { get; set; }
        public float Lat { get; set; }
    }
}
