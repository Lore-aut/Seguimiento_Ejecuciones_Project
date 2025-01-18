using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.domain.Entities.Procedures;

namespace SeguimientoEjecuciones.Application.Procedures.Commands.UpdateProcedure
{
    public record UpdateProcedureCommand(Procedure Procedure) :ICommand ;
}
