using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagos.Infrastructure.Repositories.Base
{
    public class PagoDbContext: DbContext
    {
        public PagoDbContext(DbContextOptions<PagoDbContext> options)
            : base(options)
        {            

        }

        public virtual DbSet<Domain.Models.Pago> Pago { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            #region Configuraando las entidades en archivos de tipos separados
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PagoDbContext).Assembly);
            #endregion

            #region Configuracion de las entidades en el mismo ModelCreating
            //modelBuilder.Entity<Categoria>(
            //    p =>
            //    {
            //        p.ToTable("Categoria");
            //        p.HasKey(c => c.IdCategoria);
            //        //p.Property(p => p.Nombre).HasColumnName("Nombre");
            //    }
            //    );


            //modelBuilder.Entity<Cliente>(
            //    p =>
            //    {
            //        p.ToTable("Cliente");
            //        p.HasKey(c => c.IdCliente);
            //    }
            //    );

            //modelBuilder.Entity<Producto>(
            //    p =>
            //    {
            //        p.ToTable("Producto");
            //        p.HasKey(c => c.IdProducto);
            //        p.Property(c => c.PrecioUnitario).HasPrecision(2);

            //        p.HasOne(p => p.Categoria).WithMany(p => p.Productos)
            //            .HasForeignKey(p => p.IdCategoria);
            //    }                
            //    );


            //modelBuilder.Entity<Domain.Models.Venta>(
            //   p =>
            //   {
            //       p.ToTable("Venta");
            //       p.HasKey(c => c.IdVenta);

            //       p.HasOne(p => p.Cliente).WithMany(p => p.Ventas)
            //            .HasForeignKey(p => p.IdCliente);
            //   }
            //   );


            //modelBuilder.Entity<Domain.Models.VentaDetalle>(
            //   p =>
            //   {
            //       p.ToTable("VentaDetalle");
            //       p.HasKey(c => c.IdVentaDetalle);

            //       p.HasOne(p => p.Venta).WithMany(p => p.Detalle)
            //            .HasForeignKey(p => p.IdVenta);

            //       p.HasOne(p => p.Producto).WithMany(p => p.VentaDetalles)
            //           .HasForeignKey(p => p.IdProducto);
            //   }
            //   );

            #endregion


        }
    }
}
