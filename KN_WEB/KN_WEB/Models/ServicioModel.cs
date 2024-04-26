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
    public class ServicioModel
    {

        public List<ServicioEnt> ObtenerListado()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "servicio/getList"; ;
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<ServicioEnt>>().Result;
                }
                return null;
            }
        }

        public ServicioEnt ObtenerServicio(int id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "servicio/getService?id=" + id;
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(url);

                var response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadFromJsonAsync<ServicioEnt>().Result;
                }
                return null;
            }
        }

        public bool AgregarServicio(ServicioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "servicio/insertService";
                JsonContent body = JsonContent.Create(entidad);
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<bool>().Result;
                }
                return false;
            }
        }

        public bool ModificarServicio(ServicioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "servicio/updateService";
                JsonContent body = JsonContent.Create(entidad);
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Put;
                request.RequestUri = new Uri(url);
                request.Content = body;

                var response = client.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadFromJsonAsync<bool>().Result;
                }
                return false;
            }
        }

    }
}