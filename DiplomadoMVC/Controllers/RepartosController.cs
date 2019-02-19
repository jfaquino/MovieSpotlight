using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomadoMVC.Data;

namespace DiplomadoMVC.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class RepartosController : Controller
    {
        private DiplomadoDbContext db = new DiplomadoDbContext();

        // GET: Repartos
        public ActionResult Index()
        {
            var repartos = db.Repartos.Include(r => r.Actor).Include(r => r.Pelicula);
            return View(repartos.ToList());
        }

        // GET: Repartos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reparto reparto = db.Repartos
                .Include(r => r.Actor)
                .Include(r => r.Pelicula)
                .FirstOrDefault(r => r.Id == id);

            if (reparto == null)
            {
                return HttpNotFound();
            }
            return View(reparto);
        }

        // GET: Repartos/Create
        public ActionResult Create()
        {
            ViewBag.IdActor = new SelectList(db.Actores, "Id", "Nombre");
            ViewBag.IdPelicula = new SelectList(db.Peliculas, "Id", "Titulo");
            return View();
        }

        // POST: Repartos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdPelicula,IdActor")] Reparto reparto)
        {
            if (ModelState.IsValid)
            {
                db.Repartos.Add(reparto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdActor = new SelectList(db.Actores, "Id", "Nombre", reparto.IdActor);
            ViewBag.IdPelicula = new SelectList(db.Peliculas, "Id", "Titulo", reparto.IdPelicula);
            return View(reparto);
        }

        // GET: Repartos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Reparto reparto = db.Repartos
                .Include(r => r.Actor)
                .Include(r => r.Pelicula)
                .FirstOrDefault(r => r.Id == id);

            if (reparto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdActor = new SelectList(db.Actores, "Id", "Nombre", reparto.IdActor);
            ViewBag.IdPelicula = new SelectList(db.Peliculas, "Id", "Titulo", reparto.IdPelicula);
            return View(reparto);
        }

        // POST: Repartos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdPelicula,IdActor")] Reparto reparto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reparto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdActor = new SelectList(db.Actores, "Id", "Nombre", reparto.IdActor);
            ViewBag.IdPelicula = new SelectList(db.Peliculas, "Id", "Titulo", reparto.IdPelicula);
            return View(reparto);
        }

        // GET: Repartos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparto reparto = db.Repartos.Find(id);
            if (reparto == null)
            {
                return HttpNotFound();
            }
            return View(reparto);
        }

        // POST: Repartos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reparto reparto = db.Repartos.Find(id);
            db.Repartos.Remove(reparto);
            db.SaveChanges();
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
