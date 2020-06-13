using System;
using System.Collections.Generic;

namespace KurirOngkir.Models
{
    public class Kota
    {
        public RajaOngkir rajaongkir { get; set; }

        public class RajaOngkir
        {
            public Query query { get; set; }
            public Status status { get; set; }
            public List<Results> results { get; set; }
        }

        public class Query
        {
            public string key { get; set; }
        }

        public class Status
        {
            public int code { get; set; }
            public string description { get; set; }
        }

        public class Results
        {
            public string city_id { get; set; }
            public string province_id { get; set; }
            public string province { get; set; }
            public string type { get; set; }
            public string city_name { get; set; }
            public string postal_code { get; set; }
        }
    }
}