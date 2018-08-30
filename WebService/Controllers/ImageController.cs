using DAL;
using IASData.Enumerable;
using IASData.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebService.Controllers
{
    public class ImageController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        [HttpPost]
        public ActionResult SaveProfilePic(int id)
        {
            List<SystemMessageViewModel> messageViewModel = new List<SystemMessageViewModel>();
            DAL.Person person = db.PersonRepository.GetById(id);
            var postedFiles = Request.Files;
            if (postedFiles.Count == 1)
            {
                if (postedFiles[0] != null && postedFiles[0].IsImage())
                {
                    if (postedFiles[0].ContentLength <= 500000)
                    {
                        person.PersonProfilePic = Guid.NewGuid().ToString() + Path.GetExtension(postedFiles[0].FileName);
                        db.PersonRepository.Update(person);
                        db.Save();

                        if (!string.IsNullOrEmpty(person.PersonProfilePic))
                            if (person.PersonProfilePic != "nopic.jpg")
                            {
                                System.IO.File.Delete(Server.MapPath("../../Images/Person/Personal/" + person.PersonProfilePic));
                                System.IO.File.Delete(Server.MapPath("../../Images/Person/Personal/Thumb/" + person.PersonProfilePic));
                            }

                        postedFiles[0].SaveAs(Server.MapPath("../../Images/Person/Personal/" + person.PersonProfilePic));
                        ImageResizer img = new ImageResizer();
                        img.Resize(Server.MapPath("../../Images/Person/Personal/" + person.PersonProfilePic),
                            Server.MapPath("../../Images/Person/Personal/Thumb/" + person.PersonProfilePic));
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

    }
}
