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

namespace WebProjectAPI_Prog3.Models
{
    public class USER_ADMINController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/USER_ADMIN
        public IQueryable<USER_ADMIN> GetUSER_ADMIN()
        {
            return db.USER_ADMIN;
        }

        // GET: api/USER_ADMIN/5
        [ResponseType(typeof(USER_ADMIN))]
        public IHttpActionResult GetUSER_ADMIN(int id)
        {
            USER_ADMIN uSER_ADMIN = db.USER_ADMIN.Find(id);
            if (uSER_ADMIN == null)
            {
                return NotFound();
            }

            return Ok(uSER_ADMIN);
        }

        // PUT: api/USER_ADMIN/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUSER_ADMIN(int id, USER_ADMIN uSER_ADMIN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSER_ADMIN.ID)
            {
                return BadRequest();
            }

            db.Entry(uSER_ADMIN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USER_ADMINExists(id))
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

        // POST: api/USER_ADMIN
        [ResponseType(typeof(USER_ADMIN))]
        public IHttpActionResult PostUSER_ADMIN(USER_ADMIN uSER_ADMIN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USER_ADMIN.Add(uSER_ADMIN);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uSER_ADMIN.ID }, uSER_ADMIN);
        }

        // DELETE: api/USER_ADMIN/5
        [ResponseType(typeof(USER_ADMIN))]
        public IHttpActionResult DeleteUSER_ADMIN(int id)
        {
            USER_ADMIN uSER_ADMIN = db.USER_ADMIN.Find(id);
            if (uSER_ADMIN == null)
            {
                return NotFound();
            }

            db.USER_ADMIN.Remove(uSER_ADMIN);
            db.SaveChanges();

            return Ok(uSER_ADMIN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USER_ADMINExists(int id)
        {
            return db.USER_ADMIN.Count(e => e.ID == id) > 0;
        }
    }
}