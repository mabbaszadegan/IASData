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
    public class BasePersonSicknessTypeController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonSicknessType
        public ActionResult Index(int id)
        {
            List<DAL.PersonSicknessType> personSicknessTypes = db.PersonSicknessTypeRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.SicknessTypes = db.SicknessTypeRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personSicknessTypes);
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
            List<DAL.PersonSicknessType> personSicknessTypes = db.PersonSicknessTypeRepository.Get(q => q.PersonId == personId && q.SicknessTypeId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personSicknessTypes);
        }

        [HttpPost]
        public ActionResult CreatePersonSicknessType(DAL.PersonSicknessType personSicknessType)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personSicknessType.InsertTime = DateTime.Now;
            personSicknessType.InsertUserId = userInfo.UserId;
            db.PersonSicknessTypeRepository.Insert(personSicknessType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personSicknessType);
            var output = "personId=" + personSicknessType.PersonSicknessTypeId;
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
            return RedirectToAction("Index", new { id = personSicknessType.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonSicknessType(DAL.PersonSicknessType model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonSicknessType personSicknessType = db.PersonSicknessTypeRepository.GetById(model.PersonSicknessTypeId);

            //personSicknessType.AbuserName = model.AbuserName;
            //personSicknessType.PersonSicknessTypeDesc = model.PersonSicknessTypeDesc;
            //personSicknessType.RelationTypeId = model.RelationTypeId;
            personSicknessType.UpdateTime = DateTime.Now;
            personSicknessType.UpdateUserId = userInfo.UserId;
            db.PersonSicknessTypeRepository.Update(personSicknessType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonSicknessTypeId;
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
        public ActionResult RemovePersonSicknessType(int id)
        {
            var personSicknessType = db.PersonSicknessTypeRepository.GetById(id);
            db.PersonSicknessTypeRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personSicknessType);
            var output = "personId=" + personSicknessType.PersonId;
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


            return RedirectToAction("Index", new { id = personSicknessType.PersonId });
        }
    }
}