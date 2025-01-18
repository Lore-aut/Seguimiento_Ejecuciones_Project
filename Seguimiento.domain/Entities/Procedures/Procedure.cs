using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using seguimiento.domain.Abstract;
using seguimiento.domain.common;
using Seguimiento.domain.Entities.Operations;

namespace Seguimiento.domain.Entities.Procedures
{
    /// <summary>
    /// Establece los miembros que debe tener una entidad operacion
    /// </summary>
    public class Procedure : Entity, IFicha, IUnityCode
    {
        #region Properties

        /// <summary>
        /// operaciones que contiene el procedimiento
        /// </summary>
       public  List<Operation> operations { set; get; }
        public string CODE { get; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }

        #endregion




        /// <summary>
        /// Requerido por EntityFramework.
        /// </summary>                                                                                                                                                                                                                                                             -                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
        protected Procedure() { }

        /// <summary>
        /// Inicializa un objeto <see cref="Procedure"/>.
        /// </summary>
        /// <param name="ID">Identificador de la entidad.</param>
        /// <param name="NAME">Nombre de la entidad.</param>
        /// <param name="DESCRIPTION">Descripcion del procedimiento.</param>
        /// <param name="UNITYCODE">Codigo de unidad del procedimiento.</param>

        public Procedure(string name, string id, string description, string unitycode, Guid Id) : base(Id)
        {
            Name = name;
            Identifier = id;
            Description = description;
            CODE = unitycode;
        }
    }

}
