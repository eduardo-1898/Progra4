using KN_WEB.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using KN_WEB.ViewClass;

namespace KN_WEB.Models
{
    public class TiqueteModel
    {

        public List<TiqueteEnt> ObtenerListado()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "tiquete/getList"; ;
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<TiqueteEnt>>().Result;
                }
                return null;
            }
        }

        public TiqueteEditView ObtenerTicketById(long id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "tiquete/getTicket?id=" + id;
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(url);

                var response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadFromJsonAsync<TiqueteEditView>().Result;
                    MensajeModel msj = new MensajeModel();
                    data.mensajes = msj.ObtenerMensaje(data.IdTiquete);
                    return data;
                }
                return null;
            }
        }


        public bool AgregarTiquete(TiqueteEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "tiquete/insertTiquete";
                JsonContent body = JsonContent.Create(entidad);
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<bool>().Result;
                }
                return false;
            }
        }

        public bool ModificarTiquete(TiqueteEnt entidad) {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "tiquete/updateTiquete";
                JsonContent body = JsonContent.Create(entidad);
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<bool>().Result;
                }
                return false;
            }
        }

    }
}