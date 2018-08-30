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
    public class PersonDamageController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonDamage
        public ActionResult Index(int id)
        {
            List<DAL.PersonDamage> PersonDamages = db.PersonDamageRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.ChildAbuseTypes = db.ChildAbuseTypeRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(PersonDamages);
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
            List<DAL.PersonDamage> PersonDamages = db.PersonDamageRepository.Get(q => q.PersonId == personId ).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(PersonDamages);
        }

        [HttpPost]
        public ActionResult CreatePersonDamage(DAL.PersonDamage PersonDamage)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            PersonDamage.InsertTime = DateTime.Now;
            PersonDamage.InsertUserId = userInfo.UserId;
            db.PersonDamageRepository.Insert(PersonDamage);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(PersonDamage);
            var output = "personId=" + PersonDamage.PersonDamageId;
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
            return RedirectToAction("Index", new { id = PersonDamage.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonDamage(DAL.PersonDamage model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonDamage PersonDamage = db.PersonDamageRepository.GetById(model.PersonDamageId);

            //PersonDamage.AbuserName = model.AbuserName;
            //PersonDamage.PersonDamageDesc = model.PersonDamageDesc;
            //PersonDamage.RelationTypeId = model.RelationTypeId;
            PersonDamage.UpdateTime = DateTime.Now;
            PersonDamage.UpdateUserId = userInfo.UserId;
            db.PersonDamageRepository.Update(PersonDamage);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonDamageId;
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
        public ActionResult RemovePersonDamage(int id)
        {
            var PersonDamage = db.PersonDamageRepository.GetById(id);
            db.PersonDamageRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(PersonDamage);
            var output = "personId=" + PersonDamage.PersonId;
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


            return RedirectToAction("Index", new { id = PersonDamage.PersonId });
        }
    }
}