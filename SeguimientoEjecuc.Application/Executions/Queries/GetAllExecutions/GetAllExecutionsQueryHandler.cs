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


namespace SeguimientoEjecuciones.Application.Executions.Queries.GetAllExecutions
{
   public class GetAllExecutionsQueryHandler : IQueryHandler<GetAllExecutionsQuery, IEnumerable<Execution>>
    {
        private readonly IExecutionRepository _executionRepository;

        public GetAllExecutionsQueryHandler(
            IExecutionRepository executionRepository)
        {
            _executionRepository = executionRepository;
        }

        public Task<IEnumerable<Execution>> Handle(GetAllExecutionsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_executionRepository.GetAllExecutions());
        }
    }
}

