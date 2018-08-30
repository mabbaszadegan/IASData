using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sosapoverty.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        UnitOfWork db = new UnitOfWork();
        // GET: Authentication

        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginViewModel login,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                string hashPassword = login.Password.EncryptTextAES("p8bq1368mz");// FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");
                var user = db.UserInfoRepository.Get(u => u.UserName == login.Username && u.UserPassword == hashPassword).SingleOrDefault();
                if (user != null)
                {
                    if (user.UserIsActive)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, login.RememberMe);
                        
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("Username", "حساب کاربری شما فعال نشده است");
                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "کاربری با اطلاعات وارد شده یافت نشد");
                }
            }

            return View(login);
        }
        public ActionResult ActiveUser(string id)
        {
            //var user = db.Users.SingleOrDefault(u => u.ActiveCode == id);
            //if (user == null)
            //{
            //    return HttpNotFound();
            //}

            //user.IsActive = true;
            //user.ActiveCode = Guid.NewGuid().ToString();
            //db.SaveChanges();
            //ViewBag.UserName = user.UserName;
            return View();
        }

        [Route("LogOff")]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}