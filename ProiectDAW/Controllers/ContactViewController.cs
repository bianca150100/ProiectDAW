using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Mail;
using ProiectDAW.Models;

namespace ProiectDAW.Controllers
{
    public class ContactViewController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email);//Email which you are getting 
                                                         //from contact us page 
                    msz.To.Add("buzoibianca00@gmail.com");//Where mail will be sent 
                    msz.Subject = vm.Subject;
                    msz.Body = vm.Message;
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.UseDefaultCredentials = true;

                    smtp.Port = 587;

                    //smtp.Credentials = new System.Net.NetworkCredential("buzoibianca00@gmail.com", "Cibernetica123");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us ";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                }
            }

            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
    }
}