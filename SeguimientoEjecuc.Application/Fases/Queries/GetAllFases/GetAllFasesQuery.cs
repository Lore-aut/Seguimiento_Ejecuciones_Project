using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.domain.Entities.Fases;


namespace SeguimientoEjecuciones.Application.Fases.Queries.GetAllFases
{
    public record GetAllFasesQuery : IQuery <IEnumerable<Fase>>;
}
