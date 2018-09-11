using DAL;
using IASData.Enumerable;
using IASData.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IASData.Provider.BaseControllers.Family
{
    public class BasePersonWorkshopController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonWorkshop
        public ActionResult Index(int id)
        {
            List<DAL.PersonWorkshop> personWorkshops = db.PersonWorkshopRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.Workshops = db.WorkshopRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personWorkshops);
        }

        public ActionResult Create(int abuseTypeId, int personId)
        {
            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");
            ViewBag.AbuseTypeId = abuseTypeId;
            ViewBag.PersonId = personId;

            return PartialView();
        }
        public ActionResult Edit(int abuseTypeId, int personId)
        {
            List<DAL.PersonWorkshop> personWorkshops = db.PersonWorkshopRepository.Get(q => q.PersonId == personId && q.WorkshopId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personWorkshops);
        }

        [HttpPost]
        public ActionResult CreatePersonWorkshop(DAL.PersonWorkshop personWorkshop)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personWorkshop.InsertTime = DateTime.Now;
            personWorkshop.InsertUserId = userInfo.UserId;
            db.PersonWorkshopRepository.Insert(personWorkshop);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personWorkshop);
            var output = "personId=" + personWorkshop.PersonWorkshopId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "ManagePerson",
                Action = "PersonIndex",
                Type = EventLogType.Insert,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);
            return RedirectToAction("Index", new { id = personWorkshop.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonWorkshop(DAL.PersonWorkshop model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonWorkshop personWorkshop = db.PersonWorkshopRepository.GetById(model.PersonWorkshopId);

            //personWorkshop.AbuserName = model.AbuserName;
            personWorkshop.PersonWorkshopDesc = model.PersonWorkshopDesc;
            //personWorkshop.RelationTypeId = model.RelationTypeId;
            personWorkshop.UpdateTime = DateTime.Now;
            personWorkshop.UpdateUserId = userInfo.UserId;
            db.PersonWorkshopRepository.Update(personWorkshop);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonWorkshopId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "ManagePerson",
                Action = "PersonIndex",
                Type = EventLogType.Update,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return RedirectToAction("Index", new { id = model.PersonId });
        }
        public ActionResult RemovePersonWorkshop(int id)
        {
            var personWorkshop = db.PersonWorkshopRepository.GetById(id);
            db.PersonWorkshopRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personWorkshop);
            var output = "personId=" + personWorkshop.PersonId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "ManagePerson",
                Action = "PersonIndex",
                Type = EventLogType.Delete,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);


            return RedirectToAction("Index", new { id = personWorkshop.PersonId });
        }
    }
}