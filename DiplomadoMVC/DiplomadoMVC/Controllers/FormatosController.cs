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
    public class FormatosController : Controller
    {
        private DiplomadoDbContext db = new DiplomadoDbContext();

        // GET: Formatos
        public ActionResult Index()
        {
            return View(db.Formatos.ToList());
        }

        // GET: Formatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formato formato = db.Formatos.Find(id);
            if (formato == null)
            {
                return HttpNotFound();
            }
            return View(formato);
        }

        // GET: Formatos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion")] Formato formato)
        {
            if (ModelState.IsValid)
            {
                db.Formatos.Add(formato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formato);
        }

        // GET: Formatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formato formato = db.Formatos.Find(id);
            if (formato == null)
            {
                return HttpNotFound();
            }
            return View(formato);
        }

        // POST: Formatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion")] Formato formato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formato);
        }

        // GET: Formatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formato formato = db.Formatos.Find(id);
            if (formato == null)
            {
                return HttpNotFound();
            }
            return View(formato);
        }

        // POST: Formatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formato formato = db.Formatos.Find(id);
            db.Formatos.Remove(formato);
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
