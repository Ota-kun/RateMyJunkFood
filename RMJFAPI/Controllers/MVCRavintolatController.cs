using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RMJFAPI.Models;

namespace RMJFAPI.Controllers
{
    public class MVCRavintolatController : Controller
    {
        private RMJFDBEntities db = new RMJFDBEntities();

        // GET: MVCRavintolat
        public async Task<ActionResult> Index()
        {
            var ravintolat = db.Ravintolat.Include(r => r.Kayttajat);
            return View(await ravintolat.ToListAsync());
        }

        // GET: MVCRavintolat/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ravintolat ravintolat = await db.Ravintolat.FindAsync(id);
            if (ravintolat == null)
            {
                return HttpNotFound();
            }
            return View(ravintolat);
        }

        // GET: MVCRavintolat/Create
        public ActionResult Create()
        {
            ViewBag.kayttajaId = new SelectList(db.Kayttajat, "kayttajaId", "nimimerkki");
            return View();
        }

        // POST: MVCRavintolat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ravintolaId,ravintolanNimi,kayttajaId,osoite,ravintolaAvaa,ravintolaSulkee,ratingDarra,ratingKanni,myyjat,kuva,alkoholi")] Ravintolat ravintolat)
        {
            if (ModelState.IsValid)
            {
                db.Ravintolat.Add(ravintolat);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.kayttajaId = new SelectList(db.Kayttajat, "kayttajaId", "nimimerkki", ravintolat.kayttajaId);
            return View(ravintolat);
        }

        // GET: MVCRavintolat/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ravintolat ravintolat = await db.Ravintolat.FindAsync(id);
            if (ravintolat == null)
            {
                return HttpNotFound();
            }
            ViewBag.kayttajaId = new SelectList(db.Kayttajat, "kayttajaId", "nimimerkki", ravintolat.kayttajaId);
            return View(ravintolat);
        }

        // POST: MVCRavintolat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ravintolaId,ravintolanNimi,kayttajaId,osoite,ravintolaAvaa,ravintolaSulkee,ratingDarra,ratingKanni,myyjat,kuva,alkoholi")] Ravintolat ravintolat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ravintolat).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.kayttajaId = new SelectList(db.Kayttajat, "kayttajaId", "nimimerkki", ravintolat.kayttajaId);
            return View(ravintolat);
        }

        // GET: MVCRavintolat/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ravintolat ravintolat = await db.Ravintolat.FindAsync(id);
            if (ravintolat == null)
            {
                return HttpNotFound();
            }
            return View(ravintolat);
        }

        // POST: MVCRavintolat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ravintolat ravintolat = await db.Ravintolat.FindAsync(id);
            db.Ravintolat.Remove(ravintolat);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
