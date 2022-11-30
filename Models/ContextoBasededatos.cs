using System;
using Microsoft.EntityFrameworkCore;
namespace proyecto_aula.Models
{
    public class ContextoBasededatos : DbContext
    {
        public ContextoBasededatos(DbContextOptions<ContextoBasededatos> opt) : base(opt) { }
        public DbSet<Post> Post { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Prestamo> Prestamo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Bibliotecario> Bibliotecario { get; set; }
    }
}
