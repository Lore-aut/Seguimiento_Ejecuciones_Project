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
using SeguimientoEjecuciones.Application.Executions.Commands.CreateExecution;
using Seguimiento.domain.Types;
using SeguimientoEjecuciones.Application.Executions.Queries.GetExecutionById;
using SeguimientoEjecuciones.Application.Fases.Queries.GetAllFases;
using SeguimientoEjecuciones.Application.Executions.Queries.GetAllExecutions;
using SeguimientoEjecuciones.Application.Fases.Commands.UpdateFase;
using SeguimientoEjecuciones.Application.Executions.Commands.UpdateExecution;
using SeguimientoEjecuciones.Application.Fases.Commands.DeleteFase;
using SeguimientoEjecuciones.Application.Executions.Commands.DeleteExecution;
using SeguimientoEjecuciones.Application.Executions.Commands.StartExecution;
using SeguimientoEjecuciones.Application.Executions.Commands.PauseExecution;
using SeguimientoEjecuciones.Application.Executions.Commands.EndExecution;


namespace SeguimientoEjecuciones.Services.Services
{
    public class ExecutionsService : Execution.ExecutionBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ExecutionsService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        public override Task<ExecutionDTO> CreateExecution(CreateExecutionRequest request, ServerCallContext context)
        {

            var command = new CreateExecutionCommand(
                 (Seguimiento.domain.Types.ExecType)request.Ex,
                 Guid.Parse(request.ActualEntity),
                 Guid.Parse(request.Pos));

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<ExecutionDTO>(result));
        }

        public override Task<NullableExecutionDTO> GetExecution(GetRequest request, ServerCallContext context)
        {
            var query = new GetExecutionByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableExecutionDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableExecutionDTO() { Execution = _mapper.Map<ExecutionDTO>(result) });
        }

        public override Task<Executions> GetAllExecutions(Empty request, ServerCallContext context)
        {
            var query = new GetAllExecutionsQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de fases al mensaje de lista de DTOs de fases.
            var ExecutionsDTOs = new Executions();
            ExecutionsDTOs.Items.AddRange(result.Select(m => _mapper.Map<ExecutionDTO>(m)));

            return Task.FromResult(ExecutionsDTOs);
        }

        public override Task<Empty> UpdateExecution(ExecutionDTO request, ServerCallContext context)
        {
            var command = new UpdateExecutionCommand(_mapper.Map<Seguimiento.domain.Entities.Executions.Execution>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> StartExecution(StartRequest request, ServerCallContext context)
        {

            var command = new StartExecutionCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> PauseExecution(PauseRequest request, ServerCallContext context)
        {
            var command = new PauseExecutionCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> EndExecution(EndRequest request, ServerCallContext context)
        {
            var command = new EndExecutionCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }
        public override Task<Empty> DeleteExecution(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteExecutionCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }


    }
}

