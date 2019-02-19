using DiplomadoMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DiplomadoMVC.Controllers
{
    public class HomeController : Controller
    {
        private DiplomadoDbContext db = new DiplomadoDbContext();
        public ActionResult Index()
        {
            ViewBag.Fondo = "/Tools/57fcaf98bbe5eb9d672d485a_Photo-10.jpg";
            ViewBag.Texto = "MovieSpotlight";

            return View(db.Peliculas.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pelicula = db.Peliculas
                .Include(p => p.Formato)
                .Include(p => p.Genero)
                .SingleOrDefault(p => p.Id == id);

            if (pelicula == null) return HttpNotFound();

            ViewBag.Fondo = $"/Images/{pelicula.Foto}";
            ViewBag.Texto = pelicula.Titulo;

            return View(pelicula);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}