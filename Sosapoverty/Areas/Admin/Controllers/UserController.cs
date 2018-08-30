using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sosapoverty.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/Bank
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Create()
        {
            return PartialView();
        }

        public ActionResult _Edit()
        {
            return PartialView();
        }

        public ActionResult _Delete()
        {
            return PartialView();
        }

        public ActionResult _Detail()
        {
            return PartialView();
        }

        public ActionResult _List()
        {
            return PartialView();
        }

    }
}