using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using WebPOinS.Shared;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Configuration;

namespace WebPOinS.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
                
        [HttpPost]
        public ActionResult Index(EmailFormModel obj)
        {

            try
            {

                //creating the object of MailMessage
                MailMessage mailMessage = new MailMessage();

                mailMessage.To.Add("softwaresales@newstead.com.sg");
                mailMessage.From = new MailAddress("softwaresales@newstead.com.sg");
                mailMessage.Subject = obj.FromName + "_" + obj.FromSubject;
                mailMessage.Body = "<p>Email: " + obj.FromEmail + "</p><p>" + obj.FromMessage+"</p>";
                mailMessage.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.office365.com";
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("softwaresales@newstead.com.sg", "P@ssw0rd");                
                smtp.Port = 587;
                smtp.Send(mailMessage);

            }

            catch 
            {
                
                //ViewBag.errorMessage = ex.Message;
                //ViewBag.Status = ViewBag.errorMessage;
            }
            return PartialView("_Sdsuccess");
        }
        
    }
}