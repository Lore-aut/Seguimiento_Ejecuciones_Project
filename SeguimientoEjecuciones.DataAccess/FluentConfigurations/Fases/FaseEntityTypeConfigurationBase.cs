using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Fases;
using SeguimientoEjecuciones.DataAccess.FluentConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;




namespace SeguimientoEjecuciones.DataAccess.FluentConfigurations.Fases
{
    public class FaseEntityTypeConfigurationBase: EntityTypeConfigurationBase<Fase>
    {
        public override void Configure(EntityTypeBuilder<Fase> builder)
        {   
            builder.ToTable("Fase");
            base.Configure(builder);

        }
    }
}

