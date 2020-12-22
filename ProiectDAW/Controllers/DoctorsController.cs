using ProiectDAW.Data;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    public class DoctorsController : Controller
    {
        
        private CliniqueContext context = new CliniqueContext();

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Doctors/index
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["doctors"] = context.Doctors.ToList();
            return View();
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Doctors/create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // POST: /Doctors/create
        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                context.Doctors.Add(doctor);

                context.SaveChanges();

                return RedirectToAction("Index", "Doctors");
            }

            return View(doctor);
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /Doctors/update/{id}
        [HttpGet]
        public ActionResult Update(int id)
        {
            var doctor = context.Doctors.Find(id);

            if (doctor == null)
            {
                return HttpNotFound();
            }

            return View(doctor);
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // POST: /Doctors/update
        [HttpPost]
        public ActionResult Update(Doctor doctor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldDoct = context.Doctors.Find(doctor.Id);

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

                    return RedirectToAction("Index", "Doctors");
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
        // GET: /Doctors/delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var doctor = context.Doctors.Find(id);

            if (doctor == null)
            {
                return HttpNotFound();
            }

            context.Doctors.Remove(doctor);

            context.SaveChanges();

            return RedirectToAction("Index", "Doctors");
        }

        // poate fi accesat doar de catre Admin
        [Authorize(Roles = "Admin")]
        // GET: /doctors/details/{id}
        [HttpGet]
        public ActionResult Details(int id)
        {
            var doctor = context.Doctors.Find(id);

            if (doctor == null)
            {
                return HttpNotFound();
            }

            return View(doctor);
        }

        public ActionResult List()
        {
            ViewData["doctors"] = context.Doctors.ToList();
            return View();
        }


    }
}
