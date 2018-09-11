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
    public class BasePersonSkillTypeController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonSkillType
        public ActionResult Index(int id)
        {
            List<DAL.PersonSkillType> personSkillTypes = db.PersonSkillTypeRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.SkillTypes = db.SkillTypeRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personSkillTypes);
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
            List<DAL.PersonSkillType> personSkillTypes = db.PersonSkillTypeRepository.Get(q => q.PersonId == personId && q.SkillTypeId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personSkillTypes);
        }

        [HttpPost]
        public ActionResult CreatePersonSkillType(DAL.PersonSkillType personSkillType)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personSkillType.InsertTime = DateTime.Now;
            personSkillType.InsertUserId = userInfo.UserId;
            db.PersonSkillTypeRepository.Insert(personSkillType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personSkillType);
            var output = "personId=" + personSkillType.PersonSkillTypeId;
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
            return RedirectToAction("Index", new { id = personSkillType.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonSkillType(DAL.PersonSkillType model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonSkillType personSkillType = db.PersonSkillTypeRepository.GetById(model.PersonSkillTypeId);

            //personSkillType.AbuserName = model.AbuserName;
            personSkillType.PersonSkillTypeDesc = model.PersonSkillTypeDesc;
            //personSkillType.RelationTypeId = model.RelationTypeId;
            personSkillType.UpdateTime = DateTime.Now;
            personSkillType.UpdateUserId = userInfo.UserId;
            db.PersonSkillTypeRepository.Update(personSkillType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonSkillTypeId;
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
        public ActionResult RemovePersonSkillType(int id)
        {
            var personSkillType = db.PersonSkillTypeRepository.GetById(id);
            db.PersonSkillTypeRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personSkillType);
            var output = "personId=" + personSkillType.PersonId;
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


            return RedirectToAction("Index", new { id = personSkillType.PersonId });
        }
    }
}