using KN_WEB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using System.Configuration;

namespace KN_WEB.Models
{
    public class InventarioModel
    {

        public List<InventarioEnt> ObtenerListado()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() +"inventario/getList"; ;
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<InventarioEnt>>().Result;
                }
                return null;
            }
        }

        public InventarioEnt ObtenerInventario(int id) {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "inventario/getInventary?id=" + id;
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(url);

                var response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadFromJsonAsync<InventarioEnt>().Result;
                }
                return null;
            }
        }

        public bool AgregarInventario(InventarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "inventario/insertInventory";
                JsonContent body = JsonContent.Create(entidad);
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<bool>().Result;
                }
                return false;
            }
        }

        public bool ModificarInventario(InventarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "inventario/updateInventory";
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