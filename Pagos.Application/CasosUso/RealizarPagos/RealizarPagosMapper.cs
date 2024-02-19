using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pagos.Domain.Models;
using System.Reflection;

namespace Pagos.Application.CasosUso.AdministrarProductos.ConsultarProductos
{
    public class RealizarPagosMapper : Profile
    {
        public RealizarPagosMapper()
        {
            CreateMap<RealizarPagosRequest, Domain.Models.Pago>();
                //.ForMember(dest => dest.Detalle, map => map.MapFrom(src => src.Productos));
        }
    }
}
