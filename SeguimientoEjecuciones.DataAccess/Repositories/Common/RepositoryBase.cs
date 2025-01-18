using SeguimientoEjecuciones.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain;

namespace SeguimientoEjecuciones.DataAccess.Repositories.Common
{   /// <summary>
/// Clase base para repositorio
/// </summary>
    public abstract class RepositoryBase
    { ///<summary> Contexto del soporte de datos </summary>
        protected ApplicationContext _context;

        protected RepositoryBase(ApplicationContext context) {
            _context = context;
        }
    }
}
