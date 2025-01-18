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
using Seguimiento.domain.Entities.Procedures;
using Seguimiento.domain.Entities.Executions;

namespace Seguimiento.DataAccess.Tests
{
    [TestClass]
    public class ProcedureTests
    {

        private IFaseRepository _faseRepository;
        private IOperationRepository _operationRepository;
        private IExecutionRepository _executionRepository;
        private IProcedureRepository _procRepository;
        private IUnitOfWork _unitOfWork;

        public ProcedureTests()
        {
            ApplicationContext context =
               new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _faseRepository = new FaseRepository(context);
            _operationRepository = new OperationRepository(context);
            _executionRepository = new ExecutionRepository(context);
            _procRepository = new ProcedureRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }



        [DataRow("Fundición", "EF116052304", "Fundir los minerales","P1")]
        [TestMethod]

        public void Can_Add_New_Procedure(string name, string id, string description,string code)
        {
            // Arrange
            Guid Id = Guid.NewGuid();
            Procedure proc = new Procedure(
                name,
                id,
                description,
                code,
                Id);

            // Execute
            _procRepository.AddProcedure(proc);
            _unitOfWork.SaveChanges();

            // Assert
            Procedure? loadedProcedure = _procRepository.GetProcedureById(Id);
            Assert.IsNotNull(loadedProcedure);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Procedure_By_Id(int position)
        {
            // Arrange
            var procs = _procRepository.GetAllProcedures().ToList();
            Assert.IsNotNull(procs);
            Assert.IsTrue(position < procs.Count);
            Procedure procToGet = procs[position];

            // Execute
            Procedure? loadedProcedure = _procRepository.GetProcedureById(procToGet.Id);

            // Assert
            Assert.IsNotNull(loadedProcedure);
        }

        [TestMethod]
        public void Can_Get_All_Fases()
        {
            // Arange
            var procs = _procRepository.GetAllProcedures().ToList();
            Assert.IsNotNull(procs);
            int count = procs.Count;

            //Execute
            int loadedCount =  _procRepository.GetAllProcedures().ToList().Count;

            //Assert
            Assert.AreEqual(count,loadedCount);

        }




        [DataRow(0, "MO345213456")]
        [TestMethod]
        public void Can_Update_Procedure(int position, string id)
        {
            // Arrange
            var procs = _procRepository.GetAllProcedures().ToList();
            Assert.IsNotNull(procs);
            Assert.IsTrue(position < procs.Count);
            Procedure procToUpdate = procs[position];

            // Execute
            procToUpdate.Identifier = id;
            _procRepository.UpdateProcedure(procToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Procedure? loadedProcedure = _procRepository.GetProcedureById(procToUpdate.Id);
            Assert.IsNotNull(loadedProcedure);
            Assert.AreEqual(loadedProcedure.Identifier, id);
        }


        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Procedure(int position)
        {
            // Arrange
            var procs = _procRepository.GetAllProcedures().ToList();
            Assert.IsNotNull(procs);
            Assert.IsTrue(position < procs.Count);
            Procedure procToDelete = procs[position];

            // Execute
            _procRepository.DeleteProcedure(procToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Procedure? loadedProcedure = _procRepository.GetProcedureById(procToDelete.Id);
            Assert.IsNull(loadedProcedure);
        }

       

        [TestMethod]
        public void Cannot_Get_Procedure_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Procedure? loadedProcedure = _procRepository.GetProcedureById(Guid.Empty);

            // Assert
            Assert.IsNull(loadedProcedure);
        }
    }
}
