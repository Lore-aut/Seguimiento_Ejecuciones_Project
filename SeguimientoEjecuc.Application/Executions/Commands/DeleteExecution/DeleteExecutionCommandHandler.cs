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

namespace SeguimientoEjecuciones.Application.Executions.Commands.DeleteExecution
{
    public class DeleteExecutionCommandHandler : ICommandHandler<DeleteExecutionCommand>
    {
        private readonly IExecutionRepository _executionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExecutionCommandHandler(
            IExecutionRepository executionRepository,
            IUnitOfWork unitOfWork)
        {
            _executionRepository = executionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteExecutionCommand request, CancellationToken cancellationToken)
        {
            var executionToDelete = _executionRepository.GetExecutionById(request.id);
            if (executionToDelete is null)
                return Task.CompletedTask;
            _executionRepository.DeleteExecution(executionToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}

