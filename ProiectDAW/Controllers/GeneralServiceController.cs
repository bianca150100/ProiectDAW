using Microsoft.AspNet.Identity;
using ProiectDAW.Data;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    public class GeneralServiceController : Controller
    {
        private ClinicaContext context = new ClinicaContext();

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Services/index
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["generalServices"] = context.GeneralService.ToList();
            return View();
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /GeneralService/create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // POST: /GeneralService/create
        [HttpPost]
        public ActionResult Create(GeneralService ser)
        {
            if (ModelState.IsValid)
            {
                context.GeneralService.Add(ser);

                context.SaveChanges();

                return RedirectToAction("Index", "GeneralService");
            }

            return View(ser);
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /GeneralService/update/{id}
        [HttpGet]
        public ActionResult Update(int id)
        {
            var serv = context.Services.Find(id);

            if (serv == null)
            {
                return HttpNotFound();
            }

            return View(serv);
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // POST: /GeneralService/update
        [HttpPost]
        public ActionResult Update(GeneralService serv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldServ = context.GeneralService.Find(serv.GeneralServiceId);

                    if (oldServ == null)
                    {
                        return HttpNotFound();
                    }

                    oldServ.Name = serv.Name;
                    oldServ.Description = serv.Description;
                    oldServ.RecoveryPeriod = serv.RecoveryPeriod;

                    TryUpdateModel(oldServ);

                    context.SaveChanges();

                    return RedirectToAction("Index", "GeneralService");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(serv);
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Services/delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var serv = context.GeneralService.Find(id);

            if (serv == null)
            {
                return HttpNotFound();
            }

            context.GeneralService.Remove(serv);

            context.SaveChanges();

            return RedirectToAction("Index", "GeneralService");
        }

        public ActionResult List()
        {
            ViewData["generalServices"] = context.GeneralService.ToList();
            return View();
        }

        public ActionResult ListCateg()
        {
            var serv = context.Services.Where( x => x.GeneralServiceId == 2).ToList();
            ViewData["generalServices2"] = serv;
            ViewData["allGeneralServ"] = context.GeneralService.ToList();
            ViewData["allServ"] = context.Services.ToList();
            var user = User.Identity.GetUserName();
            if (user.Equals("admin@admin.com"))
            {
                ViewData["adminLogin"] = "admin";
            }
            else
            {
                ViewData["adminLogin"] = "nu";
            }
            return View();
        }
    }
}