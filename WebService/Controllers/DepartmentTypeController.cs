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
    public class DepartmentTypeController : ApiController
    {
        private readonly UnitOfWork _db = new UnitOfWork();

        // GET: api/DepartmentType
        public IEnumerable<DepartmentType> GetDepartmentTypes()
        {
            return _db.DepartmentTypeRepository.Get();
        }

        // GET: api/DepartmentType/5
        [ResponseType(typeof(DepartmentType))]
        public IHttpActionResult GetDepartmentType(int id)
        {
            DepartmentType DepartmentType = _db.DepartmentTypeRepository.GetById(id);
            if (DepartmentType == null)
            {
                return NotFound();
            }

            return Ok(DepartmentType);
        }

        // PUT: api/DepartmentType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartmentType(int id, DepartmentType DepartmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != DepartmentType.DepartmentTypeId)
            {
                return BadRequest();
            }

            DepartmentType.UpdateTime = DateTime.Now;
            DepartmentType.UpdateUserId = 1;

            _db.DepartmentTypeRepository.Update(DepartmentType);

            try
            {
                _db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentTypeExists(id))
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

        // POST: api/DepartmentType
        [ResponseType(typeof(DepartmentType))]
        public IHttpActionResult PostDepartmentType(DepartmentType DepartmentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DepartmentType.InsertTime = DateTime.Now;

            _db.DepartmentTypeRepository.Insert(DepartmentType);
            _db.Save();

            return CreatedAtRoute("DefaultApi", new { id = DepartmentType.DepartmentTypeId }, DepartmentType);
        }

        // DELETE: api/DepartmentType/5
        [ResponseType(typeof(DepartmentType))]
        public IHttpActionResult DeleteDepartmentType(int id)
        {
            _db.DepartmentTypeRepository.Delete(id);

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

        private bool DepartmentTypeExists(int id)
        {
            return _db.DepartmentTypeRepository.Get(q => q.DepartmentTypeId == id).Any();
        }
    }
}