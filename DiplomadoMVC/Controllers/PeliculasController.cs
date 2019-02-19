using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomadoMVC.Data;

namespace DiplomadoMVC.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class PeliculasController : Controller
    {
        private DiplomadoDbContext db = new DiplomadoDbContext();

        // GET: Peliculas
        public ActionResult Index()
        {
            var peliculas = db.Peliculas.Include(p => p.Formato).Include(p => p.Genero);
            return View(peliculas.ToList());
        }

        // GET: Peliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pelicula pelicula = db.Peliculas
                .Include(p => p.Formato)
                .Include(p => p.Genero)
                .SingleOrDefault(p => p.Id == id);

            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            ViewBag.IdFormato = new SelectList(db.Formatos, "Id", "Nombre");
            ViewBag.IdGenero = new SelectList(db.Generos, "Id", "Nombre");
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdFormato,IdGenero,Titulo,Descripcion,Anio,Sinopsis,Precio,Puntuacion")] Pelicula pelicula, HttpPostedFileBase fileBase)
        {
            if(fileBase != null)
            {
                var imageName = Path.GetFileName(fileBase.FileName);
                var localPath = Server.MapPath($"~/Images/{imageName}");
                fileBase.SaveAs(localPath);

                pelicula.Foto = imageName;

                if (ModelState.IsValid)
                {
                    db.Peliculas.Add(pelicula);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
                ModelState.AddModelError("", "Debe seleccionar una imagen para el Estudiante");

            ViewBag.IdFormato = new SelectList(db.Formatos, "Id", "Nombre", pelicula.IdFormato);
            ViewBag.IdGenero = new SelectList(db.Generos, "Id", "Nombre", pelicula.IdGenero);

            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFormato = new SelectList(db.Formatos, "Id", "Nombre", pelicula.IdFormato);
            ViewBag.IdGenero = new SelectList(db.Generos, "Id", "Nombre", pelicula.IdGenero);
            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdFormato,IdGenero,Titulo,Descripcion,Anio,Sinopsis,Precio,Puntuacion,Foto")] Pelicula pelicula, HttpPostedFileBase fileBase)
        {
            if (fileBase != null)
            {
                var imageName = Path.GetFileName(fileBase.FileName);
                var localPath = Server.MapPath($"~/Images/{imageName}");
                fileBase.SaveAs(localPath);

                pelicula.Foto = imageName;
            }

            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFormato = new SelectList(db.Formatos, "Id", "Nombre", pelicula.IdFormato);
            ViewBag.IdGenero = new SelectList(db.Generos, "Id", "Nombre", pelicula.IdGenero);
            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pelicula pelicula = db.Peliculas
                .Include(p => p.Formato)
                .Include(p => p.Genero)
                .SingleOrDefault(p => p.Id == id);

            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            db.Peliculas.Remove(pelicula);
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
