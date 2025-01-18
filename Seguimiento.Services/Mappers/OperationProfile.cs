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
                .ForMember(t => t.Items1, o => o.MapFrom(s => s.procs))
                .ForMember(t => t.Items2, o => o.MapFrom(s => s.fases))
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()));

            CreateMap<Seguimiento.GrpcProtos.OperationDTO, Seguimiento.domain.Entities.Operations.Operation>()
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.Id, o => o.MapFrom((s => new Guid(s.Id))))
                .ForMember(t => t.CODE, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.Identifier, o => o.MapFrom(s => s.Identifier.ToString()))
                .ForMember(t => t.procs, o => o.MapFrom(s => s.Items1))
                .ForMember(t => t.fases, o => o.MapFrom(s => s.Items2))
                .ForMember(t => t.Description, o => o.MapFrom(s => s.Description));


        }
    }
}