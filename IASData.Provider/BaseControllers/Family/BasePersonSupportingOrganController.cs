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
    public class BasePersonSupportingOrganController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonSupportingOrgan
        public ActionResult Index(int id)
        {
            List<DAL.PersonSupportingOrgan> personSupportingOrgans = db.PersonSupportingOrganRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.SupportingOrgans = db.SupportingOrganRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personSupportingOrgans);
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
            List<DAL.PersonSupportingOrgan> personSupportingOrgans = db.PersonSupportingOrganRepository.Get(q => q.PersonId == personId && q.SupportingOrganId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personSupportingOrgans);
        }

        [HttpPost]
        public ActionResult CreatePersonSupportingOrgan(DAL.PersonSupportingOrgan personSupportingOrgan)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personSupportingOrgan.InsertTime = DateTime.Now;
            personSupportingOrgan.InsertUserId = userInfo.UserId;
            db.PersonSupportingOrganRepository.Insert(personSupportingOrgan);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personSupportingOrgan);
            var output = "personId=" + personSupportingOrgan.PersonSupportingOrganId;
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
            return RedirectToAction("Index", new { id = personSupportingOrgan.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonSupportingOrgan(DAL.PersonSupportingOrgan model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonSupportingOrgan personSupportingOrgan = db.PersonSupportingOrganRepository.GetById(model.PersonSupportingOrganId);

            //personSupportingOrgan.AbuserName = model.AbuserName;
            //personSupportingOrgan.PersonSupportingOrganDesc = model.PersonSupportingOrganDesc;
            //personSupportingOrgan.RelationTypeId = model.RelationTypeId;
            personSupportingOrgan.UpdateTime = DateTime.Now;
            personSupportingOrgan.UpdateUserId = userInfo.UserId;
            db.PersonSupportingOrganRepository.Update(personSupportingOrgan);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonSupportingOrganId;
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
        public ActionResult RemovePersonSupportingOrgan(int id)
        {
            var personSupportingOrgan = db.PersonSupportingOrganRepository.GetById(id);
            db.PersonSupportingOrganRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personSupportingOrgan);
            var output = "personId=" + personSupportingOrgan.PersonId;
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


            return RedirectToAction("Index", new { id = personSupportingOrgan.PersonId });
        }
    }
}