using KN_WEB.Entities;
using KN_WEB.Models;
using KN_WEB.Uitls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    public class UsuariosController : Controller
    {
        public ActionResult Index() {
            var roles = new RolesModel();
            ViewBag.Roles = roles.ObtenerListado();
            return View();
        }

        /// <summary>
        /// Obtiene el listado completo de los equipos que se encuentran en inventario
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            try
            {
                UsuarioModel model = new UsuarioModel();
                var list = model.ObtenerListado();
                var response = new DataTableResponseModel<UsuarioEnt>
                {
                    data = list.ToList(),
                    RecordsFiltered = list.Count(),
                    RecordsTotal = list.Count()
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new List<UsuarioEnt>());
            }
        }

        /// <summary>
        /// Almacena un nuevo equipo en la tabla de inventarios
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult InsertUser(UsuarioEnt request)
        {
            try
            {
                UsuarioModel model = new UsuarioModel();
                if (request.IdUsuario != 0)
                {
                    var response = model.ModificarUsuario(request);
                    if (response)
                    {
                        TempData["SuccessMesagge"] = "Se ha modificado el registro con éxito";
                        return RedirectToAction("Index", "Usuarios");
                    }
                }
                else
                {
                    TempData["ErrorMesagge"] = "No se ha logrado realizar al accion en el sistema";
                    return RedirectToAction("Index", "Usuarios");
                }
                TempData["ErrorMesagge"] = "No se ha logrado realizar al accion en el sistema";
                return RedirectToAction("Index", "Usuarios");

            }
            catch (Exception)
            {
                TempData["ErrorMesagge"] = "Ha ocurrido un error al intentar modificar el usuario en el sistema";
                return RedirectToAction("Index", "Usuarios");
            }
        }

        /// <summary>
        /// Obtiene el equipo solicitado por medio del id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetUserById(int id)
        {
            try
            {
                UsuarioModel model = new UsuarioModel();
                var response = model.ObtenerUsuario(id);
                if (response != null)
                {
                    return Json(response);
                }

                TempData["ErrorMesagge"] = "No se ha logrado obtener el equipo solicitado";
                return RedirectToAction("Index", "Usuarios");
            }
            catch (Exception)
            {

                TempData["ErrorMesagge"] = "Ha ocurrido un error al intentar obtener el equipo solicitado";
                return RedirectToAction("Index", "Usuarios");
            }
        }
    }
}