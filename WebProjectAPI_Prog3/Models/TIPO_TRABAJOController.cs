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
    public class TIPO_TRABAJOController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/TIPO_TRABAJO
        public IQueryable<TIPO_TRABAJO> GetTIPO_TRABAJO()
        {
            return db.TIPO_TRABAJO;
        }

        // GET: api/TIPO_TRABAJO/5
        [ResponseType(typeof(TIPO_TRABAJO))]
        public IHttpActionResult GetTIPO_TRABAJO(int id)
        {
            TIPO_TRABAJO tIPO_TRABAJO = db.TIPO_TRABAJO.Find(id);
            if (tIPO_TRABAJO == null)
            {
                return NotFound();
            }

            return Ok(tIPO_TRABAJO);
        }

        // PUT: api/TIPO_TRABAJO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTIPO_TRABAJO(int id, TIPO_TRABAJO tIPO_TRABAJO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tIPO_TRABAJO.ID)
            {
                return BadRequest();
            }

            db.Entry(tIPO_TRABAJO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TIPO_TRABAJOExists(id))
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

        // POST: api/TIPO_TRABAJO
        [ResponseType(typeof(TIPO_TRABAJO))]
        public IHttpActionResult PostTIPO_TRABAJO(TIPO_TRABAJO tIPO_TRABAJO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TIPO_TRABAJO.Add(tIPO_TRABAJO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tIPO_TRABAJO.ID }, tIPO_TRABAJO);
        }

        // DELETE: api/TIPO_TRABAJO/5
        [ResponseType(typeof(TIPO_TRABAJO))]
        public IHttpActionResult DeleteTIPO_TRABAJO(int id)
        {
            TIPO_TRABAJO tIPO_TRABAJO = db.TIPO_TRABAJO.Find(id);
            if (tIPO_TRABAJO == null)
            {
                return NotFound();
            }

            db.TIPO_TRABAJO.Remove(tIPO_TRABAJO);
            db.SaveChanges();

            return Ok(tIPO_TRABAJO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TIPO_TRABAJOExists(int id)
        {
            return db.TIPO_TRABAJO.Count(e => e.ID == id) > 0;
        }
    }
}