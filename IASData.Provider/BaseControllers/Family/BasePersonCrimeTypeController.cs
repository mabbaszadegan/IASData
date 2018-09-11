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
    public class BasePersonCrimeTypeController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonCrimeType
        public ActionResult Index(int id)
        {
            List<DAL.PersonCrimeType> personCrimeTypes = db.PersonCrimeTypeRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.CrimeTypes = db.CrimeTypeRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personCrimeTypes);
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
            List<DAL.PersonCrimeType> personCrimeTypes = db.PersonCrimeTypeRepository.Get(q => q.PersonId == personId && q.CrimeTypeId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personCrimeTypes);
        }

        [HttpPost]
        public ActionResult CreatePersonCrimeType(DAL.PersonCrimeType personCrimeType)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personCrimeType.InsertTime = DateTime.Now;
            personCrimeType.InsertUserId = userInfo.UserId;
            db.PersonCrimeTypeRepository.Insert(personCrimeType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personCrimeType);
            var output = "personId=" + personCrimeType.PersonCrimeTypeId;
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
            return RedirectToAction("Index", new { id = personCrimeType.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonCrimeType(DAL.PersonCrimeType model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonCrimeType personCrimeType = db.PersonCrimeTypeRepository.GetById(model.PersonCrimeTypeId);

            //personCrimeType.AbuserName = model.AbuserName;
            personCrimeType.PersonCrimeTypeDesc = model.PersonCrimeTypeDesc;
            //personCrimeType.RelationTypeId = model.RelationTypeId;
            personCrimeType.UpdateTime = DateTime.Now;
            personCrimeType.UpdateUserId = userInfo.UserId;
            db.PersonCrimeTypeRepository.Update(personCrimeType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonCrimeTypeId;
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
        public ActionResult RemovePersonCrimeType(int id)
        {
            var personCrimeType = db.PersonCrimeTypeRepository.GetById(id);
            db.PersonCrimeTypeRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personCrimeType);
            var output = "personId=" + personCrimeType.PersonId;
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


            return RedirectToAction("Index", new { id = personCrimeType.PersonId });
        }
    }
}