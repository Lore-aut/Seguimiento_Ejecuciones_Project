using SeguimientoEjecuciones.DataAccess.FluentConfigurations.Common;
using seguimiento.domain.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Executions;
using seguimiento.domain.types;
using Seguimiento.domain.Types;


namespace SeguimientoEjecuciones.DataAccess.FluentConfigurations.Executions
{
    public class ExecutionEntityTypeConfigurationBase : EntityTypeConfigurationBase<Execution>
    {
        public override void Configure(EntityTypeBuilder<Execution> builder)
        {
            builder.ToTable("Execution");
            //Almacena el enum State como una string
            builder.Property(x => x.state).HasConversion<string>();
            builder.Property(x => x.execType).HasConversion<string>();
            builder.Property(x => x.beggin).HasColumnType("datetime");
            builder.Property(x => x.end).HasColumnType("datetime");

            base.Configure(builder);


        }
}
}

