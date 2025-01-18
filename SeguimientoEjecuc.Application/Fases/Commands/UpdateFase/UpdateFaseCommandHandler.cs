using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.DataAccess.Repositories.Fases;
using Seguimiento.domain.Entities.Fases;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.Contracts.Fases;
using Seguimiento.Contracts;

namespace SeguimientoEjecuciones.Application.Fases.Commands.UpdateFase
{
    public class UpdateFaseCommandHandler : ICommandHandler<UpdateFaseCommand>
    {
        private readonly IFaseRepository _faseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFaseCommandHandler(
            IFaseRepository faseRepository,
            IUnitOfWork unitOfWork)
        {
            _faseRepository = faseRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(UpdateFaseCommand request, CancellationToken cancellationToken)
        {
            _faseRepository.UpdateFase(request.Fase);
            _unitOfWork.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
