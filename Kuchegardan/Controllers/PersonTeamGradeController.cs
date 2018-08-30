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
    public class PersonTeamGradeController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonTeamGrade
        public ActionResult Index(int id)
        {
            List<DAL.PersonTeamGrade> personTeamGrades = db.PersonTeamGradeRepository.Get(q => q.PersonTeamId == id).ToList();
           // ViewBag.TeamGrades = db.TeamGradeRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personTeamGrades);
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
            List<DAL.PersonTeamGrade> personTeamGrades = db.PersonTeamGradeRepository.Get(q => q.PersonTeamId == personId && q.PersonTeamGradeId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personTeamGrades);
        }

        [HttpPost]
        public ActionResult CreatePersonTeamGrade(DAL.PersonTeamGrade personTeamGrade)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personTeamGrade.InsertTime = DateTime.Now;
            personTeamGrade.InsertUserId = userInfo.UserId;
            db.PersonTeamGradeRepository.Insert(personTeamGrade);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personTeamGrade);
            var output = "personId=" + personTeamGrade.PersonTeamGradeId;
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
            return RedirectToAction("Index", new { id = personTeamGrade.PersonTeamId });
        }

        [HttpPost]
        public ActionResult EditPersonTeamGrade(DAL.PersonTeamGrade model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonTeamGrade personTeamGrade = db.PersonTeamGradeRepository.GetById(model.PersonTeamGradeId);

            //personTeamGrade.AbuserName = model.AbuserName;
            //personTeamGrade.PersonTeamGradeDesc = model.PersonTeamGradeDesc;
            //personTeamGrade.RelationTypeId = model.RelationTypeId;
            personTeamGrade.UpdateTime = DateTime.Now;
            personTeamGrade.UpdateUserId = userInfo.UserId;
            db.PersonTeamGradeRepository.Update(personTeamGrade);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonTeamGradeId;
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

            return RedirectToAction("Index", new { id = model.PersonTeamId });
        }
        public ActionResult RemovePersonTeamGrade(int id)
        {
            var personTeamGrade = db.PersonTeamGradeRepository.GetById(id);
            db.PersonTeamGradeRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personTeamGrade);
            var output = "personId=" + personTeamGrade.PersonTeamId;
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


            return RedirectToAction("Index", new { id = personTeamGrade.PersonTeamId });
        }
    }
}