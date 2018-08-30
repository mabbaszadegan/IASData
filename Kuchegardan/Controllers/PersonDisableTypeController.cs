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
    public class PersonDisableTypeController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonDisableType
        public ActionResult Index(int id)
        {
            List<DAL.PersonDisableType> personDisableTypes = db.PersonDisableTypeRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.DisableTypes = db.DisableTypeRepository.Get().ToList();
            ViewBag.PersonId = id;
            return PartialView(personDisableTypes);
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
            List<DAL.PersonDisableType> personDisableTypes = db.PersonDisableTypeRepository.Get(q => q.PersonId == personId && q.DisableTypeId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personDisableTypes);
        }

        [HttpPost]
        public ActionResult CreatePersonDisableType(DAL.PersonDisableType personDisableType)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personDisableType.InsertTime = DateTime.Now;
            personDisableType.InsertUserId = userInfo.UserId;
            db.PersonDisableTypeRepository.Insert(personDisableType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personDisableType);
            var output = "personId=" + personDisableType.PersonDisableTypeId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonDisableType",
                Action = "CreatePersonDisableType",
                Type = EventLogType.Insert,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);
            return RedirectToAction("Index", new { id = personDisableType.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonDisableType(DAL.PersonDisableType model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonDisableType personDisableType = db.PersonDisableTypeRepository.GetById(model.PersonDisableTypeId);

            personDisableType.PersonDisableTypeDesc = model.PersonDisableTypeDesc;
            personDisableType.UpdateTime = DateTime.Now;
            personDisableType.UpdateUserId = userInfo.UserId;
            db.PersonDisableTypeRepository.Update(personDisableType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonDisableTypeId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonDisableType",
                Action = "EditPersonDisableType",
                Type = EventLogType.Update,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return RedirectToAction("Index", new { id = model.PersonId });
        }
        public ActionResult RemovePersonDisableType(int id)
        {
            var personDisableType = db.PersonDisableTypeRepository.GetById(id);
            db.PersonDisableTypeRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personDisableType);
            var output = "personId=" + personDisableType.PersonId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonDisableType",
                Action = "RemovePersonDisableType",
                Type = EventLogType.Delete,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);


            return RedirectToAction("Index", new { id = personDisableType.PersonId });
        }
    }
}