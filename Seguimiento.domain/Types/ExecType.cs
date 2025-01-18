using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguimiento.domain.Types
{

    /// <summary>
    /// Tipos de ejecuciones 
    /// </summary>
    public enum ExecType
    {
        /// <summary>
        /// La ejecucion es de una fase
        /// </summary>
        FaseExecution,

        /// <summary>
        /// La ejecucion es de una operacion
        /// </summary>
        OperationExecution,

        /// <summary>
        /// La ejecucion es de un procedimiento
        /// </summary>
        ProcedureExecution
    }
}
