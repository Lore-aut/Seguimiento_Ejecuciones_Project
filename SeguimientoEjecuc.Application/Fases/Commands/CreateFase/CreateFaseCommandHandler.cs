using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguimiento.domain.Entities.Fases;
using SeguimientoEjecuciones.DataAccess.Repositories.Fases;
using SeguimientoEjecuciones.DataAccess;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.Contracts.Fases;
using Seguimiento.Contracts;

namespace SeguimientoEjecuciones.Application.Fases.Commands.CreateFase
{
    public class CreateFaseCommandHandler : ICommandHandler<CreateFaseCommand,Fase>
    {
        private readonly IFaseRepository _faseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFaseCommandHandler( IFaseRepository faseRepository, IUnitOfWork unitOfWork)
        {
            _faseRepository = faseRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Fase> Handle(CreateFaseCommand request, CancellationToken cancellationToken)
        {
            Fase result = new Fase(
                request.Name,
                request.ID,
                request.Description,
                Guid.NewGuid());

            _faseRepository.AddFase(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
