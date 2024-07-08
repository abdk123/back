using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.Hr.Employees.Services
{
    public class EmployeeDomainService : SouccarDomainService<Employee, int>, IEmployeeDomainService
    {
        public EmployeeDomainService(IRepository<Employee, int> employeeRepository) : base(employeeRepository)
        {
        }
    }
}

