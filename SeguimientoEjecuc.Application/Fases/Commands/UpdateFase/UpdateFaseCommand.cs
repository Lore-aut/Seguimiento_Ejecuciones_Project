using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Fases;
using SeguimientoEjecuciones.Application.Abstract;


namespace SeguimientoEjecuciones.Application.Fases.Commands.UpdateFase
{
        public record UpdateFaseCommand(Fase Fase) : ICommand ;
    
}
