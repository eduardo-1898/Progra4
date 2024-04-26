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
    public class RolesModel
    {
        public List<RolesEnt> ObtenerListado()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "roles/getList"; ;
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<RolesEnt>>().Result;
                }
                return null;
            }
        }
    }
}