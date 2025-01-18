using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seguimiento.domain.types
{
    /// <summary>
    /// Estados en los que se encontraran las ejecuciones
    /// </summary>
    public enum State
    {
        /// <summary>
        /// En espera de ser accionada
        /// </summary>
        Idle,
        /// <summary>
        /// Ejecutandose
        /// </summary>
        Running,
        /// <summary>
        /// Temporalmente detenida
        /// </summary>
        Paused,
        /// <summary>
        /// Completada
        /// </summary>
        Completed
    }
}

