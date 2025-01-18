using seguimiento.domain.Abstract;
using seguimiento.domain.common;
using Seguimiento.domain.Entities.Operations;
using Seguimiento.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Seguimiento.domain.Entities.Fases
{
    public class Fase : Entity, IFicha
    {
        /// <summary>
        /// Establece los miembros que debe tener una entidad Fase
        /// </summary>

        #region Properties
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }

        /// <summary>
        ///  Operaciones a la que pertence la fase
        /// </summary>
        public List<Operation> operations { set; get; }
        #endregion


        /// <summary>
        /// Requerido por EntityFramework.
        /// </summary>
        protected Fase() { }

        /// <summary>
        /// Inicializa un objeto <see cref="Fase"/>.
        /// </summary>
        /// <param name="ID">Identificador de la entidad.</param>
        /// <param name="NAME">Nombre de la entidad.</param>
        /// <param name="DESCRIPTION">Descripcion de la fase.</param>


        public Fase(string name, string id, string description, Guid Id) : base(Id)
        {
            Name = name;
            Identifier = id;
            Description = description;

        }
    }
}

