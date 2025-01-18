using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Procedures;
using SeguimientoEjecuciones.Application;
using SeguimientoEjecuciones.DataAccess.Repositories.Procedures;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.Contracts.Procedures;
using Seguimiento.Contracts;

namespace SeguimientoEjecuciones.Application.Procedures.Queries.GetAllProcedures
{
    public class GetAllProceduresQueryHandler : IQueryHandler<GetAllProceduresQuery, IEnumerable<Procedure>>
    {
        private readonly IProcedureRepository _procedureRepository;

        public GetAllProceduresQueryHandler(
            IProcedureRepository procedureRepository)
        {
            _procedureRepository = procedureRepository;
        }

        public Task<IEnumerable<Procedure>> Handle(GetAllProceduresQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_procedureRepository.GetAllProcedures());
        }
    }
}
