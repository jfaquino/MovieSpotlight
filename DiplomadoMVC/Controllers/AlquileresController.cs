using DiplomadoMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DiplomadoMVC.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AlquileresController : Controller
    {
        private DiplomadoDbContext db = new DiplomadoDbContext();
        // GET: Alquileres
        public ActionResult Index()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "Id", "Nombre");
            ViewBag.IdPelicula = new SelectList(db.Peliculas, "Id", "Titulo");

            return View(db.Alquileres
                .Include(c => c.Cliente)
                .Include(a => a.AlquilerDetalles).ToList());
        }

        public JsonResult GetPeliculaData(int id, int cantidad, int dias)
        {
            var pelicula = db.Peliculas.Find(id);
            var amount = pelicula.Precio * cantidad * dias;

            return Json(new { id, pelicula.Titulo, pelicula.Precio, cantidad, dias, amount }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveAlquiler(int idCliente, Orden[] orden)
        {
            var result = "Vacío.";

            if(orden != null)
            {
                var cliente = db.Clientes.FirstOrDefault(c => c.Id == idCliente);
                decimal total = 0;

                var alquiler = new Alquiler
                {
                    Fecha = DateTime.Now,
                    Cliente = cliente
                };                

                foreach (var peli in orden)
                {                    
                    var pelicula = db.Peliculas.Find(peli.Id);
                    total = pelicula.Precio * peli.Cantidad * peli.Dias;

                    var alquilerDetalle = new AlquilerDetalle
                    {
                       Precio = pelicula.Precio,
                       Cantidad = peli.Cantidad,
                       Dias = peli.Dias,
                       Alquiler = alquiler,
                       Pelicula = pelicula
                    };
                    
                    db.AlquilerDetalles.Add(alquilerDetalle);
                }

                alquiler.Total = total;
                alquiler.Observaciones = "Ninguna.";

                db.Alquileres.Add(alquiler);
                db.SaveChanges();

                result = "¡Procesado!";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public class Orden
        {
            public int Id { get; set; }
            public int Cantidad { get; set; }
            public int Dias { get; set; }
        }
    }
}