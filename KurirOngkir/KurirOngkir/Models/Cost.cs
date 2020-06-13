﻿using System;
using System.Collections.Generic;

namespace KurirOngkir.Models
{
    public class Cost
    {
        public RajaOngkir rajaongkir { get; set; }

        public class RajaOngkir
        {
            public Query query { get; set; }
            public Status status { get; set; }
            public OriginDetails origin_details { get; set; }
            public DestinationDetails destination_details { get; set; }
            public List<Results> results { get; set; }
        }

        public class Query
        {
            public string key { get; set; }
            public string origin { get; set; }
            public string destination { get; set; }
            public double weight { get; set; }
            public string courier { get; set; }
        }

        public class Status
        {
            public int code { get; set; }
            public string description { get; set; }
        }

        public class OriginDetails
        {
            public string city_id { get; set; }
            public string province_id { get; set; }
            public string province { get; set; }
            public string type { get; set; }
            public string city_name { get; set; }
            public string postal_code { get; set; }   
        }

        public class DestinationDetails
        {
            public string city_id { get; set; }
            public string province_id { get; set; }
            public string province { get; set; }
            public string type { get; set; }
            public string city_name { get; set; }
            public string postal_code { get; set; }
        }

        public class Results
        {
            public string code { get; set; }
            public string name { get; set; }
            public List<Costs> costs { get; set; }

            public class Costs
            {
                public string service { get; set; }
                public string description { get; set; }
                public List<CostVal> cost { get; set; }

                public class CostVal
                {
                    public string value { get; set; }
                    public string etd { get; set; }
                    public string note { get; set; }
                }
            }

        }
    }
}