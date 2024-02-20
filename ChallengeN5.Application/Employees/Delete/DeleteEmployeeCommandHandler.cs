using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Employees.Delete
{
    internal sealed class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ErrorOr<Unit>>
    {
        private readonly IRepository<Employee> _EmployeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteEmployeeCommandHandler(IRepository<Employee> EmployeeRepository, IUnitOfWork unitOfWork)
        {
            _EmployeeRepository = EmployeeRepository ?? throw new ArgumentNullException(nameof(EmployeeRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            if (await _EmployeeRepository.GetByIdAsync(command.Id) is not Employee Employee)
            {
                return Error.NotFound("Employee.NotFound", "The Employee with the provide Id was not found.");
            }

            _EmployeeRepository.Delete(Employee);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
