using Seguimiento.Contracts.Operations;
using Seguimiento.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Operations;
using Seguimiento.domain.Entities.Fases;

namespace Seguimiento.Contracts.Operations
{
    /// <summary>
    /// Describe las funcionalidades necesarias
    /// para dar persistencia a operacion.
    /// </summary>
    public interface IOperationRepository
    {
        /// <summary>
        /// Añade una operacion al soporte de datos.
        /// </summary>
        /// <param name="operacion">operacion a añadir.</param>
        void AddOperation(Operation operation);

        /// <summary>
        /// Obtiene una operacion del soporte de datos a partir de su identificador.
        /// </summary>
        /// <param name="id">Identificador de la operacion.</param>
        /// <returns>operacion obtenida del soporte de datos; de no existir, <see langword="null"/>.</returns>
         Operation? GetOperationById(Guid id);

        /// <summary>
        /// Obtiene todas las operacion de compra del soporte de datos.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Operation> GetAllOperations() ;

        /// <summary>
        /// Actualiza el valor de una operacion en el soporte de datos.
        /// </summary>
        /// <param name="Operation">Instancia con la información a actualizar de la operacion.</param>
        void UpdateOperation(Operation operation);

        /// <summary>
        /// Elimina una operacion del soporte de datos.
        /// </summary>
        /// <param name="Operation">Operacion a eliminar.</param>
        void DeleteOperation(Operation operation);
    }
}
