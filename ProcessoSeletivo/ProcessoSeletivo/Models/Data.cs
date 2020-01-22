using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivo.Models
{
    public class Data
    {
        public int id { get; set; }
        public Coordinates coord { get; set; }
        public string country { get; set; }
        public string name { get; set; }
        public int zoom { get; set; }
    }
}
