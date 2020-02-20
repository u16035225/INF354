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
    public class Parish2_0Controller : ApiController
    {
        private ELCSAEntities db = new ELCSAEntities();

        // GET: api/Parish2_0
        public IQueryable<Parish2_0> GetParish2_0()
        {
            return db.Parish2_0;
        }

        // GET: api/Parish2_0/5
        [ResponseType(typeof(Parish2_0))]
        public IHttpActionResult GetParish2_0(int id)
        {
            Parish2_0 parish2_0 = db.Parish2_0.Find(id);
            if (parish2_0 == null)
            {
                return NotFound();
            }

            return Ok(parish2_0);
        }

        // PUT: api/Parish2_0/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParish2_0(int id, Parish2_0 parish2_0)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parish2_0.RegisterID)
            {
                return BadRequest();
            }

            db.Entry(parish2_0).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Parish2_0Exists(id))
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

        // POST: api/Parish2_0
        [ResponseType(typeof(Parish2_0))]
        public IHttpActionResult PostParish2_0(Parish2_0 parish2_0)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parish2_0.Add(parish2_0);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Parish2_0Exists(parish2_0.RegisterID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = parish2_0.RegisterID }, parish2_0);
        }

        // DELETE: api/Parish2_0/5
        [ResponseType(typeof(Parish2_0))]
        public IHttpActionResult DeleteParish2_0(int id)
        {
            Parish2_0 parish2_0 = db.Parish2_0.Find(id);
            if (parish2_0 == null)
            {
                return NotFound();
            }

            db.Parish2_0.Remove(parish2_0);
            db.SaveChanges();

            return Ok(parish2_0);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Parish2_0Exists(int id)
        {
            return db.Parish2_0.Count(e => e.RegisterID == id) > 0;
        }
    }
}