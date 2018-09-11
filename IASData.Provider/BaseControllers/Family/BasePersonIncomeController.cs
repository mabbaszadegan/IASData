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
    public class BasePersonIncomeController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonIncome
        public ActionResult Index(int id)
        {
            List<DAL.PersonIncome> personIncomes = db.PersonIncomeRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.Incomes = db.IncomeTypeRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personIncomes);
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
            List<DAL.PersonIncome> personIncomes = db.PersonIncomeRepository.Get(q => q.PersonId == personId && q.IncomeTypeId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personIncomes);
        }

        [HttpPost]
        public ActionResult CreatePersonIncome(DAL.PersonIncome personIncome)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personIncome.InsertTime = DateTime.Now;
            personIncome.InsertUserId = userInfo.UserId;
            db.PersonIncomeRepository.Insert(personIncome);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personIncome);
            var output = "personId=" + personIncome.PersonIncomeId;
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
            return RedirectToAction("Index", new { id = personIncome.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonIncome(DAL.PersonIncome model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonIncome personIncome = db.PersonIncomeRepository.GetById(model.PersonIncomeId);

            //personIncome.AbuserName = model.AbuserName;
            //personIncome.PersonIncomeDesc = model.PersonIncomeDesc;
            //personIncome.RelationTypeId = model.RelationTypeId;
            personIncome.UpdateTime = DateTime.Now;
            personIncome.UpdateUserId = userInfo.UserId;
            db.PersonIncomeRepository.Update(personIncome);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonIncomeId;
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
        public ActionResult RemovePersonIncome(int id)
        {
            var personIncome = db.PersonIncomeRepository.GetById(id);
            db.PersonIncomeRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personIncome);
            var output = "personId=" + personIncome.PersonId;
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


            return RedirectToAction("Index", new { id = personIncome.PersonId });
        }
    }
}