using IDGS904ASP.Models;
using IDGS904ASP.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDGS904ASP.Controllers
{
    public class ArchivosController : Controller
    {
        // GET: Archivos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registra()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registra(Alumno alum)
        {
            var op1 = new GuardaService();
            //ViewBag.Res = op1.Calculos(op);
            op1.GuardaArchivo(alum);
            return View();
        }

        public ActionResult LeerDatos()
        {
            var arch = new LeerService();
            ViewBag.tem = arch.LeerArchivo();
            return View();
        }
    }
}
