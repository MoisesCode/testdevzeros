using Microsoft.EntityFrameworkCore;
using System;
using entity;

namespace dal
{
    public class TestWebContext : DbContext
    {
        public TestWebContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Detalle> Detalles { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Interesado> Interesados { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
