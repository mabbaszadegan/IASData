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
    public class BasePersonMostInfoController : Controller
    {
        private UnitOfWork db = new UnitOfWork();
        // GET: PersonMostInfo
        public ActionResult PersonMostInfoIndex(int id)
        {
            ViewBag.PersonId = id;

            return PartialView();
        }

        public ActionResult PersonSocialWorkInfo(int id)
        {
            Person person = db.PersonRepository.GetById(id);
            PersonViewModel personViewModel = new PersonViewModel
            {
                PersonId = person.PersonId,
                PersonLeavedFamily = person.PersonLeavedFamily,
                PersonLeavedFamilyDateSolar = person.PersonLeavedFamilyDateSolar,
                PersonLeavedFamilyDate = person.PersonLeavedFamilyDate,
                PersonLeavingHouseCauseDesc = person.PersonLeavingHouseCauseDesc,
                PersonLeavingHouseCauseId = person.PersonLeavingHouseCauseId,
                PersonLeavingHouseDesc = person.PersonLeavingHouseDesc,
                PersonAddress = person.PersonAddress,

                PersonIsWorkedChild = person.PersonIsWorkedChild,
                JobDesc = person.JobDesc,
                JobStatusId = person.JobStatusId,
                JobId = person.JobId,
                JobSalary = person.JobSalary,
                PersonLivelihood = person.PersonLivelihood,

                EducationStatusId = person.EducationStatusId,
                EducationTypeId = person.EducationTypeId,
                EducationDesc = person.EducationDesc,

                PersonHasChildMarriage = person.PersonHasChildMarriage,
                ChildMarriageCauseId = person.ChildMarriageCauseId,
                PersonChildMarriageDesc = person.PersonChildMarriageDesc,

                DrugHistoryId = person.DrugHistoryId,
                DrugStatusId = person.DrugStatusId,
                DrugWithdrawalHistoryId = person.DrugWithdrawalHistoryId,

                PersonCanTraveling = person.PersonCanTraveling,
                PersonTravelingDesc = person.PersonTravelingDesc,

                PersonDesc = person.PersonDesc,

            };

            InitForm(personViewModel);
            return PartialView(personViewModel);
        }

        [HttpPost]
        public ActionResult EditSocialWork(PersonViewModel personViewModel)
        {
            EventLogViewModel eventLogView = new EventLogViewModel();
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            DAL.Person person = db.PersonRepository.GetById(personViewModel.PersonId);
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            person.PersonLeavedFamily = personViewModel.PersonLeavedFamily;
            if (personViewModel.PersonLeavedFamily)
            {
                if (!string.IsNullOrEmpty(personViewModel.PersonLeavedFamilyDateSolar))
                {
                    person.PersonLeavedFamilyDateSolar = personViewModel.PersonLeavedFamilyDateSolar;
                    person.PersonLeavedFamilyDate = personViewModel.PersonLeavedFamilyDateSolar.ToZipedTextOnly().ToDate();
                }
                else
                {
                    person.PersonLeavedFamilyDateSolar = null;
                    person.PersonLeavedFamilyDate = null;
                }

                if (!string.IsNullOrEmpty(personViewModel.PersonLeavingHouseCauseDesc))
                {
                    person.PersonLeavingHouseCauseDesc = personViewModel.PersonLeavingHouseCauseDesc;
                }
                else
                {
                    person.PersonLeavingHouseCauseDesc = null;
                }
                if (!string.IsNullOrEmpty(personViewModel.PersonLeavingHouseDesc))
                {
                    person.PersonLeavingHouseDesc = personViewModel.PersonLeavingHouseDesc;
                }
                else
                {
                    person.PersonLeavingHouseDesc = null;
                }
                if (!string.IsNullOrEmpty(personViewModel.PersonAddress))
                {
                    person.PersonAddress = personViewModel.PersonAddress;
                }
                else
                {
                    person.PersonAddress = null;
                }
            }
            else
            {
                person.PersonLeavedFamilyDateSolar = null;
                person.PersonLeavedFamilyDate = null;

                person.PersonLeavingHouseCauseDesc = null;
                person.PersonLeavingHouseDesc = null;
                person.PersonAddress = personViewModel.PersonAddress;
                person.PersonAddress = null;
            }

            person.PersonIsWorkedChild = personViewModel.PersonIsWorkedChild;
            if (!string.IsNullOrEmpty(personViewModel.JobDesc))
                person.JobDesc = personViewModel.JobDesc;
            else
                person.JobDesc = null;

            if (personViewModel.JobStatusId > 0)
                person.JobStatusId = personViewModel.JobStatusId;
            else
                person.JobStatusId = null;

            if (personViewModel.JobId > 0)
                person.JobId = personViewModel.JobId;
            else
                person.JobId = null;


            if (!string.IsNullOrEmpty(personViewModel.JobDesc))
                person.JobDesc = personViewModel.JobDesc;
            else
                person.JobDesc = null;

            if (personViewModel.EducationStatusId > 0)
                person.EducationStatusId = personViewModel.EducationStatusId;
            else
                person.EducationStatusId = null;

            if (personViewModel.EducationTypeId > 0)
                person.EducationTypeId = personViewModel.EducationTypeId;
            else
                person.EducationTypeId = null;

            if (!string.IsNullOrEmpty(personViewModel.EducationDesc))
                person.EducationDesc = personViewModel.EducationDesc;
            else
                person.EducationDesc = null;

            person.PersonHasChildMarriage = personViewModel.PersonHasChildMarriage;
            if (!string.IsNullOrEmpty(personViewModel.PersonChildMarriageDesc))
                person.PersonChildMarriageDesc = personViewModel.PersonChildMarriageDesc;
            else
                person.PersonChildMarriageDesc = null;
            if (personViewModel.DrugHistoryId > 0)
                person.DrugHistoryId = personViewModel.DrugHistoryId;
            else
                person.DrugHistoryId = null;
            if (personViewModel.DrugStatusId > 0)
                person.DrugStatusId = personViewModel.DrugStatusId;
            else
                person.DrugStatusId = null;
            if (personViewModel.DrugWithdrawalHistoryId > 0)
                person.DrugWithdrawalHistoryId = personViewModel.DrugWithdrawalHistoryId;
            else
                person.DrugWithdrawalHistoryId = null;

            if (!string.IsNullOrEmpty(personViewModel.PersonDesc))
                person.PersonDesc = personViewModel.PersonDesc;
            else
                person.PersonDesc = null;


            if (messageViewModel.Any(q => q.Type == 1))
            {

                eventLogView = new EventLogViewModel
                {
                    Area = null,
                    Controller = "PersonMostInfo",
                    Action = "EditSocialWork",
                    Type = EventLogType.Update,
                    Input = new JavaScriptSerializer().Serialize(personViewModel),
                    Output = new JavaScriptSerializer().Serialize(messageViewModel),
                    Description = "",
                    //UserId=User.Identity.
                };
                Common.HttpLogInsert(eventLogView);


                return PartialView("_SystemMessages", messageViewModel);
            }
       
            db.Save();

            messageViewModel.Add(new SystemMessageViewModel
            {
                Title = "",
                Desc = "ثبت با موفقیت انجام شد!",
                Type = 2
            });

            var input = new JavaScriptSerializer().Serialize(personViewModel);
            var output = new JavaScriptSerializer().Serialize(messageViewModel);
            eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonMostInfo",
                Action = "EditSocialWork",
                Type = EventLogType.Update,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return PartialView("_SystemMessages", messageViewModel);
        }
        private void InitForm(PersonViewModel person)
        {
            List<SelectListItem> JobStatusId = new List<SelectListItem>();
            JobStatusId.Add(new SelectListItem { Text = "", Value = "0" });
            JobStatusId.AddRange(db.JobStatusRepository.Get().Select(q => new SelectListItem { Value = q.JobStatusId.ToString(), Text = q.JobStatusName }).OrderBy(q => q.Text));
            ViewBag.JobStatusId = new SelectList(JobStatusId, "Value", "Text");

            List<SelectListItem> JobId = new List<SelectListItem>();
            //JobStatusId.Add(new SelectListItem { Text = "", Value = "0" });
            //JobStatusId.AddRange(db.JobStatusRepository.Get().Select(q => new SelectListItem { Value = q.JobStatusId.ToString(), Text = q.JobStatusName }).OrderBy(q => q.Text));
            ViewBag.JobId = new SelectList(JobId, "Value", "Text");

            List<SelectListItem> EducationStatusId = new List<SelectListItem>();
            EducationStatusId.Add(new SelectListItem { Text = "", Value = "0" });
            EducationStatusId.AddRange(db.EducationStatusRepository.Get().Select(q => new SelectListItem { Value = q.EducationStatusId.ToString(), Text = q.EducationStatusName }).OrderBy(q => q.Text));
            ViewBag.EducationStatusId = new SelectList(EducationStatusId, "Value", "Text");

            List<SelectListItem> EducationTypeId = new List<SelectListItem>();
            EducationTypeId.Add(new SelectListItem { Text = "", Value = "0" });
            EducationTypeId.AddRange(db.EducationTypeRepository.Get().OrderBy(q => q.EducationTypeIndex).Select(q => new SelectListItem { Value = q.EducationTypeId.ToString(), Text = q.EducationTypeName }));
            ViewBag.EducationTypeId = new SelectList(EducationTypeId, "Value", "Text");

            List<SelectListItem> DrugHistoryId = new List<SelectListItem>();
            DrugHistoryId.Add(new SelectListItem { Text = "", Value = "0" });
            DrugHistoryId.AddRange(db.DrugHistoryRepository.Get().Select(q => new SelectListItem { Value = q.DrugHistoryId.ToString(), Text = q.DrugHistoryName }).OrderBy(q => q.Text));
            ViewBag.DrugHistoryId = new SelectList(DrugHistoryId, "Value", "Text");

            List<SelectListItem> DrugStatusId = new List<SelectListItem>();
            DrugStatusId.Add(new SelectListItem { Text = "", Value = "0" });
            DrugStatusId.AddRange(db.DrugStatusRepository.Get().Select(q => new SelectListItem { Value = q.DrugStatusId.ToString(), Text = q.DrugStatusName }).OrderBy(q => q.Text));
            ViewBag.DrugStatusId = new SelectList(DrugStatusId, "Value", "Text");

            List<SelectListItem> DrugWithdrawalHistoryId = new List<SelectListItem>();
            DrugWithdrawalHistoryId.Add(new SelectListItem { Text = "", Value = "0" });
            DrugWithdrawalHistoryId.AddRange(db.DrugWithdrawalHistoryRepository.Get().Select(q => new SelectListItem { Value = q.DrugWithdrawalHistoryId.ToString(), Text = q.DrugWithdrawalHistoryName }).OrderBy(q => q.Text));
            ViewBag.DrugWithdrawalHistoryId = new SelectList(DrugWithdrawalHistoryId, "Value", "Text");

        }


    }
}