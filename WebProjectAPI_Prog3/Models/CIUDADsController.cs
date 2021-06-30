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
    public class CIUDADsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/CIUDADs
        public IQueryable<CIUDAD> GetCIUDAD()
        {
            return db.CIUDAD;
        }

        // GET: api/CIUDADs/5
        [ResponseType(typeof(CIUDAD))]
        public IHttpActionResult GetCIUDAD(int id)
        {
            CIUDAD cIUDAD = db.CIUDAD.Find(id);
            if (cIUDAD == null)
            {
                return NotFound();
            }

            return Ok(cIUDAD);
        }

        // PUT: api/CIUDADs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCIUDAD(int id, CIUDAD cIUDAD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cIUDAD.ID)
            {
                return BadRequest();
            }

            db.Entry(cIUDAD).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CIUDADExists(id))
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

        // POST: api/CIUDADs
        [ResponseType(typeof(CIUDAD))]
        public IHttpActionResult PostCIUDAD(CIUDAD cIUDAD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CIUDAD.Add(cIUDAD);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cIUDAD.ID }, cIUDAD);
        }

        // DELETE: api/CIUDADs/5
        [ResponseType(typeof(CIUDAD))]
        public IHttpActionResult DeleteCIUDAD(int id)
        {
            CIUDAD cIUDAD = db.CIUDAD.Find(id);
            if (cIUDAD == null)
            {
                return NotFound();
            }

            db.CIUDAD.Remove(cIUDAD);
            db.SaveChanges();

            return Ok(cIUDAD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CIUDADExists(int id)
        {
            return db.CIUDAD.Count(e => e.ID == id) > 0;
        }
    }
}