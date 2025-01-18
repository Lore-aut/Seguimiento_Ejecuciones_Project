using SeguimientoEjecuciones.DataAccess.FluentConfigurations.Common;
using seguimiento.domain.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Procedures;
using Seguimiento.domain.Entities.Fases;



namespace SeguimientoEjecuciones.DataAccess.FluentConfigurations.Procedures
{
    public class ProcedureEntityTypeConfigurationBase : EntityTypeConfigurationBase<Procedure>
    {
        public override void Configure(EntityTypeBuilder<Procedure> builder)
        {
            builder.ToTable("Procedure");
            base.Configure(builder);
        }
    }
}