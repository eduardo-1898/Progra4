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
    [FilterConfig]
    public class ServiciosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Obtiene el listado completo de los equipos que se encuentran en servicios
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            try
            {
                ServicioModel model = new ServicioModel();
                var list = model.ObtenerListado();
                var response = new DataTableResponseModel<ServicioEnt>
                {
                    data = list.ToList(),
                    RecordsFiltered = list.Count(),
                    RecordsTotal = list.Count()
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new List<ServicioEnt>());
            }
        }

        /// <summary>
        /// Almacena un nuevo equipo en la tabla de servicios
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult InsertServicio(ServicioEnt request)
        {
            try
            {
                ServicioModel model = new ServicioModel();
                if (request.idServicio != 0)
                {
                    var response = model.ModificarServicio(request);
                    if (response)
                    {
                        TempData["SuccessMesagge"] = "Se ha modificado el registro con éxito";
                        return RedirectToAction("Index", "Servicios");
                    }
                }
                else
                {
                    var response = model.AgregarServicio(request);
                    if (response)
                    {
                        TempData["SuccessMesagge"] = "Se ha creado el registro con éxito";
                        return RedirectToAction("Index", "Servicios");
                    }
                }
                TempData["ErrorMesagge"] = "No se ha logrado realizar al accion en el sistema";
                return RedirectToAction("Index", "Servicios");

            }
            catch (Exception)
            {
                TempData["ErrorMesagge"] = "Ha ocurrido un error al intentar ingresar el inventario al sistema";
                return RedirectToAction("Index", "Servicios");
            }
        }

        /// <summary>
        /// Obtiene el servicios solicitado por medio del id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetServicioById(int id)
        {
            try
            {
                ServicioModel model = new ServicioModel();
                var response = model.ObtenerServicio(id);
                if (response != null)
                {
                    return Json(response);
                }

                TempData["ErrorMesagge"] = "No se ha logrado obtener el equipo solicitado";
                return RedirectToAction("Index", "Inventario");
            }
            catch (Exception)
            {

                TempData["ErrorMesagge"] = "Ha ocurrido un error al intentar obtener el equipo solicitado";
                return RedirectToAction("Index", "Inventario");
            }
        }
    }
}