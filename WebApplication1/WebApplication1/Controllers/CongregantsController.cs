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
    public class CongregantsController : ApiController
    {
        private ELCSAEntities db = new ELCSAEntities();

        // GET: api/Congregants
        public IQueryable<Congregant> GetCongregants()
        {
            return db.Congregants;
        }

        // GET: api/Congregants/5
        [ResponseType(typeof(Congregant))]
        public IHttpActionResult GetCongregant(int id)
        {
            Congregant congregant = db.Congregants.Find(id);
            if (congregant == null)
            {
                return NotFound();
            }

            return Ok(congregant);
        }

        // PUT: api/Congregants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCongregant(int id, Congregant congregant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != congregant.RegisterNo)
            {
                return BadRequest();
            }

            db.Entry(congregant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongregantExists(id))
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

        // POST: api/Congregants
        [ResponseType(typeof(Congregant))]
        public IHttpActionResult PostCongregant(Congregant congregant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Congregants.Add(congregant);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CongregantExists(congregant.RegisterNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = congregant.RegisterNo }, congregant);
        }

        // DELETE: api/Congregants/5
        [ResponseType(typeof(Congregant))]
        public IHttpActionResult DeleteCongregant(int id)
        {
            Congregant congregant = db.Congregants.Find(id);
            if (congregant == null)
            {
                return NotFound();
            }

            db.Congregants.Remove(congregant);
            db.SaveChanges();

            return Ok(congregant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CongregantExists(int id)
        {
            return db.Congregants.Count(e => e.RegisterNo == id) > 0;
        }
    }
}