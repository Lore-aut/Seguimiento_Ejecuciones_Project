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


namespace SeguimientoEjecuciones.Application.Executions.Queries.GetExecutionById
{
    public class GetExecutionByIdQueryHandler : IQueryHandler<GetExecutionByIdQuery,Execution?>
    {
        private readonly IExecutionRepository _executionRepository;

        public GetExecutionByIdQueryHandler(IExecutionRepository executionRepository)
        {
            _executionRepository = executionRepository;
        }

        public Task<Execution?> Handle(GetExecutionByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_executionRepository.GetExecutionById(request.id));
        }
    }
}

