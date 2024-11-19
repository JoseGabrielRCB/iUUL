using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoApi.Entidades
{
    internal class Conversion
    {
        
        public string time_last_update_unix {  get; set; }  
        public string time_last_update_utc { get; set; }    

        public string time_next_update_unix { get; set; }

        public string  time_next_update_utc { get; set; }   

        public string base_code { get; set; }   

        public string target_code { get; set; }

        public double conversion_rate { get; set; } 

        public string TermsOfUse { get; set; }

        public bool Verifica = false;
    }
}
