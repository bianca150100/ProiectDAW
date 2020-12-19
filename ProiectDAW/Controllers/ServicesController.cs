using ProiectDAW.Data;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    // poate fi accesat doar de catre Admin
    [Authorize(Roles = "Admin")]
    public class ServicesController : Controller
    {
        private CliniqueContext context = new CliniqueContext();

        // GET: /Services/index
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["services"] = context.Services.ToList();
            return View();
        }

        // GET: /Services/create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Services/create
        [HttpPost]
        public ActionResult Create(Service ser)
        {
            if (ModelState.IsValid)
            {
                context.Services.Add(ser);

                context.SaveChanges();

                return RedirectToAction("Index", "Services");
            }

            return View(ser);
        }

        // GET: /Services/update/{id}
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

        // POST: /Services/update
        [HttpPost]
        public ActionResult Update(Service serv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldServ = context.Services.Find(serv.Id);

                    if (oldServ == null)
                    {
                        return HttpNotFound();
                    }

                    oldServ.Name = serv.Name;
                    oldServ.Pret = serv.Pret;

                    TryUpdateModel(oldServ);

                    context.SaveChanges();

                    return RedirectToAction("Index", "Services");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(serv);
        }

        // GET: /Services/delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var serv = context.Services.Find(id);

            if (serv == null)
            {
                return HttpNotFound();
            }

            context.Services.Remove(serv);

            context.SaveChanges();

            return RedirectToAction("Index", "Services");
        }

    }
}