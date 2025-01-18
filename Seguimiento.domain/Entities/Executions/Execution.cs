using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using seguimiento.domain.Abstract;
using seguimiento.domain.common;
using seguimiento.domain.types;
using Seguimiento.domain.Entities.Procedures;
using Seguimiento.domain.Types;

namespace Seguimiento.domain.Entities.Executions
{
    /// <summary>
    /// Establece los miembros que debe tener una entidad ejecucion
    /// </summary>
    public class Execution : Entity
    {
        #region Properties


        public Guid post_entity {  get; set; }
        public Guid actual_entity { get; set; }
        public DateTime? beggin { get; set; }
        public DateTime? end { get; set; }

        public State state { get; set; }
        public ExecType execType { get; set; }

        #endregion

       /// <summary>
       /// Requerido por EntityFramework.
       /// </summary>

       protected Execution() { }

        /// <summary>
        ///  Inicializa un objeto <see cref="Execution"/>.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <param name="s"></param>

        public Execution(ExecType ex,Guid actualEntity,Guid Id, Guid postEntity, DateTime? b=null,DateTime? e=null, State s=State.Idle) : base(Id)
        {   
            beggin = b;
            end = e;
            execType = ex;
            actual_entity = actualEntity;
            post_entity = postEntity;
            state = s;
        }


    }

}