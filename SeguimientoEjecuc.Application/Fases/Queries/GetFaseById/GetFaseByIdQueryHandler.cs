using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain;
using SeguimientoEjecuciones.Application.Fases;
using SeguimientoEjecuciones.DataAccess.Repositories.Fases;
using Seguimiento.domain.Entities.Fases;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.Contracts.Fases;

namespace SeguimientoEjecuciones.Application.Fases.Queries.GetFaseById
{
    public class GetFaseByIdQueryHandler : IQueryHandler<GetFaseByIdQuery,Fase?>
    {
        private readonly IFaseRepository _faseRepository; 

        public GetFaseByIdQueryHandler (IFaseRepository faseRepository)
        {
            _faseRepository = faseRepository;
        }

        public Task<Fase?> Handle(GetFaseByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_faseRepository.GetFaseById(request.Id));
        }
    }
}
