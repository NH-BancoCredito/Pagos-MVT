using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pagos.Application.CasosUso.AdministrarProductos.ConsultarProductos;

namespace Pagos.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PagosController(IMediator mediator)
        {
            _mediator = mediator;
        }        

        [HttpPut("realizarPago")]
        public async Task<IActionResult> RealizarPago([FromBody] RealizarPagosRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
        
    }
}
