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
using APIsparn.Models;

namespace APIsparn.Controllers
{
    public class USERsController : ApiController
    {
        private SPAEntitiesrn db = new SPAEntitiesrn();

        // GET: api/USERs
        public IQueryable<USER> GetUSERS()
        {
            return db.USERS;
        }

        // GET: api/USERs/5
        [ResponseType(typeof(USER))]
        public IHttpActionResult GetUSER(int id)
        {
            USER uSER = db.USERS.Find(id);
            if (uSER == null)
            {
                return NotFound();
            }

            return Ok(uSER);
        }



        // PUT: api/USERs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUSER(int id, USER uSER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSER.ID)
            {
                return BadRequest();
            }

            db.Entry(uSER).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USERExists(id))
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


        [ResponseType(typeof(void))]
        public IHttpActionResult PostUSER(string uname, string pword, string name, bool sex, DateTime dob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            USER u = new USER();
            u.USERNAME = uname;
            u.PASSWORDS = pword;

            db.USERS.Add(u);
            db.SaveChanges();

            TTCANHAN info = new TTCANHAN();
            info.HOTEN = name;
            info.NGAYSINH = dob;
            info.GIOITINH = sex;
            db.TTCANHANs.Add(info);
            db.SaveChanges();

            return Ok();
        }

        /*

        // POST: api/USERs
        [ResponseType(typeof(USER))]
        public IHttpActionResult PostUSER(USER uSER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USERS.Add(uSER);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uSER.ID }, uSER);
        }

        */

        // DELETE: api/USERs/5
        [ResponseType(typeof(USER))]
        public IHttpActionResult DeleteUSER(int id)
        {
            USER uSER = db.USERS.Find(id);
            if (uSER == null)
            {
                return NotFound();
            }

            db.USERS.Remove(uSER);
            db.SaveChanges();

            return Ok(uSER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USERExists(int id)
        {
            return db.USERS.Count(e => e.ID == id) > 0;
        }
    }
}