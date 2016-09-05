using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Innova.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Modulo1()
        {
            ViewBag.Message = "Se ha seleccionado el modulo 1";
            return View();
        }

        public ActionResult Opcion1Modulo1()
        {
            ViewBag.Message = "Se ha seleccionado la opcion 1 del modulo Gestión Pedagógica";
            return View();
        }

        public ActionResult Opcion2Modulo1()
        {
            ViewBag.Message = "Se ha seleccionado la opcion 2 del modulo Gestión Pedagógica";
            return View();
        }

        public ActionResult Opcion3Modulo1()
        {
            ViewBag.Message = "Se ha seleccionado la opcion 3 del modulo Gestión Pedagógica";
            return View();
        }


        public ActionResult Modulo2()
        {
            ViewBag.Message = "Your modulo2 page.";
            return View();
        }

        public ActionResult Modulo3()
        {
            ViewBag.Message = "Your modulo2 page.";
            return View();
        }
        public ActionResult Modulo4()
        {
            ViewBag.Message = "Your modulo3 page.";
            return View();
        }
        public ActionResult Modulo5()
        {
            ViewBag.Message = "Your modulo4 page.";
            return View();
        }
        public ActionResult Modulo6()
        {
            ViewBag.Message = "Your modulo5 page.";
            return View();
        }
    }
}
