using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Employees.Update
{
    internal sealed class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ErrorOr<Unit>>
    {
        private readonly IRepository<Employee> _EmployeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateEmployeeCommandHandler(IRepository<Employee> EmployeeRepository, IUnitOfWork unitOfWork)
        {
            _EmployeeRepository = EmployeeRepository ?? throw new ArgumentNullException(nameof(EmployeeRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Unit>> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            if (!await _EmployeeRepository.ExistsAsync(command.Id))
            {
                return Error.NotFound("Employee.NotFound", "The Employee with the provide Id was not found.");
            }


            Employee Employee = new Employee(command.Id, command.Name,
                command.LastName,
                command.Email,
                command.PhoneNumber);

            _EmployeeRepository.Update(Employee);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
