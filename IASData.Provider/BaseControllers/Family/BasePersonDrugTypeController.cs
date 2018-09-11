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
    public class BasePersonDrugTypeController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonDrugType
        public ActionResult Index(int id)
        {
            List<DAL.PersonDrugType> personDrugTypes = db.PersonDrugTypeRepository.Get(q => q.PersonId == id).ToList();
            //ViewBag.DrugTypes = db.DrugTypeRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personDrugTypes);
        }

        public ActionResult Create(int personId)
        {
            List<SelectListItem> drugTypeId = new List<SelectListItem>();
            drugTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.DrugTypeRepository.Get().OrderBy(q => q.DrugTypeName))
            {
                drugTypeId.Add(new SelectListItem { Value = item.DrugTypeId.ToString(), Text = item.DrugTypeName });
            }
            ViewBag.DrugTypeId = new SelectList(drugTypeId, "Value", "Text");
           
            ViewBag.PersonId = personId;

            return PartialView();
        }
        public ActionResult Edit(int personId)
        {
            List<DAL.PersonDrugType> personDrugTypes = db.PersonDrugTypeRepository.Get(q => q.PersonId == personId).ToList();

            List<SelectListItem> drugTypeId = new List<SelectListItem>();
            drugTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.DrugTypeRepository.Get().OrderBy(q => q.DrugTypeName))
            {
                drugTypeId.Add(new SelectListItem { Value = item.DrugTypeId.ToString(), Text = item.DrugTypeName });
            }
            ViewBag.DrugTypeId = new SelectList(drugTypeId, "Value", "Text");

            return PartialView(personDrugTypes);
        }

        [HttpPost]
        public ActionResult CreatePersonDrugType(DAL.PersonDrugType personDrugType)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personDrugType.InsertTime = DateTime.Now;
            personDrugType.InsertUserId = userInfo.UserId;
            db.PersonDrugTypeRepository.Insert(personDrugType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personDrugType);
            var output = "personId=" + personDrugType.PersonDrugTypeId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonDrugType",
                Action = "CreatePersonDrugType",
                Type = EventLogType.Insert,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);
            return RedirectToAction("Index", new { id = personDrugType.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonDrugType(DAL.PersonDrugType model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonDrugType personDrugType = db.PersonDrugTypeRepository.GetById(model.PersonDrugTypeId);

            personDrugType.DrugDesc = model.DrugDesc;
            personDrugType.DrugStartCause = model.DrugStartCause;
            personDrugType.DrugStartYear = model.DrugStartYear;
            personDrugType.DrugStopCause = model.DrugStopCause;
            personDrugType.DrugStopYear = model.DrugStopYear;

            //personDrugType.PersonDrugTypeDesc = model.PersonDrugTypeDesc;
            personDrugType.DrugTypeId = model.DrugTypeId;
            personDrugType.UpdateTime = DateTime.Now;
            personDrugType.UpdateUserId = userInfo.UserId;
            db.PersonDrugTypeRepository.Update(personDrugType);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonDrugTypeId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonDrugType",
                Action = "EditPersonDrugType",
                Type = EventLogType.Update,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return RedirectToAction("Index", new { id = model.PersonId });
        }
        public ActionResult RemovePersonDrugType(int id)
        {
            var personDrugType = db.PersonDrugTypeRepository.GetById(id);
            db.PersonDrugTypeRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personDrugType);
            var output = "personId=" + personDrugType.PersonId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonDrugType",
                Action = "RemovePersonDrugType",
                Type = EventLogType.Delete,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);


            return RedirectToAction("Index", new { id = personDrugType.PersonId });
        }
    }
}