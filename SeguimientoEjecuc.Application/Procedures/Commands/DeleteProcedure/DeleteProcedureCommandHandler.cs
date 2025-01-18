using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeguimientoEjecuciones.Application.Abstract;
using Seguimiento.domain.Entities.Procedures;
using SeguimientoEjecuciones.DataAccess.Repositories.Procedures;
using Seguimiento.Contracts.Procedures;
using Seguimiento.Contracts;

namespace SeguimientoEjecuciones.Application.Procedures.Commands.DeleteProcedure
{
    public class DeleteProcedureCommandHandler : ICommandHandler<DeleteProcedureCommand>
    {
        private readonly IProcedureRepository _procedureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProcedureCommandHandler(
            IProcedureRepository procedureRepository,
            IUnitOfWork unitOfWork)
        {
            _procedureRepository = procedureRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteProcedureCommand request, CancellationToken cancellationToken)
        {
            var procedureToDelete = _procedureRepository.GetProcedureById(request.id);
            if (procedureToDelete is null)
                return Task.CompletedTask;
            _procedureRepository.DeleteProcedure(procedureToDelete);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
