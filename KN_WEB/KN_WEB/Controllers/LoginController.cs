using KN_WEB.Entities;
using KN_WEB.Models;
using KN_WEB.Uitls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{

    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RecuperarContraseña()
        {
            return View();
        }

        /// <summary>
        /// Maneja la peticion de cambio de contrasenna enviada al correo electronico
        /// </summary>
        /// <param name="token"></param>
        /// <param name="correo"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ActivarCambioContrasenna(string token, string correo)
        {
            try
            {
                HttpContext.Session["emailPassword"] = correo;
                HttpContext.Session["token"] = token;
                return RedirectToAction("CambiarContrasenna", "Login");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "La pagina no se ha podido cargar correctamente";
                return RedirectToAction("CambiarContrasenna", "Login");
            }
        }

        /// <summary>
        /// Metodo que devuelve la vista para hacer la modificación de la contraseña
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CambiarContrasenna() 
        {
            var model = new UsuarioEnt { Correo = HttpContext.Session["emailPassword"].ToString() };
            return View(model);
        }

        /// <summary>
        /// Metodo que permite realizar el cambio de contraseña conectandose al API
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ChangePassword(UsuarioEnt request) {
            try
            {
                UsuarioModel iniciar = new UsuarioModel();
                var response = await iniciar.CambiarContrasennaAsync(request, HttpContext.Session["token"].ToString());
                if (response)
                {
                    TempData["SuccessMesagge"] = "La contraseña ha sido modificada éxitosamente";
                    HttpContext.Session["emailPassword"] = null;
                    HttpContext.Session["token"] = null;
                    return View("Index");
                }
                else {
                    TempData["ErrorMesagge"] = "No se ha logrado modificar la contraseña";
                    return View("CambiarContrasenna");
                }
            }
            catch (Exception)
            {
                TempData["ErrorMesagge"] = "Ha ocurrido un error al intentar cambiar la contraseña";
                return View("CambiarContrasenna");
            }
        }

        /// <summary>
        /// Realiza la conexión con el API para validar que las credenciales sean las correctas.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SingIn(UsuarioEnt request)
        {
            try
            {
                UsuarioModel iniciar = new UsuarioModel();
                var response = iniciar.IniciarSesion(request);
                if (response != null)
                {
                    HttpContext.Session["userInfo"] = JsonConvert.SerializeObject(response);
                    HttpContext.Session["userName"] = response.Nombre;
                    return RedirectToAction("Index", "Home");
                }
                TempData["ErrorMesagge"] = "El correo o la contraseña son incorrectas, favor validar nuevamente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["ErrorMesagge"] = "Ha ocurrido un error al generar el nuevo usuario";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Cierra la sesión del usuario, limpia la cache del sistema y devuelve al login de la aplicación.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LogOut()
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");

            }
        }

        /// <summary>
        /// Metodo que solicita correo para restablecer la contrasena
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ForgotPassword(UsuarioEnt userModel) {

            try
            {
                //Obtiene el cuerpo del correo almacenado en el archivo config.json
                var path = Server.MapPath("~/config.json");
                StreamReader r = new StreamReader(path);
                string jsonString = r.ReadToEnd();
                var json = (JObject)JsonConvert.DeserializeObject(jsonString);
                string bodyEmail = json["email"].Value<string>();

                var token = await Authenticate();
                token = token.Replace(@"""", "");
                bodyEmail = bodyEmail.Replace("[URL_LINK]", "https://localhost:44354/Login/ActivarCambioContrasenna?token="+token+"&correo="+userModel.Correo);

                InterfaceEmail.SendEmail(new CorreoService { Asunto = "Recuperacion de contraseña", Destinatario = userModel.Correo, Cuerpo = bodyEmail });
                TempData["SuccessMesagge"] = "Se ha enviado un correo a " + userModel.Correo + " con los pasos para restablecer la contrasena";
                return View("Index");
            }
            catch (Exception)
            {
                TempData["ErrorMesagge"] = "Ha ocurrido un error al intentar generar la acción";
                return View("RecuperarContraseña");
            }
        }

        /// <summary>
        /// Metodo que permite registrar nuevos usuarios
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SingOn(UsuarioEnt request)
        {
            try
            {
                UsuarioModel iniciar = new UsuarioModel();
                var response = iniciar.RegistrarUsuario(request);
                if (response)
                {
                    TempData["SuccessMesagge"] = "El usuario con el correo "+request.Correo + " ha sido creado exitosamente.";
                    return RedirectToAction("Index");
                }
                TempData["ErrMessage"] = "No se pudo generar el nuevo usuario";
                return RedirectToAction("Registro");
            }
            catch (Exception)
            {
                TempData["ErrMessage"] = "Ha ocurrido un error al generar el nuevo usuario";
                return RedirectToAction("Registro");
            }
        }

        /// <summary>
        /// Obtiene el JWT para la conexión con el API expuesto, cambiar el nombre correcto que tenga la key en el web config.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        private async Task<string> Authenticate()
        {
            HttpClient client = new HttpClient();
            var json = new StringContent(JsonConvert.SerializeObject(new KeyRequest { Key = ConfigurationManager.AppSettings["JWT_SECRET_KEY"] }), Encoding.UTF8, "application/json");
            //Se debe de cambiar la ruta por la que va a contener el API que vamos a implementar.
            var response = await client.PostAsync(ConfigurationManager.AppSettings.Get("baseTicketsEndpoint") + "api/authenticate", json);
            var data = await response.Content.ReadAsStreamAsync();

            StreamReader sr = new StreamReader(data);
            var result = sr.ReadToEnd();

            return result;

        }
    }
}