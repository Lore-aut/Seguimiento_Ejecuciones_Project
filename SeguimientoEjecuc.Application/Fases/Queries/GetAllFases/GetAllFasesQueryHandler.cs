using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Fases;
using SeguimientoEjecuciones.Application;
using SeguimientoEjecuciones.DataAccess.Repositories.Fases;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.Contracts.Fases;

namespace SeguimientoEjecuciones.Application.Fases.Queries.GetAllFases
{
    public class GetAllFasesQueryHandler : IQueryHandler<GetAllFasesQuery, IEnumerable<Fase>>
    {
        private readonly IFaseRepository _faseRepository;

        public GetAllFasesQueryHandler(
            IFaseRepository faseRepository)
        {
            _faseRepository = faseRepository;
        }

        public Task<IEnumerable<Fase>> Handle(GetAllFasesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_faseRepository.GetAllFases());
        }
    }
}
