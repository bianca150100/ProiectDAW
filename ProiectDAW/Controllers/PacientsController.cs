using ProiectDAW.Data;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    public class PacientsController : Controller
    {
        private ClinicaContext context = new ClinicaContext();

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Pacients/index
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["Pacients"] = context.Pacients.ToList();
            return View();
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Pacients/create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // POST: /Pacients/create
        [HttpPost]
        public ActionResult Create(Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                context.Pacients.Add(pacient);

                context.SaveChanges();

                return RedirectToAction("Index", "Pacients");
            }

            return View(pacient);
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Pacients/update/{id}
        [HttpGet]
        public ActionResult Update(int id)
        {
            var pacient = context.Pacients.Find(id);

            if (pacient == null)
            {
                return HttpNotFound();
            }

            return View(pacient);
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // POST: /Pacients/update
        [HttpPost]
        public ActionResult Update(Pacient pacient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldPac = context.Pacients.Find(pacient.PacientId);

                    if (oldPac == null)
                    {
                        return HttpNotFound();
                    }

                    oldPac.FirstName = pacient.FirstName;
                    oldPac.LastName = pacient.LastName;
                    oldPac.Email = pacient.Email;


                    TryUpdateModel(oldPac);

                    context.SaveChanges();

                    return RedirectToAction("Index", "Pacients");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(pacient);
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Pacients/delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var pacient = context.Pacients.Find(id);

            if (pacient == null)
            {
                return HttpNotFound();
            }

            context.Pacients.Remove(pacient);

            context.SaveChanges();

            return RedirectToAction("Index", "Pacients");
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Pacients/details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var pacient = context.Pacients.Find(id);

            if (pacient == null)
            {
                return HttpNotFound();
            }

            return View(pacient);
        }

        public ActionResult List()
        {
            ViewData["Pacients"] = context.Pacients.ToList();
            return View();
        }


    }
}
