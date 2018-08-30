using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAL;

namespace WebService.Controllers
{
    public class AccessController : ApiController
    {
        private readonly UnitOfWork _db = new UnitOfWork();

        // GET: api/Access
        public IQueryable<AccessLevel> GetAccessLevels()
        {
            return null;
        }

        // GET: api/Access/5
        [ResponseType(typeof(AccessLevel))]
        public IHttpActionResult GetAccessLevel(int id)
        {
            return null;
        }

        // PUT: api/Access/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccessLevel(int id, AccessLevel accessLevel)
        {

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Access
        [ResponseType(typeof(AccessLevel))]
        public IHttpActionResult PostAccessManager(AccessManager input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AccessManager accessManager = new AccessManager(_db);
            List<AccessItem> accessItems = new List<AccessItem>();
            var result = accessManager.AllowLogin(input.UserName, input.Password);
            if (result.UserTempId.HasValue)
                accessItems = accessManager.GetAccessList(result.UserTempId.Value);

            var menuItems = accessItems.Select(q => new { ControllerName= q.ControllerName.ToString() , q.SubsystemName, q.SubsystemId, q.ParentSubsystemId }).Distinct().ToList();//.GroupBy(q => new { q.SubsystemId, q.ParentSubsystemId, q.ControllerName, q.SubsystemName }).ToList();
            return CreatedAtRoute("DefaultApi", "", new { result, menuItems });
        }

        // DELETE: api/Access/5
        [ResponseType(typeof(AccessLevel))]
        public IHttpActionResult DeleteAccessLevel(int id)
        {
            return null;
        }
    }
}