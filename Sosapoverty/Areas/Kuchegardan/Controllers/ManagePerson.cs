using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace Sosapoverty.Areas.Kuchegardan.Controllers
{
    public class ManagePerson : Controller
    {
        private IASDataEntities db = new IASDataEntities();

        // GET: Kuchegardan/ManagePerson
        public ActionResult Index()
        {
            var person = db.Person.Include(p => p.Bank).Include(p => p.Belive).Include(p => p.BloodType).Include(p => p.ChildMarriageCause).Include(p => p.City).Include(p => p.Department).Include(p => p.DrugHistory).Include(p => p.DrugStatus).Include(p => p.DrugWithdrawalHistory).Include(p => p.EducationField).Include(p => p.EducationStatus).Include(p => p.EducationType).Include(p => p.Ethnic).Include(p => p.Gender).Include(p => p.HealthType).Include(p => p.InsuranceType).Include(p => p.Job).Include(p => p.JobStatus).Include(p => p.LeavingHouseCause).Include(p => p.MaritalStatus).Include(p => p.Nationality).Include(p => p.Person1).Include(p => p.Person2).Include(p => p.PersonStatus).Include(p => p.Province).Include(p => p.Religion).Include(p => p.SupportingOrgan);
            return View(person.ToList());
        }

        // GET: Kuchegardan/ManagePerson/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Kuchegardan/ManagePerson/Create
        public ActionResult Create()
        {
            ViewBag.BankId = new SelectList(db.Bank, "BankId", "BankName");
            ViewBag.BeliveId = new SelectList(db.Belive, "BeliveId", "BeliveName");
            ViewBag.BloodTypeId = new SelectList(db.BloodType, "BloodTypeId", "BloodTypeName");
            ViewBag.ChildMarriageCauseId = new SelectList(db.ChildMarriageCause, "ChildMarriageCauseId", "ChildMarriageCauseName");
            ViewBag.BirthCityId = new SelectList(db.City, "CityId", "CityName");
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentCode");
            ViewBag.DrugHistoryId = new SelectList(db.DrugHistory, "DrugHistoryId", "DrugHistoryName");
            ViewBag.DrugStatusId = new SelectList(db.DrugStatus, "DrugStatusId", "DrugStatusName");
            ViewBag.DrugWithdrawalHistoryId = new SelectList(db.DrugWithdrawalHistory, "DrugWithdrawalHistoryId", "DrugWithdrawalHistoryName");
            ViewBag.EducationFieldId = new SelectList(db.EducationField, "EducationFieldId", "EducationFieldName");
            ViewBag.EducationStatusId = new SelectList(db.EducationStatus, "EducationStatusId", "EducationStatusName");
            ViewBag.EducationTypeId = new SelectList(db.EducationType, "EducationTypeId", "EducationTypeName");
            ViewBag.EthnicId = new SelectList(db.Ethnic, "EthnicId", "EthnicName");
            ViewBag.GenderId = new SelectList(db.Gender, "GenderId", "GenderName");
            ViewBag.HealthTypeId = new SelectList(db.HealthType, "HealthTypeId", "HealthTypeName");
            ViewBag.InsuranceTypeId = new SelectList(db.InsuranceType, "InsuranceTypeId", "InsuranceTypeName");
            ViewBag.JobId = new SelectList(db.Job, "JobId", "JobName");
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "JobStatusId", "JobStatusName");
            ViewBag.PersonLeavingHouseCauseId = new SelectList(db.LeavingHouseCause, "LeavingHouseCauseId", "LeavingHouseCauseName");
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "MaritalStatusId", "MaritalStatusName");
            ViewBag.NationalityId = new SelectList(db.Nationality, "NationalityId", "NationalityName");
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "PersonCode");
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "PersonCode");
            ViewBag.PersonStatusId = new SelectList(db.PersonStatus, "PersonStatusId", "PersonStatusName");
            ViewBag.BirthProvinceId = new SelectList(db.Province, "ProvinceId", "ProvinceName");
            ViewBag.ReligionId = new SelectList(db.Religion, "ReligionId", "ReligionName");
            ViewBag.SupportingOrganId = new SelectList(db.SupportingOrgan, "SupportingOrganId", "SupportingOrganName");
            return View();
        }

        // POST: Kuchegardan/ManagePerson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,PersonCode,PersonFilingDate,PersonFilingDateSolar,PersonFilingName,PersonCoveredDate,PersonCoveredDateSolar,PersonCoveredDesc,PersonFirstName,PersonLastName,PersonFatherName,PersonIdentityNo,PersonNationalCode,PersonBirthYear,PersonBirthMonth,PersonBirthDay,PersonBirthDate,PersonBirthDateSolar,PersonMonthlyIncome,PersonMonthlyExpense,PersonDesc,PersonCellPhone1,PersonCellPhone2,BankId,PersonBankAccount,PersonBankCard,PersonBankBranch,PersonShirtSize,PersonPantSize,PersonShoesSize,PersonHeight,PersonWeight,PersonBMIIndex,PersonZiped,PersonHasPassport,PersonHasCard,PersonLeavedFamily,PersonLeavedFamilyDateSolar,PersonLeavedFamilyDate,PersonLeavingHouseCauseId,PersonLeavingHouseCauseDesc,PersonLeavingHouseDesc,PersonAddress,PersonAddressZiped,PersonLeavedEducation,PersonIsWorkedChild,PersonHasInjectionCard,PersonGetBlueCard,PersonCanTraveling,PersonTravelingDesc,PersonSupportedByOtherNGO,PersonSupportedByOtherNGODesc,PersonSupportedByIAS,SupportingOrganId,DepartmentId,PersonStatusId,BeliveId,ReligionId,GenderId,EducationTypeId,EducationFieldId,EducationStatusId,EducationDesc,NationalityId,EthnicId,MigrateDuration,BirthProvinceId,BirthCityId,PersonLivelihood,JobStatusId,JobId,JobDesc,JobSalary,ChildMarriageCauseId,PersonHasChildMarriage,PersonChildMarriageDesc,MaritalStatusId,HealthTypeId,DrugHistoryId,DrugWithdrawalHistoryId,DrugStatusId,BloodTypeId,InsuranceTypeId,InsuranceDesc,SportTarget,InsertUserId,InsertTime,UpdateUserId,UpdateTime")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Person.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankId = new SelectList(db.Bank, "BankId", "BankName", person.BankId);
            ViewBag.BeliveId = new SelectList(db.Belive, "BeliveId", "BeliveName", person.BeliveId);
            ViewBag.BloodTypeId = new SelectList(db.BloodType, "BloodTypeId", "BloodTypeName", person.BloodTypeId);
            ViewBag.ChildMarriageCauseId = new SelectList(db.ChildMarriageCause, "ChildMarriageCauseId", "ChildMarriageCauseName", person.ChildMarriageCauseId);
            ViewBag.BirthCityId = new SelectList(db.City, "CityId", "CityName", person.BirthCityId);
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentCode", person.DepartmentId);
            ViewBag.DrugHistoryId = new SelectList(db.DrugHistory, "DrugHistoryId", "DrugHistoryName", person.DrugHistoryId);
            ViewBag.DrugStatusId = new SelectList(db.DrugStatus, "DrugStatusId", "DrugStatusName", person.DrugStatusId);
            ViewBag.DrugWithdrawalHistoryId = new SelectList(db.DrugWithdrawalHistory, "DrugWithdrawalHistoryId", "DrugWithdrawalHistoryName", person.DrugWithdrawalHistoryId);
            ViewBag.EducationFieldId = new SelectList(db.EducationField, "EducationFieldId", "EducationFieldName", person.EducationFieldId);
            ViewBag.EducationStatusId = new SelectList(db.EducationStatus, "EducationStatusId", "EducationStatusName", person.EducationStatusId);
            ViewBag.EducationTypeId = new SelectList(db.EducationType, "EducationTypeId", "EducationTypeName", person.EducationTypeId);
            ViewBag.EthnicId = new SelectList(db.Ethnic, "EthnicId", "EthnicName", person.EthnicId);
            ViewBag.GenderId = new SelectList(db.Gender, "GenderId", "GenderName", person.GenderId);
            ViewBag.HealthTypeId = new SelectList(db.HealthType, "HealthTypeId", "HealthTypeName", person.HealthTypeId);
            ViewBag.InsuranceTypeId = new SelectList(db.InsuranceType, "InsuranceTypeId", "InsuranceTypeName", person.InsuranceTypeId);
            ViewBag.JobId = new SelectList(db.Job, "JobId", "JobName", person.JobId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "JobStatusId", "JobStatusName", person.JobStatusId);
            ViewBag.PersonLeavingHouseCauseId = new SelectList(db.LeavingHouseCause, "LeavingHouseCauseId", "LeavingHouseCauseName", person.PersonLeavingHouseCauseId);
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "MaritalStatusId", "MaritalStatusName", person.MaritalStatusId);
            ViewBag.NationalityId = new SelectList(db.Nationality, "NationalityId", "NationalityName", person.NationalityId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "PersonCode", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "PersonCode", person.PersonId);
            ViewBag.PersonStatusId = new SelectList(db.PersonStatus, "PersonStatusId", "PersonStatusName", person.PersonStatusId);
            ViewBag.BirthProvinceId = new SelectList(db.Province, "ProvinceId", "ProvinceName", person.BirthProvinceId);
            ViewBag.ReligionId = new SelectList(db.Religion, "ReligionId", "ReligionName", person.ReligionId);
            ViewBag.SupportingOrganId = new SelectList(db.SupportingOrgan, "SupportingOrganId", "SupportingOrganName", person.SupportingOrganId);
            return View(person);
        }

        // GET: Kuchegardan/ManagePerson/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankId = new SelectList(db.Bank, "BankId", "BankName", person.BankId);
            ViewBag.BeliveId = new SelectList(db.Belive, "BeliveId", "BeliveName", person.BeliveId);
            ViewBag.BloodTypeId = new SelectList(db.BloodType, "BloodTypeId", "BloodTypeName", person.BloodTypeId);
            ViewBag.ChildMarriageCauseId = new SelectList(db.ChildMarriageCause, "ChildMarriageCauseId", "ChildMarriageCauseName", person.ChildMarriageCauseId);
            ViewBag.BirthCityId = new SelectList(db.City, "CityId", "CityName", person.BirthCityId);
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentCode", person.DepartmentId);
            ViewBag.DrugHistoryId = new SelectList(db.DrugHistory, "DrugHistoryId", "DrugHistoryName", person.DrugHistoryId);
            ViewBag.DrugStatusId = new SelectList(db.DrugStatus, "DrugStatusId", "DrugStatusName", person.DrugStatusId);
            ViewBag.DrugWithdrawalHistoryId = new SelectList(db.DrugWithdrawalHistory, "DrugWithdrawalHistoryId", "DrugWithdrawalHistoryName", person.DrugWithdrawalHistoryId);
            ViewBag.EducationFieldId = new SelectList(db.EducationField, "EducationFieldId", "EducationFieldName", person.EducationFieldId);
            ViewBag.EducationStatusId = new SelectList(db.EducationStatus, "EducationStatusId", "EducationStatusName", person.EducationStatusId);
            ViewBag.EducationTypeId = new SelectList(db.EducationType, "EducationTypeId", "EducationTypeName", person.EducationTypeId);
            ViewBag.EthnicId = new SelectList(db.Ethnic, "EthnicId", "EthnicName", person.EthnicId);
            ViewBag.GenderId = new SelectList(db.Gender, "GenderId", "GenderName", person.GenderId);
            ViewBag.HealthTypeId = new SelectList(db.HealthType, "HealthTypeId", "HealthTypeName", person.HealthTypeId);
            ViewBag.InsuranceTypeId = new SelectList(db.InsuranceType, "InsuranceTypeId", "InsuranceTypeName", person.InsuranceTypeId);
            ViewBag.JobId = new SelectList(db.Job, "JobId", "JobName", person.JobId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "JobStatusId", "JobStatusName", person.JobStatusId);
            ViewBag.PersonLeavingHouseCauseId = new SelectList(db.LeavingHouseCause, "LeavingHouseCauseId", "LeavingHouseCauseName", person.PersonLeavingHouseCauseId);
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "MaritalStatusId", "MaritalStatusName", person.MaritalStatusId);
            ViewBag.NationalityId = new SelectList(db.Nationality, "NationalityId", "NationalityName", person.NationalityId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "PersonCode", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "PersonCode", person.PersonId);
            ViewBag.PersonStatusId = new SelectList(db.PersonStatus, "PersonStatusId", "PersonStatusName", person.PersonStatusId);
            ViewBag.BirthProvinceId = new SelectList(db.Province, "ProvinceId", "ProvinceName", person.BirthProvinceId);
            ViewBag.ReligionId = new SelectList(db.Religion, "ReligionId", "ReligionName", person.ReligionId);
            ViewBag.SupportingOrganId = new SelectList(db.SupportingOrgan, "SupportingOrganId", "SupportingOrganName", person.SupportingOrganId);
            return View(person);
        }

        // POST: Kuchegardan/ManagePerson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,PersonCode,PersonFilingDate,PersonFilingDateSolar,PersonFilingName,PersonCoveredDate,PersonCoveredDateSolar,PersonCoveredDesc,PersonFirstName,PersonLastName,PersonFatherName,PersonIdentityNo,PersonNationalCode,PersonBirthYear,PersonBirthMonth,PersonBirthDay,PersonBirthDate,PersonBirthDateSolar,PersonMonthlyIncome,PersonMonthlyExpense,PersonDesc,PersonCellPhone1,PersonCellPhone2,BankId,PersonBankAccount,PersonBankCard,PersonBankBranch,PersonShirtSize,PersonPantSize,PersonShoesSize,PersonHeight,PersonWeight,PersonBMIIndex,PersonZiped,PersonHasPassport,PersonHasCard,PersonLeavedFamily,PersonLeavedFamilyDateSolar,PersonLeavedFamilyDate,PersonLeavingHouseCauseId,PersonLeavingHouseCauseDesc,PersonLeavingHouseDesc,PersonAddress,PersonAddressZiped,PersonLeavedEducation,PersonIsWorkedChild,PersonHasInjectionCard,PersonGetBlueCard,PersonCanTraveling,PersonTravelingDesc,PersonSupportedByOtherNGO,PersonSupportedByOtherNGODesc,PersonSupportedByIAS,SupportingOrganId,DepartmentId,PersonStatusId,BeliveId,ReligionId,GenderId,EducationTypeId,EducationFieldId,EducationStatusId,EducationDesc,NationalityId,EthnicId,MigrateDuration,BirthProvinceId,BirthCityId,PersonLivelihood,JobStatusId,JobId,JobDesc,JobSalary,ChildMarriageCauseId,PersonHasChildMarriage,PersonChildMarriageDesc,MaritalStatusId,HealthTypeId,DrugHistoryId,DrugWithdrawalHistoryId,DrugStatusId,BloodTypeId,InsuranceTypeId,InsuranceDesc,SportTarget,InsertUserId,InsertTime,UpdateUserId,UpdateTime")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BankId = new SelectList(db.Bank, "BankId", "BankName", person.BankId);
            ViewBag.BeliveId = new SelectList(db.Belive, "BeliveId", "BeliveName", person.BeliveId);
            ViewBag.BloodTypeId = new SelectList(db.BloodType, "BloodTypeId", "BloodTypeName", person.BloodTypeId);
            ViewBag.ChildMarriageCauseId = new SelectList(db.ChildMarriageCause, "ChildMarriageCauseId", "ChildMarriageCauseName", person.ChildMarriageCauseId);
            ViewBag.BirthCityId = new SelectList(db.City, "CityId", "CityName", person.BirthCityId);
            ViewBag.DepartmentId = new SelectList(db.Department, "DepartmentId", "DepartmentCode", person.DepartmentId);
            ViewBag.DrugHistoryId = new SelectList(db.DrugHistory, "DrugHistoryId", "DrugHistoryName", person.DrugHistoryId);
            ViewBag.DrugStatusId = new SelectList(db.DrugStatus, "DrugStatusId", "DrugStatusName", person.DrugStatusId);
            ViewBag.DrugWithdrawalHistoryId = new SelectList(db.DrugWithdrawalHistory, "DrugWithdrawalHistoryId", "DrugWithdrawalHistoryName", person.DrugWithdrawalHistoryId);
            ViewBag.EducationFieldId = new SelectList(db.EducationField, "EducationFieldId", "EducationFieldName", person.EducationFieldId);
            ViewBag.EducationStatusId = new SelectList(db.EducationStatus, "EducationStatusId", "EducationStatusName", person.EducationStatusId);
            ViewBag.EducationTypeId = new SelectList(db.EducationType, "EducationTypeId", "EducationTypeName", person.EducationTypeId);
            ViewBag.EthnicId = new SelectList(db.Ethnic, "EthnicId", "EthnicName", person.EthnicId);
            ViewBag.GenderId = new SelectList(db.Gender, "GenderId", "GenderName", person.GenderId);
            ViewBag.HealthTypeId = new SelectList(db.HealthType, "HealthTypeId", "HealthTypeName", person.HealthTypeId);
            ViewBag.InsuranceTypeId = new SelectList(db.InsuranceType, "InsuranceTypeId", "InsuranceTypeName", person.InsuranceTypeId);
            ViewBag.JobId = new SelectList(db.Job, "JobId", "JobName", person.JobId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "JobStatusId", "JobStatusName", person.JobStatusId);
            ViewBag.PersonLeavingHouseCauseId = new SelectList(db.LeavingHouseCause, "LeavingHouseCauseId", "LeavingHouseCauseName", person.PersonLeavingHouseCauseId);
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "MaritalStatusId", "MaritalStatusName", person.MaritalStatusId);
            ViewBag.NationalityId = new SelectList(db.Nationality, "NationalityId", "NationalityName", person.NationalityId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "PersonCode", person.PersonId);
            ViewBag.PersonId = new SelectList(db.Person, "PersonId", "PersonCode", person.PersonId);
            ViewBag.PersonStatusId = new SelectList(db.PersonStatus, "PersonStatusId", "PersonStatusName", person.PersonStatusId);
            ViewBag.BirthProvinceId = new SelectList(db.Province, "ProvinceId", "ProvinceName", person.BirthProvinceId);
            ViewBag.ReligionId = new SelectList(db.Religion, "ReligionId", "ReligionName", person.ReligionId);
            ViewBag.SupportingOrganId = new SelectList(db.SupportingOrgan, "SupportingOrganId", "SupportingOrganName", person.SupportingOrganId);
            return View(person);
        }

        // GET: Kuchegardan/ManagePerson/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Kuchegardan/ManagePerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Person.Find(id);
            db.Person.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
