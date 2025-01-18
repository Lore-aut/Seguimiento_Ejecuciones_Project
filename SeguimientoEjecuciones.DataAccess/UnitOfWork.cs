using Microsoft.EntityFrameworkCore;
using SeguimientoEjecuciones.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.DataAccess;
using Seguimiento.Contracts;


namespace SeguimientoEjecuciones.DataAccess
{
   ///<summary> Implementacion de IUnitOfWork </summary>
   public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            if (!context.Database.CanConnect())
                context.Database.Migrate();
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
