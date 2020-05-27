using HousesForRent.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
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
            
            string fromPassword = ConfigurationManager.AppSettings["Password"].ToString();
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

        public void EmailRecipient()
        {
            var email = User.Identity.Name;

            //if (!string.IsNullOrEmpty(email) && new EmailAddressAttribute().IsValid(email))
            //{
            //    return;
            //}
            var fromAddress = new MailAddress("frumrental@gmail.com", "Frum rental");
            var toAddress = new MailAddress(email);

            string fromPassword = ConfigurationManager.AppSettings["Password"].ToString();
            var r = (string)TempData["Recipient"];
            string subject = "";
            string body = "";
            if (r == "renew")
            {
                subject = "Message from frumrental: Renewed";
                body = "You have successfully renewed your listing. If you have any question please reply to this email";
            }
            if (r == "add")
            {
                subject = "Message from frumrental: Added";
                body = "You have successfully Added your listing. If you have any question please reply to this email";
            }

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        public ActionResult GetLocations()
        {
            var repo = new LeaserRepository();
            return Json(repo.GetAllLocations(), JsonRequestBehavior.AllowGet);
        }
    }
}