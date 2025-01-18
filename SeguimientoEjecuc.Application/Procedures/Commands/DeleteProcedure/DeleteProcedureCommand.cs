using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.Application.Abstract;


namespace SeguimientoEjecuciones.Application.Procedures.Commands.DeleteProcedure
{
    public record DeleteProcedureCommand(Guid id) : ICommand;
}
