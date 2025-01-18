using Seguimiento.Contracts.Executions;
using SeguimientoEjecuciones.DataAccess.Context;
using SeguimientoEjecuciones.DataAccess.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Executions;

namespace SeguimientoEjecuciones.DataAccess.Repositories.Executions
{
    public class ExecutionRepository : RepositoryBase, IExecutionRepository
    {
        public ExecutionRepository(ApplicationContext context)
            : base(context) { }

        public void AddExecution(Execution execution)
        {
            _context.exec.Add(execution);
        }

        public void DeleteExecution(Execution execution)
        {
            _context.exec.Remove(execution);
        }

        public IEnumerable<Execution> GetAllExecutions()
        {
            return _context.exec.ToList();
        }

        public Execution? GetExecutionById(Guid id)
        {
            return _context.exec.FirstOrDefault(x => x.Id == id);
        }


        public void UpdateExecution(Execution execution)
        {
            _context.exec.Update(execution);
        }

        public void StartExecution(Execution execution)
        {
            execution.state = seguimiento.domain.types.State.Running;
            execution.beggin = DateTime.Now;
            _context.exec.Update(execution);
        }

        public void StopExecution(Execution execution)
        {
            execution.state = seguimiento.domain.types.State.Paused;
            _context.exec.Update(execution);

        }

        public void EndExecution(Execution execution)
        {
            execution.state = seguimiento.domain.types.State.Completed;
            execution.end = DateTime.Now;
            _context.exec.Update(execution);
        }
        

    }
}
