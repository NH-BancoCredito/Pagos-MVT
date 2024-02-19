using Pagos.Domain.Models;
using Pagos.Domain.Repositories;
using Pagos.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagos.Infrastructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly PagoDbContext _context;
        public PagoRepository(PagoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Realizar(Pago pago)
        {
            //throw new NotImplementedException();
            _context.Pago.Add(pago);

            await _context.SaveChangesAsync(); //INSERT VENTA() VALUES(.....)

            return pago.IdPago > 0;
        }
    }
}
