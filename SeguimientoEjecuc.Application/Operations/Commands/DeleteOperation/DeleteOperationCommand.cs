using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Operations;
using SeguimientoEjecuciones.Application.Abstract;

namespace SeguimientoEjecuciones.Application.Operations.Commands.DeleteOperation
{
    public record DeleteOperationCommand(Guid id) : ICommand;
}
