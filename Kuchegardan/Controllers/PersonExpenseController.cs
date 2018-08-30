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
    public class PersonExpenseController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonExpense
        public ActionResult Index(int id)
        {
            List<DAL.PersonExpense> personExpenses = db.PersonExpenseRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.Expenses = db.ExpenseTypeRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personExpenses);
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
            List<DAL.PersonExpense> personExpenses = db.PersonExpenseRepository.Get(q => q.PersonId == personId && q.ExpenseTypeId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personExpenses);
        }

        [HttpPost]
        public ActionResult CreatePersonExpense(DAL.PersonExpense personExpense)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personExpense.InsertTime = DateTime.Now;
            personExpense.InsertUserId = userInfo.UserId;
            db.PersonExpenseRepository.Insert(personExpense);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personExpense);
            var output = "personId=" + personExpense.PersonExpenseId;
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
            return RedirectToAction("Index", new { id = personExpense.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonExpense(DAL.PersonExpense model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonExpense personExpense = db.PersonExpenseRepository.GetById(model.PersonExpenseId);

            //personExpense.AbuserName = model.AbuserName;
            //personExpense.PersonExpenseDesc = model.PersonExpenseDesc;
            //personExpense.RelationTypeId = model.RelationTypeId;
            personExpense.UpdateTime = DateTime.Now;
            personExpense.UpdateUserId = userInfo.UserId;
            db.PersonExpenseRepository.Update(personExpense);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonExpenseId;
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
        public ActionResult RemovePersonExpense(int id)
        {
            var personExpense = db.PersonExpenseRepository.GetById(id);
            db.PersonExpenseRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personExpense);
            var output = "personId=" + personExpense.PersonId;
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


            return RedirectToAction("Index", new { id = personExpense.PersonId });
        }
    }
}