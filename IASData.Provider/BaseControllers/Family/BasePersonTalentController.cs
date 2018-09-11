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
    public class BasePersonTalentController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonTalent
        public ActionResult Index(int id)
        {
            List<DAL.PersonTalent> personTalents = db.PersonTalentRepository.Get(q => q.PersonId == id).ToList();
            //ViewBag.Talents = db.TalentRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personTalents);
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
            List<DAL.PersonTalent> personTalents = db.PersonTalentRepository.Get(q => q.PersonId == personId ).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personTalents);
        }

        [HttpPost]
        public ActionResult CreatePersonTalent(DAL.PersonTalent personTalent)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personTalent.InsertTime = DateTime.Now;
            personTalent.InsertUserId = userInfo.UserId;
            db.PersonTalentRepository.Insert(personTalent);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personTalent);
            var output = "personId=" + personTalent.PersonTalentId;
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
            return RedirectToAction("Index", new { id = personTalent.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonTalent(DAL.PersonTalent model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonTalent personTalent = db.PersonTalentRepository.GetById(model.PersonTalentId);

            //personTalent.AbuserName = model.AbuserName;
            //personTalent.PersonTalentDesc = model.PersonTalentDesc;
            //personTalent.RelationTypeId = model.RelationTypeId;
            personTalent.UpdateTime = DateTime.Now;
            personTalent.UpdateUserId = userInfo.UserId;
            db.PersonTalentRepository.Update(personTalent);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonTalentId;
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
        public ActionResult RemovePersonTalent(int id)
        {
            var personTalent = db.PersonTalentRepository.GetById(id);
            db.PersonTalentRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personTalent);
            var output = "personId=" + personTalent.PersonId;
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


            return RedirectToAction("Index", new { id = personTalent.PersonId });
        }
    }
}