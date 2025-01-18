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

namespace SeguimientoEjecuciones.Application.Executions.Commands.UpdateExecution
{
    public class UpdateExecutionCommandHandler : ICommandHandler<UpdateExecutionCommand>
    {
        private readonly IExecutionRepository _executionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateExecutionCommandHandler(
            IExecutionRepository executionRepository,
            IUnitOfWork unitOfWork)
        {
            _executionRepository = executionRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateExecutionCommand request, CancellationToken cancellationToken)
        {
            _executionRepository.UpdateExecution(request.Execution);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
    

