using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;

namespace WebService.Controllers
{
    public class MyAPIController : ApiController
    {
        private readonly UnitOfWork _db = new UnitOfWork();

        public IEnumerable<UserInfo> AllowLogin([FromBody]string value)
        {
            var users = _db.UserInfoRepository.Get();
            return users;
        }

        #region Bank

        // GET: api/MyAPI
        public IEnumerable<Bank> GetBanks()
        {
            return _db.BankRepository.Get();
        }

        // GET: api/MyAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MyAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MyAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MyAPI/5
        public void Delete(int id)
        {
        }
        #endregion
    }
}
