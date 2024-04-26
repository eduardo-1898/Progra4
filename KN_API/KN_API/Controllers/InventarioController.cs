using KN_API.Entities;
using KN_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KN_API.Controllers
{
    public class InventarioController : ApiController
    {

        [HttpGet]
        [Route("inventario/getList")]
        public List<ConsultarTodoInventario_Result> getList()
        {
            try
            {
                using (var bd = new Services365Entities()) {
                    var datos = bd.ConsultarTodoInventario().ToList();
                    return datos;
                }
            }
            catch (Exception)
            {
                return new List<ConsultarTodoInventario_Result>();
            }
        }

        [HttpGet]
        [Route("inventario/getInventary")]
        public ConsultarInventario_Result getInventaryById(string id)
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.ConsultarInventario(id).First();
                    return datos;
                }
            }
            catch (Exception)
            {
                return new ConsultarInventario_Result();
            }
        }

        [HttpPost]
        [Route("inventario/insertInventory")]
        public bool insertInventory(InventarioEnt model)
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.CrearInventario(model.TipoEquipo, model.Marca, model.Modelo, model.Serie, model.Nombre, model.VersionInv);
                    return (datos>0);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut]
        [Route("inventario/updateInventory")]
        public bool updateInventory(InventarioEnt model)
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.ActualizarInventario(model.IdInventario,model.TipoEquipo, model.Marca, model.Modelo, model.Serie, model.Nombre, model.VersionInv);
                    return (datos > 0);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}