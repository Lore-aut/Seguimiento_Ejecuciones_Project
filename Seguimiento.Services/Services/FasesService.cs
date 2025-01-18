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



namespace SeguimientoEjecuciones.Service.Services
{
    public class FasesService : Fase.FaseBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FasesService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override Task<FaseDTO> CreateFase(CreateFaseRequest request, ServerCallContext context)
        {

            var command = new CreateFaseCommand(
                request.Name,
                request.Id,
                request.Description);

            var result = _mediator.Send(command).Result;

            return Task.FromResult(_mapper.Map<FaseDTO>(result));
        }

        public override Task<NullableFaseDTO> GetFase(GetRequest request, ServerCallContext context)
        {
            var query = new GetFaseByIdQuery(new Guid(request.Id));

            var result = _mediator.Send(query).Result;

            if (result is null)
                return Task.FromResult(new NullableFaseDTO() { Null = NullValue.NullValue });
            return Task.FromResult(new NullableFaseDTO() { Fase = _mapper.Map<FaseDTO>(result) });
        }

        public override Task<Fases> GetAllFases(Empty request, ServerCallContext context)
        {
            var query = new GetAllFasesQuery();

            var result = _mediator.Send(query).Result;

            // Convirtiendo de lista de motocicletas al mensaje de lista de DTOs de motocicletas.
            var FasesDTOs = new Fases();
            FasesDTOs.Items.AddRange(result.Select(m => _mapper.Map<FaseDTO>(m)));

            return Task.FromResult(FasesDTOs);
        }

        public override Task<Empty> UpdateFase(FaseDTO request, ServerCallContext context)
        {
            var command = new UpdateFaseCommand(_mapper.Map<Seguimiento.domain.Entities.Fases.Fase>(request));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

        public override Task<Empty> DeleteFase(DeleteRequest request, ServerCallContext context)
        {
            var command = new DeleteFaseCommand(new Guid(request.Id));

            _mediator.Send(command);

            return Task.FromResult(new Empty());
        }

    }
}
