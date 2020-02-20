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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PastorsController : ApiController
    {
        private ELCSAEntities db = new ELCSAEntities();

        // GET: api/Pastors
        public IQueryable<Pastor> GetPastors()
        {
            return db.Pastors;
        }

        // GET: api/Pastors/5
        [ResponseType(typeof(Pastor))]
        public IHttpActionResult GetPastor(int id)
        {
            Pastor pastor = db.Pastors.Find(id);
            if (pastor == null)
            {
                return NotFound();
            }

            return Ok(pastor);
        }

        // PUT: api/Pastors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPastor(int id, Pastor pastor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pastor.RegisterNo)
            {
                return BadRequest();
            }

            db.Entry(pastor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastorExists(id))
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

        // POST: api/Pastors
        [ResponseType(typeof(Pastor))]
        public IHttpActionResult PostPastor(Pastor pastor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pastors.Add(pastor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PastorExists(pastor.RegisterNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pastor.RegisterNo }, pastor);
        }

        // DELETE: api/Pastors/5
        [ResponseType(typeof(Pastor))]
        public IHttpActionResult DeletePastor(int id)
        {
            Pastor pastor = db.Pastors.Find(id);
            if (pastor == null)
            {
                return NotFound();
            }

            db.Pastors.Remove(pastor);
            db.SaveChanges();

            return Ok(pastor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PastorExists(int id)
        {
            return db.Pastors.Count(e => e.RegisterNo == id) > 0;
        }
    }
}