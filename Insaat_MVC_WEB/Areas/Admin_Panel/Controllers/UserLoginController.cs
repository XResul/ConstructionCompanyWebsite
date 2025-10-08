using Insaat_MVC_WEB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Insaat_MVC_WEB.Areas.Admin_Panel.Controllers
{
    public class UserLoginController : Controller
    {
        EntityModelContext db =new EntityModelContext(); 
        // GET: Admin_Panel/UserLogin
        public ActionResult Login()
        {
            return View(new Users());
        }

        [HttpPost]
        public ActionResult Login(Users u)
        {
            string passwordHash = WebLibrary.CryptoClass.ToSHA1Hash(u.UserPassword);

            var user = db.Users.Where(us => us.Email == u.Email && us.UserPassword == passwordHash).FirstOrDefault();

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                HttpCookie cerez = new HttpCookie("user");
                cerez.Expires = DateTime.Now.AddDays(2);
                cerez.Value = user.UserId.ToString();
                Response.Cookies.Add(cerez);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.hata = "Kullanıcı adı veya şifre hatalı";
            }
            return View(u);
        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


    }
}