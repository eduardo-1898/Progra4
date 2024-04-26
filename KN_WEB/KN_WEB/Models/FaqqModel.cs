using KN_WEB.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;

namespace KN_WEB.Models
{
    public class FaqqModel
    {
        public bool AgregarFaqq(FaqEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44330/api/insertarFaq";
                JsonContent body = JsonContent.Create(entidad);
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return true; // Devuelve true si la operación fue exitosa.
                }
                return false; // Devuelve false si la operación falló.
            }
        }

        public List<FaqEnt> ObtenerFaqq()
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:44330/api/obtenerFaq";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    var json = resp.Content.ReadAsStringAsync().Result;
                    var faqList = JsonConvert.DeserializeObject<List<FaqEnt>>(json);
                    return faqList;
                }
                return new List<FaqEnt>(); // Retornar una lista vacía en caso de error
            }
        }
    }
}