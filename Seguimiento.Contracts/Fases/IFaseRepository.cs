using Seguimiento.domain.Entities.Fases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Seguimiento.Contracts.Fases
{
    /// <summary>
    /// Describe las funcionalidades necesarias
    /// para dar persistencia a fases.
    /// </summary>
    public interface IFaseRepository
    {
        /// <summary>
        /// Añade una fase al soporte de datos.
        /// </summary>
        /// <param name="fase">Fase a añadir.</param>
        void AddFase(Fase fase);

        /// <summary>
        /// Obtiene un fase del soporte de datos a partir de su identificador.
        /// </summary>
        /// <typeparam name="T">Tipo de fase a obtener</typeparam>
        /// <param name="id">Identificador del fase.</param>
        /// <returns>Fase obtenido del soporte de datos; de no existir, <see langword="null"/>.</returns>
        Fase? GetFaseById(Guid id);

        /// <summary>
        /// Obtiene todos los fase del soporte de datos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<Fase> GetAllFases();

        /// <summary>
        /// Actualiza el valor de un cliente en el soporte de datos.
        /// </summary>
        /// <param name="fase">Instancia con la información a actualizar de la fase.</param>
        void UpdateFase(Fase fase);

        /// <summary>
        /// Elimina una Fase del soporte de datos
        /// </summary>
        /// <param name="Fase">Fase a eliminar.</param>
        void DeleteFase(Fase fase);
    }
}
