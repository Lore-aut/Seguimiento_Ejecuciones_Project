using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.domain.Entities.Executions;

namespace SeguimientoEjecuciones.Application.Executions.Queries.GetExecutionById
{
    public record GetExecutionByIdQuery(Guid id) : IQuery<Execution?>;
}
