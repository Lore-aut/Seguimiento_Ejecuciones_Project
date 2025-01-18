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

namespace SeguimientoEjecuciones.Application.Operations.Commands.UpdateOperation
{
    public class UpdateOperationCommandHandler : ICommandHandler<UpdateOperationCommand>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOperationCommandHandler(
            IOperationRepository operationRepository,
            IUnitOfWork unitOfWork)
        {
            _operationRepository = operationRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateOperationCommand request, CancellationToken cancellationToken)
        {
            _operationRepository.UpdateOperation(request.Operation);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}

