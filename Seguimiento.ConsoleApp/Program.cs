using Seguimiento.domain.Entities;
using Seguimiento.GrpcProtos;
using Grpc.Net.Client;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Seguimiento.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Presione una tecla para conectar");
            Console.ReadKey();

            Console.WriteLine("Creating channel and client");

            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var channel = GrpcChannel.ForAddress(
                "https://localhost:7259",
                new GrpcChannelOptions { HttpHandler = httpHandler });

            if (channel is null)
            {
                Console.WriteLine("Cannot connect");
                channel.Dispose();
                return;
            }
           
            var client = new Seguimiento.GrpcProtos.Fase.FaseClient(channel);

            Console.WriteLine("Presione una tecla para crear una fase");
            Console.ReadKey();
            var createResponse = client.CreateFase(new CreateFaseRequest()
            {    
                Name = "Calentamiento",
             
                Id = "FC4523",
                
                Description = "Se calienta lentamente"

            });

            if (createResponse is null)
            {
                Console.WriteLine("Cannot create fase");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Creación exitosa.");
            }

            Console.WriteLine("Presione una tecla para obtener todas las fases");
            Console.ReadKey();
            var getResponse = client.GetAllFases(new Google.Protobuf.WellKnownTypes.Empty());
            if (getResponse.Items is null)
            {
                Console.WriteLine("Cannot get");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de {getResponse.Items.Count} motocicletas");
            }

            Console.WriteLine($"Presione una tecla para obtener la fase con Id {createResponse.Id}");
            Console.ReadKey();
            var getByIdResponse = client.GetFase(new GetRequest() { Id = createResponse.Id.ToString() });
            if (getByIdResponse is null)
            {
                Console.WriteLine("Cannot get fase");
                channel.Dispose();
                return;
            }
            else
            {
                Console.WriteLine($"Obtención exitosa de la fase {getByIdResponse.Fase.Name}");
            }

            Console.WriteLine("Presione una tecla para modificar la fase");
            Console.ReadKey();
            createResponse.Description = "Se calienta rapidamente";
            client.UpdateFase(createResponse);

            var updatedGetResponse = client.GetFase(new GetRequest() { Id = createResponse.Id });
            if (updatedGetResponse is not null &&
                updatedGetResponse.KindCase == NullableFaseDTO.KindOneofCase.Fase &&
                updatedGetResponse.Fase.Description == createResponse.Description)
            {
                Console.WriteLine($"Modificación exitosa.");
            }

            Console.WriteLine("Presione una tecla para eliminar la fase");
            Console.ReadKey();

            client.DeleteFase(new DeleteRequest() { Id = createResponse.Id });
            var deletedGetResponse = client.GetFase(new GetRequest() { Id = createResponse.Id });
            if (deletedGetResponse is null ||
                deletedGetResponse.KindCase != NullableFaseDTO.KindOneofCase.Fase)
            {
                Console.WriteLine($"Eliminación exitosa.");
            }


            channel.Dispose();

        }

    }
}