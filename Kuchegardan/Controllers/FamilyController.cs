using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DAL;
using IASData.Enumerable;
using IASData.Utility;

namespace Kuchegardan.Controllers
{
    public class FamilyController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: Family
        public ActionResult FamilyIndex(int id)
        {
            var family = db.FamilyRepository.GetById(id);
            string phone1 = (family.FamilyPhone.Count > 0) ? family.FamilyPhone.OrderBy(q => q.FamilyPhoneId).ToList()[0].Phone : family.FamilyPhone1;
            string phone1Desc = (family.FamilyPhone.Count > 0) ? family.FamilyPhone.OrderBy(q => q.FamilyPhoneId).ToList()[0].FamilyPhoneDesc : family.FamilyPhone1Desc;
            string phone2 = (family.FamilyPhone.Count > 1) ? family.FamilyPhone.OrderBy(q => q.FamilyPhoneId).ToList()[1].Phone : family.FamilyPhone2;
            string phone2Desc = (family.FamilyPhone.Count > 1) ? family.FamilyPhone.OrderBy(q => q.FamilyPhoneId).ToList()[1].FamilyPhoneDesc : family.FamilyPhone2Desc;
            string cellPhone1 = (family.FamilyPhone.Count > 2) ? family.FamilyPhone.OrderBy(q => q.FamilyPhoneId).ToList()[2].Phone : family.FamilyCellPhone1;
            string cellPhone1Desc = (family.FamilyPhone.Count > 2) ? family.FamilyPhone.OrderBy(q => q.FamilyPhoneId).ToList()[2].FamilyPhoneDesc : family.FamilyCellPhone1Desc;
            string cellPhone2 = (family.FamilyPhone.Count > 3) ? family.FamilyPhone.OrderBy(q => q.FamilyPhoneId).ToList()[3].Phone : family.FamilyCellPhone2;
            string cellPhone2Desc = (family.FamilyPhone.Count > 3) ? family.FamilyPhone.OrderBy(q => q.FamilyPhoneId).ToList()[3].FamilyPhoneDesc : family.FamilyCellPhone2Desc;

            InitForm(family);
            DAL.FamilyViewModel familyViewModel = new FamilyViewModel
            {
                FamilyId = family.FamilyId,
                FamilyPhone1 = phone1,
                FamilyPhone1Desc = phone1Desc,
                FamilyCellPhone1 = cellPhone1,
                FamilyCellPhone1Desc = cellPhone1Desc,
                FamilyPhone2 = phone2,
                FamilyPhone2Desc = phone2Desc,
                FamilyCellPhone2 = cellPhone2,
                FamilyCellPhone2Desc = cellPhone2,
                ReferrerId = family.ReferrerId,
                FamilyAddress = family.FamilyAddress,
                AlleyId = family.AlleyId,
                //DepartmentId = family.DepartmentId,
                DrinkingWaterDesc = family.DrinkingWaterDesc,
                DrinkingWaterNearlyDistance = family.DrinkingWaterNearlyDistance,
                FamilyAddressZiped = family.FamilyAddressZiped,
                FamilyCode = family.FamilyCode,
                FamilyDesc = family.FamilyDesc,
                FamilyHasDomesticViolence = family.FamilyHasDomesticViolence,
                FamilyHasDomesticViolenceDesc = family.FamilyHasDomesticViolenceDesc,
                FamilyHealthAmount = family.FamilyHealthAmount,
                FamilyIsMigrated = family.FamilyIsMigrated,
                FamilyLatitude = family.FamilyLatitude,
                FamilyLongitude = family.FamilyLongitude,
                FamilyMemberCount = family.FamilyMemberCount,
                FamilyMonthlyIncome = family.FamilyMonthlyIncome,
                FamilyMonthlyExpense = family.FamilyMonthlyExpense,
                FamilyMortgageAmount = family.FamilyMortgageAmount,
                FamilyOtherCostAmount = family.FamilyOtherCostAmount,
                FamilyRentAmount = family.FamilyRentAmount,
                FamilyStatusId = family.FamilyStatusId,
                FamilyZiped = family.FamilyZiped,
                FatherAddress = family.FatherAddress,
                FatherAddressZiped = family.FatherAddressZiped,
                FatherDiedAge = family.FatherDiedAge,
                FatherDiedCauseDesc = family.FatherDiedCauseDesc,
                FatherDiedCauseId = family.FatherDiedCauseId,
                FatherDiedDate = family.FatherDiedDate,
                FatherDiedDateSolar = family.FatherDiedDateSolar,
                FatherIsDied = family.FatherIsDied,
                FatherIsLeavedFamily = family.FatherIsLeavedFamily,
                FatherLeavedFamilyDate = family.FatherLeavedFamilyDate,
                FatherLeavedFamilyDateSolar = family.FatherLeavedFamilyDateSolar,
                FatherLeavingHouseCauseDesc = family.FatherLeavingHouseCauseDesc,
                FatherLeavingHouseCauseId = family.FatherLeavingHouseCauseId,
                FuelTypeId = family.FuelTypeId,
                GuardianAddress = family.GuardianAddress,
                GuardianAddressZiped = family.GuardianAddressZiped,
                GuardianCellPhone = family.GuardianCellPhone,
                GuardianName = family.GuardianName,
                GuardianPhone = family.GuardianPhone,
                GuardianRelationTypeDesc = family.GuardianRelationTypeDesc,
                GuardianRelationTypeId = family.GuardianRelationTypeId,
                HasDrinkingWater = family.HasDrinkingWater,
                HasGas = family.HasGas,
                HasInternetAccess = family.HasInternetAccess,
                HasMobileSignal = family.HasMobileSignal,
                HasPower = family.HasPower,
                HouseArea = family.HouseArea,
                HouseBuildingMaterialId = family.HouseBuildingMaterialId,
                HouseId = family.HouseId,
                HouseStatusId = family.HouseStatusId,
                // InsertTime  = family.,
                //InsertUserId   = family.,
                MembersCount = family.FamilyMember.Count,
                MigrationCauseId = family.MigrationCauseId,
                MigrationDesc = family.MigrationDesc,
                MigrationYear = family.MigrationYear,
                MotherAddress = family.MotherAddress,
                MotherAddressZiped = family.MotherAddressZiped,
                MotherDiedAge = family.MotherDiedAge,
                MotherDiedCauseDesc = family.MotherDiedCauseDesc,
                MotherDiedCauseId = family.MotherDiedCauseId,
                MotherDiedDate = family.MotherDiedDate,
                MotherDiedDateSolar = family.MotherDiedDateSolar,
                MotherIsDied = family.MotherIsDied,
                MotherIsLeavedFamily = family.MotherIsLeavedFamily,
                MotherIsPregnant = family.MotherIsPregnant,
                MotherLeavedFamilyDate = family.MotherLeavedFamilyDate,
                MotherLeavedFamilyDateSolar = family.MotherLeavedFamilyDateSolar,
                MotherLeavingHouseCauseDesc = family.MotherLeavingHouseCauseDesc,
                MotherLeavingHouseCauseId = family.MotherLeavingHouseCauseId,
                ParentsHaveDifferentEthnic = family.ParentsHaveDifferentEthnic,
                ParentsHaveDifferentNationality = family.ParentsHaveDifferentNationality,
                ParentsMaritalStatusId = family.ParentsMaritalStatusId,
                PersonId = family.PersonId,
                //Phone = family.Phone,
                Plaque = family.Plaque,
                PowerSupplyDesc = family.PowerSupplyDesc,
                PowerSupplyId = family.PowerSupplyId,
                ResidenceTypeId = family.ResidenceTypeId,
                ResidentialContextId = family.ResidentialContextId,
                SegmentDesc = family.SegmentDesc,
                SegmentId = family.SegmentId,
                SewageSystem = family.SewageSystem,
                SewageSystemDesc = family.SewageSystemDesc,
                StreetId = family.StreetId,
                //UpdateTime    = family.,
                //  UpdateUserId  = family.,
                WasteCollectionSystem = family.WasteCollectionSystem,
                WasteCollectionSystemDesc = family.WasteCollectionSystemDesc,
                WaterSourceId = family.WaterSourceId,
                //Members = family.Members,
            };


            return PartialView(familyViewModel);
        }

        //public ActionResult ContactInfo(int familyId)
        //{
        //    var family = db.FamilyRepository.GetById(familyId);
        //    return PartialView(family);
        //}
        //public ActionResult HouseInfo(int familyId)
        //{
        //    var family = db.FamilyRepository.GetById(familyId);
        //    InitForm(family);
        //    return PartialView(family);
        //}
        //public ActionResult GuardianInfo(int familyId)
        //{
        //    var family = db.FamilyRepository.GetById(familyId);
        //    InitForm(family);
        //    return PartialView(family);
        //}
        //public ActionResult SocialWorkingInfo(int familyId)
        //{
        //    var family = db.FamilyRepository.GetById(familyId);
        //    InitForm(family);
        //    return PartialView(family);
        //}
        //public ActionResult FatherInfo(int familyId)
        //{
        //    var family = db.FamilyRepository.GetById(familyId);
        //    InitForm(family);
        //    return PartialView(family);
        //}
        //public ActionResult MotherInfo(int familyId)
        //{
        //    var family = db.FamilyRepository.GetById(familyId);
        //    InitForm(family);
        //    return PartialView(family);
        //}

        private void InitForm(Family family)
        {
            LookupModel emtyItem = new LookupModel { Value = "0", Name = "" };

            List<LookupModel> residenceTypes = new List<LookupModel>();
            residenceTypes.Add(emtyItem);
            residenceTypes.AddRange(db.ResidenceTypeRepository.Get().Select(q => new LookupModel { Value = q.ResidenceTypeId.ToString(), Name = q.ResidenceTypeName }).OrderBy(q => q.Name));
            ViewBag.ResidenceTypeId = new SelectList(residenceTypes, "Value", "Name", family.ResidenceTypeId);

            List<LookupModel> Alley = new List<LookupModel>();
            Alley.Add(emtyItem);
            Alley.AddRange(db.AlleyRepository.Get().Select(q => new LookupModel { Value = q.AlleyId.ToString(), Name = q.AlleyName }).OrderBy(q => q.Name));
            ViewBag.AlleyId = new SelectList(Alley, "Value", "Name", family.AlleyId);

            List<LookupModel> FamilyStatus = new List<LookupModel>();
            FamilyStatus.Add(emtyItem);
            FamilyStatus.AddRange(db.FamilyStatusRepository.Get().Select(q => new LookupModel { Value = q.FamilyStatusId.ToString(), Name = q.FamilyStatusName }).OrderBy(q => q.Name));
            ViewBag.FamilyStatusId = new SelectList(FamilyStatus, "Value", "Name", family.FamilyStatusId);

            List<LookupModel> FatherDiedCause = new List<LookupModel>();
            FatherDiedCause.Add(emtyItem);
            FatherDiedCause.AddRange(db.DiedCauseRepository.Get().Select(q => new LookupModel { Value = q.DiedCauseId.ToString(), Name = q.DiedCauseName }).OrderBy(q => q.Name));
            ViewBag.FatherDiedCauseId = new SelectList(FatherDiedCause, "Value", "Name", family.FatherDiedCauseId);
            ViewBag.MotherDiedCauseId = new SelectList(FatherDiedCause, "Value", "Name", family.MotherDiedCauseId);

            List<LookupModel> FatherLeavingHouseCause = new List<LookupModel>();
            FatherLeavingHouseCause.Add(emtyItem);
            FatherLeavingHouseCause.AddRange(db.LeavingHouseCauseRepository.Get().Select(q => new LookupModel { Value = q.LeavingHouseCauseId.ToString(), Name = q.LeavingHouseCauseName }).OrderBy(q => q.Name));
            ViewBag.FatherLeavingHouseCauseId = new SelectList(FatherLeavingHouseCause, "Value", "Name", family.FatherLeavingHouseCauseId);
            ViewBag.MotherLeavingHouseCauseId = new SelectList(FatherLeavingHouseCause, "Value", "Name", family.MotherLeavingHouseCauseId);


            List<LookupModel> FuelType = new List<LookupModel>();
            FuelType.Add(emtyItem);
            FuelType.AddRange(db.FuelTypeRepository.Get().Select(q => new LookupModel { Value = q.FuelTypeId.ToString(), Name = q.FuelTypeName }).OrderBy(q => q.Name));
            ViewBag.FuelTypeId = new SelectList(FuelType, "Value", "Name", family.FuelTypeId);

            List<LookupModel> GuardianRelationType = new List<LookupModel>();
            GuardianRelationType.Add(emtyItem);
            GuardianRelationType.AddRange(db.RelationTypeRepository.Get().Select(q => new LookupModel { Value = q.RelationTypeId.ToString(), Name = q.RelationTypeName }).OrderBy(q => q.Name));
            ViewBag.GuardianRelationTypeId = new SelectList(GuardianRelationType, "Value", "Name", family.GuardianRelationTypeId);

            List<LookupModel> HouseBuildingMaterial = new List<LookupModel>();
            HouseBuildingMaterial.Add(emtyItem);
            HouseBuildingMaterial.AddRange(db.HouseBuildingMaterialRepository.Get().Select(q => new LookupModel { Value = q.HouseBuildingMaterialId.ToString(), Name = q.HouseBuildingMaterialName }).OrderBy(q => q.Name));
            ViewBag.HouseBuildingMaterialId = new SelectList(HouseBuildingMaterial, "Value", "Name", family.HouseBuildingMaterialId);

            List<LookupModel> House = new List<LookupModel>();
            House.Add(emtyItem);
            House.AddRange(db.HouseRepository.Get().Select(q => new LookupModel { Value = q.HouseId.ToString(), Name = q.AddressComponent.AddressComponentName }).OrderBy(q => q.Name));
            ViewBag.HouseId = new SelectList(House, "Value", "Name", family.HouseId);

            List<LookupModel> HouseStatus = new List<LookupModel>();
            HouseStatus.Add(emtyItem);
            HouseStatus.AddRange(db.HouseStatusRepository.Get().Select(q => new LookupModel { Value = q.HouseStatusId.ToString(), Name = q.HouseStatusName }).OrderBy(q => q.Name));
            ViewBag.HouseStatusId = new SelectList(HouseStatus, "Value", "Name", family.HouseStatusId);

            List<LookupModel> MigrationCause = new List<LookupModel>();
            MigrationCause.Add(emtyItem);
            MigrationCause.AddRange(db.MigrationCauseRepository.Get().Select(q => new LookupModel { Value = q.MigrationCauseId.ToString(), Name = q.MigrationCauseName }).OrderBy(q => q.Name));
            ViewBag.MigrationCauseId = new SelectList(MigrationCause, "Value", "Name", family.MigrationCauseId);

            List<LookupModel> ParentsMaritalStatus = new List<LookupModel>();
            ParentsMaritalStatus.Add(emtyItem);
            ParentsMaritalStatus.AddRange(db.MaritalStatusRepository.Get().Select(q => new LookupModel { Value = q.MaritalStatusId.ToString(), Name = q.MaritalStatusName }).OrderBy(q => q.Name));
            ViewBag.ParentsMaritalStatusId = new SelectList(ParentsMaritalStatus, "Value", "Name", family.ParentsMaritalStatusId);

            List<LookupModel> PowerSupply = new List<LookupModel>();
            PowerSupply.Add(emtyItem);
            PowerSupply.AddRange(db.PowerSupplyRepository.Get().Select(q => new LookupModel { Value = q.PowerSupplyId.ToString(), Name = q.PowerSupplyName }).OrderBy(q => q.Name));
            ViewBag.PowerSupplyId = new SelectList(PowerSupply, "Value", "Name", family.PowerSupplyId);

            List<LookupModel> Referrer = new List<LookupModel>();
            Referrer.Add(emtyItem);
            Referrer.AddRange(db.ReferrerRepository.Get().Select(q => new LookupModel { Value = q.ReferrerId.ToString(), Name = q.ReferrerName }).OrderBy(q => q.Name));
            ViewBag.ReferrerId = new SelectList(Referrer.ToList(), "Value", "Name", family.ReferrerId);

            List<LookupModel> ResidentialContext = new List<LookupModel>();
            ResidentialContext.Add(emtyItem);
            ResidentialContext.AddRange(db.ResidentialContextRepository.Get().Select(q => new LookupModel { Value = q.ResidentialContextId.ToString(), Name = q.ResidentialContextName }).OrderBy(q => q.Name));
            ViewBag.ResidentialContextId = new SelectList(ResidentialContext, "Value", "Name", family.ResidentialContextId);

            List<LookupModel> Segment = new List<LookupModel>();
            Segment.Add(emtyItem);
            Segment.AddRange(db.SegmentRepository.Get().Select(q => new LookupModel { Value = q.SegmentId.ToString(), Name = q.SegmentName }).OrderBy(q => q.Name));
            ViewBag.SegmentId = new SelectList(Segment, "Value", "Name", family.SegmentId);

            List<LookupModel> Street = new List<LookupModel>();
            Street.Add(emtyItem);
            Street.AddRange(db.StreetRepository.Get().Select(q => new LookupModel { Value = q.StreetId.ToString(), Name = q.StreetName }).OrderBy(q => q.Name));
            ViewBag.StreetId = new SelectList(Street, "Value", "Name", family.StreetId);

            List<LookupModel> WaterSource = new List<LookupModel>();
            WaterSource.Add(emtyItem);
            WaterSource.AddRange(db.WaterSourceRepository.Get().Select(q => new LookupModel { Value = q.WaterSourceId.ToString(), Name = q.WaterSourceName }).OrderBy(q => q.Name));
            ViewBag.WaterSourceId = new SelectList(WaterSource, "Value", "Name", family.WaterSourceId);

        }

        [HttpPost]
        public ActionResult EditContactInfo(FamilyViewModel familyViewModel)
        {
            EventLogViewModel eventLogView = new EventLogViewModel();
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.Family family = db.FamilyRepository.GetById(familyViewModel.FamilyId);

            if (
                !string.IsNullOrEmpty(familyViewModel.FamilyPhone1) ||
                !string.IsNullOrEmpty(familyViewModel.FamilyPhone2) ||
                !string.IsNullOrEmpty(familyViewModel.FamilyCellPhone1) ||
                !string.IsNullOrEmpty(familyViewModel.FamilyCellPhone2))
            {
                if (!string.IsNullOrEmpty(familyViewModel.FamilyPhone1))
                {
                    DAL.FamilyPhone familyPhone = new FamilyPhone();
                    if (db.FamilyPhoneRepository.Get(q => q.FamilyId == familyViewModel.FamilyId && q.Phone == familyViewModel.FamilyPhone1).Any())
                    {
                        familyPhone = db.FamilyPhoneRepository.Get(q => q.FamilyId == familyViewModel.FamilyId && q.Phone == familyViewModel.FamilyPhone1).FirstOrDefault();
                        familyPhone.UpdateTime = DateTime.Now;
                        familyPhone.UpdateUserId = userInfo.UserId;
                        db.FamilyPhoneRepository.Update(familyPhone);

                    }
                    else
                    {

                        familyPhone.InsertTime = DateTime.Now;
                        familyPhone.InsertUserId = userInfo.UserId;
                        family.FamilyPhone.Add(familyPhone);
                        db.FamilyPhoneRepository.Insert(familyPhone);

                    }
                    if (!string.IsNullOrEmpty(familyViewModel.FamilyPhone1))
                        familyPhone.Phone = familyViewModel.FamilyPhone1;

                    if (!string.IsNullOrEmpty(familyViewModel.FamilyPhone1Desc))
                        familyPhone.FamilyPhoneDesc = familyViewModel.FamilyPhone1Desc;

                }

                if (!string.IsNullOrEmpty(familyViewModel.FamilyPhone2))
                {
                    DAL.FamilyPhone familyPhone = new FamilyPhone();
                    if (db.FamilyPhoneRepository.Get(q => q.FamilyId == familyViewModel.FamilyId && q.Phone == familyViewModel.FamilyPhone2).Any())
                    {
                        familyPhone = db.FamilyPhoneRepository.Get(q => q.FamilyId == familyViewModel.FamilyId && q.Phone == familyViewModel.FamilyPhone2).FirstOrDefault();
                        familyPhone.UpdateTime = DateTime.Now;
                        familyPhone.UpdateUserId = userInfo.UserId;
                        db.FamilyPhoneRepository.Update(familyPhone);

                    }
                    else
                    {

                        familyPhone.InsertTime = DateTime.Now;
                        familyPhone.InsertUserId = userInfo.UserId;
                        family.FamilyPhone.Add(familyPhone);
                        db.FamilyPhoneRepository.Insert(familyPhone);

                    }
                    if (!string.IsNullOrEmpty(familyViewModel.FamilyPhone2))
                        familyPhone.Phone = familyViewModel.FamilyPhone2;

                    if (!string.IsNullOrEmpty(familyViewModel.FamilyPhone2Desc))
                        familyPhone.FamilyPhoneDesc = familyViewModel.FamilyPhone2Desc;

                }

                if (!string.IsNullOrEmpty(familyViewModel.FamilyCellPhone1))
                    if (familyViewModel.FamilyCellPhone1.IsMobileNumber())
                    {
                        DAL.FamilyPhone familyPhone = new FamilyPhone();
                        if (db.FamilyPhoneRepository.Get(q => q.FamilyId == familyViewModel.FamilyId && q.Phone == familyViewModel.FamilyCellPhone1).Any())
                        {
                            familyPhone = db.FamilyPhoneRepository.Get(q => q.FamilyId == familyViewModel.FamilyId && q.Phone == familyViewModel.FamilyCellPhone1).FirstOrDefault();
                            familyPhone.UpdateTime = DateTime.Now;
                            familyPhone.UpdateUserId = userInfo.UserId;
                            db.FamilyPhoneRepository.Update(familyPhone);

                        }
                        else
                        {

                            familyPhone.InsertTime = DateTime.Now;
                            familyPhone.InsertUserId = userInfo.UserId;
                            family.FamilyPhone.Add(familyPhone);
                            db.FamilyPhoneRepository.Insert(familyPhone);

                        }
                        if (!string.IsNullOrEmpty(familyViewModel.FamilyCellPhone1))
                            familyPhone.Phone = familyViewModel.FamilyCellPhone1.ToZipedMobileNumber();

                        if (!string.IsNullOrEmpty(familyViewModel.FamilyCellPhone1Desc))
                            familyPhone.FamilyPhoneDesc = familyViewModel.FamilyCellPhone1Desc;

                    }
                    else
                    {
                        messageViewModel.Add(new SystemMessageViewModel
                        {
                            Title = "فیلدهای اجباری",
                            Desc = "موبایل1 نامعتبر است!",
                            Type = 1
                        });
                    }

                if (!string.IsNullOrEmpty(familyViewModel.FamilyCellPhone2))
                    if (familyViewModel.FamilyCellPhone2.IsMobileNumber())
                    {
                        DAL.FamilyPhone familyPhone = new FamilyPhone();
                        if (db.FamilyPhoneRepository.Get(q => q.FamilyId == familyViewModel.FamilyId && q.Phone == familyViewModel.FamilyCellPhone2).Any())
                        {
                            familyPhone = db.FamilyPhoneRepository.Get(q => q.FamilyId == familyViewModel.FamilyId && q.Phone == familyViewModel.FamilyCellPhone2).FirstOrDefault();
                            familyPhone.UpdateTime = DateTime.Now;
                            familyPhone.UpdateUserId = userInfo.UserId;
                            db.FamilyPhoneRepository.Update(familyPhone);

                        }
                        else
                        {

                            familyPhone.InsertTime = DateTime.Now;
                            familyPhone.InsertUserId = userInfo.UserId;
                            family.FamilyPhone.Add(familyPhone);
                            db.FamilyPhoneRepository.Insert(familyPhone);

                        }
                        if (!string.IsNullOrEmpty(familyViewModel.FamilyCellPhone2))
                            familyPhone.Phone = familyViewModel.FamilyCellPhone2.ToZipedMobileNumber();

                        if (!string.IsNullOrEmpty(familyViewModel.FamilyCellPhone2Desc))
                            familyPhone.FamilyPhoneDesc = familyViewModel.FamilyCellPhone2Desc;

                    }
                    else
                    {
                        messageViewModel.Add(new SystemMessageViewModel
                        {
                            Title = "فیلدهای اجباری",
                            Desc = "موبایل2 نامعتبر است!",
                            Type = 1
                        });
                    }


            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "حداقل یک تلفن ضروری است!",
                    Type = 1
                });
            }


            if (!string.IsNullOrEmpty(familyViewModel.FamilyAddress))
            {
                family.FamilyAddress = familyViewModel.FamilyAddress;
                family.FamilyAddressZiped = familyViewModel.FamilyAddress.ToZipedAddress();
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "نشانی ضروری است!",
                    Type = 1
                });
            }

            if (familyViewModel.ReferrerId != 0)
                family.ReferrerId = familyViewModel.ReferrerId;
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "ارجاع دهنده ضروری است!",
                    Type = 1
                });
            }
            if (messageViewModel.Any(q => q.Type == 1))
            {
                eventLogView = new EventLogViewModel
                {
                    Area = null,
                    Controller = "Family",
                    Action = "EditContactInfo",
                    Type = EventLogType.Error,
                    Input = new JavaScriptSerializer().Serialize(familyViewModel),
                    Output = new JavaScriptSerializer().Serialize(messageViewModel),
                    Description = "",
                    //UserId=User.Identity.
                };
                Common.HttpLogInsert(eventLogView);

                return PartialView("_SystemMessages", messageViewModel);
            }
            family.UpdateTime = DateTime.Now;
            family.UpdateUserId = userInfo.UserId;

            db.FamilyRepository.Update(family);
            db.Save();

            messageViewModel.Add(new SystemMessageViewModel
            {
                Title = "",
                Desc = "ثبت با موفقیت انجام شد!",
                Type = 2
            });
            var input = new JavaScriptSerializer().Serialize(familyViewModel);
            var output = new JavaScriptSerializer().Serialize(messageViewModel);
            eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "Family",
                Action = "EditContactInfo",
                Type = EventLogType.Update,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return PartialView("_SystemMessages", messageViewModel);
        }
        public ActionResult EditGuardianInfo(FamilyViewModel familyViewModel)
        {
            EventLogViewModel eventLogView = new EventLogViewModel();
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.Family family = db.FamilyRepository.GetById(familyViewModel.FamilyId);

            if (
                !string.IsNullOrEmpty(familyViewModel.GuardianName) ||
                !string.IsNullOrEmpty(familyViewModel.GuardianRelationTypeDesc) ||
                familyViewModel.GuardianRelationTypeId.HasValue)
            {
                if (!string.IsNullOrEmpty(familyViewModel.GuardianPhone))
                {
                    DAL.FamilyPhone familyPhone = new FamilyPhone();
                    if (db.FamilyPhoneRepository.Get(q => q.FamilyId == familyViewModel.FamilyId && q.Phone == familyViewModel.GuardianPhone).Any())
                    {
                        familyPhone = db.FamilyPhoneRepository.Get(q => q.FamilyId == familyViewModel.FamilyId && q.Phone == familyViewModel.GuardianPhone).FirstOrDefault();
                        familyPhone.UpdateTime = DateTime.Now;
                        familyPhone.UpdateUserId = userInfo.UserId;
                        db.FamilyPhoneRepository.Update(familyPhone);

                    }
                    else
                    {

                        familyPhone.InsertTime = DateTime.Now;
                        familyPhone.InsertUserId = userInfo.UserId;
                        family.FamilyPhone.Add(familyPhone);
                        db.FamilyPhoneRepository.Insert(familyPhone);

                    }
                    if (!string.IsNullOrEmpty(familyViewModel.GuardianPhone))
                        familyPhone.Phone = familyViewModel.GuardianPhone;

                    familyPhone.FamilyPhoneDesc = "شماره تماس قیم " + (!string.IsNullOrEmpty(familyViewModel.GuardianName) ? familyViewModel.GuardianName : "");

                }

               
                if (!string.IsNullOrEmpty(familyViewModel.GuardianCellPhone))
                    if (familyViewModel.GuardianCellPhone.IsMobileNumber())
                    {
                        DAL.FamilyPhone familyPhone = new FamilyPhone();
                        if (db.FamilyPhoneRepository.Get(q => q.FamilyId == familyViewModel.FamilyId && q.Phone == familyViewModel.GuardianCellPhone).Any())
                        {
                            familyPhone = db.FamilyPhoneRepository.Get(q => q.FamilyId == familyViewModel.FamilyId && q.Phone == familyViewModel.GuardianCellPhone).FirstOrDefault();
                            familyPhone.UpdateTime = DateTime.Now;
                            familyPhone.UpdateUserId = userInfo.UserId;
                            db.FamilyPhoneRepository.Update(familyPhone);

                        }
                        else
                        {

                            familyPhone.InsertTime = DateTime.Now;
                            familyPhone.InsertUserId = userInfo.UserId;
                            family.FamilyPhone.Add(familyPhone);
                            db.FamilyPhoneRepository.Insert(familyPhone);

                        }
                        if (!string.IsNullOrEmpty(familyViewModel.GuardianCellPhone))
                            familyPhone.Phone = familyViewModel.GuardianCellPhone.ToZipedMobileNumber();

                        familyPhone.FamilyPhoneDesc = "شماره تماس قیم " + (!string.IsNullOrEmpty(familyViewModel.GuardianName) ? familyViewModel.GuardianName : "");

                    }
                    else
                    {
                        messageViewModel.Add(new SystemMessageViewModel
                        {
                            Title = "فیلدهای اجباری",
                            Desc = "تلفن همراه قیم نامعتبر است!",
                            Type = 1
                        });
                    }

               

            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "نام یا نسبت قیم ضروری است!",
                    Type = 1
                });
            }


            if (!string.IsNullOrEmpty(familyViewModel.GuardianAddress))
            {
                family.GuardianAddress = familyViewModel.GuardianAddress;
                family.GuardianAddressZiped = familyViewModel.GuardianAddress.ToZipedAddress();
            }
            else
            {
                family.GuardianAddress = null;
                family.GuardianAddressZiped = null;
            }

           
            if (messageViewModel.Any(q => q.Type == 1))
            {
                eventLogView = new EventLogViewModel
                {
                    Area = null,
                    Controller = "Family",
                    Action = "EditGuardianInfo",
                    Type = EventLogType.Error,
                    Input = new JavaScriptSerializer().Serialize(familyViewModel),
                    Output = new JavaScriptSerializer().Serialize(messageViewModel),
                    Description = "",
                    //UserId=User.Identity.
                };
                Common.HttpLogInsert(eventLogView);

                return PartialView("_SystemMessages", messageViewModel);
            }
            family.UpdateTime = DateTime.Now;
            family.UpdateUserId = userInfo.UserId;

            db.FamilyRepository.Update(family);
            db.Save();

            messageViewModel.Add(new SystemMessageViewModel
            {
                Title = "",
                Desc = "ثبت با موفقیت انجام شد!",
                Type = 2
            });
            var input = new JavaScriptSerializer().Serialize(familyViewModel);
            var output = new JavaScriptSerializer().Serialize(messageViewModel);
            eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "Family",
                Action = "EditGuardianInfo",
                Type = EventLogType.Update,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return PartialView("_SystemMessages", messageViewModel);
        }

        [HttpPost]
        public ActionResult EditFatherInfo(FamilyViewModel familyViewModel)
        {
            EventLogViewModel eventLogView = new EventLogViewModel();
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.Family family = db.FamilyRepository.GetById(familyViewModel.FamilyId);

            family.FatherIsDied = familyViewModel.FatherIsDied;
            family.FatherIsLeavedFamily = familyViewModel.FatherIsLeavedFamily;
            if (familyViewModel.FatherIsDied)
            {

                if (!string.IsNullOrEmpty(familyViewModel.FatherDiedDateSolar))
                {
                    family.FatherDiedDateSolar = familyViewModel.FatherDiedDateSolar;
                    family.FatherDiedDate = familyViewModel.FatherDiedDateSolar.ToZipedTextOnly().ToDate();
                }

                if (familyViewModel.FatherDiedAge.HasValue)
                    if (familyViewModel.FatherDiedAge > 10 && familyViewModel.FatherDiedAge < 120)
                        family.FatherDiedAge = familyViewModel.FatherDiedAge;
                    else
                    {
                        messageViewModel.Add(new SystemMessageViewModel
                        {
                            Title = "فیلدهای اجباری",
                            Desc = "سن هنگام فوت نامعتبر است!",
                            Type = 1
                        });
                    }

                if (familyViewModel.FatherDiedCauseId.HasValue && familyViewModel.FatherDiedCauseId != 0)
                    family.FatherDiedCauseId = familyViewModel.FatherDiedCauseId;
                if (!string.IsNullOrEmpty(familyViewModel.FatherDiedCauseDesc))
                    family.FatherDiedCauseDesc = familyViewModel.FamilyPhone1Desc;

            }
            else
            {
                family.FatherDiedDateSolar = null;
                family.FatherDiedDate = null;
                family.FatherDiedAge = null;
                family.FatherDiedCauseId = null;
                family.FatherDiedCauseDesc = null;
            }

            if (familyViewModel.FatherIsLeavedFamily)
            {
                if (!string.IsNullOrEmpty(familyViewModel.FatherLeavedFamilyDateSolar))
                {
                    family.FatherLeavedFamilyDateSolar = familyViewModel.FatherLeavedFamilyDateSolar;
                    family.FatherLeavedFamilyDate = familyViewModel.FatherLeavedFamilyDateSolar.ToZipedTextOnly().ToDate();
                }

                if (familyViewModel.FatherLeavingHouseCauseId.HasValue && familyViewModel.FatherLeavingHouseCauseId != 0)
                    family.FatherLeavingHouseCauseId = familyViewModel.FatherLeavingHouseCauseId;
                if (!string.IsNullOrEmpty(familyViewModel.FatherLeavingHouseCauseDesc))
                    family.FatherLeavingHouseCauseDesc = familyViewModel.FatherLeavingHouseCauseDesc;
                if (!string.IsNullOrEmpty(familyViewModel.FatherAddress))
                {
                    family.FatherAddress = familyViewModel.FatherAddress;
                    family.FatherAddressZiped = familyViewModel.FatherAddress.ToZipedAddress();
                }

            }
            else
            {

                family.FatherLeavedFamilyDateSolar = null;
                family.FatherLeavedFamilyDate = null;
                family.FatherLeavingHouseCauseId = null;
                family.FatherLeavingHouseCauseDesc = null;
                family.FatherAddress = null;
                family.FatherAddressZiped = null;

            }



            if (messageViewModel.Any(q => q.Type == 1))
            {
                eventLogView = new EventLogViewModel
                {
                    Area = null,
                    Controller = "Family",
                    Action = "EditFatherInfo",
                    Type = EventLogType.Error,
                    Input = new JavaScriptSerializer().Serialize(familyViewModel),
                    Output = new JavaScriptSerializer().Serialize(messageViewModel),
                    Description = "",
                    //UserId=User.Identity.
                };
                Common.HttpLogInsert(eventLogView);
                return PartialView("_SystemMessages", messageViewModel);
            }
            family.UpdateTime = DateTime.Now;
            family.UpdateUserId = userInfo.UserId;

            db.FamilyRepository.Update(family);
            db.Save();

            messageViewModel.Add(new SystemMessageViewModel
            {
                Title = "",
                Desc = "ثبت با موفقیت انجام شد!",
                Type = 2
            });

            var input = new JavaScriptSerializer().Serialize(familyViewModel);
            var output = new JavaScriptSerializer().Serialize(messageViewModel);
            eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "Family",
                Action = "EditFatherInfo",
                Type = EventLogType.Update,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);


            return PartialView("_SystemMessages", messageViewModel);
        }

        [HttpPost]
        public ActionResult EditMotherInfo(FamilyViewModel familyViewModel)
        {
            EventLogViewModel eventLogView = new EventLogViewModel();

            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.Family family = db.FamilyRepository.GetById(familyViewModel.FamilyId);
            family.MotherIsDied = familyViewModel.MotherIsDied;
            family.MotherIsLeavedFamily = familyViewModel.MotherIsLeavedFamily;

            if (familyViewModel.MotherIsDied)
            {

                if (!string.IsNullOrEmpty(familyViewModel.MotherDiedDateSolar))
                {
                    family.MotherDiedDateSolar = familyViewModel.MotherDiedDateSolar;
                    family.MotherDiedDate = familyViewModel.MotherDiedDateSolar.ToZipedTextOnly().ToDate();
                }

                if (familyViewModel.MotherDiedAge.HasValue)
                    if (familyViewModel.MotherDiedAge > 10 && familyViewModel.MotherDiedAge < 120)
                        family.MotherDiedAge = familyViewModel.MotherDiedAge;
                    else
                    {
                        messageViewModel.Add(new SystemMessageViewModel
                        {
                            Title = "فیلدهای اجباری",
                            Desc = "سن هنگام فوت نامعتبر است!",
                            Type = 1
                        });
                    }

                if (familyViewModel.MotherDiedCauseId.HasValue && familyViewModel.MotherDiedCauseId != 0)
                    family.MotherDiedCauseId = familyViewModel.MotherDiedCauseId;
                if (!string.IsNullOrEmpty(familyViewModel.MotherDiedCauseDesc))
                    family.MotherDiedCauseDesc = familyViewModel.FamilyPhone1Desc;

            }
            else
            {
                family.MotherDiedDateSolar = null;
                family.MotherDiedDate = null;
                family.MotherDiedAge = null;
                family.MotherDiedCauseId = null;
                family.MotherDiedCauseDesc = null;
            }

            if (familyViewModel.MotherIsLeavedFamily)
            {
                if (!string.IsNullOrEmpty(familyViewModel.MotherLeavedFamilyDateSolar))
                {
                    family.MotherLeavedFamilyDateSolar = familyViewModel.MotherLeavedFamilyDateSolar;
                    family.MotherLeavedFamilyDate = familyViewModel.MotherLeavedFamilyDateSolar.ToZipedTextOnly().ToDate();
                }

                if (familyViewModel.MotherLeavingHouseCauseId.HasValue && familyViewModel.MotherLeavingHouseCauseId != 0)
                    family.MotherLeavingHouseCauseId = familyViewModel.MotherLeavingHouseCauseId;
                if (!string.IsNullOrEmpty(familyViewModel.MotherLeavingHouseCauseDesc))
                    family.MotherLeavingHouseCauseDesc = familyViewModel.MotherLeavingHouseCauseDesc;
                if (!string.IsNullOrEmpty(familyViewModel.MotherAddress))
                {
                    family.MotherAddress = familyViewModel.MotherAddress;
                    family.MotherAddressZiped = familyViewModel.MotherAddress.ToZipedAddress();
                }

            }
            else
            {

                family.MotherLeavedFamilyDateSolar = null;
                family.MotherLeavedFamilyDate = null;
                family.MotherLeavingHouseCauseId = null;
                family.MotherLeavingHouseCauseDesc = null;
                family.MotherAddress = null;
                family.MotherAddressZiped = null;

            }



            if (messageViewModel.Any(q => q.Type == 1))
            {
                eventLogView = new EventLogViewModel
                {
                    Area = null,
                    Controller = "Family",
                    Action = "EditMotherInfo",
                    Type = EventLogType.Error,
                    Input = new JavaScriptSerializer().Serialize(familyViewModel),
                    Output = new JavaScriptSerializer().Serialize(messageViewModel),
                    Description = "",
                    //UserId=User.Identity.
                };
                Common.HttpLogInsert(eventLogView);
                return PartialView("_SystemMessages", messageViewModel);

            }
            family.UpdateTime = DateTime.Now;
            family.UpdateUserId = userInfo.UserId;

            db.FamilyRepository.Update(family);
            db.Save();

            messageViewModel.Add(new SystemMessageViewModel
            {
                Title = "",
                Desc = "ثبت با موفقیت انجام شد!",
                Type = 2
            });

            var input = new JavaScriptSerializer().Serialize(familyViewModel);
            var output = new JavaScriptSerializer().Serialize(messageViewModel);
            eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "Family",
                Action = "EditMotherInfo",
                Type = EventLogType.Update,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return PartialView("_SystemMessages", messageViewModel);
        }

        [HttpPost]
        public ActionResult EditHouseInfo(FamilyViewModel familyViewModel)
        {
            EventLogViewModel eventLogView = new EventLogViewModel();
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.Family family = db.FamilyRepository.GetById(familyViewModel.FamilyId);

            if (
                familyViewModel.ResidenceTypeId != 0 ||
                familyViewModel.ResidentialContextId.HasValue ||
                familyViewModel.HouseStatusId != 0 ||
                !familyViewModel.HouseArea.HasValue)
            {


                if (familyViewModel.ResidenceTypeId != 0)
                    family.ResidenceTypeId = familyViewModel.ResidenceTypeId;
                else
                    family.ResidenceTypeId = null;
                if (familyViewModel.ResidentialContextId.HasValue)
                    family.ResidentialContextId = familyViewModel.ResidentialContextId;
                else
                    family.ResidentialContextId = null;
                if (familyViewModel.HouseStatusId != 0)
                    family.HouseStatusId = familyViewModel.HouseStatusId;
                else
                    family.HouseStatusId = null;
                if (familyViewModel.HouseStatusId.HasValue)
                    family.HouseArea = familyViewModel.HouseArea;
                else
                    family.HouseArea = null;



            }


            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "انتخاب حداقل یک آیتم ضروری است!",
                    Type = 1
                });
            }


            if (messageViewModel.Any(q => q.Type == 1))
            {

                eventLogView = new EventLogViewModel
                {
                    Area = null,
                    Controller = "Family",
                    Action = "EditHouseInfo",
                    Type = EventLogType.Error,
                    Input = new JavaScriptSerializer().Serialize(familyViewModel),
                    Output = new JavaScriptSerializer().Serialize(messageViewModel),
                    Description = "",
                    //UserId=User.Identity.
                };
                Common.HttpLogInsert(eventLogView);
                return PartialView("_SystemMessages", messageViewModel);

            }
            family.UpdateTime = DateTime.Now;
            family.UpdateUserId = userInfo.UserId;

            db.FamilyRepository.Update(family);
            db.Save();

            messageViewModel.Add(new SystemMessageViewModel
            {
                Title = "",
                Desc = "ثبت با موفقیت انجام شد!",
                Type = 2
            });

            var input = new JavaScriptSerializer().Serialize(familyViewModel);
            var output = new JavaScriptSerializer().Serialize(messageViewModel);
            eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "Family",
                Action = "EditHouseInfo",
                Type = EventLogType.Update,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return PartialView("_SystemMessages", messageViewModel);
        }

    }
}
