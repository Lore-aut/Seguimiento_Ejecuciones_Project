using Seguimiento.domain.Entities.Fases;
using Seguimiento.GrpcProtos;

using AutoMapper;
using Google.Protobuf.WellKnownTypes;

namespace SeguimientoEjecuciones.Service.Mappers
{
    public class OperationProfile : Profile
    {

        public OperationProfile()
        {

            CreateMap<Seguimiento.domain.Entities.Operations.Operation, Seguimiento.GrpcProtos.OperationDTO>()
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.Code, o => o.MapFrom(s => s.CODE))
                .ForMember(t => t.Description, o => o.MapFrom(s => s.Description))
                .ForMember(t => t.Identifier, o => o.MapFrom(s => s.Identifier))
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
               .ForMember(t => t.Items1, o => o.MapFrom(s => s.fases.Select(c => c.Id.ToString())))
                .ForMember(t => t.Items2, o => o.MapFrom(s => s.procs.Select(c => c.Id.ToString())));

            CreateMap<Seguimiento.GrpcProtos.OperationDTO, Seguimiento.domain.Entities.Operations.Operation>()
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.Id, o => o.MapFrom((s => new Guid(s.Id))))
                .ForMember(t => t.CODE, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.Identifier, o => o.MapFrom(s => s.Identifier.ToString()))
                .ForMember(t => t.Description, o => o.MapFrom(s => s.Description))
             .ForMember(dest => dest.fases, opt => opt.MapFrom(src =>
                src.Items1.Select(cadena => new Seguimiento.domain.Entities.Fases.Fase(Guid.Parse(cadena))).ToList()))
                .ForMember(dest => dest.procs, opt => opt.MapFrom(src =>
                src.Items2.Select(cadena => new Seguimiento.domain.Entities.Procedures.Procedure(Guid.Parse(cadena))).ToList()));


        }
    }
}