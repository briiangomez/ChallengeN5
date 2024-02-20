using ChallengeN5.Application.Employees.Common;
using ChallengeN5.Application.Permissions.Common;
using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Employees.GetAll
{
    internal sealed class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, ErrorOr<IReadOnlyList<EmployeeResponse>>>
    {
        private readonly IRepository<Employee> _EmployeeRepository;

        public GetAllEmployeesQueryHandler(IRepository<Employee> EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository ?? throw new ArgumentNullException(nameof(EmployeeRepository));
        }

        public async Task<ErrorOr<IReadOnlyList<EmployeeResponse>>> Handle(GetAllEmployeesQuery query, CancellationToken cancellationToken)
        {
            IReadOnlyList<Employee> Employees = await _EmployeeRepository.GetAll();

            return Employees.Select(Employee => new EmployeeResponse(
                    Employee.Id,
                    Employee.Name,
                    Employee.FullName,
                    Employee.Email,
                    Employee.PhoneNumber)
                ).ToList();
        }
    }
}
