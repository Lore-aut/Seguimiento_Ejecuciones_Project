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

namespace SeguimientoEjecuciones.Application.Fases.Commands.DeleteFase
{

    public class DeleteFaseCommandHandler : ICommandHandler<DeleteFaseCommand>
    {
        private readonly IFaseRepository _faseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFaseCommandHandler(
            IFaseRepository faseRepository,
            IUnitOfWork unitOfWork)
        {
            _faseRepository = faseRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteFaseCommand request, CancellationToken cancellationToken)
        {
            var faseToDelete = _faseRepository.GetFaseById(request.id);
            if (faseToDelete is null)
                return Task.CompletedTask;
            _faseRepository.DeleteFase(faseToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }

}
