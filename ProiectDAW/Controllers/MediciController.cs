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
    public class MediciController : Controller
    {
        
        private ClinicaContext context = new ClinicaContext();

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Medici/index
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["Medici"] = context.Medici.ToList();
            return View();
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Medici/create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // POST: /Medici/create
        [HttpPost]
        public ActionResult Create(Medic doctor)
        {
            if (ModelState.IsValid)
            {
                context.Medici.Add(doctor);

                context.SaveChanges();

                return RedirectToAction("Index", "Medici");
            }

            return View(doctor);
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Medici/update/{id}
        [HttpGet]
        public ActionResult Update(int id)
        {
            var doctor = context.Medici.Find(id);

            if (doctor == null)
            {
                return HttpNotFound();
            }

            return View(doctor);
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // POST: /Medici/update
        [HttpPost]
        public ActionResult Update(Medic doctor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldDoct = context.Medici.Find(doctor.MedicId);

                    if (oldDoct == null)
                    {
                        return HttpNotFound();
                    }

                    oldDoct.FirstName = doctor.FirstName;
                    oldDoct.LastName = doctor.LastName;
                    oldDoct.Email = doctor.Email;
                    oldDoct.PhoneNumber = doctor.PhoneNumber;
                    oldDoct.Experience = doctor.Experience;
                    oldDoct.Description = doctor.Description;
                    oldDoct.Function = doctor.Function;

                    TryUpdateModel(oldDoct);

                    context.SaveChanges();

                    return RedirectToAction("Index", "Medici");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(doctor);
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Medici/delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var doctor = context.Medici.Find(id);

            if (doctor == null)
            {
                return HttpNotFound();
            }

            context.Medici.Remove(doctor);

            context.SaveChanges();

            return RedirectToAction("Index", "Medici");
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Medici/details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var doctor = context.Medici.Find(id);

            if (doctor == null)
            {
                return HttpNotFound();
            }

            return View(doctor);
        }

        public ActionResult List()
        {
            ViewData["Medici"] = context.Medici.ToList();
            return View();
        }

        public JsonResult Lista()
        {
            var user = User.Identity.GetUserName();
            var app = context.Appointments.Where(x => x.Email == user).ToList();
            var app2 = context.Medici.ToList();
            return Json(app, JsonRequestBehavior.AllowGet);
        }

    }
}
