using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using seguimiento.domain.Abstract;
using seguimiento.domain.common;
using Seguimiento.domain.Entities.Fases;
using Seguimiento.domain.Entities.Procedures;

namespace Seguimiento.domain.Entities.Operations
{
    /// <summary>
    /// Establece los miembros que debe tener una entidad operacion
    /// </summary>
    public class Operation : Entity, IFicha, IUnityCode
    {
        #region Properties

        /// <summary>
        /// Fases que contiene la operacion
        /// </summary>
        public List<Fase> fases { set; get; }

        /// <summary>
        /// Procedimientos a los que pertenece la operacion
        /// </summary>
        public List<Procedure> procs { set; get; }

        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }

        public string CODE { get; }

        #endregion

        /// <summary>
        /// Requerido por EntityFramework.
        /// </summary>
        protected Operation() { }

        /// <summary>
        /// Inicializa un objeto <see cref="Operation"/>.
        /// </summary>
        /// <param name="ID">Identificador de la entidad.</param>
        /// <param name="NAME">Nombre de la entidad.</param>
        /// <param name="DESCRIPTION">Descripcion de la operacion.</param>
        /// <param name="UNITYCODE">Codigo de unidad de la operacion.</param>

        public Operation(string name, string id, string description, string unitycode, Guid Id) : base(Id)
        {
            Name = name;
            Identifier = id;
            Description = description;
            CODE = unitycode;
        }
    }

}