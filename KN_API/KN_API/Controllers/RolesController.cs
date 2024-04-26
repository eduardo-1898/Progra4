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
    public class RolesController : ApiController
    {
        [HttpGet]
        [Route("roles/getList")]
        public List<RolesEnt> getList()
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.Rols.Select(roles => new RolesEnt
                    {
                        IdRol = roles.IdRol,
                        NombreRol = roles.NombreRol
                    }).ToList();

                    return datos;
                }
            }
            catch (Exception)
            {
                return new List<RolesEnt>();
            }
        }
    }
}