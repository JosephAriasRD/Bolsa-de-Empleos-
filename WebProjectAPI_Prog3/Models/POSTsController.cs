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
    public class POSTsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/POSTs
        public IQueryable<POST> GetPOST()
        {
            return db.POST;
        }

        // GET: api/POSTs/5
        [ResponseType(typeof(POST))]
        public IHttpActionResult GetPOST(int id)
        {
            POST pOST = db.POST.Find(id);
            if (pOST == null)
            {
                return NotFound();
            }

            return Ok(pOST);
        }

        // PUT: api/POSTs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPOST(int id, POST pOST)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pOST.ID)
            {
                return BadRequest();
            }

            db.Entry(pOST).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!POSTExists(id))
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

        // POST: api/POSTs
        [ResponseType(typeof(POST))]
        public IHttpActionResult PostPOST(POST pOST)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.POST.Add(pOST);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pOST.ID }, pOST);
        }

        // DELETE: api/POSTs/5
        [ResponseType(typeof(POST))]
        public IHttpActionResult DeletePOST(int id)
        {
            POST pOST = db.POST.Find(id);
            if (pOST == null)
            {
                return NotFound();
            }

            db.POST.Remove(pOST);
            db.SaveChanges();

            return Ok(pOST);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool POSTExists(int id)
        {
            return db.POST.Count(e => e.ID == id) > 0;
        }
    }
}