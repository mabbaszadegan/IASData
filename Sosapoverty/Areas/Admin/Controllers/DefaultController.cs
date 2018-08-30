using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sosapoverty.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Admin/Default
        public ActionResult Index()
        {
            //Session["UserId"] = id;

            return View();
        }

        public ActionResult _Home()
        {
            return PartialView();
        }
        public ActionResult _Login()
        {
            return PartialView();
        }

        public ActionResult _Menubar()
        {
            return PartialView();
        }
    }
}