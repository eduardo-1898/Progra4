using KN_WEB.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace KN_WEB.Models
{
    public class MensajeModel
    {

        public List<MensajeEnt> ObtenerMensaje(long id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "mensaje/getMensajes?id=" + id;
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(url);

                var response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadFromJsonAsync<List<MensajeEnt>>().Result;
                }
                return null;
            }
        }

        public bool AgregarMensaje(MensajeEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "mensaje/insertMensaje";
                JsonContent body = JsonContent.Create(entidad);
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<bool>().Result;
                }
                return false;
            }
        }

    }
}