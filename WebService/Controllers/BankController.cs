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
    public class BankController : ApiController
    {
        private readonly UnitOfWork _db = new UnitOfWork();

        // GET: api/Bank
        public IEnumerable<Bank> GetBanks()
        {
            return _db.BankRepository.Get();
        }

        // GET: api/Bank/5
        [ResponseType(typeof(Bank))]
        public IHttpActionResult GetBank(int id)
        {
            Bank bank = _db.BankRepository.GetById(id);
            if (bank == null)
            {
                return NotFound();
            }

            return Ok(bank);
        }

        // PUT: api/Bank/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBank(int id, Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bank.BankId)
            {
                return BadRequest();
            }

            bank.UpdateTime = DateTime.Now;
            bank.UpdateUserId = 1;

            _db.BankRepository.Update(bank);

            try
            {
                _db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankExists(id))
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

        // POST: api/Bank
        [ResponseType(typeof(Bank))]
        public IHttpActionResult PostBank(Bank bank)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bank.InsertTime = DateTime.Now;

            _db.BankRepository.Insert(bank);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = bank.BankId }, bank);
        }

        // DELETE: api/Bank/5
        [ResponseType(typeof(Bank))]
        public IHttpActionResult DeleteBank(int id)
        {
            _db.BankRepository.Delete(id);

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

        private bool BankExists(int id)
        {
            return _db.BankRepository.Get(q => q.BankId == id).Any();
        }
    }
}