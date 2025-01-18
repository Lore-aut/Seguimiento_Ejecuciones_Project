using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.domain.Entities.Procedures;
using SeguimientoEjecuciones.DataAccess.Repositories.Procedures;
using Seguimiento.Contracts.Procedures;
using Seguimiento.Contracts;

namespace SeguimientoEjecuciones.Application.Procedures.Queries.GetProcedureById
{
    public class GetProcedureByIdQueryHandler : IQueryHandler<GetProcedureByIdQuery, Procedure?>
    {
        private readonly IProcedureRepository _procedureRepository;

        public GetProcedureByIdQueryHandler(IProcedureRepository procedureRepository)
        {
            _procedureRepository = procedureRepository;
        }

        public Task<Procedure?> Handle(GetProcedureByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_procedureRepository.GetProcedureById(request.id));
        }
    }
}
