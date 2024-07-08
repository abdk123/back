using Souccar.Hr.Employees.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.Hr.Employees.Services
{
    public class EmployeeAppService :
        AsyncSouccarAppService<Employee, EmployeeDto, int, FullPagedRequestDto, CreateEmployeeDto, UpdateEmployeeDto>, IEmployeeAppService
    {
        private readonly IEmployeeDomainService _employeeDomainService;
        public EmployeeAppService(IEmployeeDomainService employeeDomainService) : base(employeeDomainService)
        {
            _employeeDomainService = employeeDomainService;
        }
    }
}

