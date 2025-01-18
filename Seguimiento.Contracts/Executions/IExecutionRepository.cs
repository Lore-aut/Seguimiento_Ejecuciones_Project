using Seguimiento.Contracts.Executions;
using Seguimiento.domain.Entities.Executions;
using Seguimiento.domain.Entities.Fases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguimiento.Contracts.Executions
{
    /// <summary>
    /// Describe las funcionalidades necesarias
    /// para dar persistencia a una ejecucion.
    /// </summary>
    public interface IExecutionRepository
    {
        /// <summary>
        /// Añade una ejecucion al soporte de datos.
        /// </summary>
        /// <param name="Procedure">ejecucion a añadir.</param>
        void AddExecution(Execution execution);

        /// <summary>
        /// Obtiene una ejecucion del soporte de datos a partir de su identificador.
        /// </summary>
        /// <param name="id">Identificador de la ejecucion.</param>
        /// <returns> ejecucion obtenida del soporte de datos; de no existir, <see langword="null"/>.</returns>
        Execution? GetExecutionById(Guid id) ;

        /// <summary>
        /// Obtiene todas las ejecuciones de compra del soporte de datos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Execution> GetAllExecutions() ;

        /// <summary>
        /// Actualiza el valor de una ejecucion en el soporte de datos.
        /// </summary>
        /// <param name="Execution">Instancia con la información a actualizar de la ejecucion.</param>
        void UpdateExecution(Execution execution);

        /// <summary>
        /// Elimina una ejecucion del soporte de datos.
        /// </summary>
        /// <param name="execution">ejecucion a eliminar.</param>
        void DeleteExecution(Execution execution);

        /// <summary>
        /// Da inicio a cualquier tipo de ejecucion
        /// </summary>
        /// <param name="execution"></param>
        void StartExecution(Execution execution);

        /// <summary>
        /// Detiene cualquier tipo de ejecucion
        /// </summary>
        /// <param name="execution"></param>
        void StopExecution(Execution execution);

        /// <summary>
        /// Finaliza todo tipo de ejecucion
        /// </summary>
        /// <param name="execution"></param>
        void EndExecution(Execution execution);

    }
}