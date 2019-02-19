using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DiplomadoMVC.Data
{
    public class DiplomadoDbContext : DbContext
    {
        public DiplomadoDbContext() 
            : base("DefaultConnectionData")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }        
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Formato> Formatos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<AlquilerDetalle> AlquilerDetalles { get; set; }
        public DbSet<AlquilerEstado> AlquilerEstados { get; set; }
        public DbSet<Reparto> Repartos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Comentario>().HasRequired(c => c.Usuario);
            //modelBuilder.Entity<Comentario>().HasRequired(c => c.Entrada);

            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}