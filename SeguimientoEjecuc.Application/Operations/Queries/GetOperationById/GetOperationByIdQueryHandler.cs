using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.DataAccess.Repositories.Operations;
using Seguimiento.domain.Entities.Operations;
using Seguimiento.Contracts.Operations;
using Seguimiento.Contracts;
using SeguimientoEjecuciones.Application.Abstract;

namespace SeguimientoEjecuciones.Application.Operations.Queries.GetOperationById
{
    public class GetOperationByIdQueryHandler : IQueryHandler <GetOperationByIdQuery, Operation?>
    {
        private readonly IOperationRepository _operationRepository;

        public GetOperationByIdQueryHandler(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public Task<Operation?> Handle(GetOperationByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_operationRepository.GetOperationById(request.Id));
        }
    }
}
