using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pagos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagos.Infrastructure.Repositories.Base.EFConfigurations
{
    public class PagoEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Models.Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("Pago");
            builder.HasKey(c => c.IdPago);
            //builder.Property(c => c.Monto).HasPrecision(2);
            //builder.HasOne(p => p.).WithMany(p => p.Ventas).HasForeignKey(p => p.IdCliente);
        }
    }
}
