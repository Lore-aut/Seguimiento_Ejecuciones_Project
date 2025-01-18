using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MediatR;
using Seguimiento.Contracts;
using Seguimiento.Contracts.Fases;
using Seguimiento.GrpcProtos;
using SeguimientoEjecuciones.Application.Fases.Commands.CreateFase;
using SeguimientoEjecuciones.Application.Fases.Queries.GetFaseById;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using SeguimientoEjecuciones.Service.Mappers;
using SeguimientoEjecuciones.Application.Procedures.Commands.CreateProcedure;
using SeguimientoEjecuciones.Application.Procedures.Queries.GetProcedureById;
using SeguimientoEjecuciones.Application.Procedures.Queries.GetAllProcedures;
using SeguimientoEjecuciones.Application.Procedures.Commands.UpdateProcedure;
using SeguimientoEjecuciones.Application.Procedures.Commands.DeleteProcedure;


namespace SeguimientoEjecuciones.Services.Services
{
    public class ProceduresService : Procedure.ProcedureBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProceduresService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<ProcedureDTO> CreateProcedure(CreateProcedureRequest request, ServerCallContext context)
        {

            var command = new CreateProcedureCommand(
                request.Name,
                request.Id,
                request.Description,
                request.Unitycode);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<ProcedureDTO>(result));
        }

        public override Task<NullableProcedureDTO> GetProcedure(GetRequest request, ServerCallContext context)
        {
            var query = new GetProcedureByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableProcedureDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableProcedureDTO() { Procedure = _mapper.Map<ProcedureDTO>(result) });
        }

        public override Task<Procedures> GetAllProcedures(Empty request, ServerCallContext context)
        {
            var query = new GetAllProceduresQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de fases al mensaje de lista de DTOs de fases.
            var ProceduresDTOs = new Procedures();
            ProceduresDTOs.Items.AddRange(result.Select(m => _mapper.Map<ProcedureDTO>(m)));

            return Task.FromResult(ProceduresDTOs);
        }

        public override Task<Empty> UpdateProcedure(ProcedureDTO request, ServerCallContext context)
        {
            var command = new UpdateProcedureCommand(_mapper.Map<Seguimiento.domain.Entities.Procedures.Procedure>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteProcedure(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteProcedureCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
    }
}