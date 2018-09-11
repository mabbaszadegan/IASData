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
    public class BasePersonJobController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonJob
        public ActionResult Index(int id)
        {
            List<DAL.PersonJob> personJobs = db.PersonJobRepository.Get(q => q.PersonId == id).ToList();
            ViewBag.Jobs = db.JobRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personJobs);
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
            List<DAL.PersonJob> personJobs = db.PersonJobRepository.Get(q => q.PersonId == personId && q.JobId == abuseTypeId).ToList();

            List<SelectListItem> relationTypeId = new List<SelectListItem>();
            relationTypeId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName))
            {
                relationTypeId.Add(new SelectListItem { Value = item.RelationTypeId.ToString(), Text = item.RelationTypeName });
            }
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "Value", "Text");

            return PartialView(personJobs);
        }

        [HttpPost]
        public ActionResult CreatePersonJob(DAL.PersonJob personJob)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            personJob.InsertTime = DateTime.Now;
            personJob.InsertUserId = userInfo.UserId;
            db.PersonJobRepository.Insert(personJob);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personJob);
            var output = "personId=" + personJob.PersonJobId;
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
            return RedirectToAction("Index", new { id = personJob.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonJob(DAL.PersonJob model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonJob personJob = db.PersonJobRepository.GetById(model.PersonJobId);

            //personJob.AbuserName = model.AbuserName;
            personJob.PersonJobDesc = model.PersonJobDesc;
            //personJob.RelationTypeId = model.RelationTypeId;
            personJob.UpdateTime = DateTime.Now;
            personJob.UpdateUserId = userInfo.UserId;
            db.PersonJobRepository.Update(personJob);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonJobId;
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
        public ActionResult RemovePersonJob(int id)
        {
            var personJob = db.PersonJobRepository.GetById(id);
            db.PersonJobRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personJob);
            var output = "personId=" + personJob.PersonId;
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


            return RedirectToAction("Index", new { id = personJob.PersonId });
        }
    }
}