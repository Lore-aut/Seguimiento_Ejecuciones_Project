using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.DataAccess.Repositories.Executions;
using SeguimientoEjecuciones.DataAccess;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.domain.Entities.Executions;
using Seguimiento.Contracts.Executions;
using Seguimiento.Contracts;
using Seguimiento.domain.Types;

namespace SeguimientoEjecuciones.Application.Executions.Commands.CreateExecution
{
    public class CreateExecutionCommandHandler : ICommandHandler<CreateExecutionCommand, Execution>
    {
        private readonly IExecutionRepository _executionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateExecutionCommandHandler(IExecutionRepository executionRepository, IUnitOfWork unitOfWork)
        {
            _executionRepository = executionRepository;
            _unitOfWork = unitOfWork;
        }

        
        public Task<Execution> Handle(CreateExecutionCommand request, CancellationToken cancellationToken)
        {
            Execution result = new Execution(
                request.ex,
                request.actualEntity,
                new Guid(),
                request.pos)
                ;

            _executionRepository.AddExecution(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}

