using ProiectDAW.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    public class HomeController : Controller
    {
        private ClinicaContext context = new ClinicaContext();
        public ActionResult Index()
        {
            ViewData["generalServices"] = context.GeneralService.ToList();
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


    }
}