using Seguimiento.domain.Entities.Fases;
using Seguimiento.GrpcProtos;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;


namespace SeguimientoEjecuciones.Service.Mappers
{
    public class ProcedureProfile : Profile
    {
        public ProcedureProfile()
        {

            CreateMap<Seguimiento.domain.Entities.Procedures.Procedure, Seguimiento.GrpcProtos.ProcedureDTO>()
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.Description, o => o.MapFrom(s => s.Description))
                .ForMember(t => t.Code, o => o.MapFrom(s => s.CODE))
                .ForMember(t => t.Identifier, o => o.MapFrom(s => s.Identifier))
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Items, o => o.MapFrom(s => s.operations));

            CreateMap<Seguimiento.GrpcProtos.ProcedureDTO, Seguimiento.domain.Entities.Procedures.Procedure>()
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                .ForMember(t => t.CODE, o => o.MapFrom(s => s.Code))
                .ForMember(t => t.Identifier, o => o.MapFrom(s => s.Identifier))
                .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                .ForMember(t => t.Description, o => o.MapFrom(s => s.Description))
                .ForMember(t => t.operations, o => o.MapFrom(s => s.Items));

        }

    }
}
