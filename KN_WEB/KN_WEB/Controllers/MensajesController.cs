using KN_WEB.Entities;
using KN_WEB.Models;
using KN_WEB.Uitls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    [FilterConfig]
    public class MensajesController : Controller
    {
        public ActionResult AddMensajeTiquete(string msj, int? idTiquete)
        {
            try
            {
                var request = new MensajeEnt();
                request.Mensaje = msj.ToString();
                request.IdTiquete = (int)idTiquete;

                var mensaje = new MensajeModel();
                var userInfo = JsonConvert.DeserializeObject<UsuarioEnt>(HttpContext.Session["userInfo"].ToString());
                request.IdUsuario = userInfo.IdUsuario;
                var response = mensaje.AgregarMensaje(request);
                CorreoService correo = new CorreoNewMessage(userInfo.Correo, request.IdTiquete);

                if (response)
                {
                    InterfaceEmail.SendEmail(correo);
                    return Json("OK");
                }
                return Json("BAD");

            }
            catch (Exception ex)
            {
                return Json("ERROR");

            }
        }
    }
}