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
    public class RuokaKommentitController : ApiController
    {
        private RMJFDBEntities db = new RMJFDBEntities();

        // GET: api/RuokaKommentit
        public IQueryable<RuokaKommentit> GetRuokaKommentit()
        {
            return db.RuokaKommentit;
        }

        // GET: api/RuokaKommentit/5
        [ResponseType(typeof(RuokaKommentit))]
        public async Task<IHttpActionResult> GetRuokaKommentit(int id)
        {
            RuokaKommentit ruokaKommentit = await db.RuokaKommentit.FindAsync(id);
            if (ruokaKommentit == null)
            {
                return NotFound();
            }

            return Ok(ruokaKommentit);
        }

        // PUT: api/RuokaKommentit/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRuokaKommentit(int id, RuokaKommentit ruokaKommentit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ruokaKommentit.ruoKommenttiId)
            {
                return BadRequest();
            }

            db.Entry(ruokaKommentit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RuokaKommentitExists(id))
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

        // POST: api/RuokaKommentit
        [ResponseType(typeof(RuokaKommentit))]
        public async Task<IHttpActionResult> PostRuokaKommentit(RuokaKommentit ruokaKommentit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RuokaKommentit.Add(ruokaKommentit);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ruokaKommentit.ruoKommenttiId }, ruokaKommentit);
        }

        // DELETE: api/RuokaKommentit/5
        [ResponseType(typeof(RuokaKommentit))]
        public async Task<IHttpActionResult> DeleteRuokaKommentit(int id)
        {
            RuokaKommentit ruokaKommentit = await db.RuokaKommentit.FindAsync(id);
            if (ruokaKommentit == null)
            {
                return NotFound();
            }

            db.RuokaKommentit.Remove(ruokaKommentit);
            await db.SaveChangesAsync();

            return Ok(ruokaKommentit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RuokaKommentitExists(int id)
        {
            return db.RuokaKommentit.Count(e => e.ruoKommenttiId == id) > 0;
        }
    }
}