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
using SeguimientoEjecuciones.Application.Fases.Queries.GetAllFases;
using SeguimientoEjecuciones.Application.Fases.Commands.UpdateFase;
using SeguimientoEjecuciones.Application.Fases.Commands.DeleteFase;
using SeguimientoEjecuciones.Application.Operations.Commands.CreateOperation;
using SeguimientoEjecuciones.Application.Operations.Queries.GetOperationById;
using SeguimientoEjecuciones.Application.Operations.Queries.GetAllOperations;
using SeguimientoEjecuciones.Application.Operations.Commands.UpdateOperation;
using SeguimientoEjecuciones.Application.Operations.Commands.DeleteOperation;


namespace SeguimientoEjecuciones.Services.Services
{
    public class OperationsService : Operation.OperationBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OperationsService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<OperationDTO> CreateOperation(CreateOperationRequest request, ServerCallContext context)
        {
            var command = new CreateOperationCommand(
                 request.Name,
                 request.Id,
                 request.Description,
                 request.Code);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<OperationDTO>(result));
        }

        public override Task<NullableOperationDTO> GetOperation(GetRequest request, ServerCallContext context)
        {
            var query = new GetOperationByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableOperationDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableOperationDTO() { Operation = _mapper.Map<OperationDTO>(result) });
        }

        public override Task<Operations> GetAllOperations(Empty request, ServerCallContext context)
        {
            var query = new GetAllOperationsQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de operaciones al mensaje de lista de DTOs de operaciones.
            var OperationDTOs = new Operations();
            OperationDTOs.Items.AddRange(result.Select(m => _mapper.Map<OperationDTO>(m)));

            return Task.FromResult(OperationDTOs);
        }

        public override Task<Empty> UpdateOperation(OperationDTO request, ServerCallContext context)
        {
            var command = new UpdateOperationCommand(_mapper.Map<Seguimiento.domain.Entities.Operations.Operation>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteOperation(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteOperationCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

    }
}