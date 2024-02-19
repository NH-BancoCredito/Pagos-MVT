using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pagos.Application.Common;
using Pagos.Domain.Repositories;
using Pagos.Domain.Service.Events;
using MongoDB.Bson.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Reflection;

namespace Pagos.Application.CasosUso.AdministrarProductos.ConsultarProductos
{
    public class RealizarPagosHandler :
        IRequestHandler<RealizarPagosRequest, IResult>
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IMapper _mapper;
        private readonly IEventSender _eventSender;

        public RealizarPagosHandler(IPagoRepository pagoRepository, IMapper mapper
            , IEventSender eventSender)
        {
            _pagoRepository = pagoRepository;
            _mapper = mapper;
            _eventSender = eventSender;
        }
       

        public async Task<IResult> Handle(RealizarPagosRequest request, CancellationToken cancellationToken)
        {


            IResult response = null;
            //Aplicando el automapper para convertir el objeto Request a venta dominio
            var pago = _mapper.Map<Domain.Models.Pago>(request);

            await _pagoRepository.Realizar(pago);

            response = new SuccessResult<int>(pago.IdPago);

            return response;

            //IResult response = null;

            //try
            //{
            //    var producto = await _pagoRepository.Realizar(request.IdVenta); // .Consultar(request.IdVenta);
            //    producto.Stock += request.NumeroCuotas; //aumentar el stock
            //    //var actualizar = await _pagoRepository.Modificar(producto);
            //    if (actualizar)
            //    {
            //        await _eventSender.PublishAsync("stocks", JsonSerializer.Serialize(producto), cancellationToken);
            //        //Publicar la información en la cola de Kafka
            //        return new SuccessResult();
            //    }
            //    else
            //        return new FailureResult();
            //}
            //catch (Exception ex)
            //{
            //    response = new FailureResult();
            //    return response;
            //}


        }
    }
}
