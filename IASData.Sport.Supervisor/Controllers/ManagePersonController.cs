using DAL;
using IASData.Enumerable;
using IASData.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
//using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IASData.Sport.Supervisor.Controllers
{
    [Authorize(Roles = "admin,SportDepartmentAdmin")]
    public class ManagePersonController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: ManagePerson
        public ActionResult PersonIndex(int? tabId = null, int pageId = 0)
        {
            return View();
        }


        public ActionResult CheckPerson(int? familyId = null)
        {
            InitForm();
            ViewBag.FamilyId = familyId;

            if (familyId.HasValue)
            {
                FamilyMember familyMember = db.FamilyRepository.GetById(familyId).FamilyMember.FirstOrDefault();
                PersonViewModel personViewModel = new PersonViewModel
                {
                    DepartmentId = familyMember.Person.DepartmentId,
                    NationalityId = familyMember.Person.NationalityId
                };
                return PartialView(personViewModel);
            }
            else
            {
                return PartialView();
            }
        }
        public ActionResult CreateSimplePerson(PersonViewModel personViewModel)
        {
            ViewBag.SelectedNationalityId = personViewModel.NationalityId;
            ViewBag.NationalityName = db.NationalityRepository.GetById(personViewModel.NationalityId).NationalityName;
            ViewBag.NationalCode = personViewModel.PersonNationalCode;
            ViewBag.FirstName = personViewModel.PersonFirstName;
            ViewBag.LastName = personViewModel.PersonLastName;
            ViewBag.FatherName = personViewModel.PersonFatherName;
            ViewBag.MotherName = personViewModel.PersonMotherName;
            ViewBag.SelectedDepartmentId = personViewModel.DepartmentId;
            ViewBag.DepartmentName = db.DepartmentRepository.GetById(personViewModel.DepartmentId).DepartmentName;
            ViewBag.SelectedRelationTypeId = personViewModel.RelationTypeId;
            ViewBag.RelationTypeName = db.RelationTypeRepository.GetById(personViewModel.RelationTypeId).RelationTypeName;
            if (db.RelationTypeRepository.GetById(personViewModel.RelationTypeId).GenderId > 0)
            {
                ViewBag.SelectedGenderId = db.RelationTypeRepository.GetById(personViewModel.RelationTypeId).GenderId;
                ViewBag.GenderName = db.RelationTypeRepository.GetById(personViewModel.RelationTypeId).Gender.GenderName;
            }
            if (personViewModel.RegionId > 0)
            {
                ViewBag.SelectedRegionId = personViewModel.RegionId;
                ViewBag.RegionName = db.RegionRepository.GetById(personViewModel.RegionId).RegionName;
            }
            if (personViewModel.SegmentId > 0)
            {
                ViewBag.SelectedSegmentId = personViewModel.SegmentId;
                ViewBag.SegmentName = db.SegmentRepository.GetById(personViewModel.SegmentId).SegmentName;
            }
            ViewBag.IsParent = personViewModel.IsParent;

            InitForm();
            ViewBag.FamilyId = personViewModel.FamilyId;


            return PartialView();
        }

        [HttpPost]
        public ActionResult CreatePerson(PersonViewModel personViewModel)
        {
            EventLogViewModel eventLogView = new EventLogViewModel();
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            DAL.Person person = new Person();
            DAL.Family family = new Family();
            DAL.FamilyMember familyMember = new FamilyMember();
            if (personViewModel.FamilyId.HasValue)
            {
                family = db.FamilyRepository.GetById(personViewModel.FamilyId);
            }

            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            family.FamilyCode = Common.GetTrackingNo("Family", null, personViewModel.DepartmentId);
            person.PersonCode = Common.GetTrackingNo("Person", family.FamilyCode, personViewModel.DepartmentId);

            if (personViewModel.DepartmentId > 0)
            {
                person.DepartmentId = personViewModel.DepartmentId;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "خانه ایرانی/نمایندگی ضروری است!",
                    Type = 1
                });
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonFilingDateSolar))
            {
                person.PersonFilingDateSolar = personViewModel.PersonFilingDateSolar;
                person.PersonFilingDate = personViewModel.PersonFilingDateSolar.ToZipedTextOnly().ToDate();
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "تاریخ شناسایی ضروری است!",
                    Type = 1
                });
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonFirstName))
            {
                person.PersonFirstName = personViewModel.PersonFirstName;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "نام فرد ضروری است!",
                    Type = 1
                });
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonLastName))
            {
                person.PersonLastName = personViewModel.PersonLastName;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "نام خانوادگی ضروری است!",
                    Type = 1
                });
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonFatherName))
            {
                person.PersonFatherName = personViewModel.PersonFatherName;
            }
            else
            {
                //اگر دختر یا پسر خانواده باشد نام پدر و مادر اجباری است 
                //if (personViewModel.RelationTypeId == 8 || personViewModel.RelationTypeId == 6)
                //    messageViewModel.Add(new SystemMessageViewModel
                //    {
                //        Title = "فیلدهای اجباری",
                //        Desc = "نام مادر ضروری است!",
                //        Type = 1
                //    });
                person.PersonFatherName = null;
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonMotherName))
            {
                person.PersonMotherName = personViewModel.PersonMotherName;
            }
            else
            {
                //messageViewModel.Add(new SystemMessageViewModel
                //{
                //    Title = "فیلدهای اجباری",
                //    Desc = "نام مادر ضروری است!",
                //    Type = 1
                //});
                person.PersonMotherName = null;
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonBirthDay))
            {
                if (personViewModel.PersonBirthDay.IsNumeric())
                {
                    if (Convert.ToInt32(personViewModel.PersonBirthDay) <= 31 && Convert.ToInt32(personViewModel.PersonBirthDay) > 0)
                    {
                        person.PersonBirthDay = Convert.ToInt32(personViewModel.PersonBirthDay).ToString("D2");
                    }
                    else
                    {
                        messageViewModel.Add(new SystemMessageViewModel
                        {
                            Title = "فیلدهای اجباری",
                            Desc = "روز تولد نامعتبر است!",
                            Type = 1
                        });
                    }
                }
                else
                {
                    messageViewModel.Add(new SystemMessageViewModel
                    {
                        Title = "فیلدهای اجباری",
                        Desc = "روز تولد نامعتبر است!",
                        Type = 1
                    });
                }
            }
            else
            {
                person.PersonBirthDay = null;
            }

            if (!string.IsNullOrEmpty(personViewModel.PersonBirthMonth))
            {
                if (personViewModel.PersonBirthMonth.IsNumeric())
                {
                    if (Convert.ToInt32(personViewModel.PersonBirthMonth) <= 12 && Convert.ToInt32(personViewModel.PersonBirthMonth) > 0)
                    {
                        person.PersonBirthMonth = Convert.ToInt32(personViewModel.PersonBirthMonth).ToString("D2");
                    }
                    else
                    {
                        messageViewModel.Add(new SystemMessageViewModel
                        {
                            Title = "فیلدهای اجباری",
                            Desc = "ماه تولد نامعتبر است!",
                            Type = 1
                        });
                    }
                }
                else
                {
                    messageViewModel.Add(new SystemMessageViewModel
                    {
                        Title = "فیلدهای اجباری",
                        Desc = "ماه تولد نامعتبر است!",
                        Type = 1
                    });
                }
            }
            else
            {
                person.PersonBirthMonth = null;
            }

            if (!string.IsNullOrEmpty(personViewModel.PersonBirthYear))
            {
                if (personViewModel.PersonBirthYear.IsNumeric())
                {
                    if (personViewModel.PersonBirthYear.Length == 4)
                    {
                        if (personViewModel.PersonBirthYear.CompareTo("1280") > 0 && personViewModel.PersonBirthYear.CompareTo("1400") < 0)
                        {
                            person.PersonBirthYear = personViewModel.PersonBirthYear;
                        }
                        else
                        {
                            messageViewModel.Add(new SystemMessageViewModel
                            {
                                Title = "فیلدهای اجباری",
                                Desc = "سال تولد نامعتبر است!",
                                Type = 1
                            });
                        }
                    }
                    else
                    {
                        messageViewModel.Add(new SystemMessageViewModel
                        {
                            Title = "فیلدهای اجباری",
                            Desc = "سال تولد باید چهاررقمی وارد شود؛ مثلا: 1385!",
                            Type = 1
                        });
                    }
                }
                else
                {
                    messageViewModel.Add(new SystemMessageViewModel
                    {
                        Title = "فیلدهای اجباری",
                        Desc = "سال تولد نامعتبر است!",
                        Type = 1
                    });
                }
            }
            else
            {
                person.PersonBirthYear = null;
            }

            if (!string.IsNullOrEmpty(person.PersonBirthYear) && !string.IsNullOrEmpty(person.PersonBirthMonth) && !string.IsNullOrEmpty(person.PersonBirthMonth))
            {
                string PersonBirthDate = person.PersonBirthYear + "/" + person.PersonBirthMonth + "/" + person.PersonBirthDay;
                person.PersonBirthDateSolar = PersonBirthDate;
                person.PersonBirthDate = PersonBirthDate.ToZipedTextOnly().ToDate();
            }


            if ((personViewModel.NationalityId > 0))
            {
                person.NationalityId = personViewModel.NationalityId;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "ملیت ضروری است!",
                    Type = 1
                });
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonNationalCode))
            {
                if (db.PersonRepository.Get(q => q.PersonNationalCode == personViewModel.PersonNationalCode && person.PersonNationalCode != personViewModel.PersonNationalCode).Any())
                {
                    messageViewModel.Add(new SystemMessageViewModel
                    {
                        Title = "فیلدهای اجباری",
                        Desc = "کد ملی وارد شده تکراری است!",
                        Type = 1
                    });
                }
                else if (!personViewModel.PersonNationalCode.IsNationalCode())
                {
                    messageViewModel.Add(new SystemMessageViewModel
                    {
                        Title = "فیلدهای اجباری",
                        Desc = "کد ملی وارد شده نامعتبر است!",
                        Type = 1
                    });
                }
                else
                {
                    person.PersonNationalCode = personViewModel.PersonNationalCode;
                }
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonIdentityNo))
            {
                person.PersonIdentityNo = personViewModel.PersonIdentityNo;
            }
            else
            {
                person.PersonIdentityNo = null;
            }

            if (!string.IsNullOrEmpty(personViewModel.PersonFilingName))
            {
                person.PersonFilingName = personViewModel.PersonFilingName;
            }
            else
            {
                person.PersonFilingName = null;
            }

            if (!string.IsNullOrEmpty(personViewModel.PersonCoveredDateSolar))
            {
                person.PersonCoveredDateSolar = personViewModel.PersonCoveredDateSolar;
                person.PersonCoveredDate = personViewModel.PersonCoveredDateSolar.ToZipedTextOnly().ToDate();
            }
            else
            {
                person.PersonCoveredDateSolar = null;
                person.PersonCoveredDate = null;
            }
            if (personViewModel.PersonStatusId > 0)
            {
                person.PersonStatusId = personViewModel.PersonStatusId;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "وضعیت ضروری است!",
                    Type = 1
                });
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonCoveredDesc))
            {
                person.PersonCoveredDesc = personViewModel.PersonCoveredDesc;
            }
            else
            {
                person.PersonCoveredDesc = null;
            }

            if ((personViewModel.GenderId != -1))
            {
                person.GenderId = personViewModel.GenderId;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "جنسیت ضروری است!",
                    Type = 1
                });
            }
            if ((personViewModel.MaritalStatusId > 0))
            {
                person.MaritalStatusId = personViewModel.MaritalStatusId;
            }
            else
            {
                person.MaritalStatusId = null;
            }

            if ((personViewModel.EthnicId > 0))
            {
                person.EthnicId = personViewModel.EthnicId;
            }
            else
            {
                person.EthnicId = null;
            }

            if ((personViewModel.BeliveId > 0))
            {
                person.BeliveId = personViewModel.BeliveId;
            }
            else
            {
                person.BeliveId = null;
            }

            if ((personViewModel.ReligionId > 0))
            {
                person.ReligionId = personViewModel.ReligionId;
            }
            else
            {
                person.ReligionId = null;
            }

            if ((personViewModel.MigrateDuration > 0))
            {
                person.MigrateDuration = personViewModel.MigrateDuration;
            }
            else
            {
                person.MigrateDuration = null;
            }
            //if (!string.IsNullOrEmpty(personViewModel.PersonFirstName))
            //    person.PersonFirstName = personViewModel.PersonFirstName;
            //if (!string.IsNullOrEmpty(personViewModel.PersonFirstName))
            //    person.PersonFirstName = personViewModel.PersonFirstName;
            //if (!string.IsNullOrEmpty(personViewModel.PersonFirstName))
            //    person.PersonFirstName = personViewModel.PersonFirstName;
            //if (!string.IsNullOrEmpty(personViewModel.PersonFirstName))
            //    person.PersonFirstName = personViewModel.PersonFirstName;
            person.InsertTime = DateTime.Now;
            person.InsertUserId = userInfo.UserId;

            if (personViewModel.RelationTypeId.HasValue && personViewModel.RelationTypeId > 0)
            {
                familyMember.RelationTypeId = personViewModel.RelationTypeId.Value;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "موقعیت در خانواده ضروری است!",
                    Type = 1
                });
            }
            if (personViewModel.IsParent)
            {
                try
                {
                    var members = person.FamilyMember.FirstOrDefault().Family.FamilyMember;
                    foreach (var item in members)
                    {
                        item.FamilyMemberIsParent = false;
                        db.FamilyMemberRepository.Update(item);
                    }
                }
                catch { }
            }
            familyMember.FamilyMemberIsParent = personViewModel.IsParent;
            familyMember.InsertTime = DateTime.Now;
            familyMember.InsertUserId = userInfo.UserId;

            if (messageViewModel.Any(q => q.Type == 1))
            {

                eventLogView = new EventLogViewModel
                {
                    Area = null,
                    Controller = "ManagePerson",
                    Action = "CreatePerson",
                    Type = EventLogType.Error,
                    Input = new JavaScriptSerializer().Serialize(personViewModel),
                    Output = new JavaScriptSerializer().Serialize(messageViewModel),
                    Description = "",
                    //UserId=User.Identity.
                };
                Common.HttpLogInsert(eventLogView);


                return PartialView("_SystemMessages", messageViewModel);

            }

            if (!personViewModel.FamilyId.HasValue)
            {

                if (personViewModel.RegionId > 0)
                {
                    family.RegionId = personViewModel.RegionId;
                }

                if (personViewModel.SegmentId > 0)
                {
                    family.SegmentId = personViewModel.SegmentId;
                }

                family.FamilyAddress = "";
                family.FamilyAddressZiped = "";
                family.FamilyZiped = "";



                family.InsertTime = DateTime.Now;
                family.InsertUserId = userInfo.UserId;

                db.FamilyRepository.Insert(family);

            }
            else
            {
                family.UpdateTime = DateTime.Now;
                family.UpdateUserId = userInfo.UserId;

                db.FamilyRepository.Update(family);

            }
            family.FamilyMember.Add(familyMember);
            person.FamilyMember.Add(familyMember);
            person.Family.Add(family);
            db.PersonRepository.Insert(person);
            db.FamilyMemberRepository.Insert(familyMember);


            db.Save();
            messageViewModel.Add(new SystemMessageViewModel
            {
                Title = "",
                Desc = "ثبت با موفقیت انجام شد!",
                Type = 2
            });
            ViewBag.PersonId = person.PersonId;
            ViewBag.FamilyId = family.FamilyId;
            var input = new JavaScriptSerializer().Serialize(personViewModel);
            var output = new JavaScriptSerializer().Serialize(messageViewModel);
            eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "ManagePerson",
                Action = "CreatePerson",
                Type = EventLogType.Insert,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return PartialView("_SystemMessages", messageViewModel);

            //return GetPersons(family.FamilyId);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult GetPersons(PersonViewModel personViewModel)
        {
            ViewBag.ShowCreateMember = false;
            ViewBag.ShowContinue = true;
            DAL.Attachment attachment = db.AttachmentRepository.Get(q => q.AttachmentTypeId == (int)Enumerable.AttachmentTypes.Person && q.AttachmentOwnerId == personViewModel.PersonId).FirstOrDefault();

            EventLogViewModel eventLogView = new EventLogViewModel();
            ViewBag.NationalityId = personViewModel.NationalityId;
            ViewBag.NationalCode = personViewModel.PersonNationalCode;
            ViewBag.FirstName = personViewModel.PersonFirstName;
            ViewBag.LastName = personViewModel.PersonLastName;
            ViewBag.FatherName = personViewModel.PersonFatherName;
            ViewBag.MotherName = personViewModel.PersonMotherName;
            ViewBag.FamilyId = personViewModel.FamilyId;
            ViewBag.RegionId = personViewModel.RegionId;
            ViewBag.SegmentId = personViewModel.SegmentId;
            ViewBag.RelationTypeId = personViewModel.RelationTypeId;
            ViewBag.DepartmentId = personViewModel.DepartmentId;
            ViewBag.IsParent = personViewModel.IsParent;
            var user = db.UserInfoRepository.Get(u => u.UserName == User.Identity.Name).SingleOrDefault();
            List<int> departments = user.UserDepartment.Where(q => q.Department.DepartmentIsActive).Select(q => q.DepartmentId).ToList();
            ViewBag.AccessibleDepartments = departments;
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();


            if (personViewModel.NationalityId > 0 && personViewModel.RelationTypeId > 0 && personViewModel.DepartmentId > 0)
            {
                if (personViewModel.FamilyId.HasValue && personViewModel.FamilyId > 0)
                {
                    if (db.FamilyMemberRepository.Get(q => q.FamilyId == personViewModel.FamilyId && q.RelationTypeId == personViewModel.RelationTypeId && !q.RelationType.RelationTypeCanDuplicate).Any())
                    {
                        messageViewModel.Add(new SystemMessageViewModel { Title = "خطا", Desc = "موقعیت انتخابی فرد در خانواده تکراری است!" });
                    }
                }
                List<Person> person = db.PersonRepository.Get(q => q.NationalityId == personViewModel.NationalityId).ToList();
                List<PersonViewModel> personViewModels = new List<PersonViewModel>();
                if (
                    !string.IsNullOrEmpty(personViewModel.PersonNationalCode) ||
                    (!string.IsNullOrEmpty(personViewModel.PersonFirstName) && !string.IsNullOrEmpty(personViewModel.PersonLastName) /* !string.IsNullOrEmpty(personViewModel.PersonFatherName) && !string.IsNullOrEmpty(personViewModel.PersonMotherName)*/))
                {
                    if (!string.IsNullOrEmpty(personViewModel.PersonNationalCode))
                    {
                        if (personViewModel.PersonNationalCode.IsNationalCode())
                        {
                            person = person.Where(q => q.PersonNationalCode == personViewModel.PersonNationalCode).ToList();
                        }
                        else
                        {
                            messageViewModel.Add(new SystemMessageViewModel { Title = "خطا", Desc = "کد ملی وارد شده نامعتبر است!" });

                            eventLogView = new EventLogViewModel
                            {
                                Area = null,
                                Controller = "ManagePerson",
                                Action = "GetPersons",
                                Type = EventLogType.Error,
                                Input = new JavaScriptSerializer().Serialize(personViewModel),
                                Output = new JavaScriptSerializer().Serialize(messageViewModel),
                                Description = "",
                                //UserId=User.Identity.
                            };
                            Common.HttpLogInsert(eventLogView);

                            return PartialView("_SystemMessages", messageViewModel);
                        }
                    }
                    if (!string.IsNullOrEmpty(personViewModel.PersonFirstName))
                    {
                        try
                        {
                            person = person.Where(q => (q.PersonFirstName != null) ? q.PersonFirstName.Contains(personViewModel.PersonFirstName) : false).ToList();

                        }
                        catch (Exception)
                        {

                        }
                    }

                    if (!string.IsNullOrEmpty(personViewModel.PersonLastName))
                    {
                        try
                        {
                            person = person.Where(q => (q.PersonLastName != null) ? q.PersonLastName.ToZipedTextOnly().Contains(personViewModel.PersonLastName.ToZipedTextOnly()) : false).ToList();
                        }
                        catch (Exception)
                        {

                        }
                    }

                    if (!string.IsNullOrEmpty(personViewModel.PersonFatherName))
                    {
                        try
                        {
                            person = person.Where(q => ((q.PersonFatherName != null) ? q.PersonFatherName.ToZipedTextOnly().Contains(personViewModel.PersonFatherName.ToZipedTextOnly()) : false) || q.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 2 && ((p.Person.PersonFirstName != null) ? p.Person.PersonFirstName.ToZipedTextOnly().Contains(personViewModel.PersonFatherName.ToZipedTextOnly()) : false))).ToList();
                        }
                        catch (Exception)
                        {

                        }
                    }

                    if (!string.IsNullOrEmpty(personViewModel.PersonMotherName))
                    {
                        try
                        {
                            person = person.Where(q => (
                            (q.PersonFatherName != null) ? q.PersonFatherName.ToZipedTextOnly().Contains(personViewModel.PersonFatherName.ToZipedTextOnly()) : false) ||
                            q.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 1 && ((p.Person.PersonFirstName != null) ? p.Person.PersonFirstName.ToZipedTextOnly().Contains(personViewModel.PersonMotherName.ToZipedTextOnly()) : false))).ToList();

                        }
                        catch (Exception)
                        {

                        }
                    }

                    if (person == null)
                    {
                        return HttpNotFound();
                    }

                    if (person.Count == 1 && !string.IsNullOrEmpty(personViewModel.PersonNationalCode))
                    {
                        ViewBag.ShowContinue = false;
                    }

                    foreach (var item in person)
                    {
                        personViewModels.Add(new PersonViewModel
                        {
                            PersonId = item.PersonId,
                            FamilyId = item.FamilyMember.FirstOrDefault().FamilyId,
                            PersonCode = item.PersonCode,
                            PersonCoveredDateSolar = item.PersonCoveredDateSolar,
                            DepartmentId = item.DepartmentId,
                            PersonFirstName = item.PersonFirstName,
                            PersonLastName = item.PersonLastName,
                            PersonFatherName = (
                                                    !string.IsNullOrEmpty(item.PersonFatherName) ?
                                                    item.PersonFatherName :
                                                    (
                                                        item.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 2) ?
                                                        item.FamilyMember.FirstOrDefault().Family.FamilyMember.FirstOrDefault(p => p.RelationTypeId == 2).Person.PersonFirstName :
                                                        "ثبت نشده"
                                                    )
                                                ),
                            PersonMotherName = (
                                                    !string.IsNullOrEmpty(item.PersonMotherName) ?
                                                    item.PersonMotherName :
                                                    (
                                                        item.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 1) ?
                                                        item.FamilyMember.FirstOrDefault().Family.FamilyMember.FirstOrDefault(p => p.RelationTypeId == 1).Person.PersonFirstName :
                                                        "ثبت نشده"
                                                    )
                                                ),
                            NationalityId = item.NationalityId,
                            PersonProfilePic = Constants.AttachmentServiceUrl + "?AttachmentId=" + ((attachment != null) ? attachment.AttachmentId.ToString() : "-1") + "&Thumbnail=150",
                        });
                    }

                    var input = new JavaScriptSerializer().Serialize(personViewModel);
                    var output = new JavaScriptSerializer().Serialize(personViewModels);
                    eventLogView = new EventLogViewModel
                    {
                        Area = null,
                        Controller = "ManagePerson",
                        Action = "GetPersons",
                        Type = EventLogType.Search,
                        Input = input,
                        Output = output,
                        Description = "",
                        //UserId=User.Identity.
                    };
                    Common.HttpLogInsert(eventLogView);

                    return PartialView("PersonList", personViewModels);
                }
                else
                {
                    if (personViewModel.NationalityId == 1)
                    {
                        messageViewModel.Add(new SystemMessageViewModel { Title = "خطا", Desc = "برای ثبت فرد ایرانی حتما بایستی کد ملی و یا نام و نام خانوادگی فرد وارد شود!" });
                    }
                    else
                    {
                        messageViewModel.Add(new SystemMessageViewModel { Title = "خطا", Desc = "لطفا برای شروع نام و نام خانوادگی فرد را وارد کنید!" });
                    }

                    if (personViewModel.DepartmentId == 0)
                    {
                        messageViewModel.Add(new SystemMessageViewModel { Title = "خطا", Desc = "انتخاب خانه ایرانی/نمایندگی ضروری است!" });
                    }

                    if (personViewModel.RelationTypeId == 0)
                    {
                        messageViewModel.Add(new SystemMessageViewModel { Title = "خطا", Desc = "انتخاب موقعیت در خانواده ضروری است!" });
                    }

                    if (personViewModel.NationalityId == 0)
                    {
                        messageViewModel.Add(new SystemMessageViewModel { Title = "خطا", Desc = "انتخاب ملیت ضروری است!" });
                    }

                    var input = new JavaScriptSerializer().Serialize(personViewModel);
                    var output = new JavaScriptSerializer().Serialize(messageViewModel);
                    eventLogView = new EventLogViewModel
                    {
                        Area = null,
                        Controller = "ManagePerson",
                        Action = "GetPersons",
                        Type = EventLogType.Error,
                        Input = input,
                        Output = output,
                        Description = "",
                        //UserId=User.Identity.
                    };
                    Common.HttpLogInsert(eventLogView);

                    return PartialView("_SystemMessages", messageViewModel);
                }
            }
            else
            {
                //if (personViewModel.NationalityId == 1)
                //    messageViewModel.Add(new SystemMessageViewModel { Title = "خطا", Desc = "برای ثبت فرد ایرانی حتما بایستی کد ملی و یا نام و نام خانوادگی فرد وارد شود!" });
                //else
                //    messageViewModel.Add(new SystemMessageViewModel { Title = "خطا", Desc = "لطفا برای شروع نام و نام خانوادگی فرد را وارد کنید!" });

                if (personViewModel.DepartmentId == 0)
                {
                    messageViewModel.Add(new SystemMessageViewModel { Title = "خطا", Desc = "انتخاب خانه ایرانی/نمایندگی ضروری است!" });
                }

                if (personViewModel.RelationTypeId == 0)
                {
                    messageViewModel.Add(new SystemMessageViewModel { Title = "خطا", Desc = "انتخاب موقعیت در خانواده ضروری است!" });
                }

                if (personViewModel.NationalityId == 0)
                {
                    messageViewModel.Add(new SystemMessageViewModel { Title = "خطا", Desc = "انتخاب ملیت ضروری است!" });
                }

                var input = new JavaScriptSerializer().Serialize(personViewModel);
                var output = new JavaScriptSerializer().Serialize(messageViewModel);
                eventLogView = new EventLogViewModel
                {
                    Area = null,
                    Controller = "ManagePerson",
                    Action = "GetPersons",
                    Type = EventLogType.Error,
                    Input = input,
                    Output = output,
                    Description = "",
                    //UserId=User.Identity.
                };
                Common.HttpLogInsert(eventLogView);

                return PartialView("_SystemMessages", messageViewModel);
            }

        }
        public ActionResult GetPersonsByFamilyId(int familyId)
        {
            ViewBag.ShowCreateMember = true;
            ViewBag.ShowContinue = false;

            SystemMessageViewModel messageViewModel = new SystemMessageViewModel();
            List<Person> person = db.FamilyMemberRepository.Get(q => q.FamilyId == familyId).Select(q => q.Person).ToList();
            List<PersonViewModel> personViewModels = new List<PersonViewModel>();
            var user = db.UserInfoRepository.Get(u => u.UserName == User.Identity.Name).SingleOrDefault();
            List<int> departments = user.UserDepartment.Where(q => q.Department.DepartmentIsActive).Select(q => q.DepartmentId).ToList();
            ViewBag.AccessibleDepartments = departments;


            foreach (var item in person)
            {
                DAL.Attachment attachment = db.AttachmentRepository.Get(q => q.AttachmentTypeId == (int)Enumerable.AttachmentTypes.Person && q.AttachmentOwnerId == item.PersonId).FirstOrDefault();
                personViewModels.Add(new PersonViewModel
                {
                    PersonId = item.PersonId,
                    FamilyId = familyId,
                    IsParent = item.FamilyMember.FirstOrDefault().FamilyMemberIsParent,
                    RelationTypeId = item.FamilyMember.FirstOrDefault().RelationTypeId,
                    RelationTypeName = item.FamilyMember.FirstOrDefault().RelationType.RelationTypeName,
                    FamilyMemberExpireTimeSolar = item.FamilyMember.FirstOrDefault().FamilyMemberExpireTimeSolar,
                    ExpireCauseName = (item.FamilyMember.FirstOrDefault().ExpireCauseId.HasValue) ? item.FamilyMember.FirstOrDefault().ExpireCause.ExpireCauseName : null,
                    PersonCode = item.PersonCode,
                    PersonCoveredDateSolar = item.PersonCoveredDateSolar,
                    DepartmentId = item.DepartmentId,
                    PersonFirstName = item.PersonFirstName,
                    PersonLastName = item.PersonLastName,
                    PersonFatherName = (
                                            !string.IsNullOrEmpty(item.PersonFatherName) ?
                                            item.PersonFatherName :
                                            (
                                                item.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 2) ?
                                                item.FamilyMember.FirstOrDefault().Family.FamilyMember.FirstOrDefault(p => p.RelationTypeId == 2).Person.PersonFirstName :
                                                "ثبت نشده"
                                            )
                                        ),
                    PersonMotherName = (
                                            !string.IsNullOrEmpty(item.PersonMotherName) ?
                                            item.PersonMotherName :
                                            (
                                                item.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 1) ?
                                                item.FamilyMember.FirstOrDefault().Family.FamilyMember.FirstOrDefault(p => p.RelationTypeId == 1).Person.PersonFirstName :
                                                "ثبت نشده"
                                            )
                                        ),
                    PersonProfilePic = Constants.AttachmentServiceUrl + "?AttachmentId=" + ((attachment != null) ? attachment.AttachmentId.ToString() : "-1") + "&Thumbnail=150",
                });
            }

            ViewBag.FamilyId = familyId;

            //var input = "familyId=" + familyId;
            //var output = new JavaScriptSerializer().Serialize(messageViewModel);
            //EventLogViewModel eventLogView = new EventLogViewModel
            //{
            //    Area = null,
            //    Controller = "ManagePerson",
            //    Action = "GetPersonsByFamilyId",
            //    Type = EventLogType.Search,
            //    Input = input,
            //    Output = output,
            //    Description = "",
            //    //UserId=User.Identity.
            //};
            //Common.HttpLogInsert(eventLogView);

            return PartialView("PersonList", personViewModels);

        }

        public ActionResult SearchPerson(DAL.FamilySearchViewModel model, int? tabId = null, int pageId = 0)
        {
            int pageSize = 50;
            int skip = pageId * pageSize;
            List<PersonViewModel> personList = new List<PersonViewModel>();
            try
            {
                ViewBag.SearchModel = model;

                if (User.Identity.IsAuthenticated)
                {
                    var user = db.UserInfoRepository.Get(u => u.UserName == User.Identity.Name).SingleOrDefault();
                    List<int> accesibleDepartments = user.UserDepartment.Where(q => q.Department.DepartmentIsActive && q.Department.DepartmentTypeId != (int)Enumerable.DepartmentType.DiscoveryTeam).Select(q => q.DepartmentId).ToList();

                    IQueryable<DAL.Person> people = db.PersonRepository.Get(q => accesibleDepartments.Contains(q.DepartmentId));

                    if (model.DepartmentId > 0)
                    {
                        people = people.Where(q => q.DepartmentId == model.DepartmentId);
                    }

                    if (model.NationalityId > 0)
                    {
                        people = people.Where(q => q.NationalityId == model.NationalityId);
                    }

                    if (model.EthnicId > 0)
                    {
                        people = people.Where(q => q.EthnicId == model.EthnicId);
                    }

                    if (model.PersonStatusId > 0)
                    {
                        people = people.Where(q => q.PersonStatusId == model.PersonStatusId);
                    }

                    if (model.RelationTypeId > 0)
                    {
                        people = people.Where(q => q.FamilyMember.Any(p => p.RelationTypeId == model.RelationTypeId));
                    }

                    if (model.GenderId > 0)
                    {
                        people = people.Where(q => q.GenderId == model.GenderId);
                    }

                    if (model.MaritalStatusId > 0)
                    {
                        people = people.Where(q => q.MaritalStatusId == model.MaritalStatusId);
                    }

                    if (!string.IsNullOrEmpty(model.PersonFirstName))
                    {
                        people = people.Where(q => q.PersonFirstName.Contains(model.PersonFirstName));
                    }

                    if (!string.IsNullOrEmpty(model.PersonLastName))
                    {
                        people = people.Where(q => q.PersonLastName.Contains(model.PersonLastName));
                    }

                    if (!string.IsNullOrEmpty(model.PersonFatherName))
                    {
                        people = people.Where(q => q.PersonFatherName.Contains(model.PersonFatherName));
                    }

                    if (!string.IsNullOrEmpty(model.PersonMotherName))
                    {
                        people = people.Where(q => q.PersonMotherName.Contains(model.PersonMotherName));
                    }

                    if (!string.IsNullOrEmpty(model.PersonNationalCode))
                    {
                        people = people.Where(q => q.PersonNationalCode.Contains(model.PersonNationalCode));
                    }

                    if (!string.IsNullOrEmpty(model.PersonBirthYearFrom))
                    {
                        people = people.Where(q => q.PersonBirthYear.CompareTo(model.PersonBirthYearFrom) >= 0);
                    }

                    if (!string.IsNullOrEmpty(model.PersonBirthYearTo))
                    {
                        people = people.Where(q => q.PersonBirthYear.CompareTo(model.PersonBirthYearTo) <= 0);
                    }

                    List<DAL.DepartmentViewModel> departments = new List<DepartmentViewModel>();
                    departments = people.Select(q => new DepartmentViewModel
                    {
                        DepartmentId = q.FamilyMember.FirstOrDefault().Person.DepartmentId,
                        DepartmentName = q.FamilyMember.FirstOrDefault().Person.Department.DepartmentName,
                        DepartmentCode = q.FamilyMember.FirstOrDefault().Person.Department.DepartmentCode,
                        PersonsCount = q.FamilyMember.FirstOrDefault().Person.Department.Person.Count(),

                    }).Distinct().ToList();
                    ViewBag.Departments = departments;
                    if (!tabId.HasValue)
                    {
                        tabId = departments.OrderBy(q => q.DepartmentCode).First().DepartmentId;
                    }

                    people = people.Where(q => q.FamilyMember.FirstOrDefault().Person.DepartmentId == tabId);


                    int pageCount = people.Count() / pageSize;
                    if (people.Count() % pageSize > 0)
                    {
                        pageCount++;
                    }

                    ViewBag.PageCount = pageCount;
                    foreach (var item in people.OrderBy(q => q.PersonCode).Skip(skip).Take(pageSize))
                    {
                        try
                        {
                            DAL.Attachment attachment = db.AttachmentRepository.Get(q => q.AttachmentTypeId == (int)Enumerable.AttachmentTypes.Person && q.AttachmentOwnerId == item.PersonId).FirstOrDefault();
                            personList.Add(new PersonViewModel
                            {
                                FamilyId = item.FamilyMember.FirstOrDefault().FamilyId,
                                DepartmentId = item.FamilyMember.FirstOrDefault().Person.DepartmentId,
                                PersonId = item.PersonId,
                                IsParent = item.FamilyMember.FirstOrDefault().FamilyMemberIsParent,
                                RelationTypeId = item.FamilyMember.FirstOrDefault().RelationTypeId,
                                RelationTypeName = item.FamilyMember.FirstOrDefault().RelationType.RelationTypeName,
                                FamilyMemberExpireTimeSolar = item.FamilyMember.FirstOrDefault().FamilyMemberExpireTimeSolar,
                                ExpireCauseName = (item.FamilyMember.FirstOrDefault().ExpireCauseId.HasValue) ? item.FamilyMember.FirstOrDefault().ExpireCause.ExpireCauseName : null,
                                PersonCode = item.PersonCode,
                                PersonCoveredDateSolar = item.PersonCoveredDateSolar,
                                PersonFirstName = item.PersonFirstName,
                                PersonLastName = item.PersonLastName,
                                PersonFatherName = (
                                            !string.IsNullOrEmpty(item.PersonFatherName) ?
                                            item.PersonFatherName :
                                            (
                                                item.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 2) ?
                                                item.FamilyMember.FirstOrDefault().Family.FamilyMember.FirstOrDefault(p => p.RelationTypeId == 2).Person.PersonFirstName :
                                                "ثبت نشده"
                                            )
                                        ),
                                PersonMotherName = (
                                            !string.IsNullOrEmpty(item.PersonMotherName) ?
                                            item.PersonMotherName :
                                            (
                                                item.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 1) ?
                                                item.FamilyMember.FirstOrDefault().Family.FamilyMember.FirstOrDefault(p => p.RelationTypeId == 1).Person.PersonFirstName :
                                                "ثبت نشده"
                                            )
                                        ),
                                PersonIdentityDocument = item.PersonIdentityDocument,
                                PersonProfilePic = Constants.AttachmentServiceUrl + "?AttachmentId=" + ((attachment != null) ? attachment.AttachmentId.ToString() : "-1") + "&Thumbnail=150",

                            });


                        }
                        catch (Exception) { }
                    }


                    ViewBag.TabID = tabId;
                    ViewBag.PageID = pageId;
                    InitForm();

                    var input = new JavaScriptSerializer().Serialize(model);
                    var output = new JavaScriptSerializer().Serialize(personList);
                    EventLogViewModel eventLogView = new EventLogViewModel
                    {
                        Area = null,
                        Controller = "ManagePerson",
                        Action = "Search",
                        Type = EventLogType.Search,
                        Input = input,
                        Output = output,
                        Description = "",
                        //UserId=User.Identity.
                    };
                    Common.HttpLogInsert(eventLogView);
                }
            }
            catch (Exception)
            {
            }
            return PartialView("PersonIX", personList);
        }
        public ActionResult SearchForm(DAL.FamilySearchViewModel model)
        {
            InitForm();
            return PartialView();
        }

        public ActionResult UploadProfilePic(int id)
        {
            DAL.Person person = db.PersonRepository.GetById(id);
            DAL.Attachment attachment = db.AttachmentRepository.Get(q => q.AttachmentTypeId == (int)Enumerable.AttachmentTypes.Person && q.AttachmentOwnerId == person.PersonId).FirstOrDefault();
            PersonViewModel personViewModel = new PersonViewModel
            {
                PersonId = person.PersonId,
                PersonFirstName = person.PersonFirstName,
                PersonLastName = person.PersonLastName,
                PersonCode = person.PersonCode,
                PersonFatherName = (
                                                !string.IsNullOrEmpty(person.PersonFatherName) ?
                                                person.PersonFatherName :
                                                (
                                                    person.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 2) ?
                                                    person.FamilyMember.FirstOrDefault().Family.FamilyMember.FirstOrDefault(p => p.RelationTypeId == 2).Person.PersonFirstName :
                                                    "ثبت نشده"
                                                )
                                            ),
                PersonMotherName = (
                                                !string.IsNullOrEmpty(person.PersonMotherName) ?
                                                person.PersonMotherName :
                                                (
                                                    person.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 1) ?
                                                    person.FamilyMember.FirstOrDefault().Family.FamilyMember.FirstOrDefault(p => p.RelationTypeId == 1).Person.PersonFirstName :
                                                    "ثبت نشده"
                                                )
                                            ),
                PersonProfilePic = Constants.AttachmentServiceUrl + "?AttachmentId=" + ((attachment != null) ? attachment.AttachmentId.ToString() : "-1") + "&Thumbnail=150",
            };


            return PartialView(personViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProfilePic(int id)
        {
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            DAL.Attachment attachment = new Attachment();
            AttachmentType attachmentType = db.AttachmentTypeRepository.GetById((int)Enumerable.AttachmentTypes.Person);
            string attachmentTypeAllowedFormat = attachmentType.AttachmentTypeAllowedFormat;
            var postedFiles = Request.Files;
            if (postedFiles.Count == 1)
            {
                if (postedFiles[0] != null && postedFiles[0].IsImage())
                {
                    if (postedFiles[0].ContentLength <= attachmentType.AttachmentTypeMaxSize)
                    {
                        string[] allowExtentions = attachmentTypeAllowedFormat.Split(',');
                        if (!string.IsNullOrEmpty(System.IO.Path.GetExtension(postedFiles[0].FileName)) &&
                            allowExtentions.Contains(System.IO.Path.GetExtension(postedFiles[0].FileName).ToLower()))
                        {
                            foreach (var item in db.AttachmentRepository.Get(a => a.AttachmentOwnerId == id && a.AttachmentTypeId == (int)Enumerable.AttachmentTypes.Person))
                            {
                                db.AttachmentRepository.Delete(item);
                            }
                            byte[] fileData = null;
                            using (var binaryReader = new BinaryReader(postedFiles[0].InputStream))
                            {
                                binaryReader.BaseStream.Position = 0;
                                fileData = binaryReader.ReadBytes(postedFiles[0].ContentLength);
                            }
                            attachment.AttachmentContent = fileData;
                            attachment.AttachmentDesc = "عکس پرسنلی";
                            attachment.AttachmentExtention = System.IO.Path.GetExtension(postedFiles[0].FileName).Replace(".", "");  //(fuPersonalImage.FileName.Substring(fuPersonalImage.FileName.IndexOf(".") + 1));
                            attachment.AttachmentFileName = Guid.NewGuid() + "_" + postedFiles[0].FileName;
                            attachment.AttachmentZiped = postedFiles[0].FileName.ToZipedTextOnly();
                            // OBJA.AttachmentContent =Convert.ToByte(fuPersonalImage.PostedFile);
                            attachment.AttachmentContentType = postedFiles[0].ContentType;

                            attachment.AttachmentOwnerId = id;


                            attachment.AttachmentTypeId = (int)Enumerable.AttachmentTypes.Person;
                            attachment.AttachmentTime = DateTime.Now;
                            attachment.AttachmentTimeSolar = DateTime.Now.ToDateSolar();
                            attachment.UserId = userInfo.UserId;


                            attachment.InsertUserId = userInfo.UserId;
                            attachment.InsertTime = DateTime.Now;
                            db.AttachmentRepository.Insert(attachment);
                            db.Save();
                        }
                        else
                        {
                            messageViewModel.Add(new SystemMessageViewModel
                            {
                                Title = "خطا!",
                                Desc = "فرمت فایل مجاز نیست!"
                            });
                        }
                    }
                    else
                    {
                        messageViewModel.Add(new SystemMessageViewModel
                        {
                            Title = "خطا!",
                            Desc = "حجم تصویر بیش از حد مجاز است!"
                        });
                    }
                }
                else
                {
                    messageViewModel.Add(new SystemMessageViewModel
                    {
                        Title = "خطا!",
                        Desc = "فرمت فایل غیر مجاز است!"
                    });
                }
            }
            ViewBag.SelectedPersonId = id;
            messageViewModel.Add(new SystemMessageViewModel
            {
                Title = "",
                Desc = "ثبت اطلاعات با موفقیت انجام شد!"
            });

            var input = "id=" + id;
            var output = new JavaScriptSerializer().Serialize(messageViewModel);
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "ManagePerson",
                Action = "SaveProfilePic",
                Type = EventLogType.Insert,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return PartialView("_SystemMessages", messageViewModel);
            //  return RedirectToAction("PersonIndex", new { tabId = person.DepartmentId, pageId = ViewBag.PageID});
        }

        public ActionResult AddNewMember(int id)
        {
            DAL.Family family = db.FamilyRepository.GetById(id);
            return PartialView();
        }
        public ActionResult EditMember(int id)
        {
            DAL.Person person = db.PersonRepository.GetById(id);
            DAL.Attachment attachment = db.AttachmentRepository.Get(q => q.AttachmentTypeId == (int)Enumerable.AttachmentTypes.Person && q.AttachmentOwnerId == id).FirstOrDefault();
            PersonViewModel personViewModel = new PersonViewModel
            {
                PersonId = person.PersonId,
                PersonFirstName = person.PersonFirstName,
                PersonLastName = person.PersonLastName,
                PersonCode = person.PersonCode,
                PersonFatherName = person.PersonFatherName,
                PersonMotherName = person.PersonMotherName,
                RelationTypeId = person.FamilyMember.FirstOrDefault().RelationTypeId,
                IsParent = person.FamilyMember.FirstOrDefault().FamilyMemberIsParent,
                BankId = person.BankId,
                BeliveId = person.BeliveId,
                BirthCityId = person.BirthCityId,
                BirthProvinceId = person.BirthProvinceId,
                DepartmentId = person.DepartmentId,
                EthnicId = person.EthnicId,
                MaritalStatusId = person.MaritalStatusId,
                BloodTypeId = person.BloodTypeId,
                ChildMarriageCauseId = person.ChildMarriageCauseId,
                DrugHistoryId = person.DrugHistoryId,
                DrugStatusId = person.DrugStatusId,
                DrugWithdrawalHistoryId = person.DrugWithdrawalHistoryId,
                EducationDesc = person.EducationDesc,
                EducationFieldId = person.EducationFieldId,
                EducationStatusId = person.EducationStatusId,
                EducationTypeId = person.EducationTypeId,
                GenderId = person.GenderId,
                HealthTypeId = person.HealthTypeId,
                InsuranceDesc = person.InsuranceDesc,
                InsuranceTypeId = person.InsuranceTypeId,
                MigrateDuration = person.MigrateDuration,
                NationalityId = person.NationalityId,
                PersonBirthDateSolar = person.PersonBirthDateSolar,
                PersonBirthDay = person.PersonBirthDay,
                PersonBirthMonth = person.PersonBirthMonth,
                PersonBirthYear = person.PersonBirthYear,
                PersonCoveredDateSolar = person.PersonCoveredDateSolar,
                PersonCoveredDesc = person.PersonCoveredDesc,
                PersonIdentityNo = person.PersonIdentityNo,
                PersonBMIIndex = person.PersonBMIIndex,
                PersonStatusId = person.PersonStatusId,
                PersonFilingDateSolar = person.PersonFilingDateSolar,
                PersonDesc = person.PersonDesc,
                PersonFilingName = person.PersonFilingName,
                PersonNationalCode = person.PersonNationalCode,
                ReligionId = person.ReligionId,
                FamilyId = person.FamilyMember.FirstOrDefault().FamilyId,
                PersonProfilePic = Constants.AttachmentServiceUrl + "?AttachmentId=" + ((attachment != null) ? attachment.AttachmentId.ToString() : "-1") + "&Thumbnail=150",
            };

            InitForm(personViewModel);
            return PartialView(personViewModel);
        }
        public ActionResult EditIdentityDocuments(int id)
        {
            DAL.Person person = db.PersonRepository.GetById(id);
            DAL.Attachment attachment = db.AttachmentRepository.Get(q => q.AttachmentTypeId == (int)Enumerable.AttachmentTypes.Person && q.AttachmentOwnerId == id).FirstOrDefault();

            PersonViewModel personViewModel = new PersonViewModel
            {
                PersonId = person.PersonId,
                PersonFirstName = person.PersonFirstName,
                PersonLastName = person.PersonLastName,
                PersonCode = person.PersonCode,
                PersonFatherName = person.PersonFatherName,
                PersonMotherName = person.PersonMotherName,
                RelationTypeId = person.FamilyMember.FirstOrDefault().RelationTypeId,
                IsParent = person.FamilyMember.FirstOrDefault().FamilyMemberIsParent,
                BankId = person.BankId,
                BeliveId = person.BeliveId,
                BirthCityId = person.BirthCityId,
                BirthProvinceId = person.BirthProvinceId,
                DepartmentId = person.DepartmentId,
                EthnicId = person.EthnicId,
                MaritalStatusId = person.MaritalStatusId,
                BloodTypeId = person.BloodTypeId,
                ChildMarriageCauseId = person.ChildMarriageCauseId,
                DrugHistoryId = person.DrugHistoryId,
                DrugStatusId = person.DrugStatusId,
                DrugWithdrawalHistoryId = person.DrugWithdrawalHistoryId,
                EducationDesc = person.EducationDesc,
                EducationFieldId = person.EducationFieldId,
                EducationStatusId = person.EducationStatusId,
                EducationTypeId = person.EducationTypeId,
                GenderId = person.GenderId,
                HealthTypeId = person.HealthTypeId,
                InsuranceDesc = person.InsuranceDesc,
                InsuranceTypeId = person.InsuranceTypeId,
                MigrateDuration = person.MigrateDuration,
                NationalityId = person.NationalityId,
                PersonBirthDateSolar = person.PersonBirthDateSolar,
                PersonBirthDay = person.PersonBirthDay,
                PersonBirthMonth = person.PersonBirthMonth,
                PersonBirthYear = person.PersonBirthYear,
                PersonCoveredDateSolar = person.PersonCoveredDateSolar,
                PersonCoveredDesc = person.PersonCoveredDesc,
                PersonIdentityNo = person.PersonIdentityNo,
                PersonBMIIndex = person.PersonBMIIndex,
                PersonStatusId = person.PersonStatusId,
                PersonFilingDateSolar = person.PersonFilingDateSolar,
                PersonDesc = person.PersonDesc,
                PersonFilingName = person.PersonFilingName,
                PersonNationalCode = person.PersonNationalCode,
                ReligionId = person.ReligionId,
                FamilyId = person.FamilyMember.FirstOrDefault().FamilyId,
                PersonProfilePic = Constants.AttachmentServiceUrl + "?AttachmentId=" + ((attachment != null) ? attachment.AttachmentId.ToString() : "-1") + "&Thumbnail=150",
            };

            InitForm(personViewModel);
            return PartialView(personViewModel);
        }
        public ActionResult EditBirthDate(int id)
        {
            DAL.Person person = db.PersonRepository.GetById(id);
            DAL.Attachment attachment = db.AttachmentRepository.Get(q => q.AttachmentTypeId == (int)Enumerable.AttachmentTypes.Person && q.AttachmentOwnerId == id).FirstOrDefault();

            PersonViewModel personViewModel = new PersonViewModel
            {
                PersonId = person.PersonId,
                PersonFirstName = person.PersonFirstName,
                PersonLastName = person.PersonLastName,
                PersonCode = person.PersonCode,
                PersonFatherName = person.PersonFatherName,
                PersonMotherName = person.PersonMotherName,
                RelationTypeId = person.FamilyMember.FirstOrDefault().RelationTypeId,
                IsParent = person.FamilyMember.FirstOrDefault().FamilyMemberIsParent,
                BankId = person.BankId,
                BeliveId = person.BeliveId,
                BirthCityId = person.BirthCityId,
                BirthProvinceId = person.BirthProvinceId,
                DepartmentId = person.DepartmentId,
                EthnicId = person.EthnicId,
                MaritalStatusId = person.MaritalStatusId,
                BloodTypeId = person.BloodTypeId,
                ChildMarriageCauseId = person.ChildMarriageCauseId,
                DrugHistoryId = person.DrugHistoryId,
                DrugStatusId = person.DrugStatusId,
                DrugWithdrawalHistoryId = person.DrugWithdrawalHistoryId,
                EducationDesc = person.EducationDesc,
                EducationFieldId = person.EducationFieldId,
                EducationStatusId = person.EducationStatusId,
                EducationTypeId = person.EducationTypeId,
                GenderId = person.GenderId,
                HealthTypeId = person.HealthTypeId,
                InsuranceDesc = person.InsuranceDesc,
                InsuranceTypeId = person.InsuranceTypeId,
                MigrateDuration = person.MigrateDuration,
                NationalityId = person.NationalityId,
                PersonBirthDateSolar = person.PersonBirthDateSolar,
                PersonBirthDay = person.PersonBirthDay,
                PersonBirthMonth = person.PersonBirthMonth,
                PersonBirthYear = person.PersonBirthYear,
                PersonCoveredDateSolar = person.PersonCoveredDateSolar,
                PersonCoveredDesc = person.PersonCoveredDesc,
                PersonIdentityNo = person.PersonIdentityNo,
                PersonBMIIndex = person.PersonBMIIndex,
                PersonStatusId = person.PersonStatusId,
                PersonFilingDateSolar = person.PersonFilingDateSolar,
                PersonDesc = person.PersonDesc,
                PersonFilingName = person.PersonFilingName,
                PersonNationalCode = person.PersonNationalCode,
                ReligionId = person.ReligionId,
                FamilyId = person.FamilyMember.FirstOrDefault().FamilyId,
                PersonProfilePic = Constants.AttachmentServiceUrl + "?AttachmentId=" + ((attachment != null) ? attachment.AttachmentId.ToString() : "-1") + "&Thumbnail=150",
            };

            InitForm(personViewModel);
            return PartialView(personViewModel);
        }
        private void InitForm(PersonViewModel person)
        {
            //LookupModel emtyItem = new LookupModel { Value = "0", Name = "" };

            List<Belive> beliveId = new List<Belive>
            {
                new Belive { BeliveName = "" }
            };
            beliveId.AddRange(db.BeliveRepository.Get().OrderBy(q => q.BeliveName));
            ViewBag.BeliveId = new SelectList(beliveId, "BeliveId", "BeliveName", person.BeliveId);

            List<Ethnic> EthnicId = new List<Ethnic>
            {
                new Ethnic { EthnicName = "" }
            };
            EthnicId.AddRange(db.EthnicRepository.Get().OrderBy(q => q.EthnicName));
            ViewBag.EthnicId = new SelectList(db.EthnicRepository.Get(), "EthnicId", "EthnicName", person.EthnicId);

            List<MaritalStatus> maritalStatusId = new List<MaritalStatus>
            {
                new MaritalStatus { MaritalStatusName = "" }
            };
            maritalStatusId.AddRange(db.MaritalStatusRepository.Get().OrderBy(q => q.MaritalStatusName));
            ViewBag.MaritalStatusId = new SelectList(maritalStatusId, "MaritalStatusId", "MaritalStatusName", person.MaritalStatusId);

            //List<LookupModel> genders = new List<LookupModel>();
            //genders.Add(emtyItem);
            //genders.AddRange(db.GenderRepository.Get().Select(q => new LookupModel { Value = q.GenderId.ToString(), Name = q.GenderName }).OrderBy(q => q.Name));
            //ViewBag.GenderId = new SelectList(genders, "Value", "Name", person.GenderId);

            //List<Gender> genders = new List<Gender>();
            //genders.Add(new Gender { GenderId = -1, GenderName = "" });
            //genders.AddRange(db.GenderRepository.Get().OrderBy(q => q.GenderName));
            //ViewBag.GenderId = new SelectList(db.GenderRepository.Get(), "GenderId", "GenderName", person.GenderId);

            List<Nationality> nationalityId = new List<Nationality>
            {
                new Nationality { NationalityName = "" }
            };
            nationalityId.AddRange(db.NationalityRepository.Get().OrderBy(q => q.NationalityName));
            ViewBag.NationalityId = new SelectList(nationalityId, "NationalityId", "NationalityName", person.NationalityId);

            List<PersonStatus> personStatusId = new List<PersonStatus>
            {
                new PersonStatus { PersonStatusName = "" }
            };
            personStatusId.AddRange(db.PersonStatusRepository.Get().OrderBy(q => q.PersonStatusName));
            ViewBag.PersonStatusId = new SelectList(personStatusId, "PersonStatusId", "PersonStatusName", person.PersonStatusId);

            List<Religion> religionId = new List<Religion>
            {
                new Religion { ReligionName = "" }
            };
            religionId.AddRange(db.ReligionRepository.Get().OrderBy(q => q.ReligionName));
            ViewBag.ReligionId = new SelectList(religionId, "ReligionId", "ReligionName", person.ReligionId);

            List<RelationType> relationTypeId = new List<RelationType>
            {
                new RelationType { RelationTypeName = "" }
            };
            relationTypeId.AddRange(db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName));
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "RelationTypeId", "RelationTypeName", person.RelationTypeId);

            //List<SelectListItem> ProvinceId = new List<SelectListItem>();
            //ProvinceId.Add(new SelectListItem { Text = "", Value = "0" });
            //ProvinceId.AddRange(db.ProvinceRepository.Get().Select(q => new SelectListItem { Value = q.ProvinceId.ToString(), Text = q.ProvinceName }).OrderBy(q => q.Text));
            //ViewBag.ProvinceId = new SelectList(ProvinceId, "Value", "Text", person.);

            //List<SelectListItem> CityId = new List<SelectListItem>();
            //CityId.Add(new SelectListItem { Text = "", Value = "0" });
            //CityId.AddRange(db.CityRepository.Get().Select(q => new SelectListItem { Value = q.CityId.ToString(), Text = q.CityName }).OrderBy(q => q.Text));
            //ViewBag.CityId = new SelectList(relationTypeId, "Value", "Text");

            //List<SelectListItem> RegionId = new List<SelectListItem>();
            //RegionId.Add(new SelectListItem { Text = "", Value = "0" });
            ////RegionId.AddRange(db.RegionRepository.Get().Select(q => new SelectListItem { Value = q.RegionId.ToString(), Text = q.RegionName }).OrderBy(q => q.Text));
            //ViewBag.ProvinceId = new SelectList(relationTypeId, "Value", "Text");

            //List<SelectListItem> SegmentId = new List<SelectListItem>();
            //SegmentId.Add(new SelectListItem { Text = "", Value = "0" });
            //SegmentId.AddRange(db.SegmentRepository.Get().Select(q => new SelectListItem { Value = q.SegmentId.ToString(), Text = q.SegmentName }).OrderBy(q => q.Text));
            //ViewBag.SegmentId = new SelectList(relationTypeId, "Value", "Text");

        }
        private void InitForm()
        {
            //LookupModel emtyItem = new LookupModel { Value = "0", Name = "" };

            var user = db.UserInfoRepository.Get(u => u.UserName == User.Identity.Name).SingleOrDefault();
            List<Department> departmentId = new List<Department>();
            List<DAL.Department> departments = user.UserDepartment.Where(q => q.Department.DepartmentIsActive && q.Department.DepartmentTypeId != (int)Enumerable.DepartmentType.DiscoveryTeam).Select(q => new Department
            {
                DepartmentId = q.DepartmentId,
                DepartmentName = q.Department.DepartmentName,
                DepartmentCode = q.Department.DepartmentCode,

            }
                 ).ToList();
            departmentId.Add(new Department { DepartmentName = "" });
            departmentId.AddRange(departments.OrderBy(q => q.DepartmentName));
            ViewBag.DepartmentId = new SelectList(departmentId, "DepartmentId", "DepartmentName");

            //List<LookupModel> belives = new List<LookupModel>();
            //belives.Add(emtyItem);
            //belives.AddRange(db.BeliveRepository.Get().Select(q => new LookupModel { Value = q.BeliveId.ToString(), Name = q.BeliveName }).OrderBy(q => q.Name));
            //ViewBag.BeliveId = new SelectList(belives, "Value", "Name");

            List<Ethnic> EthnicId = new List<Ethnic>
            {
                new Ethnic { EthnicName = "" }
            };
            EthnicId.AddRange(db.EthnicRepository.Get().OrderBy(q => q.EthnicName));
            ViewBag.EthnicId = new SelectList(db.EthnicRepository.Get(), "EthnicId", "EthnicName");

            List<MaritalStatus> maritalStatusId = new List<MaritalStatus>
            {
                new MaritalStatus { MaritalStatusName = "" }
            };
            maritalStatusId.AddRange(db.MaritalStatusRepository.Get().OrderBy(q => q.MaritalStatusName));
            ViewBag.MaritalStatusId = new SelectList(maritalStatusId, "MaritalStatusId", "MaritalStatusName");

            List<SelectListItem> genders = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "" }
            };
            genders.AddRange(db.GenderRepository.Get().Select(q => new SelectListItem { Value = q.GenderId.ToString(), Text = q.GenderName }).OrderBy(q => q.Text));
            ViewBag.GenderId = new SelectList(genders, "Value", "Text");

            List<Nationality> nationalityId = new List<Nationality>
            {
                new Nationality { NationalityName = "" }
            };
            nationalityId.AddRange(db.NationalityRepository.Get().OrderBy(q => q.NationalityName));
            ViewBag.NationalityId = new SelectList(nationalityId, "NationalityId", "NationalityName");

            List<SelectListItem> personStatusId = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "" }
            };
            personStatusId.AddRange(db.PersonStatusRepository.Get().Select(q => new SelectListItem { Value = q.PersonStatusId.ToString(), Text = q.PersonStatusName }).OrderBy(q => q.Text));
            ViewBag.PersonStatusId = new SelectList(personStatusId, "Value", "Text");

            List<Religion> religionId = new List<Religion>
            {
                new Religion { ReligionName = "" }
            };
            religionId.AddRange(db.ReligionRepository.Get().OrderBy(q => q.ReligionName));
            ViewBag.ReligionId = new SelectList(religionId, "ReligionId", "ReligionName");

            List<RelationType> relationTypeId = new List<RelationType>
            {
                new RelationType { RelationTypeName = "" }
            };
            relationTypeId.AddRange(db.RelationTypeRepository.Get().OrderBy(q => q.RelationTypeName));
            ViewBag.RelationTypeId = new SelectList(relationTypeId, "RelationTypeId", "RelationTypeName");

            List<SelectListItem> ProvinceId = new List<SelectListItem>
            {
                new SelectListItem { Text = "", Value = "0" }
            };
            ProvinceId.AddRange(db.ProvinceRepository.Get().Select(q => new SelectListItem { Value = q.ProvinceId.ToString(), Text = q.ProvinceName }).OrderBy(q => q.Text));
            ViewBag.ProvinceId = new SelectList(ProvinceId, "Value", "Text");

            List<SelectListItem> CityId = new List<SelectListItem>
            {
                new SelectListItem { Text = "", Value = "0" }
            };
            //CityId.AddRange(db.CityRepository.Get().Select(q => new SelectListItem { Value = q.CityId.ToString(), Text = q.CityName }).OrderBy(q => q.Text));
            ViewBag.CityId = new SelectList(CityId, "Value", "Text");

            List<SelectListItem> RegionId = new List<SelectListItem>
            {
                new SelectListItem { Text = "", Value = "0" }
            };
            //RegionId.AddRange(db.RegionRepository.Get().Select(q => new SelectListItem { Value = q.RegionId.ToString(), Text = q.RegionName }).OrderBy(q => q.Text));
            ViewBag.RegionId = new SelectList(RegionId, "Value", "Text");

            List<SelectListItem> SegmentId = new List<SelectListItem>
            {
                new SelectListItem { Text = "", Value = "0" }
            };
            //SegmentId.AddRange(db.SegmentRepository.Get().Select(q => new SelectListItem { Value = q.SegmentId.ToString(), Text = q.SegmentName }).OrderBy(q => q.Text));
            ViewBag.SegmentId = new SelectList(SegmentId, "Value", "Text");

        }

        [HttpPost]
        public ActionResult EditMember(PersonViewModel personViewModel)
        {
            EventLogViewModel eventLogView = new EventLogViewModel();
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            DAL.Person person = db.PersonRepository.GetById(personViewModel.PersonId);
            DAL.FamilyMember familyMember = person.FamilyMember.FirstOrDefault();
            DAL.Family family = familyMember.Family;
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();

            if (!string.IsNullOrEmpty(personViewModel.PersonFilingDateSolar))
            {
                person.PersonFilingDateSolar = personViewModel.PersonFilingDateSolar;
                person.PersonFilingDate = personViewModel.PersonFilingDateSolar.ToZipedTextOnly().ToDate();
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "تاریخ شناسایی ضروری است!",
                    Type = 1
                });
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonFirstName))
            {
                person.PersonFirstName = personViewModel.PersonFirstName;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "نام فرد ضروری است!",
                    Type = 1
                });
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonLastName))
            {
                person.PersonLastName = personViewModel.PersonLastName;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "نام خانوادگی ضروری است!",
                    Type = 1
                });
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonFatherName))
            {
                person.PersonFatherName = personViewModel.PersonFatherName;
            }
            else
            {
                //اگر دختر یا پسر خانواده باشد نام پدر و مادر اجباری است 
                //if (personViewModel.RelationTypeId == 8 || personViewModel.RelationTypeId == 6)
                //    messageViewModel.Add(new SystemMessageViewModel
                //    {
                //        Title = "فیلدهای اجباری",
                //        Desc = "نام مادر ضروری است!",
                //        Type = 1
                //    });
                person.PersonFatherName = null;
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonMotherName))
            {
                person.PersonMotherName = personViewModel.PersonMotherName;
            }
            else
            {
                //messageViewModel.Add(new SystemMessageViewModel
                //{
                //    Title = "فیلدهای اجباری",
                //    Desc = "نام مادر ضروری است!",
                //    Type = 1
                //});
                person.PersonMotherName = null;
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonBirthDay))
            {
                if (personViewModel.PersonBirthDay.IsNumeric())
                {
                    if (Convert.ToInt32(personViewModel.PersonBirthDay) <= 31 && Convert.ToInt32(personViewModel.PersonBirthDay) > 0)
                    {
                        person.PersonBirthDay = Convert.ToInt32(personViewModel.PersonBirthDay).ToString("D2");
                    }
                    else
                    {
                        messageViewModel.Add(new SystemMessageViewModel
                        {
                            Title = "فیلدهای اجباری",
                            Desc = "روز تولد نامعتبر است!",
                            Type = 1
                        });
                    }
                }
                else
                {
                    messageViewModel.Add(new SystemMessageViewModel
                    {
                        Title = "فیلدهای اجباری",
                        Desc = "روز تولد نامعتبر است!",
                        Type = 1
                    });
                }
            }
            else
            {
                person.PersonBirthDay = null;
            }

            if (!string.IsNullOrEmpty(personViewModel.PersonBirthMonth))
            {
                if (personViewModel.PersonBirthMonth.IsNumeric())
                {
                    if (Convert.ToInt32(personViewModel.PersonBirthMonth) <= 12 && Convert.ToInt32(personViewModel.PersonBirthMonth) > 0)
                    {
                        person.PersonBirthMonth = Convert.ToInt32(personViewModel.PersonBirthMonth).ToString("D2");
                    }
                    else
                    {
                        messageViewModel.Add(new SystemMessageViewModel
                        {
                            Title = "فیلدهای اجباری",
                            Desc = "ماه تولد نامعتبر است!",
                            Type = 1
                        });
                    }
                }
                else
                {
                    messageViewModel.Add(new SystemMessageViewModel
                    {
                        Title = "فیلدهای اجباری",
                        Desc = "ماه تولد نامعتبر است!",
                        Type = 1
                    });
                }
            }
            else
            {
                person.PersonBirthMonth = null;
            }

            if (!string.IsNullOrEmpty(personViewModel.PersonBirthYear))
            {
                if (personViewModel.PersonBirthYear.IsNumeric())
                {
                    if (personViewModel.PersonBirthYear.Length == 4)
                    {
                        if (personViewModel.PersonBirthYear.CompareTo("1280") > 0 && personViewModel.PersonBirthYear.CompareTo("1400") < 0)
                        {
                            person.PersonBirthYear = personViewModel.PersonBirthYear;
                        }
                        else
                        {
                            messageViewModel.Add(new SystemMessageViewModel
                            {
                                Title = "فیلدهای اجباری",
                                Desc = "سال تولد نامعتبر است!",
                                Type = 1
                            });
                        }
                    }
                    else
                    {
                        messageViewModel.Add(new SystemMessageViewModel
                        {
                            Title = "فیلدهای اجباری",
                            Desc = "سال تولد باید چهاررقمی وارد شود؛ مثلا: 1385!",
                            Type = 1
                        });
                    }
                }
                else
                {
                    messageViewModel.Add(new SystemMessageViewModel
                    {
                        Title = "فیلدهای اجباری",
                        Desc = "سال تولد نامعتبر است!",
                        Type = 1
                    });
                }
            }
            else
            {
                person.PersonBirthYear = null;
            }

            if (!string.IsNullOrEmpty(person.PersonBirthYear) && !string.IsNullOrEmpty(person.PersonBirthMonth) && !string.IsNullOrEmpty(person.PersonBirthMonth))
            {
                string PersonBirthDate = person.PersonBirthYear + "/" + person.PersonBirthMonth + "/" + person.PersonBirthDay;
                person.PersonBirthDateSolar = PersonBirthDate;
                person.PersonBirthDate = PersonBirthDate.ToZipedTextOnly().ToDate();
            }


            if ((personViewModel.NationalityId > 0))
            {
                person.NationalityId = personViewModel.NationalityId;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "ملیت ضروری است!",
                    Type = 1
                });
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonNationalCode))
            {
                if (db.PersonRepository.Get(q => q.PersonNationalCode == personViewModel.PersonNationalCode && person.PersonNationalCode != personViewModel.PersonNationalCode).Any())
                {
                    messageViewModel.Add(new SystemMessageViewModel
                    {
                        Title = "فیلدهای اجباری",
                        Desc = "کد ملی وارد شده تکراری است!",
                        Type = 1
                    });
                }
                else if (!personViewModel.PersonNationalCode.IsNationalCode())
                {
                    messageViewModel.Add(new SystemMessageViewModel
                    {
                        Title = "فیلدهای اجباری",
                        Desc = "کد ملی وارد شده نامعتبر است!",
                        Type = 1
                    });
                }
                else
                {
                    person.PersonNationalCode = personViewModel.PersonNationalCode;
                }
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonIdentityNo))
            {
                person.PersonIdentityNo = personViewModel.PersonIdentityNo;
            }
            else
            {
                person.PersonIdentityNo = null;
            }

            if (!string.IsNullOrEmpty(personViewModel.PersonFilingName))
            {
                person.PersonFilingName = personViewModel.PersonFilingName;
            }
            else
            {
                person.PersonFilingName = null;
            }

            if (!string.IsNullOrEmpty(personViewModel.PersonCoveredDateSolar))
            {
                person.PersonCoveredDateSolar = personViewModel.PersonCoveredDateSolar;
                person.PersonCoveredDate = personViewModel.PersonCoveredDateSolar.ToZipedTextOnly().ToDate();
            }
            else
            {
                person.PersonCoveredDateSolar = null;
                person.PersonCoveredDate = null;
            }
            if (personViewModel.PersonStatusId > 0)
            {
                person.PersonStatusId = personViewModel.PersonStatusId;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "وضعیت ضروری است!",
                    Type = 1
                });
            }
            if (!string.IsNullOrEmpty(personViewModel.PersonCoveredDesc))
            {
                person.PersonCoveredDesc = personViewModel.PersonCoveredDesc;
            }
            else
            {
                person.PersonCoveredDesc = null;
            }

            if ((personViewModel.GenderId != -1))
            {
                person.GenderId = personViewModel.GenderId;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "جنسیت ضروری است!",
                    Type = 1
                });
            }
            if ((personViewModel.MaritalStatusId > 0))
            {
                person.MaritalStatusId = personViewModel.MaritalStatusId;
            }
            else
            {
                person.MaritalStatusId = null;
            }

            if ((personViewModel.EthnicId > 0))
            {
                person.EthnicId = personViewModel.EthnicId;
            }
            else
            {
                person.EthnicId = null;
            }

            if ((personViewModel.BeliveId > 0))
            {
                person.BeliveId = personViewModel.BeliveId;
            }
            else
            {
                person.BeliveId = null;
            }

            if ((personViewModel.ReligionId > 0))
            {
                person.ReligionId = personViewModel.ReligionId;
            }
            else
            {
                person.ReligionId = null;
            }

            if ((personViewModel.MigrateDuration > 0))
            {
                person.MigrateDuration = personViewModel.MigrateDuration;
            }
            else
            {
                person.MigrateDuration = null;
            }
            //if (!string.IsNullOrEmpty(personViewModel.PersonFirstName))
            //    person.PersonFirstName = personViewModel.PersonFirstName;
            //if (!string.IsNullOrEmpty(personViewModel.PersonFirstName))
            //    person.PersonFirstName = personViewModel.PersonFirstName;
            //if (!string.IsNullOrEmpty(personViewModel.PersonFirstName))
            //    person.PersonFirstName = personViewModel.PersonFirstName;
            //if (!string.IsNullOrEmpty(personViewModel.PersonFirstName))
            //    person.PersonFirstName = personViewModel.PersonFirstName;
            person.UpdateTime = DateTime.Now;
            person.UpdateUserId = userInfo.UserId;

            family.UpdateTime = DateTime.Now;
            family.UpdateUserId = userInfo.UserId;
            if (personViewModel.RelationTypeId.HasValue && personViewModel.RelationTypeId > 0)
            {
                familyMember.RelationTypeId = personViewModel.RelationTypeId.Value;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "موقعیت در خانواده ضروری است!",
                    Type = 1
                });
            }
            if (personViewModel.IsParent)
            {
                var members = person.FamilyMember.FirstOrDefault().Family.FamilyMember;
                foreach (var item in members)
                {
                    item.FamilyMemberIsParent = false;
                }
            }
            familyMember.FamilyMemberIsParent = personViewModel.IsParent;
            familyMember.UpdateTime = DateTime.Now;
            familyMember.UpdateUserId = userInfo.UserId;

            if (messageViewModel.Any(q => q.Type == 1))
            {

                eventLogView = new EventLogViewModel
                {
                    Area = null,
                    Controller = "ManagePerson",
                    Action = "EditMember",
                    Type = EventLogType.Error,
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
                Controller = "ManagePerson",
                Action = "EditMember",
                Type = EventLogType.Update,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);

            return PartialView("_SystemMessages", messageViewModel);
        }

        public ActionResult MemberSportInfo(int id)
        {
            DAL.Person person = db.PersonRepository.GetById(id);
            DAL.Attachment attachment = db.AttachmentRepository.Get(q => q.AttachmentTypeId == (int)Enumerable.AttachmentTypes.Person && q.AttachmentOwnerId == id).FirstOrDefault();
            PersonViewModel personViewModel = new PersonViewModel
            {
                PersonId = person.PersonId,
                PersonFirstName = person.PersonFirstName,
                PersonLastName = person.PersonLastName,
                PersonCode = person.PersonCode,
                PersonFatherName = (
                                                !string.IsNullOrEmpty(person.PersonFatherName) ?
                                                person.PersonFatherName :
                                                (
                                                    person.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 2) ?
                                                    person.FamilyMember.FirstOrDefault().Family.FamilyMember.FirstOrDefault(p => p.RelationTypeId == 2).Person.PersonFirstName :
                                                    "ثبت نشده"
                                                )
                                            ),
                PersonMotherName = (
                                                !string.IsNullOrEmpty(person.PersonMotherName) ?
                                                person.PersonMotherName :
                                                (
                                                    person.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 1) ?
                                                    person.FamilyMember.FirstOrDefault().Family.FamilyMember.FirstOrDefault(p => p.RelationTypeId == 1).Person.PersonFirstName :
                                                    "ثبت نشده"
                                                )
                                            ),
                PersonProfilePic = Constants.AttachmentServiceUrl + "?AttachmentId=" + ((attachment != null) ? attachment.AttachmentId.ToString() : "-1") + "&Thumbnail=150",
            };
            return PartialView(personViewModel);
        }
        public ActionResult RemoveMember(int id)
        {
            DAL.Person person = db.PersonRepository.GetById(id);
            DAL.Attachment attachment = db.AttachmentRepository.Get(q => q.AttachmentTypeId == (int)Enumerable.AttachmentTypes.Person && q.AttachmentOwnerId == id).FirstOrDefault();
            PersonViewModel personViewModel = new PersonViewModel
            {
                PersonId = person.PersonId,
                RelationTypeId = person.FamilyMember.FirstOrDefault().RelationTypeId,
                PersonFirstName = person.PersonFirstName,
                PersonLastName = person.PersonLastName,
                PersonCode = person.PersonCode,
                PersonFatherName = (
                                                !string.IsNullOrEmpty(person.PersonFatherName) ?
                                                person.PersonFatherName :
                                                (
                                                    person.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 2) ?
                                                    person.FamilyMember.FirstOrDefault().Family.FamilyMember.FirstOrDefault(p => p.RelationTypeId == 2).Person.PersonFirstName :
                                                    "ثبت نشده"
                                                )
                                            ),
                PersonMotherName = (
                                                !string.IsNullOrEmpty(person.PersonMotherName) ?
                                                person.PersonMotherName :
                                                (
                                                    person.FamilyMember.FirstOrDefault().Family.FamilyMember.Any(p => p.RelationTypeId == 1) ?
                                                    person.FamilyMember.FirstOrDefault().Family.FamilyMember.FirstOrDefault(p => p.RelationTypeId == 1).Person.PersonFirstName :
                                                    "ثبت نشده"
                                                )
                                            ),
                PersonProfilePic = Constants.AttachmentServiceUrl + "?AttachmentId=" + ((attachment != null) ? attachment.AttachmentId.ToString() : "-1") + "&Thumbnail=150",
            };
            //LookupModel emtyItem = new LookupModel { Value = "0", Name = "" };
            //List<LookupModel> expireCauses = new List<LookupModel>();
            //expireCauses.Add(emtyItem);
            //expireCauses.AddRange(db.ExpireCauseRepository.Get().Select(q => new LookupModel { Value = q.ExpireCauseId.ToString(), Name = q.ExpireCauseName }).OrderBy(q => q.Name));
            //ViewBag.ExpireCauseId = new SelectList(expireCauses, "Value", "Name");


            return PartialView(personViewModel);
        }
        [HttpPost]
        public ActionResult RemoveMember(PersonViewModel personViewModel)
        {
            EventLogViewModel eventLogView = new EventLogViewModel();
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            DAL.Person person = db.PersonRepository.GetById(personViewModel.PersonId);
            DAL.FamilyMember familyMember = person.FamilyMember.FirstOrDefault(q => q.RelationTypeId == personViewModel.RelationTypeId && !q.FamilyMemberExpireTime.HasValue);
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();


            familyMember.FamilyMemberExpireTime = DateTime.Now;
            familyMember.FamilyMemberExpireTimeSolar = DateTime.Now.ToDateSolar();


            if ((personViewModel.ExpireCauseId > 0))
            {
                familyMember.ExpireCauseId = personViewModel.ExpireCauseId;
            }
            else
            {
                messageViewModel.Add(new SystemMessageViewModel
                {
                    Title = "فیلدهای اجباری",
                    Desc = "علت ضروری است!",
                    Type = 1
                });
            }

            familyMember.UpdateTime = DateTime.Now;
            familyMember.UpdateUserId = userInfo.UserId;

            if (messageViewModel.Any(q => q.Type == 1))
            {

                eventLogView = new EventLogViewModel
                {
                    Area = null,
                    Controller = "ManagePerson",
                    Action = "RemoveMember",
                    Type = EventLogType.Error,
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
                Controller = "ManagePerson",
                Action = "RemoveMember",
                Type = EventLogType.Delete,
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
