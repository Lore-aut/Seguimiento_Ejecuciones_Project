using Seguimiento.domain.Entities.Fases;
using Seguimiento.GrpcProtos;

using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using System;
using seguimiento.domain.types;
using Seguimiento.domain.Types;

namespace SeguimientoEjecuciones.Service.Mappers
{
    public class ExecutionProfile : Profile
    {
        public ExecutionProfile()
        {


            CreateMap<Seguimiento.domain.Entities.Executions.Execution, Seguimiento.GrpcProtos.ExecutionDTO>()
                       .ForMember(dest => dest.PostEntity, opt => opt.MapFrom(src => src.post_entity.ToString()))
                       .ForMember(dest => dest.ActualEntity, opt => opt.MapFrom(src => src.actual_entity.ToString()))
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                       .ForMember(dest => dest.Beggin, opt => opt.MapFrom(src =>
                           src.beggin.HasValue
                               ? new NullableDateTimeDTO
                               {
                                   Date = new DateTimeDTO
                                   {
                                       Year = src.beggin.Value.Year,
                                       Month = src.beggin.Value.Month,
                                       Day = src.beggin.Value.Day
                                   }
                               }
                               : new NullableDateTimeDTO { Null = Google.Protobuf.WellKnownTypes.NullValue.NullValue }))
                       .ForMember(dest => dest.End, opt => opt.MapFrom(src =>
                           src.end.HasValue
                               ? new NullableDateTimeDTO
                               {
                                   Date = new DateTimeDTO
                                   {
                                       Year = src.beggin.Value.Year,
                                       Month = src.beggin.Value.Month,
                                       Day = src.beggin.Value.Day
                                   }
                               }
                               : new NullableDateTimeDTO { Null = Google.Protobuf.WellKnownTypes.NullValue.NullValue }))
                        .ForMember(dest => dest.State, opt => opt.MapFrom(src =>
                        src.state == State.Idle ? StateDTO.Idle :
                        src.state == State.Running ? StateDTO.Running :
                        src.state == State.Paused ? StateDTO.Paused :
                        src.state == State.Completed ? StateDTO.Completed :
                         StateDTO.Idle))
                        .ForMember(dest => dest.ExecType, opt => opt.MapFrom(src =>
                        src.execType == ExecType.FaseExecution ? ExecType.FaseExecution :
                        src.execType == ExecType.OperationExecution ? ExecType.OperationExecution :
                        src.execType == ExecType.ProcedureExecution ? ExecType.ProcedureExecution :
                         ExecType.ProcedureExecution));

            CreateMap<Seguimiento.GrpcProtos.ExecutionDTO, Seguimiento.domain.Entities.Executions.Execution>()
                        .ForMember(dest => dest.post_entity, opt => opt.MapFrom(src => Guid.Parse(src.PostEntity)))
                        .ForMember(dest => dest.actual_entity, opt => opt.MapFrom(src => Guid.Parse(src.ActualEntity)))
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)))
                        .ForMember(dest => dest.beggin, opt => opt.MapFrom(src =>
                           src.Beggin.KindCase == Seguimiento.GrpcProtos.NullableDateTimeDTO.KindOneofCase.Null
                           ? (DateTime?)null
                           : new DateTime(src.Beggin.Date.Year, src.Beggin.Date.Month, src.Beggin.Date.Day)))
                         .ForMember(dest => dest.end, opt => opt.MapFrom(src =>
                           src.End.KindCase == Seguimiento.GrpcProtos.NullableDateTimeDTO.KindOneofCase.Null
                           ? (DateTime?)null
                           : new DateTime(src.End.Date.Year, src.End.Date.Month, src.End.Date.Day)))
                         .ForMember(dest => dest.state, opt => opt.MapFrom(src =>
                           src.State == StateDTO.Idle ? State.Idle :
                           src.State == StateDTO.Running ? State.Running :
                           src.State == StateDTO.Paused ? State.Paused :
                           src.State == StateDTO.Completed ? State.Completed :
                           State.Idle))
                         .ForMember(dest => dest.execType, opt => opt.MapFrom(src =>
                           src.ExecType == ExecTypeDTO.Procedure ? ExecType.ProcedureExecution :
                           src.ExecType == ExecTypeDTO.Operation ? ExecType.OperationExecution :
                           src.ExecType == ExecTypeDTO.Fase ? ExecType.FaseExecution :
                           ExecType.FaseExecution));







        }
    }
}



