using Seguimiento.domain.Entities;
using Seguimiento.Contracts.Operations;
using SeguimientoEjecuciones.DataAccess.Context;
using SeguimientoEjecuciones.DataAccess.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Operations;

namespace SeguimientoEjecuciones.DataAccess.Repositories.Operations
{
    public class OperationRepository : RepositoryBase, IOperationRepository
    {
        public OperationRepository(ApplicationContext context)
            : base(context) { }

        public void AddOperation(Operation operation)
        {
            _context.operaciones.Add(operation);
        }

        public void DeleteOperation(Operation operation)
        {
            _context.operaciones.Remove(operation);
        }

        public IEnumerable<Operation> GetAllOperations()
        {
            return _context.operaciones.ToList();
        }


        public Operation? GetOperationById(Guid id)
        {
            return _context.operaciones.FirstOrDefault(x => x.Id == id);
        }


        public void UpdateOperation(Operation operation)
        {
            _context.operaciones.Update(operation);
        }


    }
}