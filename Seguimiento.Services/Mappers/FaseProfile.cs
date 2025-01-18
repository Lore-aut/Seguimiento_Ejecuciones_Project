using Seguimiento.domain.Entities.Fases;
using Seguimiento.GrpcProtos;

using AutoMapper;
using Google.Protobuf.WellKnownTypes;

namespace SeguimientoEjecuciones.Service.Mappers
{
    public class FaseProfile: Profile
    {
        public FaseProfile()
        {

            CreateMap<Seguimiento.domain.Entities.Fases.Fase, Seguimiento.GrpcProtos.FaseDTO>()
                .ForMember(t => t.Name, o => o.MapFrom(s => s.Name.ToString()))
                .ForMember(t => t.Description, o => o.MapFrom(s => s.Description.ToString()))
                .ForMember(t => t.Identifier, o => o.MapFrom(s => s.Identifier.ToString()))
                .ForMember(t => t.Id, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(t => t.Items, o => o.MapFrom(s => s.operations));



            CreateMap<Seguimiento.GrpcProtos.FaseDTO, Seguimiento.domain.Entities.Fases.Fase>()
                    .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                    .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                    .ForMember(t => t.Description, o => o.MapFrom(s => s.Description))
                    .ForMember(t => t.Identifier, o => o.MapFrom(s => s.Identifier))
                    .ForMember(t => t.operations, o => o.MapFrom(s => s.Items));
            
            

        }
    }
}
