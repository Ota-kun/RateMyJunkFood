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
    public class RuokaController : ApiController
    {
        private RMJFDBEntities db = new RMJFDBEntities();

        // GET: api/Ruoka
        public IQueryable<Ruoka> GetRuoka()
        {
            return db.Ruoka;
        }

        // GET: api/Ruoka/5
        [ResponseType(typeof(Ruoka))]
        public async Task<IHttpActionResult> GetRuoka(int id)
        {
            Ruoka ruoka = await db.Ruoka.FindAsync(id);
            if (ruoka == null)
            {
                return NotFound();
            }

            return Ok(ruoka);
        }

        // PUT: api/Ruoka/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRuoka(int id, Ruoka ruoka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ruoka.ruokaId)
            {
                return BadRequest();
            }

            db.Entry(ruoka).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RuokaExists(id))
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

        // POST: api/Ruoka
        [ResponseType(typeof(Ruoka))]
        public async Task<IHttpActionResult> PostRuoka(Ruoka ruoka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ruoka.Add(ruoka);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ruoka.ruokaId }, ruoka);
        }

        // DELETE: api/Ruoka/5
        [ResponseType(typeof(Ruoka))]
        public async Task<IHttpActionResult> DeleteRuoka(int id)
        {
            Ruoka ruoka = await db.Ruoka.FindAsync(id);
            if (ruoka == null)
            {
                return NotFound();
            }

            db.Ruoka.Remove(ruoka);
            await db.SaveChangesAsync();

            return Ok(ruoka);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RuokaExists(int id)
        {
            return db.Ruoka.Count(e => e.ruokaId == id) > 0;
        }
    }
}