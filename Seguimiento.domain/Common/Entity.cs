using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seguimiento.domain.common
{
    /// <summary>
    /// Clase base para todas las entidades.
    /// </summary>
    public abstract class Entity
    {
        #region Properties

        /// <summary>
        /// Identificador en el soporte de datos.
        /// </summary>
        public Guid Id { get; set; }

        #endregion

        /// <summary>
        /// Requerido por EntityFramework.
        /// </summary>
        protected Entity()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}

