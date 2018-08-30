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
    public class PersonInsuranceTypeController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonInsuranceType
        public ActionResult Index(int id)
        {
            List<DAL.PersonInsuranceType> personInsuranceTypes = db.PersonInsuranceTypeRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.InsuranceTypes = db.InsuranceTypeRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personInsuranceTypes);
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
            List<DAL.PersonInsuranceType> personInsuranceTypes = db.PersonInsuranceTypeRepository.Get(q => q.PersonId == personId && q.InsuranceTypeId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personInsuranceTypes);
        }

        [HttpPost]
        public ActionResult CreatePersonInsuranceType(DAL.PersonInsuranceType personInsuranceType)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personInsuranceType.InsertTime = DateTime.Now;
            personInsuranceType.InsertUserId = userInfo.UserId;
            db.PersonInsuranceTypeRepository.Insert(personInsuranceType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personInsuranceType);
            var output = "personId=" + personInsuranceType.PersonInsuranceTypeId;
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
            return RedirectToAction("Index", new { id = personInsuranceType.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonInsuranceType(DAL.PersonInsuranceType model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonInsuranceType personInsuranceType = db.PersonInsuranceTypeRepository.GetById(model.PersonInsuranceTypeId);

            //personInsuranceType.AbuserName = model.AbuserName;
            //personInsuranceType.PersonInsuranceTypeDesc = model.PersonInsuranceTypeDesc;
            //personInsuranceType.RelationTypeId = model.RelationTypeId;
            personInsuranceType.UpdateTime = DateTime.Now;
            personInsuranceType.UpdateUserId = userInfo.UserId;
            db.PersonInsuranceTypeRepository.Update(personInsuranceType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonInsuranceTypeId;
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
        public ActionResult RemovePersonInsuranceType(int id)
        {
            var personInsuranceType = db.PersonInsuranceTypeRepository.GetById(id);
            db.PersonInsuranceTypeRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personInsuranceType);
            var output = "personId=" + personInsuranceType.PersonId;
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


            return RedirectToAction("Index", new { id = personInsuranceType.PersonId });
        }
    }
}