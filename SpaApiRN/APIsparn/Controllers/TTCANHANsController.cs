using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using APIsparn.Models;

namespace APIsparn.Controllers
{
    public class TTCANHANsController : ApiController
    {
        private SPAEntitiesrn db = new SPAEntitiesrn();

        // GET: api/TTCANHANs
        public IQueryable<TTCANHAN> GetTTCANHANs()
        {
            return db.TTCANHANs;
        }

        // GET: api/TTCANHANs/5
        [ResponseType(typeof(TTCANHAN))]
        public IHttpActionResult GetTTCANHAN(int id)
        {
            TTCANHAN tTCANHAN = db.TTCANHANs.Find(id);
            if (tTCANHAN == null)
            {
                return NotFound();
            }

            return Ok(tTCANHAN);
        }

        // PUT: api/TTCANHANs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTTCANHAN(int id, TTCANHAN tTCANHAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tTCANHAN.ID_USER)
            {
                return BadRequest();
            }

            db.Entry(tTCANHAN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TTCANHANExists(id))
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

        // POST: api/TTCANHANs
        [ResponseType(typeof(TTCANHAN))]
        public IHttpActionResult PostTTCANHAN(TTCANHAN tTCANHAN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TTCANHANs.Add(tTCANHAN);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TTCANHANExists(tTCANHAN.ID_USER))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tTCANHAN.ID_USER }, tTCANHAN);
        }

        // DELETE: api/TTCANHANs/5
        [ResponseType(typeof(TTCANHAN))]
        public IHttpActionResult DeleteTTCANHAN(int id)
        {
            TTCANHAN tTCANHAN = db.TTCANHANs.Find(id);
            if (tTCANHAN == null)
            {
                return NotFound();
            }

            db.TTCANHANs.Remove(tTCANHAN);
            db.SaveChanges();

            return Ok(tTCANHAN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TTCANHANExists(int id)
        {
            return db.TTCANHANs.Count(e => e.ID_USER == id) > 0;
        }


        
    }
}