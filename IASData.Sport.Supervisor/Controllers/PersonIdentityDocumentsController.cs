using DAL;
using IASData.Enumerable;
using IASData.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IASData.Sport.Supervisor.Controllers
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
            List<SelectListItem> IdentityDocumentId = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "" }
            };
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

            List<SelectListItem> IdentityDocumentId = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "" }
            };
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
            DAL.Attachment attachment = new Attachment();
            AttachmentType attachmentType = db.AttachmentTypeRepository.GetById((int)Enumerable.AttachmentTypes.PersonIdentityDocument);
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
                            foreach (var item in db.AttachmentRepository.Get(a => a.AttachmentOwnerId == personIdentityDocument.PersonIdentityDocumentId && a.AttachmentTypeId == (int)Enumerable.AttachmentTypes.PersonIdentityDocument))
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

                            attachment.AttachmentOwnerId = personIdentityDocument.PersonIdentityDocumentId;


                            attachment.AttachmentTypeId = (int)Enumerable.AttachmentTypes.PersonIdentityDocument;
                            attachment.AttachmentTime = DateTime.Now;
                            attachment.AttachmentTimeSolar = DateTime.Now.ToDateSolar();
                            attachment.UserId = userInfo.UserId;


                            attachment.InsertUserId = userInfo.UserId;
                            attachment.InsertTime = DateTime.Now;
                            db.AttachmentRepository.Insert(attachment);
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

            DAL.Attachment attachment = new Attachment();
            AttachmentType attachmentType = db.AttachmentTypeRepository.GetById((int)Enumerable.AttachmentTypes.PersonIdentityDocument);
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
                            foreach (var item in db.AttachmentRepository.Get(a => a.AttachmentOwnerId == personIdentityDocument.PersonIdentityDocumentId && a.AttachmentTypeId == (int)Enumerable.AttachmentTypes.PersonIdentityDocument))
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

                            attachment.AttachmentOwnerId = personIdentityDocument.PersonIdentityDocumentId;


                            attachment.AttachmentTypeId = (int)Enumerable.AttachmentTypes.PersonIdentityDocument;
                            attachment.AttachmentTime = DateTime.Now;
                            attachment.AttachmentTimeSolar = DateTime.Now.ToDateSolar();
                            attachment.UserId = userInfo.UserId;


                            attachment.InsertUserId = userInfo.UserId;
                            attachment.InsertTime = DateTime.Now;
                            db.AttachmentRepository.Insert(attachment);
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
            foreach (var item in db.AttachmentRepository.Get(a => a.AttachmentOwnerId == id && a.AttachmentTypeId == (int)Enumerable.AttachmentTypes.PersonIdentityDocument))
            {
                db.AttachmentRepository.Delete(item);
            }
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