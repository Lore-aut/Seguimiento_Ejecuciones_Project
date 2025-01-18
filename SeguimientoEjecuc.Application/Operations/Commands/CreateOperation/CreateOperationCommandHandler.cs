using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Operations;
using SeguimientoEjecuciones.DataAccess.Repositories.Operations;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.Contracts.Operations;
using Seguimiento.Contracts;

namespace SeguimientoEjecuciones.Application.Operations.Commands.CreateOperation
{
    public class CreateOperationCommandHandler : ICommandHandler<CreateOperationCommand, Operation>
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOperationCommandHandler(IOperationRepository operationRepository, IUnitOfWork unitOfWork)
        {
            _operationRepository = operationRepository;
            _unitOfWork = unitOfWork;
        }


        public Task<Operation> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            Operation result = new Operation(
                request.name,
                request.id,
                request.description,
                request.unitycode,
                Guid.NewGuid());

            _operationRepository.AddOperation(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
