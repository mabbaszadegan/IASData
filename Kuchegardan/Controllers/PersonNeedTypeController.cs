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
    public class PersonNeedTypeController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonNeedType
        public ActionResult Index(int id)
        {
            List<DAL.PersonNeedType> personNeedTypes = db.PersonNeedTypeRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.NeedTypes = db.NeedTypeRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personNeedTypes);
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
            List<DAL.PersonNeedType> personNeedTypes = db.PersonNeedTypeRepository.Get(q => q.PersonId == personId && q.NeedTypeId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personNeedTypes);
        }

        [HttpPost]
        public ActionResult CreatePersonNeedType(DAL.PersonNeedType personNeedType)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personNeedType.InsertTime = DateTime.Now;
            personNeedType.InsertUserId = userInfo.UserId;
            db.PersonNeedTypeRepository.Insert(personNeedType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personNeedType);
            var output = "personId=" + personNeedType.PersonNeedTypeId;
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
            return RedirectToAction("Index", new { id = personNeedType.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonNeedType(DAL.PersonNeedType model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonNeedType personNeedType = db.PersonNeedTypeRepository.GetById(model.PersonNeedTypeId);

            //personNeedType.AbuserName = model.AbuserName;
            personNeedType.PersonNeedTypeDesc = model.PersonNeedTypeDesc;
            //personNeedType.RelationTypeId = model.RelationTypeId;
            personNeedType.UpdateTime = DateTime.Now;
            personNeedType.UpdateUserId = userInfo.UserId;
            db.PersonNeedTypeRepository.Update(personNeedType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonNeedTypeId;
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
        public ActionResult RemovePersonNeedType(int id)
        {
            var personNeedType = db.PersonNeedTypeRepository.GetById(id);
            db.PersonNeedTypeRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personNeedType);
            var output = "personId=" + personNeedType.PersonId;
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


            return RedirectToAction("Index", new { id = personNeedType.PersonId });
        }
    }
}