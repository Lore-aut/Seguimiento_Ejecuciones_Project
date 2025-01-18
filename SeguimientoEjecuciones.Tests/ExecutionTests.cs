using Seguimiento.Contracts;
using Seguimiento.domain;
using Seguimiento.domain.Entities.Executions;
using Seguimiento.domain.Entities.Procedures;
using Seguimiento.Contracts.Fases;
using Seguimiento.Contracts.Executions;
using Seguimiento.Contracts.Operations;
using Seguimiento.Contracts.Procedures;
using SeguimientoEjecuciones.DataAccess.Context;
using SeguimientoEjecuciones.DataAccess.Repositories.Fases;
using SeguimientoEjecuciones.DataAccess.Repositories.Operations;
using SeguimientoEjecuciones.DataAccess.Repositories.Procedures;
using SeguimientoEjecuciones.DataAccess.Repositories.Executions;
using seguimiento.domain.types;
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
using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Seguimiento.domain.Entities.Operations;
using Seguimiento.domain.Types;

namespace Seguimiento.DataAccess.Tests
{
    [TestClass]
    public class ExecutionTests
    {

        private IFaseRepository _faseRepository;
        private IOperationRepository _operationRepository;
        private IExecutionRepository _executionRepository;
        private IProcedureRepository _procRepository;
        private IUnitOfWork _unitOfWork;

        public ExecutionTests()
        {
            ApplicationContext context =
               new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _faseRepository = new FaseRepository(context);
            _operationRepository = new OperationRepository(context);
            _executionRepository = new ExecutionRepository(context);
            _procRepository = new ProcedureRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }


        [DataRow(2024,1,3,2024,3,2,State.Idle,ExecType.ProcedureExecution)]
        [TestMethod]

        public void Can_Add_ExecutionP(int year1,int month1,int day1,int year2,int month2,int day2,State _state,ExecType _type)
        {
            // Arrange
            Guid id_post_entity = Guid.NewGuid();
            Guid id_actual_entity = Guid.NewGuid();
            Guid id = Guid.NewGuid();

            
            Execution exec = new Execution(
                _type,
                id_actual_entity,
                id,
                id_post_entity, 
                new DateTime(year1, month1, day1),
                new DateTime(year2, month2, day2),
                 _state
                );


            // Execute
            _executionRepository.AddExecution(exec);
            _unitOfWork.SaveChanges();

            // Assert
            Execution? loadedExecution = _executionRepository.GetExecutionById(id);
            Assert.IsNotNull(loadedExecution);
        }



        [DataRow(2023, 2, 5, 2023, 6, 3, State.Running, ExecType.FaseExecution)]

        [TestMethod]
        public void Can_Add_ExecutionF(int year1, int month1, int day1, int year2, int month2, int day2, State _state, ExecType _type)
        {
            // Arrange
            Guid id_post_entity = Guid.NewGuid();
            Guid id_actual_entity = Guid.NewGuid();
            Guid id = Guid.NewGuid();


            Execution execf = new Execution(
                _type,
                id_actual_entity,
                id,
                 id_post_entity,
                new DateTime(year1, month1, day1),
                new DateTime(year2, month2, day2),
                _state);


            // Execute
            _executionRepository.AddExecution(execf);
            _unitOfWork.SaveChanges();

            // Assert
            Execution? loadedExecution = _executionRepository.GetExecutionById(id);
            Assert.IsNotNull(loadedExecution);
        }



        [DataRow(2025, 8, 9, 2025, 1,2, State.Completed, ExecType.OperationExecution)]

        [TestMethod]
        public void Can_Add_ExecutionO(int year1, int month1, int day1, int year2, int month2, int day2, State _state, ExecType _type)
        {
            // Arrange
            Guid id_post_entity = Guid.NewGuid();
            Guid id_actual_entity = Guid.NewGuid();
            Guid id = Guid.NewGuid();


            Execution execo = new Execution(
               _type,
               id_actual_entity,
               id,
                id_post_entity,
               new DateTime(year1, month1, day1),
               new DateTime(year2, month2, day2),
               _state);


            // Execute
            _executionRepository.AddExecution(execo);
            _unitOfWork.SaveChanges();

            // Assert
            Execution? loadedExecution = _executionRepository.GetExecutionById(id);
            Assert.IsNotNull(loadedExecution);
        }



        [DataRow(0)]
        [TestMethod]
        public void Can_Get_ExecutionP_By_Id(int position)
        {
            // Arrange
            var executions = _executionRepository.GetAllExecutions().ToList();
            Assert.IsNotNull(executions);
            Assert.IsTrue(position < executions.Count);
            Execution execToGet = executions[position];

            // Execute
            Execution? loadedExecution = _executionRepository.GetExecutionById(execToGet.Id);

            // Assert
            Assert.IsNotNull(loadedExecution);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_ExecutionF_By_Id(int position)
        {
            // Arrange
            var executions = _executionRepository.GetAllExecutions().ToList();
            Assert.IsNotNull(executions);
            Assert.IsTrue(position < executions.Count);
            Execution execFToGet = executions[position];

            // Execute
            Execution? loadedExecutionF = _executionRepository.GetExecutionById(execFToGet.Id);

            // Assert
            Assert.IsNotNull(loadedExecutionF);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_ExecutionO_By_Id(int position)
        {
            // Arrange
            var executions = _executionRepository.GetAllExecutions().ToList();
            Assert.IsNotNull(executions);
            Assert.IsTrue(position < executions.Count);
            Execution execOToGet = executions[position];

            // Execute
            Execution? loadedExecutionO = _executionRepository.GetExecutionById(execOToGet.Id);

            // Assert
            Assert.IsNotNull(loadedExecutionO);
        }


        [TestMethod]
        public void Cannot_Get_Execution_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Execution? loadedExecution = _executionRepository.GetExecutionById(Guid.Empty);

            // Assert
            Assert.IsNull(loadedExecution);
        }
  


        [DataRow(0,2023,3,2,2023,3,6,1)]
        [TestMethod]

        public void Can_Update_Execution(int position, int year1, int month1, int day1, int year2,int month2, int day2, int STATE)
        {
            // Arrange
            var executions = _executionRepository.GetAllExecutions().ToList();
            Assert.IsNotNull(executions);
            Assert.IsTrue(position < executions.Count);
            Execution execToUpdate = executions[position];

            DateTime Beggin = new DateTime(year1, month1, day1);
            DateTime End = new DateTime(year2, month2, day2);
            

            // Execute
            execToUpdate.beggin = Beggin;
            execToUpdate.end = End;
            execToUpdate.state = (State) STATE;
            _executionRepository.UpdateExecution(execToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Execution? loadedExecution = _executionRepository.GetExecutionById(execToUpdate.Id);
            Assert.IsNotNull(loadedExecution);
            Assert.AreEqual(loadedExecution.beggin, Beggin);
            Assert.AreEqual(loadedExecution.end, End);
            Assert.AreEqual(loadedExecution.state, (State) STATE);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Start_Execution(int position)
        {
            // Arrange
            var executions = _executionRepository.GetAllExecutions().ToList();
            Assert.IsNotNull(executions);
            Assert.IsTrue(position < executions.Count);
            Execution execToStart = executions[position];
            DateTime Now = DateTime.Now;

            //Execute 
            execToStart.state = State.Running;
            execToStart.beggin = Now;
            _executionRepository.UpdateExecution(execToStart);
            _unitOfWork.SaveChanges();

            //Assert
            Assert.AreEqual(execToStart.beggin, Now);
            Assert.AreEqual(execToStart.state, State.Running);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Stop_Execution(int position)
        {
            // Arrange
            var executions = _executionRepository.GetAllExecutions().ToList();
            Assert.IsNotNull(executions);
            Assert.IsTrue(position < executions.Count);
            Execution execToStop = executions[position];


            //Execute 
            execToStop.state = State.Paused;
            _executionRepository.UpdateExecution(execToStop);
            _unitOfWork.SaveChanges();

            //Assert
            Assert.AreEqual(execToStop.state, State.Paused);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_End_Execution(int position)
        {
            // Arrange
            var executions = _executionRepository.GetAllExecutions().ToList();
            Assert.IsNotNull(executions);
            Assert.IsTrue(position < executions.Count);
            Execution execToEnd = executions[position];
            DateTime Now = DateTime.Now;

            //Execute 
            execToEnd.state = State.Completed;
            execToEnd.end = Now;
            _executionRepository.UpdateExecution(execToEnd);
            _unitOfWork.SaveChanges();

            //Assert
            Assert.AreEqual(execToEnd.state, State.Completed);
            Assert.AreEqual(execToEnd.end, Now);
        }


        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Execution(int position)
        {
            // Arrange
            var executions = _executionRepository.GetAllExecutions().ToList();
            Assert.IsNotNull(executions);
            Assert.IsTrue(position < executions.Count);
            Execution execToDelete = executions[position];

            // Execute
            _executionRepository.DeleteExecution(execToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Execution? loadedExecution = _executionRepository.GetExecutionById(execToDelete.Id);
            Assert.IsNull(loadedExecution);
        }

        [TestMethod]
        public void Can_Get_All_Executions()
        {
            // Arange
            var procs = _executionRepository.GetAllExecutions().ToList();
            Assert.IsNotNull(procs);
            int count = procs.Count;

            //Execute
            int loadedCount = _executionRepository.GetAllExecutions().ToList().Count;

            //Assert
            Assert.AreEqual(count, loadedCount);

        }

        
    }
}
