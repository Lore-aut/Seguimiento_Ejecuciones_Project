using Seguimiento.domain.Entities.Procedures;
using Seguimiento.Contracts.Procedures;
using SeguimientoEjecuciones.DataAccess.Context;
using SeguimientoEjecuciones.DataAccess.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguimientoEjecuciones.DataAccess.Repositories.Procedures
{
    public class ProcedureRepository : RepositoryBase, IProcedureRepository
    {
        public ProcedureRepository(ApplicationContext context)
            : base(context) { }

        public void AddProcedure(Procedure procedure)
        {
            _context.proc.Add(procedure);
        }

        public void DeleteProcedure(Procedure procedure)
        {
            _context.proc.Remove(procedure);
        }

        public IEnumerable<Procedure> GetAllProcedures()
        {
            return _context.proc.ToList();
        }

       
        public Procedure? GetProcedureById(Guid id)
        {
            return _context.proc.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateProcedure(Procedure procedure)
        {
            _context.proc.Update(procedure);
        }


    }
}