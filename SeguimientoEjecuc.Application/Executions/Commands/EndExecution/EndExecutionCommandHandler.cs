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

namespace SeguimientoEjecuciones.Application.Executions.Commands.EndExecution
{
    public class EndExecutionCommandHandler : ICommandHandler<EndExecutionCommand>
    {
        private readonly IExecutionRepository _executionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EndExecutionCommandHandler(
            IExecutionRepository executionRepository,
            IUnitOfWork unitOfWork)
        {
            _executionRepository = executionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(EndExecutionCommand request, CancellationToken cancellationToken)
        {
            var executionToEnd = _executionRepository.GetExecutionById(request.id);
            if (executionToEnd is null)
                return Task.FromCanceled(cancellationToken);

            _executionRepository.EndExecution(executionToEnd);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
