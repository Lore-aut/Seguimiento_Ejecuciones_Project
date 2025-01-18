using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.DataAccess.Repositories.Operations;
using Seguimiento.domain.Entities.Operations;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.Contracts.Operations;
using Seguimiento.Contracts;

namespace SeguimientoEjecuciones.Application.Operations.Commands.DeleteOperation
{
    public class DeleteOperationCommandHandler : ICommandHandler<DeleteOperationCommand>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOperationCommandHandler(
            IOperationRepository operationRepository,
            IUnitOfWork unitOfWork)
        {
            _operationRepository = operationRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteOperationCommand request, CancellationToken cancellationToken)
        {
            var operationToDelete = _operationRepository.GetOperationById(request.id);
            if (operationToDelete is null)
                return Task.CompletedTask;
            _operationRepository.DeleteOperation(operationToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }

}
