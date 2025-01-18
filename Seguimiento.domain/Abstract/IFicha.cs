using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seguimiento.domain.Abstract
{
    /// <summary>
    /// Establece los miembros que debe tener una entidad que posee una ficha.
    /// </summary>
    public interface IFicha
    {
        #region Properties

   
        public string Name{ get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }

        #endregion

        

    }
}
