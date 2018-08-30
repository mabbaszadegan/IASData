using DAL;
using IASData.Enumerable;
using IASData.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Kuchegardan.Controllers
{
    public class PersonIdentityDocumentController : Controller
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: PersonIdentityDocument
        public ActionResult Index(int id)
        {
            List<DAL.PersonIdentityDocument> personIdentityDocuments = db.PersonIdentityDocumentRepository.Get(q => q.PersonId == id).ToList();
            //ViewBag.IdentityDocuments = db.IdentityDocumentRepository.Get();
            ViewBag.PersonId = id;
            return PartialView(personIdentityDocuments);
        }

        public ActionResult Create(int personId)
        {
            List<SelectListItem> IdentityDocumentId = new List<SelectListItem>();
            IdentityDocumentId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.IdentityDocumentRepository.Get().OrderBy(q => q.IdentityDocumentName))
            {
                IdentityDocumentId.Add(new SelectListItem { Value = item.IdentityDocumentId.ToString(), Text = item.IdentityDocumentName });
            }
            ViewBag.IdentityDocumentId = new SelectList(IdentityDocumentId, "Value", "Text");

            ViewBag.PersonId = personId;

            return PartialView();
        }
        public ActionResult Edit(int personId)
        {
            List<DAL.PersonIdentityDocument> personIdentityDocuments = db.PersonIdentityDocumentRepository.Get(q => q.PersonId == personId).ToList();

            List<SelectListItem> IdentityDocumentId = new List<SelectListItem>();
            IdentityDocumentId.Add(new SelectListItem { Value = "0", Text = "" });
            foreach (var item in db.IdentityDocumentRepository.Get().OrderBy(q => q.IdentityDocumentName))
            {
                IdentityDocumentId.Add(new SelectListItem { Value = item.IdentityDocumentId.ToString(), Text = item.IdentityDocumentName });
            }

            foreach (var item in personIdentityDocuments)
            {
                item.IdentityDocumentPic = "../Images/Person/IdentityDocument/Thumb/" + ((!string.IsNullOrEmpty(item.IdentityDocumentPic)) ? item.IdentityDocumentPic : "nopic.jpg");

            }


            ViewBag.IdentityDocumentId = new SelectList(IdentityDocumentId, "Value", "Text");

            return PartialView(personIdentityDocuments);
        }

        [HttpPost]
        public ActionResult CreatePersonIdentityDocument(DAL.PersonIdentityDocument personIdentityDocument)
        {
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            var postedFiles = Request.Files;
            if (postedFiles.Count == 1)
            {
                if (postedFiles[0] != null && postedFiles[0].IsImage())
                {
                    if (postedFiles[0].ContentLength <= 500000)
                    {
                        personIdentityDocument.IdentityDocumentPic = Guid.NewGuid().ToString() + Path.GetExtension(postedFiles[0].FileName);
                        if (!string.IsNullOrEmpty(personIdentityDocument.IdentityDocumentPic))
                            if (personIdentityDocument.IdentityDocumentPic != "nopic.jpg")
                            {
                                System.IO.File.Delete(Server.MapPath("../Images/Person/IdentityDocument/" + personIdentityDocument.IdentityDocumentPic));
                                System.IO.File.Delete(Server.MapPath("../Images/Person/IdentityDocument/Thumb/" + personIdentityDocument.IdentityDocumentPic));
                            }

                        postedFiles[0].SaveAs(Server.MapPath("../Images/Person/IdentityDocument/" + personIdentityDocument.IdentityDocumentPic));
                        ImageResizer img = new ImageResizer();
                        img.Resize(Server.MapPath("../Images/Person/IdentityDocument/" + personIdentityDocument.IdentityDocumentPic),
                            Server.MapPath("../Images/Person/IdentityDocument/Thumb/" + personIdentityDocument.IdentityDocumentPic));
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

            if (!string.IsNullOrEmpty(personIdentityDocument.ExpireTimeSolar))
            {
                personIdentityDocument.ExpireTimeSolar = personIdentityDocument.ExpireTimeSolar;
                personIdentityDocument.ExpireTime = personIdentityDocument.ExpireTimeSolar.ToZipedTextOnly().ToDate();
            }
            personIdentityDocument.InsertTime = DateTime.Now;
            personIdentityDocument.InsertUserId = userInfo.UserId;
            db.PersonIdentityDocumentRepository.Insert(personIdentityDocument);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(personIdentityDocument);
            var output = "personId=" + personIdentityDocument.PersonIdentityDocumentId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonIdentityDocument",
                Action = "CreatePersonIdentityDocument",
                Type = EventLogType.Insert,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);
            ViewBag.Messages = messageViewModel;
            return RedirectToAction("Index", new { id = personIdentityDocument.PersonId });
        }

        [HttpPost]
        public ActionResult EditPersonIdentityDocument(DAL.PersonIdentityDocument model)
        {
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            UserInfo userInfo = db.UserInfoRepository.Get(q => q.UserName == User.Identity.Name).FirstOrDefault();
            DAL.PersonIdentityDocument personIdentityDocument = db.PersonIdentityDocumentRepository.GetById(model.PersonIdentityDocumentId);

            var postedFiles = Request.Files;
            if (postedFiles.Count == 1)
            {
                if (postedFiles[0] != null && postedFiles[0].IsImage())
                {
                    if (postedFiles[0].ContentLength <= 500000)
                    {
                        personIdentityDocument.IdentityDocumentPic = Guid.NewGuid().ToString() + Path.GetExtension(postedFiles[0].FileName);
                        personIdentityDocument.UpdateTime = DateTime.Now;
                        personIdentityDocument.UpdateUserId = userInfo.UserId;

                        if (!string.IsNullOrEmpty(personIdentityDocument.IdentityDocumentPic))
                            if (personIdentityDocument.IdentityDocumentPic != "nopic.jpg")
                            {
                                System.IO.File.Delete(Server.MapPath("../Images/Person/IdentityDocument/" + personIdentityDocument.IdentityDocumentPic));
                                System.IO.File.Delete(Server.MapPath("../Images/Person/IdentityDocument/Thumb/" + personIdentityDocument.IdentityDocumentPic));
                            }

                        postedFiles[0].SaveAs(Server.MapPath("../Images/Person/IdentityDocument/" + personIdentityDocument.IdentityDocumentPic));
                        ImageResizer img = new ImageResizer();
                        img.Resize(Server.MapPath("../Images/Person/IdentityDocument/" + personIdentityDocument.IdentityDocumentPic),
                            Server.MapPath("../Images/Person/IdentityDocument/Thumb/" + personIdentityDocument.IdentityDocumentPic));
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
            if (!string.IsNullOrEmpty(model.ExpireTimeSolar))
            {
                personIdentityDocument.ExpireTimeSolar = model.ExpireTimeSolar;
                personIdentityDocument.ExpireTime = model.ExpireTimeSolar.ToZipedTextOnly().ToDate();
            }
            personIdentityDocument.IdentityDocumentCode = model.IdentityDocumentCode;
            personIdentityDocument.IdentityDocumentId = model.IdentityDocumentId;
            personIdentityDocument.IdentityDocumentSerialNo = model.IdentityDocumentSerialNo;
            personIdentityDocument.PersonIdentityDocumentDesc = model.PersonIdentityDocumentDesc;

            //personIdentityDocument.PersonIdentityDocumentDesc = model.PersonIdentityDocumentDesc;
            personIdentityDocument.IdentityDocumentId = model.IdentityDocumentId;
            personIdentityDocument.UpdateTime = DateTime.Now;
            personIdentityDocument.UpdateUserId = userInfo.UserId;
            db.PersonIdentityDocumentRepository.Update(personIdentityDocument);
            db.Save();

            var input = new JavaScriptSerializer().Serialize(model);
            var output = "personId=" + model.PersonIdentityDocumentId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonIdentityDocument",
                Action = "EditPersonIdentityDocument",
                Type = EventLogType.Update,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);
            ViewBag.Messages = messageViewModel;
            return RedirectToAction("Index", new { id = model.PersonId });
        }
        public ActionResult RemovePersonIdentityDocument(int id)
        {
            var personIdentityDocument = db.PersonIdentityDocumentRepository.GetById(id);
            db.PersonIdentityDocumentRepository.Delete(id);
            db.Save();
            var input = new JavaScriptSerializer().Serialize(personIdentityDocument);
            var output = "personId=" + personIdentityDocument.PersonId;
            EventLogViewModel eventLogView = new EventLogViewModel
            {
                Area = null,
                Controller = "PersonIdentityDocument",
                Action = "RemovePersonIdentityDocument",
                Type = EventLogType.Delete,
                Input = input,
                Output = output,
                Description = "",
                //UserId=User.Identity.
            };
            Common.HttpLogInsert(eventLogView);


            return RedirectToAction("Index", new { id = personIdentityDocument.PersonId });
        }
    }
}