using ChallengeN5.Application.Employees.Common;
using ChallengeN5.Domain.Contracts;
using ChallengeN5.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeN5.Application.Employees.GetById
{
    internal sealed class GetByIdQueryEmployeeHandler : IRequestHandler<GetByIdEmployeeQuery, ErrorOr<EmployeeResponse>>
    {
        private readonly IRepository<Employee> _EmployeeRepository;

        public GetByIdQueryEmployeeHandler(IRepository<Employee> EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository ?? throw new ArgumentNullException(nameof(EmployeeRepository));
        }

        public async Task<ErrorOr<EmployeeResponse>> Handle(GetByIdEmployeeQuery query, CancellationToken cancellationToken)
        {
            

            if (await _EmployeeRepository.GetByIdAsync(query.Id) is not Employee Employee)
            {
                return Error.NotFound("Employee.NotFound", "The Employee with the provide Id was not found.");
            }

            return new EmployeeResponse(
                Employee.Id,
                Employee.Name,
                Employee.LastName,
                Employee.Email,
                Employee.PhoneNumber);
        }

            
    }
}
