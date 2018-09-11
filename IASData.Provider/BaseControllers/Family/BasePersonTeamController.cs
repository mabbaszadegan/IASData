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
    public class BasePersonTeamController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonTeam
        public ActionResult Index(int id)
        {
            var personTeams = db.PersonTeamRepository.Get(q => q.PersonId == id).ToList();
            var person = db.PersonRepository.GetById(id);
            ViewBag.SkillTypes = db.DepartmentTeamRepository.Get(q => q.DepartmentId == person.DepartmentId && (!q.Team.GenderId.HasValue || q.Team.GenderId == person.GenderId)).Select(q => new SkillTypeViewModel
            {
                SkillTypeId = q.Team.SkillTypeId,
                SkillTypeName = q.Team.SkillType.SkillTypeName,
                SkillTypeHasBeltColor = q.Team.SkillType.SkillTypeHasBeltColor,
                SkillTypeSummaryName = q.Team.SkillType.SkillTypeSummaryName,
                SkillTypeHasExpertise = q.Team.SkillType.SkillTypeHasExpertise,
                SkillTypeHasShirtNo = q.Team.SkillType.SkillTypeHasShirtNo,
                SkillTypeIsSolitary = q.Team.SkillType.SkillTypeIsSolitary,
            }).Distinct().ToList();
            ViewBag.PersonId = id;
            return PartialView(personTeams);
        }

        public ActionResult Create(int skillTypeId, int personId)
        {
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            var person = db.PersonRepository.GetById(personId);
            var skillType = db.SkillTypeRepository.GetById(skillTypeId);
            List<SelectListItem> departmentId = new List<SelectListItem>();
            departmentId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.DepartmentTeamRepository.Get(q => q.DepartmentId == person.DepartmentId && !q.PersonTeam.Any(p => p.PersonId == personId) && q.Team.SkillTypeId == skillTypeId && (!q.Team.GenderId.HasValue || q.Team.GenderId == person.GenderId)))
            {
                departmentId.Add(new SelectListItem { Value = item.DepartmentTeamId.ToString(), Text = item.Team.TeamName });
            }
            ViewBag.DepartmentTeamId = new SelectList(departmentId, "Value", "Text");

            List<SelectListItem> BeltColorId = new List<SelectListItem>();
            BeltColorId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.BeltColorRepository.Get(q => !q.PersonTeam.Any(p => p.PersonId == personId) && q.SkillTypeId == skillTypeId))
            {
                BeltColorId.Add(new SelectListItem { Value = item.BeltColorId.ToString(), Text = item.BeltColorName });
            }
            ViewBag.BeltColorId = new SelectList(BeltColorId, "Value", "Text");

            List<SelectListItem> ExpertiseId = new List<SelectListItem>();
            ExpertiseId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.ExpertiseRepository.Get(q => !q.PersonTeam.Any(p => p.PersonId == personId) && q.SkillTypeId == skillTypeId))
            {
                ExpertiseId.Add(new SelectListItem { Value = item.ExpertiseId.ToString(), Text = item.ExpertiseName });
            }
            ViewBag.ExpertiseId = new SelectList(ExpertiseId, "Value", "Text");

            ViewBag.SkillType = skillType;
            ViewBag.PersonId = personId;

            if (departmentId.Count > 1)
                return PartialView();
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "",
                    Desc = "تیمی برای انتخاب وجود ندارد!",
                    Type = 1
                });
                return PartialView("_SystemMessages", messageViewModel);

            }

        }
        public ActionResult Edit(int skillTypeId, int personId)
        {
            List<DAL.PersonTeam> personTeams = db.PersonTeamRepository.Get(q => q.PersonId == personId).ToList();

            var person = db.PersonRepository.GetById(personId);
            var skillType = db.SkillTypeRepository.GetById(skillTypeId);
            List<SelectListItem> departmentId = new List<SelectListItem>();
            departmentId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.DepartmentTeamRepository.Get(q => q.DepartmentId == person.DepartmentId && q.Team.SkillTypeId == skillTypeId && (!q.Team.GenderId.HasValue || q.Team.GenderId == person.GenderId)))
            {
                departmentId.Add(new SelectListItem { Value = item.DepartmentTeamId.ToString(), Text = item.Team.TeamName });
            }
            ViewBag.DepartmentTeamId = new SelectList(departmentId, "Value", "Text");

            List<SelectListItem> BeltColorId = new List<SelectListItem>();
            BeltColorId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.BeltColorRepository.Get(q => q.SkillTypeId == skillTypeId))
            {
                BeltColorId.Add(new SelectListItem { Value = item.BeltColorId.ToString(), Text = item.BeltColorName });
            }
            ViewBag.BeltColorId = new SelectList(BeltColorId, "Value", "Text");

            List<SelectListItem> ExpertiseId = new List<SelectListItem>();
            ExpertiseId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.ExpertiseRepository.Get(q => q.SkillTypeId == skillTypeId))
            {
                ExpertiseId.Add(new SelectListItem { Value = item.ExpertiseId.ToString(), Text = item.ExpertiseName });
            }
            ViewBag.ExpertiseId = new SelectList(ExpertiseId, "Value", "Text");

            ViewBag.SkillType = skillType;
            ViewBag.PersonId = personId;

            return PartialView(personTeams);
        }

        [HttpPost]
        public ActionResult CreatePersonTeam(DAL.PersonTeam personTeam)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            if (!string.IsNullOrEmpty(personTeam.PersonEnterToTeamDateSolar))
            {
                personTeam.PersonEnterToTeamDateSolar = personTeam.PersonEnterToTeamDateSolar;
                personTeam.PersonEnterToTeamDate = personTeam.PersonEnterToTeamDateSolar.ToZipedTextOnly().ToDate();
            }
            if (!string.IsNullOrEmpty(personTeam.PersonExitFromTeamDateSolar))
            {
                personTeam.PersonExitFromTeamDateSolar = personTeam.PersonExitFromTeamDateSolar;
                personTeam.PersonExitFromTeamDate = personTeam.PersonExitFromTeamDateSolar.ToZipedTextOnly().ToDate();
            }
            personTeam.InsertTime = DateTime.Now;
            personTeam.InsertUserId = userInfo.UserId;
            db.PersonTeamRepository.Insert(personTeam);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personTeam);
            var output = "personId=" + personTeam.PersonTeamId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonTeam",
                Action = "CreatePersonTeam",
                Type = EventLogType.Insert,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);
            return RedirectToAction("Index", new { id = personTeam.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonTeam(DAL.PersonTeam model)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonTeam personTeam = db.PersonTeamRepository.GetById(model.PersonTeamId);


            if (!string.IsNullOrEmpty(personTeam.PersonEnterToTeamDateSolar))
            {
                personTeam.PersonEnterToTeamDateSolar = personTeam.PersonEnterToTeamDateSolar;
                personTeam.PersonEnterToTeamDate = personTeam.PersonEnterToTeamDateSolar.ToZipedTextOnly().ToDate();
            }
            if (!string.IsNullOrEmpty(personTeam.PersonExitFromTeamDateSolar))
            {
                personTeam.PersonExitFromTeamDateSolar = personTeam.PersonExitFromTeamDateSolar;
                personTeam.PersonExitFromTeamDate = personTeam.PersonExitFromTeamDateSolar.ToZipedTextOnly().ToDate();
            }
            personTeam.PersonTeamDesc = model.PersonTeamDesc;
            personTeam.UpdateTime = DateTime.Now;
            personTeam.UpdateUserId = userInfo.UserId;
            db.PersonTeamRepository.Update(personTeam);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonTeamId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonTeam",
                Action = "EditPersonTeam",
                Type = EventLogType.Update,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return RedirectToAction("Index", new { id = model.PersonId });
        }
        public ActionResult RemovePersonTeam(int id)
        {
            var personTeam = db.PersonTeamRepository.GetById(id);
            db.PersonTeamRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personTeam);
            var output = "personId=" + personTeam.PersonId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonTeam",
                Action = "RemovePersonTeam",
                Type = EventLogType.Delete,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);


            return RedirectToAction("Index", new { id = personTeam.PersonId });
        }
    }
}