using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.domain.Entities.Executions;
using SeguimientoEjecuciones.DataAccess.Repositories.Executions;
using Seguimiento.Contracts.Executions;
using Seguimiento.Contracts;

namespace SeguimientoEjecuciones.Application.Executions.Commands.StartExecution
{
    public class StartExecutionCommandHandler : ICommandHandler<StartExecutionCommand>
    {
        private readonly IExecutionRepository _executionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StartExecutionCommandHandler(
            IExecutionRepository executionRepository,
            IUnitOfWork unitOfWork)
        {
            _executionRepository = executionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(StartExecutionCommand request, CancellationToken cancellationToken)
        {
            var executionToStart = _executionRepository.GetExecutionById(request.id);
            if (executionToStart is null)
                return Task.FromCanceled(cancellationToken);

            _executionRepository.StartExecution(executionToStart);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
