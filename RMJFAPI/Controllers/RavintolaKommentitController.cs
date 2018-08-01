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
    public class RavintolaKommentitController : ApiController
    {
        private RMJFDBEntities db = new RMJFDBEntities();

        // GET: api/RavintolaKommentit
        public IQueryable<RavintolaKommentit> GetRavintolaKommentit()
        {
            return db.RavintolaKommentit;
        }

        // GET: api/RavintolaKommentit/5
        [ResponseType(typeof(RavintolaKommentit))]
        public async Task<IHttpActionResult> GetRavintolaKommentit(int id)
        {
            RavintolaKommentit ravintolaKommentit = await db.RavintolaKommentit.FindAsync(id);
            if (ravintolaKommentit == null)
            {
                return NotFound();
            }

            return Ok(ravintolaKommentit);
        }

        // PUT: api/RavintolaKommentit/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRavintolaKommentit(int id, RavintolaKommentit ravintolaKommentit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ravintolaKommentit.ravKommenttiID)
            {
                return BadRequest();
            }

            db.Entry(ravintolaKommentit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RavintolaKommentitExists(id))
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

        // POST: api/RavintolaKommentit
        [ResponseType(typeof(RavintolaKommentit))]
        public async Task<IHttpActionResult> PostRavintolaKommentit(RavintolaKommentit ravintolaKommentit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RavintolaKommentit.Add(ravintolaKommentit);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ravintolaKommentit.ravKommenttiID }, ravintolaKommentit);
        }

        // DELETE: api/RavintolaKommentit/5
        [ResponseType(typeof(RavintolaKommentit))]
        public async Task<IHttpActionResult> DeleteRavintolaKommentit(int id)
        {
            RavintolaKommentit ravintolaKommentit = await db.RavintolaKommentit.FindAsync(id);
            if (ravintolaKommentit == null)
            {
                return NotFound();
            }

            db.RavintolaKommentit.Remove(ravintolaKommentit);
            await db.SaveChangesAsync();

            return Ok(ravintolaKommentit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RavintolaKommentitExists(int id)
        {
            return db.RavintolaKommentit.Count(e => e.ravKommenttiID == id) > 0;
        }
    }
}