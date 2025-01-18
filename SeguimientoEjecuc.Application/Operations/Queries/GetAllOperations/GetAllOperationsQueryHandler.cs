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


namespace SeguimientoEjecuciones.Application.Operations.Queries.GetAllOperations
{
    public class GetAllOperationsQueryHandler : IQueryHandler<GetAllOperationsQuery, IEnumerable<Operation>>
    {
        private readonly IOperationRepository _operationRepository;

        public GetAllOperationsQueryHandler(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public Task<IEnumerable<Operation>> Handle(GetAllOperationsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_operationRepository.GetAllOperations());
        }
    }
}
