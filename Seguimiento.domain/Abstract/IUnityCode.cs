using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace seguimiento.domain.Abstract
{
    /// <summary>
    /// Establece los miembros que debe tener una entidad que posee un codigo de unidad.
    /// </summary>
    public interface IUnityCode
    {
        #region Properties

        /// <summary>
        /// Codigo de la unidad a la que pertence
        /// </summary>
        public string CODE { get; }

        #endregion


       

    }
}

