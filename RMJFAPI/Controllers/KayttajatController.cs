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
    public class KayttajatController : ApiController
    {
        private RMJFDBEntities db = new RMJFDBEntities();

        // GET: api/Kayttajat
        public IQueryable<Kayttajat> GetKayttajat()
        {
            return db.Kayttajat;
        }

        // GET: api/Kayttajat/5
        [ResponseType(typeof(Kayttajat))]
        public async Task<IHttpActionResult> GetKayttajat(int id)
        {
            Kayttajat kayttajat = await db.Kayttajat.FindAsync(id);
            if (kayttajat == null)
            {
                return NotFound();
            }

            return Ok(kayttajat);
        }

        // PUT: api/Kayttajat/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKayttajat(int id, Kayttajat kayttajat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kayttajat.kayttajaId)
            {
                return BadRequest();
            }

            db.Entry(kayttajat).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KayttajatExists(id))
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

        // POST: api/Kayttajat
        [ResponseType(typeof(Kayttajat))]
        public async Task<IHttpActionResult> PostKayttajat(Kayttajat kayttajat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kayttajat.Add(kayttajat);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = kayttajat.kayttajaId }, kayttajat);
        }

        // DELETE: api/Kayttajat/5
        [ResponseType(typeof(Kayttajat))]
        public async Task<IHttpActionResult> DeleteKayttajat(int id)
        {
            Kayttajat kayttajat = await db.Kayttajat.FindAsync(id);
            if (kayttajat == null)
            {
                return NotFound();
            }

            db.Kayttajat.Remove(kayttajat);
            await db.SaveChangesAsync();

            return Ok(kayttajat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KayttajatExists(int id)
        {
            return db.Kayttajat.Count(e => e.kayttajaId == id) > 0;
        }
    }
}