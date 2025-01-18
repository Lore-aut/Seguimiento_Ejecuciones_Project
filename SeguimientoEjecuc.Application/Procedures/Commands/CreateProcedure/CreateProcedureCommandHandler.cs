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

namespace SeguimientoEjecuciones.Application.Procedures.Commands.CreateProcedure
{
    public class CreateProcedureCommandHandler : ICommandHandler<CreateProcedureCommand, Procedure>
    {
        private readonly IProcedureRepository _procedureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProcedureCommandHandler(IProcedureRepository procedureRepository, IUnitOfWork unitOfWork)
        {
            _procedureRepository = procedureRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Procedure> Handle(CreateProcedureCommand request, CancellationToken cancellationToken)
        {
            Procedure result = new Procedure(
                request.Name,
                request.ID,
                request.Description,
                request.CODE,
                new Guid());

            _procedureRepository.AddProcedure(result);
            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
