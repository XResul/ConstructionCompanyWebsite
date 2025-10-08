using Insaat_MVC_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.Design;
using Insaat_MVC_WEB.Models.Entities;

namespace Insaat_MVC_WEB.Controllers
{
    public class ContactController : BaseController
    {
        EntityModelContext db = new EntityModelContext();
        // GET: Contact
        public ActionResult Index()
        {
            ContactViewModel view = new ContactViewModel();
            view.Contact = db.Contact.Where(c => c.LangId == BaseController.langid).Take(1).ToList().FirstOrDefault();
            if (view.Contact == null)
            {
                view.Contact = db.Contact.Take(1).ToList().FirstOrDefault();

            }
            return View(view);
        }

        public ActionResult iletisimForm(string email, string ad, string mesaj, string konu)
        {
            var mailModel = db.MailSetting.FirstOrDefault();


            string fromAddress = mailModel.SenderEmail;
            string password = mailModel.SenderPassword;

            // Alıcının e-posta adresi
            string toAddress = mailModel.ReceiverMail;

            // E-posta konusu
            string subject = konu;

            // E-posta içeriği
            string body = $"<p>Ad Soyad: {ad}</p><p>Email: <a href='mailto:{email}'>{email}</a></p><p>Konu: {konu}</p><p>Mesaj: {mesaj}</p>";



            // Gmail SMTP sunucusu ve portu
            string smtpServer = mailModel.Smtp;
            int port = mailModel.Port;

            // Gönderen e-posta adresi oluşturma
            MailAddress fromMailAddress = new MailAddress(fromAddress);

            // Alıcı e-posta adresi oluşturma
            MailAddress toMailAddress = new MailAddress(toAddress);

            // SMTP istemcisi oluşturma ve ayarlama
            SmtpClient smtpClient = new SmtpClient(smtpServer, port);
            smtpClient.EnableSsl = mailModel.EnableSsl; // SSL/TLS kullanarak güvenli bağlantı sağlar
                                                        //smtpClient.UseDefaultCredentials = true; // Gmail kimlik bilgileri kullanılacak
            smtpClient.Credentials = new NetworkCredential(fromAddress, password); // Gönderenin kimlik bilgileri


            // E-posta oluşturma ve gönderme
            using (MailMessage mailMessage = new MailMessage(fromMailAddress, toMailAddress))
            {
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                try
                {
                    smtpClient.Send(mailMessage);

                }
                catch (Exception ex)
                {

                }
            }

            //bu işte
            return RedirectToAction("index");

        }

    }
}