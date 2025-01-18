using Seguimiento.Contracts;
using Seguimiento.domain;
using Seguimiento.Contracts.Fases;
using Seguimiento.Contracts.Executions;
using Seguimiento.Contracts.Operations;
using Seguimiento.Contracts.Procedures;
using SeguimientoEjecuciones.DataAccess.Context;
using SeguimientoEjecuciones.DataAccess.Repositories.Fases;
using SeguimientoEjecuciones.DataAccess.Repositories.Operations;
using SeguimientoEjecuciones.DataAccess.Repositories.Procedures;
using SeguimientoEjecuciones.DataAccess.Repositories.Executions;
using Seguimiento.DataAccess.Tests.Utilities;
using Seguimiento.DataAccess;
using Seguimiento.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.DataAccess;
using Seguimiento.domain.Entities.Fases;
using Seguimiento.domain.Entities.Operations;
using Seguimiento.domain.Entities.Executions;

namespace Seguimiento.DataAccess.Tests
{
    [TestClass]
    public class OperationTests
    {

        private IFaseRepository _faseRepository;
        private IOperationRepository _operationRepository;
        private IExecutionRepository _executionRepository;
        private IProcedureRepository _procRepository;
        private IUnitOfWork _unitOfWork;

        public OperationTests()
        {
            ApplicationContext context =
               new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _faseRepository = new FaseRepository(context);
            _operationRepository = new OperationRepository(context);
            _executionRepository = new ExecutionRepository(context);
            _procRepository = new ProcedureRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }


        [DataRow("Ajuste de parametros", "RT829104375", "Rectificacion de desajustes","Op1")]
        [DataRow("Tratar materia prima", "OP256052304", "Eliminar impurezas","Op2")]
        [TestMethod]

        public void Can_Add_New_Operation(string name, string id, string description,string code)
        {
            // Arrange
            Guid Id = Guid.NewGuid();
            Operation operation = new Operation(
                name,
                id,
                description,
                code,
                Id);

            // Execute
            _operationRepository.AddOperation(operation);
            _unitOfWork.SaveChanges();

            // Assert
            Operation? loadedOperation = _operationRepository.GetOperationById(Id);
            Assert.IsNotNull(loadedOperation);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Operation_By_Id(int position)
        {
            // Arrange
            var operations = _operationRepository.GetAllOperations().ToList();
            Assert.IsNotNull(operations);
            Assert.IsTrue(position < operations.Count);
            Operation operationToGet = operations[position];

            // Execute
            Operation? loadedOperation = _operationRepository.GetOperationById(operationToGet.Id);

            // Assert
            Assert.IsNotNull(loadedOperation);
        }



        [DataRow(0, "MO345213456")]
        [TestMethod]
        public void Can_Update_Operation(int position, string id)
        {
            // Arrange
            var operations = _operationRepository.GetAllOperations().ToList();
            Assert.IsNotNull(operations);
            Assert.IsTrue(position < operations.Count);
            Operation operationToUpdate = operations[position];

            // Execute
            operationToUpdate.Identifier = id;
            _operationRepository.UpdateOperation(operationToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Operation? loadedOperation = _operationRepository.GetOperationById(operationToUpdate.Id);
            Assert.IsNotNull(loadedOperation);
            Assert.AreEqual(loadedOperation.Identifier, id);
        }


        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Operation(int position)
        {
            // Arrange
            var operations = _operationRepository.GetAllOperations().ToList();
            Assert.IsNotNull(operations);
            Assert.IsTrue(position < operations.Count);
            Operation operationToDelete = operations[position];

            // Execute
            _operationRepository.DeleteOperation(operationToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Operation? loadedOperation = _operationRepository.GetOperationById(operationToDelete.Id);
            Assert.IsNull(loadedOperation);
        }

        [TestMethod]
        public void Cannot_Get_Operation_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Operation? loadedOperation = _operationRepository.GetOperationById(Guid.Empty);

            // Assert
            Assert.IsNull(loadedOperation);
        }

        [TestMethod]
        public void Can_Get_All_Operations()
        {
            // Arange
            var ops = _operationRepository.GetAllOperations().ToList();
            Assert.IsNotNull(ops);
            int count = ops.Count;

            //Execute
            int loadedCount = _operationRepository.GetAllOperations().ToList().Count;

            //Assert
            Assert.AreEqual(count, loadedCount);

        }
    }
}
