using Seguimiento.Contracts.Fases;
using SeguimientoEjecuciones.DataAccess.Context;
using SeguimientoEjecuciones.DataAccess.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Fases;
using Seguimiento.domain.Entities;
using SeguimientoEjecuciones.DataAccess.Repositories.Fases;


namespace SeguimientoEjecuciones.DataAccess.Repositories.Fases
{
    public class FaseRepository : RepositoryBase, IFaseRepository
    {
        public FaseRepository(ApplicationContext context)
            : base(context) { }

        public void AddFase(Fase fase)
        {
            _context.Fases.Add(fase);
        }

        public void DeleteFase(Fase fase)
        {
            _context.Fases.Remove(fase);
        }

       
        public IEnumerable<Fase> GetAllFases()
        {
            return _context.Fases.ToList();
        }


        public Fase? GetFaseById(Guid id)
        {
            return _context.Fases.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateFase(Fase fase)
        {
            _context.Fases.Update(fase);
        }


    }
}

