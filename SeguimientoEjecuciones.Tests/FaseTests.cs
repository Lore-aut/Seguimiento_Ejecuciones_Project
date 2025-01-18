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
using Seguimiento.domain.Entities.Executions;

namespace Seguimiento.DataAccess.Tests
{
    [TestClass]
    public class FaseTests
    {

        private IFaseRepository _faseRepository;
        private IOperationRepository _operationRepository;
        private IExecutionRepository _executionRepository;
        private IProcedureRepository _procRepository;
        private IUnitOfWork _unitOfWork;

        public FaseTests()
        {
            ApplicationContext context =
               new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _faseRepository = new FaseRepository(context);
            _operationRepository = new OperationRepository(context);
            _executionRepository = new ExecutionRepository(context);
            _procRepository = new ProcedureRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }



        [DataRow("Calentamiento", "EF116052304", "Calentamiento de las calderas")]
        [DataRow("Remover", "RS256052304", "Remover hasta lograr consistencia")]
        [TestMethod]

        public void Can_Add_New_Fase(string name, string id, string description)
        {
            // Arrange
            Guid Id = Guid.NewGuid();
            Fase fase = new Fase(
                name,
                id,
                description,
                Id);

            // Execute
            _faseRepository.AddFase(fase);
            _unitOfWork.SaveChanges();

            // Assert
            Fase? loadedFase = _faseRepository.GetFaseById(Id);
            Assert.IsNotNull(loadedFase);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Fase_By_Id(int position)
        {
            // Arrange
            var fases = _faseRepository.GetAllFases().ToList();
            Assert.IsNotNull(fases);
            Assert.IsTrue(position < fases.Count);
            Fase faseToGet = fases[position];

            // Execute
            Fase? loadedFase = _faseRepository.GetFaseById(faseToGet.Id);

            // Assert
            Assert.IsNotNull(loadedFase);
        }



        [DataRow(0, "MO345213456")]
        [TestMethod]
        public void Can_Update_Fase(int position, string id)
        {
            // Arrange
            var fases = _faseRepository.GetAllFases().ToList();
            Assert.IsNotNull(fases);
            Assert.IsTrue(position < fases.Count);
            Fase faseToUpdate = fases[position];

            // Execute
            faseToUpdate.Identifier = id;
            _faseRepository.UpdateFase(faseToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Fase? loadedFase = _faseRepository.GetFaseById(faseToUpdate.Id);
            Assert.IsNotNull(loadedFase);
            Assert.AreEqual(loadedFase.Identifier, id);
        }


        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Fase(int position)
        {
            // Arrange
            var fases = _faseRepository.GetAllFases().ToList();
            Assert.IsNotNull(fases);
            Assert.IsTrue(position < fases.Count);
            Fase faseToDelete = fases[position];

            // Execute
            _faseRepository.DeleteFase(faseToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Fase? loadedFase = _faseRepository.GetFaseById(faseToDelete.Id);
            Assert.IsNull(loadedFase);
        }

        [TestMethod]
        public void Cannot_Get_Fase_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Fase? loadedFase = _faseRepository.GetFaseById(Guid.Empty);

            // Assert
            Assert.IsNull(loadedFase);
        }

        [TestMethod]
        public void Can_Get_All_Fases()
        {
            // Arange
            var procs = _faseRepository.GetAllFases().ToList();
            Assert.IsNotNull(procs);
            int count = procs.Count;

            //Execute
            int loadedCount = _faseRepository.GetAllFases().ToList().Count;

            //Assert
            Assert.AreEqual(count, loadedCount);

        }

    }
}
