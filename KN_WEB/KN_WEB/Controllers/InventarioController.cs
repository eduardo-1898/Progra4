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
    public class InventarioController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Obtiene el listado completo de los equipos que se encuentran en inventario
        /// </summary>
        /// <returns></returns>
        public ActionResult List() {
            try
            {
                InventarioModel model = new InventarioModel();
                var list = model.ObtenerListado();
                var response = new DataTableResponseModel<InventarioEnt>
                {
                    data = list.ToList(),
                    RecordsFiltered = list.Count(),
                    RecordsTotal = list.Count()
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new List<InventarioEnt>());
            }
        }

        /// <summary>
        /// Almacena un nuevo equipo en la tabla de inventarios
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult InsertInventory(InventarioEnt request) {
            try
            {
                InventarioModel model = new InventarioModel();
                if (request.IdInventario != 0)
                {
                    var response = model.ModificarInventario(request);
                    if (response)
                    {
                        TempData["SuccessMesagge"] = "Se ha modificado el registro con éxito";
                        return RedirectToAction("Index", "Inventario");
                    }
                }
                else {
                    var response = model.AgregarInventario(request);
                    if (response)
                    {
                        TempData["SuccessMesagge"] = "Se ha creado el registro con éxito";
                        return RedirectToAction("Index", "Inventario");
                    }
                }
                TempData["ErrorMesagge"] = "No se ha logrado realizar al accion en el sistema";
                return RedirectToAction("Index", "Inventario");

            }
            catch (Exception)
            {
                TempData["ErrorMesagge"] = "Ha ocurrido un error al intentar ingresar el inventario al sistema";
                return RedirectToAction("Index", "Inventario");
            }
        }

        /// <summary>
        /// Obtiene el equipo solicitado por medio del id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetInventaryById(int id) {
            try
            {
                InventarioModel model = new InventarioModel();
                var response = model.ObtenerInventario(id);
                if (response!=null)
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