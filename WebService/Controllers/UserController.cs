using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DAL;

namespace WebService.Controllers
{
    public class UserController : ApiController
    {
        private readonly UnitOfWork _db = new UnitOfWork();

        // GET: api/User
        public IEnumerable<object> GetUsers()
        {
            return _db.UserInfoRepository.Get().Select(q => new { q.TempId, q.UserId, q.UserName, q.UserPassword, q.UserFirstName, q.UserLastName, q.UserIsActive });
        }

        // GET: api/User/5
        [ResponseType(typeof(UserInfo))]
        public IHttpActionResult GetUserInfo(int id)
        {
            object userInfo = _db.UserInfoRepository.Get(q => q.UserId == id).Select(q => new { q });
            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserInfo(int id, UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userInfo.UserId)
            {
                return BadRequest();
            }

            userInfo.UpdateUserId = 1;
            userInfo.UpdateTime = DateTime.Now;
            _db.UserInfoRepository.Update(userInfo);

            try
            {
                _db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/User
        [ResponseType(typeof(UserInfo))]
        public IHttpActionResult PostUserInfo(UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            userInfo.InsertUserId = 1;
            userInfo.InsertTime = DateTime.Now;

            _db.UserInfoRepository.Insert(userInfo);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = userInfo.UserId }, userInfo);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(UserInfo))]
        public IHttpActionResult DeleteUserInfo(int id)
        {
            _db.UserInfoRepository.Delete(id);
            _db.Save();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserInfoExists(int id)
        {
            return _db.UserInfoRepository.Get(q => q.UserId == id).Any();
        }
    }
}