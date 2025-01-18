using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal;
using System.Drawing;
using System.Reflection.Emit;
using Seguimiento.domain.Entities.Fases;
using Seguimiento.domain.Entities.Operations;
using Seguimiento.domain.Entities.Procedures;
using Seguimiento.domain.Entities.Executions;
using SeguimientoEjecuciones.DataAccess.FluentConfigurations.Executions;
using SeguimientoEjecuciones.DataAccess.FluentConfigurations.Fases;
using SeguimientoEjecuciones.DataAccess.FluentConfigurations.Operations;
using SeguimientoEjecuciones.DataAccess.FluentConfigurations.Procedures;
using SeguimientoEjecuciones.DataAccess.FluentConfigurations.Common;

namespace SeguimientoEjecuciones.DataAccess.Context
{
    public class ApplicationContext : DbContext
    {
        #region Tables
        /// <summary>
        /// Tabla de fases
        /// </summary>
        public DbSet<Fase> Fases { get; set; }

        /// <summary>
        /// Tabla de Operaciones
        /// </summary>
        public DbSet<Operation> operaciones { get; set; }

        /// <summary>
        /// Tabla de Procedimiento
        /// </summary>
        public DbSet<Procedure> proc { get; set; }

        /// <summary>
        /// Tabla de Ejecuciones
        /// </summary>
        public DbSet<Execution> exec { get; set; }

        #endregion

        /// <summary> Requerido por EntityFrameworkCore para migraciones </summary>
        public ApplicationContext() { }

        /// <summary> Inicializa un objeto ApplicationContext </summary>
        public ApplicationContext(string connectionString) : base(GetOptions(connectionString)) { }

        /// <summary> Inicializa un objeto ApplicationContext </summary>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ExecutionEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new FaseEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new OperationEntityTypeConfigurationBase());
            modelBuilder.ApplyConfiguration(new ProcedureEntityTypeConfigurationBase());


        }

        #region Helpers

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionString).Options;
        }

        #endregion

    }
}

