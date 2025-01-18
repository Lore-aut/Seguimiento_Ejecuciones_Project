using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.domain.Entities.Executions;
using Seguimiento.domain.Types;
using seguimiento.domain.types;

namespace SeguimientoEjecuciones.Application.Executions.Commands.CreateExecution
{
    public record CreateExecutionCommand(ExecType ex, Guid actualEntity, Guid pos) : ICommand<Execution>;
}

