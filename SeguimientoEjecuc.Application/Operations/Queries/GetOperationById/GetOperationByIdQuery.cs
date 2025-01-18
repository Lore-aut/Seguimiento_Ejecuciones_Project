using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.DataAccess.Repositories.Operations;
using Seguimiento.domain.Entities.Operations;
using SeguimientoEjecuciones.Application.Abstract;

namespace SeguimientoEjecuciones.Application.Operations.Queries.GetOperationById
{
    public record GetOperationByIdQuery(Guid Id) : IQuery<Operation?>;
}
