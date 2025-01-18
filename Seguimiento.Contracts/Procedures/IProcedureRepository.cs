using Seguimiento.Contracts.Procedures;
using Seguimiento.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Procedures;
using Seguimiento.domain.Entities.Fases;

namespace Seguimiento.Contracts.Procedures
{
    /// <summary>
    /// Describe las funcionalidades necesarias
    /// para dar persistencia a un procedimiento.
    /// </summary>
    public interface IProcedureRepository
    {
        /// <summary>
        /// Añade un procedimiento al soporte de datos.
        /// </summary>
        /// <param name="Procedure">procedimiento a añadir.</param>
        void AddProcedure(Procedure procedure);

        /// <summary>
        /// Obtiene un procedimiento del soporte de datos a partir de su identificador.
        /// </summary>
        /// <param name="id">Identificador del procedimiento.</param>
        /// <returns> procedimiento obtenida del soporte de datos; de no existir, <see langword="null"/>.</returns>
        Procedure? GetProcedureById(Guid id);

        public IEnumerable<Procedure> GetAllProcedures();

        /// <summary>
        /// Actualiza el valor de un procedimiento en el soporte de datos.
        /// </summary>
        /// <param name="Procedure">Instancia con la información a actualizar del procedimiento.</param>
        void UpdateProcedure(Procedure procedure);

        /// <summary>
        /// Elimina un procedimiento del soporte de datos.
        /// </summary>
        /// <param name="Procedure">procedimiento a eliminar.</param>
        void DeleteProcedure(Procedure procedure);
    }
}