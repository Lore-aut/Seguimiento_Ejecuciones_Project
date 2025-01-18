using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.domain.Entities.Procedures;

namespace SeguimientoEjecuciones.Application.Procedures.Commands.CreateProcedure
{
    public record CreateProcedureCommand(string CODE, string Name, string ID, string Description) : ICommand<Procedure>;
}
