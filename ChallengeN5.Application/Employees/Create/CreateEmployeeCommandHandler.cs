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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChallengeN5.Application.Employees.Create
{
    public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ErrorOr<Guid>>
    {
        private readonly IRepository<Employee> _EmployeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateEmployeeCommandHandler(IRepository<Employee> EmployeeRepository, IUnitOfWork unitOfWork)
        {
            _EmployeeRepository = EmployeeRepository ?? throw new ArgumentNullException(nameof(EmployeeRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<ErrorOr<Guid>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {

            var Employee = new Employee(
                Guid.NewGuid(),
                command.Name,
                command.LastName,
                command.Email,
                command.PhoneNumber
            );

            _EmployeeRepository.Add(Employee);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Employee.Id;
        }
    }

}
