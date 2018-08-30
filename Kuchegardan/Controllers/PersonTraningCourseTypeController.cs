using DAL;
using IASData.Enumerable;
using IASData.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Kuchegardan.Controllers
{
    public class PersonTraningCourseTypeController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonTraningCourseType
        public ActionResult Index(int id)
        {
            List<DAL.PersonTraningCourseType> personTraningCourseTypes = db.PersonTraningCourseTypeRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.TraningCourseTypes = db.TraningCourseTypeRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personTraningCourseTypes);
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
            List<DAL.PersonTraningCourseType> personTraningCourseTypes = db.PersonTraningCourseTypeRepository.Get(q => q.PersonId == personId && q.TraningCourseTypeId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personTraningCourseTypes);
        }

        [HttpPost]
        public ActionResult CreatePersonTraningCourseType(DAL.PersonTraningCourseType personTraningCourseType)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personTraningCourseType.InsertTime = DateTime.Now;
            personTraningCourseType.InsertUserId = userInfo.UserId;
            db.PersonTraningCourseTypeRepository.Insert(personTraningCourseType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personTraningCourseType);
            var output = "personId=" + personTraningCourseType.PersonTraningCourseTypeId;
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
            return RedirectToAction("Index", new { id = personTraningCourseType.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonTraningCourseType(DAL.PersonTraningCourseType model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonTraningCourseType personTraningCourseType = db.PersonTraningCourseTypeRepository.GetById(model.PersonTraningCourseTypeId);

            //personTraningCourseType.AbuserName = model.AbuserName;
            personTraningCourseType.PersonTraningCourseTypeDesc = model.PersonTraningCourseTypeDesc;
            //personTraningCourseType.RelationTypeId = model.RelationTypeId;
            personTraningCourseType.UpdateTime = DateTime.Now;
            personTraningCourseType.UpdateUserId = userInfo.UserId;
            db.PersonTraningCourseTypeRepository.Update(personTraningCourseType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonTraningCourseTypeId;
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
        public ActionResult RemovePersonTraningCourseType(int id)
        {
            var personTraningCourseType = db.PersonTraningCourseTypeRepository.GetById(id);
            db.PersonTraningCourseTypeRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personTraningCourseType);
            var output = "personId=" + personTraningCourseType.PersonId;
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


            return RedirectToAction("Index", new { id = personTraningCourseType.PersonId });
        }
    }
}