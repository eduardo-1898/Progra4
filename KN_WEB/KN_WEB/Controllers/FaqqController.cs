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
    public class FaqqController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertFaqq(FaqEnt request)
        {
            try
            {
                FaqqModel model = new FaqqModel();
                var response = model.AgregarFaqq(request);

                if (response)
                {
                    TempData["SuccessMesagge"] = "Se ha creado el registro con éxito";
                }
                else
                {
                    TempData["ErrorMesagge"] = "No se ha logrado realizar la acción en el sistema";
                }

                return RedirectToAction("Index", "Faqq");
            }
            catch (Exception)
            {
                TempData["ErrorMesagge"] = "Ha ocurrido un error al intentar ingresar el faq al sistema";
                return RedirectToAction("Index", "Faqq");
            }
        }

        public JsonResult ListFaqq()
        {
            try
            {
                FaqqModel model = new FaqqModel();
                var list = model.ObtenerFaqq();

                // Retornar los datos en formato JSON para DataTables
                return Json(new { data = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                // En caso de error, retornar una lista vacía en formato JSON
                return Json(new { data = new List<FaqEnt>() }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}