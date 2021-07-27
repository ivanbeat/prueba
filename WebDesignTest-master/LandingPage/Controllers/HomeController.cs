using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using LandingPage.Models;

namespace LandingPage.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

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

        [HttpPost]
        [AllowAnonymous]
        public ActionResult GetBoleta(Data DataCliente)
        {
            string cadena = LandingPage.Negocio.BusPostData.ConvertLink(DataCliente);
            //return RedirectToAction("LandingPage", "LandingPage", new { IdUnico = DataCliente.IdUnico, ClaveGrupo = "G3900", Telefono = DataCliente.Telefono });
            return RedirectToAction("LandingPage", "LandingPage", new { q = cadena });
        }
    }
}