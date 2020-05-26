using HousesForRent.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace HousesForRent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = (string)TempData["EmailSent"];
            return View();
        }

        public ActionResult SendNotificationEmail(string email, string messageBody)
        {
            //if (!string.IsNullOrEmpty(email) && new EmailAddressAttribute().IsValid(email))
            //{
            //    return;
            //}
            var fromAddress = new MailAddress("frumrental@gmail.com", "Frum rental");
            var toAddress = new MailAddress("frumrental@gmail.com");
            
            string fromPassword = "";
            string subject = "Message from frumrental";
            string body = messageBody + " " + email;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

            TempData["EmailSent"] = "Email has been sent successfully.";
            return RedirectToAction("Index");
        }

        public ActionResult GetLocations()
        {
            var repo = new LeaserRepository();
            return Json(repo.GetAllLocations(), JsonRequestBehavior.AllowGet);
        }
    }
}