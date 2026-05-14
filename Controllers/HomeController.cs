using IDGS904ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDGS904ASP.Controllers
{
    public class HomeController : Controller
    {
        public RedirectToRouteResult Index()
        {
            return RedirectToAction("Index", "Pruebas");
        }

        //public RedirectResult Index()
        //{
        //    return Redirect("https://google.com.mx");
        //}

        //public ActionResult Index()
        //{
        //    var alumno1 = new Persona() { Nombre = "Carlos", Edad = 21, Empleado = true };
        //    var alumno2 = new Persona() { Nombre = "Oscar", Edad = 21, Empleado = false };

        //    //return View();
        //    return Json(new List<Persona>() { alumno1, alumno2 }, JsonRequestBehavior.AllowGet);

        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}