using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using ProiectDAW.Data;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.Controllers
{
    public class AppointmentsController : Controller
    {
        private ClinicaContext context = new ClinicaContext();
        private ApplicationDbContext ctx = new ApplicationDbContext();

        [Authorize(Roles = "Admin")]
        // GET: /Appointment/index
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["appointments"] = context.Appointments.ToList();
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public ActionResult Create()
        {
            var serv = context.Medici.Select(x => new
            {
                MedicId = x.MedicId,
                MedicName = x.FirstName
            }).ToList();

            ViewBag.Medici = new SelectList(serv, "MedicId", "MedicName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Appointment ser)
        {
            if (ModelState.IsValid)
            {
                context.Appointments.Add(ser);

                context.SaveChanges();

                return RedirectToAction("Index", "Appointments");
            }
            var serv = context.Medici.Select(x => new
            {
                MedicId = x.MedicId,
                MedicName = x.FirstName

            }).ToList();

            ViewBag.Medici = new SelectList(serv, "MedicId", "MedicName", ser.MedicId);

            return View(ser);
        }

        // GET: /Appointments/update/{id}
        [HttpGet]
        public ActionResult Update(int id)
        {
            var serv = context.Appointments.Find(id);

            if (serv == null)
            {
                return HttpNotFound();
            }

            return View(serv);
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var serv = context.Appointments.Find(id);

            if (serv == null)
            {
                return HttpNotFound();
            }

            context.Appointments.Remove(serv);

            context.SaveChanges();

            return RedirectToAction("Index", "Appointments");
        }

        public ActionResult List()
        {
            ViewData["appointments"] = context.Appointments.ToList();
            return View();
        }

        [Authorize(Roles = "User")]
        public ActionResult Myappointments()
        {
            ViewData["myappointments"] = context.Appointments.ToList();
            ViewData["medici"] = context.Medici.ToList();
            return View();
        }

        public JsonResult Appoint()
        {
            var user = User.Identity.GetUserName();
            var app = context.Appointments.Where(x => x.Email == user).ToList();
            var app2 = context.Appointments.ToList();
            var userList = User.Identity.GetUserName();
            foreach (var prog in app)
            {
                if (userList.Equals(prog.Email))
                {
                    app2.Append(prog);
                }
            }
            return Json(app, JsonRequestBehavior.AllowGet);
        }

        public JsonResult All()
        {

            var app = context.Appointments.ToList();
            var medici = context.Medici.ToList();
            //trebuie sa am : data, ora de start, medic numele, prenume
            var listaEsential = new List<Esential>();
            foreach (var prog in app)
                foreach (var medic in medici)
                {
                    if (prog.MedicId == medic.MedicId)
                    {
                        var nume = medic.FirstName + " " + medic.LastName;
                        var es = new Esential(nume, prog.Data, prog.Ora);
                        listaEsential.Add(es);
                    }
                }
            //var list = JsonConvert.SerializeObject(app, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore});
            return Json(listaEsential, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "User")]
        public ActionResult Calendar()
        {

            return View();
        }
    }
}