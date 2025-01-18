using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.domain.Entities.Executions;
using Seguimiento.Contracts.Executions;
using Seguimiento.Contracts;


namespace SeguimientoEjecuciones.Application.Executions.Commands.PauseExecution
{
    public class PauseExecutionCommandHandler : ICommandHandler<PauseExecutionCommand>
    {
        private readonly IExecutionRepository _executionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PauseExecutionCommandHandler(
            IExecutionRepository executionRepository,
            IUnitOfWork unitOfWork)
        {
            _executionRepository = executionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(PauseExecutionCommand request, CancellationToken cancellationToken)
        {
            var executionToPause = _executionRepository.GetExecutionById(request.id);
            if (executionToPause is null)
                return Task.FromCanceled(cancellationToken);

            _executionRepository.StopExecution(executionToPause);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
