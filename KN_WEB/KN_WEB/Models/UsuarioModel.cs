using KN_WEB.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;

namespace KN_WEB.Models
{
    public class UsuarioModel
    {
        public UsuarioEnt IniciarSesion(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "api/IniciarSesion";
                JsonContent body = JsonContent.Create(entidad);
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
                }
                return null;
            }
        }

        public List<UsuarioEnt> ObtenerListado()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "api/ConsultarUsuarios"; ;
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<UsuarioEnt>>().Result;
                }
                return null;
            }
        }

        public bool RegistrarUsuario(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                entidad.IdRol = 2;
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "api/RegistrarUsuario";
                JsonContent body = JsonContent.Create(entidad);
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<bool>().Result;
                }
                return false;
            }
        }

        public async Task<bool> CambiarContrasennaAsync(UsuarioEnt entidad, string token) {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "api/login/CambiarContrasenna";
                JsonContent body = JsonContent.Create(entidad);
                HttpRequestMessage resp = new HttpRequestMessage();
                resp.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                resp.Method = HttpMethod.Post;
                resp.Content = body;
                resp.RequestUri = new Uri(url);

                var response = await client.SendAsync(resp);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }

        public UsuarioEnt ObtenerUsuario(int id)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "usuario/getUser?id=" + id;
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(url);

                var response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
                }
                return null;
            }
        }

        public bool ModificarUsuario(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["baseTicketsEndpoint"].ToString() + "usuario/updateUser";
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