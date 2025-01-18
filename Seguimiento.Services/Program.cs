using Seguimiento.Contracts.Fases;
using SeguimientoEjecuciones.DataAccess.Context;
using SeguimientoEjecuciones.DataAccess.Repositories.Fases;
using SeguimientoEjecuciones.DataAccess;
using SeguimientoEjecuciones.Service.Services;
using Seguimiento.Contracts;
using SeguimientoEjecuciones.DataAccess.Repositories.Operations;
using Seguimiento.Contracts.Operations;
using SeguimientoEjecuciones.DataAccess.Repositories.Procedures;
using Seguimiento.Contracts.Procedures;
using SeguimientoEjecuciones.DataAccess.Repositories.Executions;
using Seguimiento.Contracts.Executions;
using System.Reflection.Metadata;
using Seguimiento.Services.Services;
using SeguimientoEjecuciones.Application;
using Seguimiento.GrpcProtos;
using Grpc;

namespace Seguimiento.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
         
            var builder = WebApplication.CreateBuilder(args);
            
            // Configure the HTTP request pipeline.

       

            builder.Services.AddSingleton("Data Source=Data.sqlite");
            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IFaseRepository, FaseRepository>();
            builder.Services.AddScoped<IOperationRepository, OperationRepository>();
            builder.Services.AddScoped<IProcedureRepository, ProcedureRepository>();
            builder.Services.AddScoped<IExecutionRepository, ExecutionRepository>();
            builder.Services.AddGrpc();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.AddMediatR(new MediatRServiceConfiguration()
            {
                AutoRegisterRequestProcessors = true,
            }
           .RegisterServicesFromAssemblies(typeof(AssemblyReferences).Assembly));

            var app = builder.Build();
            // Add services to the container.
    


            app.MapGrpcService<FasesService>();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            

            app.Run();

        }
    }
}



  


       

      

    