using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagos.Application.CasosUso.AdministrarProductos.ConsultarProductos
{
    public class RealizarPagosValidator : AbstractValidator<RealizarPagosRequest>
    {
        public RealizarPagosValidator()
        {
            RuleFor(item => item.IdVenta).GreaterThan(0).WithMessage("Debe especificar el código de la venta");
            RuleFor(item => item.Fecha).NotEmpty().WithMessage("Debe especificar la fecha de la venta");
            RuleFor(item => item.Monto).GreaterThan(0).WithMessage("Debe especificar el monto de la venta");
            RuleFor(item => item.FormaPago).NotEmpty().WithMessage("Debe especificar la forma de pago de la venta");
            //RuleFor(item => item.NumeroTarjeta).SetValidator(item => item.FormaPago > 2).WithMessage("Debe tener por lo menos un iten");
            When(item => item.FormaPago < 3, () => { RuleFor(item => item.NumeroTarjeta).NotEmpty().WithMessage("Debe especificar el número de tarjeta");});
            When(item => item.FormaPago < 3, () => { RuleFor(item => item.FechaVencimiento).NotEmpty().WithMessage("Debe especificar la fecha de vencimiento de la tarjeta"); });
            When(item => item.FormaPago < 3, () => { RuleFor(item => item.CVV).NotEmpty().WithMessage("Debe especificar el CVV de la tarjeta"); });
            When(item => item.FormaPago < 3, () => { RuleFor(item => item.NombreTitular).NotEmpty().WithMessage("Debe especificar el nombre del titular de la tarjeta"); });
            When(item => item.FormaPago < 3, () => { RuleFor(item => item.NumeroCuotas).GreaterThan(0).WithMessage("Debe especificar el número de cuotas"); });
        }
    }
}
