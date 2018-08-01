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
using RMJFAPI.Models;

namespace RMJFAPI.Controllers
{
    public class RavintolatController : ApiController
    {
        private RMJFDBEntities db = new RMJFDBEntities();

        // GET: api/Ravintolat
        public IQueryable<Ravintolat> GetRavintolat()
        {
            return db.Ravintolat;
        }

        // GET: api/Ravintolat/5
        [ResponseType(typeof(Ravintolat))]
        public async Task<IHttpActionResult> GetRavintolat(int id)
        {
            Ravintolat ravintolat = await db.Ravintolat.FindAsync(id);
            if (ravintolat == null)
            {
                return NotFound();
            }

            return Ok(ravintolat);
        }

        // PUT: api/Ravintolat/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRavintolat(int id, Ravintolat ravintolat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ravintolat.ravintolaId)
            {
                return BadRequest();
            }

            db.Entry(ravintolat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RavintolatExists(id))
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

        // POST: api/Ravintolat
        [ResponseType(typeof(Ravintolat))]
        public async Task<IHttpActionResult> PostRavintolat(Ravintolat ravintolat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ravintolat.Add(ravintolat);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ravintolat.ravintolaId }, ravintolat);
        }

        // DELETE: api/Ravintolat/5
        [ResponseType(typeof(Ravintolat))]
        public async Task<IHttpActionResult> DeleteRavintolat(int id)
        {
            Ravintolat ravintolat = await db.Ravintolat.FindAsync(id);
            if (ravintolat == null)
            {
                return NotFound();
            }

            db.Ravintolat.Remove(ravintolat);
            await db.SaveChangesAsync();

            return Ok(ravintolat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RavintolatExists(int id)
        {
            return db.Ravintolat.Count(e => e.ravintolaId == id) > 0;
        }
    }
}