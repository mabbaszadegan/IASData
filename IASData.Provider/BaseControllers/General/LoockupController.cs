using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IASData.Provider.BaseControllers.General
{
    public class LoockupController : Controller
    {
        DAL.UnitOfWork _db = new DAL.UnitOfWork();
        // GET: Loockup
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadEthnicsByNationalityId(int id)
        {
            //Your Code For Getting Physicans Goes Here
            var phyList = _db.EthnicRepository.Get(q => q.NationalityId == id);


            var phyData = phyList.Select(m => new SelectListItem()
            {
                Text = m.EthnicName,
                Value = m.EthnicId.ToString(),
            });
            return Json(phyData, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadCitiesByProvinceId(int id)
        {
            //Your Code For Getting Physicans Goes Here
            var phyList = _db.CityRepository.Get(q => q.ProvinceId == id);


            var phyData = phyList.Select(m => new SelectListItem()
            {
                Text = m.CityName,
                Value = m.CityId.ToString(),
            });
            return Json(phyData, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadRegionsByCityId(int id)
        {
            //Your Code For Getting Physicans Goes Here
            var phyList = _db.RegionRepository.Get(q => q.CityId == id);


            var phyData = phyList.Select(m => new SelectListItem()
            {
                Text = m.RegionName,
                Value = m.RegionId.ToString(),
            });
            return Json(phyData, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadSegmentsByRegionId(int id)
        {
            //Your Code For Getting Physicans Goes Here
            var phyList = _db.SegmentRepository.Get(q => q.SegmentId == id);


            var phyData = phyList.Select(m => new SelectListItem()
            {
                Text = m.SegmentName,
                Value = m.SegmentId.ToString(),
            });
            return Json(phyData, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadJobsByJobStatusId(int id)
        {
            //Your Code For Getting Physicans Goes Here
            var phyList = _db.JobRepository.Get(q => q.JobStatusId == id);


            var phyData = phyList.Select(m => new SelectListItem()
            {
                Text = m.JobName,
                Value = m.JobId.ToString(),
            });
            return Json(phyData, JsonRequestBehavior.AllowGet);
        }

    }
}