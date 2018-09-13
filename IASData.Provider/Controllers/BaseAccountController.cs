using DAL;
using IASData.Enumerable;
using IASData.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace IASData.Provider.Controllers
{
    public class BaseAccountController : Controller
    {
        UnitOfWork db = new UnitOfWork();
        // GET: Authentication

        //[Route("Login")]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        //[Route("Login")]
        public ActionResult Login(LoginViewModel login, string ReturnUrl)
        {
            EventLogViewModel eventLogView = new EventLogViewModel();
            string input = "";
            string output = "";

            input = new JavaScriptSerializer().Serialize(login);
            if (ModelState.IsValid)
            {
                string hashPassword = login.Password.Trim().EncryptTextAES("p8bq1368mz");// FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");
                var user = db.UserInfoRepository.Get(u => u.UserName == login.Username && u.UserPassword == hashPassword).SingleOrDefault();
                output = "";//new JavaScriptSerializer().Serialize(user);
                if (user != null)
                {
                    if (user.UserIsActive)
                    {
                        eventLogView = new EventLogViewModel
                        {
                            Area = null,
                            Controller = "Login",
                            Action = "Account",
                            Type = EventLogType.Login,
                            Input = input + "#" + ReturnUrl,
                            Output = output,
                            Description = "لاگین با موفقیت انجام شد",
                            //UserId=User.Identity.
                        };
                        Common.HttpLogInsert(eventLogView);

                        FormsAuthentication.SetAuthCookie(user.UserName, login.RememberMe);
                        if (!string.IsNullOrEmpty(ReturnUrl))
                            return Redirect(ReturnUrl);
                        else
                            return Redirect("/");
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
            output = new JavaScriptSerializer().Serialize(ModelState["Username"].Errors);

            eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "Login",
                Action = "Account",
                Type = EventLogType.Error,
                Input = input + "#" + ReturnUrl,
                Output = output,
                Description = "خطا در لاگین",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

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

        //[Route("LogOff")]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "LogOff",
                Action = "Account",
                Type = EventLogType.Logout,
                Input = null,
                Output = null,
                Description = "خروج از سیستم",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return RedirectToAction("Login");
        }

    }
}