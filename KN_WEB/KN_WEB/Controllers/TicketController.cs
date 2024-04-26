using KN_WEB.Entities;
using KN_WEB.Models;
using KN_WEB.Uitls;
using KN_WEB.ViewClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace KN_WEB.Controllers
{
    [FilterConfig]
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear() {

            var service = new ServicioModel();
            var faq = new FaqqModel();
            ViewBag.servicios = service.ObtenerListado();
            ViewBag.faq = faq.ObtenerFaqq();

            return View();
        }

        public ActionResult Edit(long id)
        {
            var usuario = new UsuarioModel();
            var estado = new EstadoModel();
            var Ticket = new TiqueteModel();
            var model = Ticket.ObtenerTicketById(id);
            ViewBag.estado = estado.ObtenerEstados();
            ViewBag.tecnico = usuario.ObtenerListado().Where(x=>x.IdRol == 3).ToList();
            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        /// <summary>
        /// Permite agregar un nuevo tiquiete generado por el usuario.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult AddTicket(TiqueteEnt request) {
            try
            {
                var Ticket = new TiqueteModel();
                var userInfo = JsonConvert.DeserializeObject<UsuarioEnt>(HttpContext.Session["userInfo"].ToString());
                request.IdUsuario = userInfo.IdUsuario;
                var response = Ticket.AgregarTiquete(request);
                CorreoService correo = new CorreoNewTicket(userInfo.Correo);

                if (response) {
                    InterfaceEmail.SendEmail(correo);
                    TempData["SuccessMesagge"] = "Se ha creado el registro con éxito";
                    return RedirectToAction("Crear");
                }

                TempData["ErrorMesagge"] = "No se ha logrado realizar al accion en el sistema";
                return RedirectToAction("Crear");
            }
            catch (Exception ex)
            {
                TempData["ErrorMesagge"] = "No se ha logrado realizar al accion en el sistema";
                return RedirectToAction("Crear");
            }
        }

        public ActionResult ModificarTicket(TiqueteEditView request) {
            try
            {
                TiqueteModel model = new TiqueteModel();
                var ent = new TiqueteEnt();
                ent.IdTiquete = request.IdTiquete;
                ent.IdEstado = request.IdEstado;
                ent.IdTecnico = request.IdTecnico;
                var response = model.ModificarTiquete(ent);
                if (response) {
                    TempData["SuccessMesagge"] = "Se ha modificado el registro con éxito";
                    var userInfo = JsonConvert.DeserializeObject<UsuarioEnt>(HttpContext.Session["userInfo"].ToString());
                    var correo = new CorreoUpdateMessage(DestinatarioCorreo((int)request.IdUsuario), (int)ent.IdTiquete);
                    InterfaceEmail.SendEmail(correo);
                    return RedirectToAction("Edit", "Ticket", new { id = request.IdTiquete });
                }
                else {
                    TempData["ErrorMesagge"] = "No se ha logrado realizar al accion en el sistema";
                    return RedirectToAction("Edit", "Ticket", new { id = request.IdTiquete });
                }
            }
            catch (Exception)
            {
                TempData["ErrorMesagge"] = "No se ha logrado realizar al accion en el sistema";
                return RedirectToAction("Edit", "Ticket", new { id = request.IdTiquete });
            }
        }
        
        public ActionResult ListOpen() {
            try
            {
                TiqueteModel model = new TiqueteModel();
                var list = listDataFilter(model.ObtenerListado()).Where(x=>x.IdEstado != 3).ToList();
                var response = new DataTableResponseModel<TiqueteEnt>
                {
                    data = list.ToList(),
                    RecordsFiltered = list.Count(),
                    RecordsTotal = list.Count()
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new List<TiqueteEnt>());
            }
        }

        public ActionResult ListClosed()
        {
            try
            {
                TiqueteModel model = new TiqueteModel();
                var list = listDataFilter(model.ObtenerListado()).Where(x => x.IdEstado == 3).ToList();
                var response = new DataTableResponseModel<TiqueteEnt>
                {
                    data = list.ToList(),
                    RecordsFiltered = list.Count(),
                    RecordsTotal = list.Count()
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new List<TiqueteEnt>());
            }
        }

        /// <summary>
        /// Me permite filtar la informacion que se le mostrara al usuario en base a su perfil de usuario
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private List<TiqueteEnt> listDataFilter(List<TiqueteEnt> data) {
            var userInfo = JsonConvert.DeserializeObject<UsuarioEnt>(HttpContext.Session["userInfo"].ToString());
            if (userInfo.IdRol == 2) {
                return data.Where(x => x.IdUsuario == userInfo.IdUsuario).ToList();
            }
            if (userInfo.IdRol == 3) {
                return data.Where(x => x.IdTecnico == userInfo.IdUsuario).ToList();
            }
            return data;
        }

        private string DestinatarioCorreo(int idUsuario) {
            try
            {
                var usuario = new UsuarioModel();
                return usuario.ObtenerListado().Where(x => x.IdUsuario == idUsuario).FirstOrDefault().Correo;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}