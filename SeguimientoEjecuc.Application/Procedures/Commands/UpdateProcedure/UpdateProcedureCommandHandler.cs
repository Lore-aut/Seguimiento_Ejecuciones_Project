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

namespace SeguimientoEjecuciones.Application.Procedures.Commands.UpdateProcedure
{
    
        public class UpdateProcedureCommandHandler : ICommandHandler<UpdateProcedureCommand>
        {
            private readonly IProcedureRepository _procedureRepository;
            private readonly IUnitOfWork _unitOfWork;

            public UpdateProcedureCommandHandler(
                IProcedureRepository procedureRepository,
                IUnitOfWork unitOfWork)
            {
                _procedureRepository = procedureRepository;
                _unitOfWork = unitOfWork;
            }

            public Task Handle(UpdateProcedureCommand request, CancellationToken cancellationToken)
            {
                _procedureRepository.UpdateProcedure(request.Procedure);
                _unitOfWork.SaveChanges();
                return Task.CompletedTask;
            }
        }
    }
