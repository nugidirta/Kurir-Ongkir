using System;
using System.Collections.Generic;

namespace KurirOngkir.Models
{
    public class Filter
    {       
        public string kota_asal_id { get; set; }
        public string kota_asal_nama { get; set; }
        public string kota_tujuan_id { get; set; }
        public string kota_tujuan_nama { get; set; }
        public double berat { get; set; }
    }
}