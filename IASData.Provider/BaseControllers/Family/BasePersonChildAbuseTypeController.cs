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
    public class BasePersonChildAbuseTypeController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonChildAbuseType
        public ActionResult Index(int id)
        {
            List<DAL.PersonChildAbuseType> personChildAbuseTypes = db.PersonChildAbuseTypeRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.ChildAbuseTypes = db.ChildAbuseTypeRepository.Get().ToList();
            ViewBag.PersonId = id;
            return PartialView(personChildAbuseTypes);
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
            List<DAL.PersonChildAbuseType> personChildAbuseTypes = db.PersonChildAbuseTypeRepository.Get(q => q.PersonId == personId && q.ChildAbuseTypeId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personChildAbuseTypes);
        }

        [HttpPost]
        public ActionResult CreatePersonChildAbuseType(DAL.PersonChildAbuseType personChildAbuseType)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personChildAbuseType.InsertTime = DateTime.Now;
            personChildAbuseType.InsertUserId = userInfo.UserId;
            db.PersonChildAbuseTypeRepository.Insert(personChildAbuseType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personChildAbuseType);
            var output = "personId=" + personChildAbuseType.PersonChildAbuseTypeId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonChildAbuseType",
                Action = "CreatePersonChildAbuseType",
                Type = EventLogType.Insert,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);
            return RedirectToAction("Index", new { id = personChildAbuseType.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonChildAbuseType(DAL.PersonChildAbuseType model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonChildAbuseType personChildAbuseType = db.PersonChildAbuseTypeRepository.GetById(model.PersonChildAbuseTypeId);

            personChildAbuseType.AbuserName = model.AbuserName;
            personChildAbuseType.PersonChildAbuseTypeDesc = model.PersonChildAbuseTypeDesc;
            personChildAbuseType.RelationTypeId = model.RelationTypeId;
            personChildAbuseType.UpdateTime = DateTime.Now;
            personChildAbuseType.UpdateUserId = userInfo.UserId;
            db.PersonChildAbuseTypeRepository.Update(personChildAbuseType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonChildAbuseTypeId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonChildAbuseType",
                Action = "EditPersonChildAbuseType",
                Type = EventLogType.Update,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return RedirectToAction("Index", new { id = model.PersonId });
        }
        public ActionResult RemovePersonChildAbuseType(int id)
        {
            var personChildAbuseType = db.PersonChildAbuseTypeRepository.GetById(id);
            db.PersonChildAbuseTypeRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personChildAbuseType);
            var output = "personId=" + personChildAbuseType.PersonId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonChildAbuseType",
                Action = "RemovePersonChildAbuseType",
                Type = EventLogType.Delete,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);


            return RedirectToAction("Index", new { id = personChildAbuseType.PersonId });
        }
    }
}