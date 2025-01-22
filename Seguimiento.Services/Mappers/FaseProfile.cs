using Seguimiento.domain.Entities.Fases;
using Seguimiento.GrpcProtos;

using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Seguimiento.domain.Entities.Operations;
using System.Linq;

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
                .ForMember(t => t.Items , o => o.MapFrom(s => s.operations.Select(c => c.Id.ToString())));
        

            CreateMap<Seguimiento.GrpcProtos.FaseDTO, Seguimiento.domain.Entities.Fases.Fase>()
                    .ForMember(t => t.Id, o => o.MapFrom(s => new Guid(s.Id)))
                    .ForMember(t => t.Name, o => o.MapFrom(s => s.Name))
                    .ForMember(t => t.Description, o => o.MapFrom(s => s.Description))
                    .ForMember(t => t.Identifier, o => o.MapFrom(s => s.Identifier))
                    .ForMember(dest => dest.operations, opt => opt.MapFrom(src =>
                src.Items.Select(cadena => new Seguimiento.domain.Entities.Operations.Operation(Guid.Parse(cadena))).ToList()));


        }
    }
}
