using SeguimientoEjecuciones.DataAccess.FluentConfigurations.Common;
using seguimiento.domain.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Operations;



namespace SeguimientoEjecuciones.DataAccess.FluentConfigurations.Operations
{
   
         public class OperationEntityTypeConfigurationBase : EntityTypeConfigurationBase<Operation>
    {
        public override void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.ToTable("Operation");


            builder.HasMany(x => x.fases).WithMany(x=>x.operations).UsingEntity("OperationPhasesId");
            builder.HasMany(x => x.procs).WithMany(x=>x.operations).UsingEntity("OperationProccessId"); ;
            base.Configure(builder);


        }
    }
}
