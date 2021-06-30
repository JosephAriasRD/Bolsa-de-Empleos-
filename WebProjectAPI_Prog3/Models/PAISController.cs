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
    public class PAISController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/PAIS
        public IQueryable<PAIS> GetPAIS()
        {
            return db.PAIS;
        }

        // GET: api/PAIS/5
        [ResponseType(typeof(PAIS))]
        public IHttpActionResult GetPAIS(int id)
        {
            PAIS pAIS = db.PAIS.Find(id);
            if (pAIS == null)
            {
                return NotFound();
            }

            return Ok(pAIS);
        }

        // PUT: api/PAIS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPAIS(int id, PAIS pAIS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pAIS.ID)
            {
                return BadRequest();
            }

            db.Entry(pAIS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PAISExists(id))
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

        // POST: api/PAIS
        [ResponseType(typeof(PAIS))]
        public IHttpActionResult PostPAIS(PAIS pAIS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PAIS.Add(pAIS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pAIS.ID }, pAIS);
        }

        // DELETE: api/PAIS/5
        [ResponseType(typeof(PAIS))]
        public IHttpActionResult DeletePAIS(int id)
        {
            PAIS pAIS = db.PAIS.Find(id);
            if (pAIS == null)
            {
                return NotFound();
            }

            db.PAIS.Remove(pAIS);
            db.SaveChanges();

            return Ok(pAIS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PAISExists(int id)
        {
            return db.PAIS.Count(e => e.ID == id) > 0;
        }
    }
}