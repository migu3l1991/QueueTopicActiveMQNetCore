using Funciones.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funciones.Database
{
    public class FacturaContext : DbContext
    {
        const string DEFAULT_SCHEMA = "ActiveMQ";
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public FacturaContext(DbContextOptions<FacturaContext> options) : base(options)
        {
            base.Database.EnsureCreated();
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>(ConfigureFacturas);
            modelBuilder.Entity<Producto>(ConfigureProductos);
        }

        private void ConfigureFacturas(EntityTypeBuilder<Factura> requestConfiguration)
        {
            requestConfiguration.ToTable("Facturas", DEFAULT_SCHEMA);

            requestConfiguration.HasKey(facturas => facturas.Id);

            requestConfiguration.Property(facturas => facturas.Nombre)
               .IsRequired()
               .HasMaxLength(30)
               .HasColumnName("Nombre");

            requestConfiguration.Property(facturas => facturas.Cedula)
               .IsRequired()
               .HasMaxLength(12)
               .HasColumnName("Cedula");

            requestConfiguration.Property(facturas => facturas.Correo)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnName("Correo");

            requestConfiguration.Property(facturas => facturas.Estado)
               .IsRequired(false)
               .HasMaxLength(10)
               .HasColumnName("Estado");
        }

        private void ConfigureProductos(EntityTypeBuilder<Producto> requestConfiguration)
        {
            requestConfiguration.ToTable("Productos", DEFAULT_SCHEMA);

            requestConfiguration.HasKey(productos => productos.SKU);

            requestConfiguration.Property(productos => productos.Cantidad)
              .IsRequired()
              .HasMaxLength(6)
              .HasColumnName("Cantidad");

            requestConfiguration.Property(productos => productos.Nombre)
              .IsRequired()
              .HasMaxLength(30)
              .HasColumnName("Nombre");

            requestConfiguration.Property(productos => productos.Precio)
              .IsRequired()
              .HasMaxLength(20)
              .HasColumnName("Precio");

            requestConfiguration.HasOne(productos => productos.Factura)
               .WithMany()
               .HasForeignKey(productos => productos.IdFactura)
               .HasConstraintName("ForeignKey_Producto_Factura");
        }
    }
}