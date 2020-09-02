using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIsparn.Models;
using System.Web.Http.Description;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace APIsparn.Controllers
{
    public class LoginController : ApiController
    {
        private SPAEntitiesrn db = new SPAEntitiesrn();

        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }


        [ResponseType(typeof(USER))]
        public IHttpActionResult GetLogin(string username, string password)
        {
            var user = db.USERS.Where(x => x.USERNAME == username && x.PASSWORDS == password).Select(x => x.ID);

            USER uSER = db.USERS.Find(user.FirstOrDefault());

            if (uSER == null)
            {
                return NotFound();
            }
            else
            {

                return Ok(uSER);
            }
        }

        // POST: api/Login
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
