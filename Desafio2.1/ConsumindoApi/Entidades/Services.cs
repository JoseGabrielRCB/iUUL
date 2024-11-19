using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoApi.Entidades
{
    internal class Services
    {
        public async Task<Conversion> Integracao(string Fonte,string destino)
        {

            HttpClient client = new HttpClient();
            string apiKey = "138d3f313c9acb38ff5389e8";
            var response = await client.GetAsync($"https://v6.exchangerate-api.com/v6/{apiKey}/pair/{Fonte}/{destino}");
            var jsonString = await response.Content.ReadAsStringAsync();
            if (jsonString.Contains("\"result\":\"error\""))
            {
                Console.WriteLine(jsonString);  
                return new Conversion { Verifica = true};
            }
            var jsonObject = JsonConvert.DeserializeObject<Conversion>(jsonString);
            if (jsonObject!= null)
            {

                return jsonObject;
            }
            else
            {
                Console.WriteLine(jsonString);
                return new Conversion
                {
                    Verifica = true
                };
            }

        }
    }
}
