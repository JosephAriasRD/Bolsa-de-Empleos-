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
    public class USER_POSTERController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/USER_POSTER
        public IQueryable<USER_POSTER> GetUSER_POSTER()
        {
            return db.USER_POSTER;
        }

        // GET: api/USER_POSTER/5
        [ResponseType(typeof(USER_POSTER))]
        public IHttpActionResult GetUSER_POSTER(int id)
        {
            USER_POSTER uSER_POSTER = db.USER_POSTER.Find(id);
            if (uSER_POSTER == null)
            {
                return NotFound();
            }

            return Ok(uSER_POSTER);
        }

        // PUT: api/USER_POSTER/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUSER_POSTER(int id, USER_POSTER uSER_POSTER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSER_POSTER.ID)
            {
                return BadRequest();
            }

            db.Entry(uSER_POSTER).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USER_POSTERExists(id))
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

        // POST: api/USER_POSTER
        [ResponseType(typeof(USER_POSTER))]
        public IHttpActionResult PostUSER_POSTER(USER_POSTER uSER_POSTER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USER_POSTER.Add(uSER_POSTER);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uSER_POSTER.ID }, uSER_POSTER);
        }

        // DELETE: api/USER_POSTER/5
        [ResponseType(typeof(USER_POSTER))]
        public IHttpActionResult DeleteUSER_POSTER(int id)
        {
            USER_POSTER uSER_POSTER = db.USER_POSTER.Find(id);
            if (uSER_POSTER == null)
            {
                return NotFound();
            }

            db.USER_POSTER.Remove(uSER_POSTER);
            db.SaveChanges();

            return Ok(uSER_POSTER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USER_POSTERExists(int id)
        {
            return db.USER_POSTER.Count(e => e.ID == id) > 0;
        }
    }
}