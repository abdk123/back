using Souccar.Hr.Employees.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;

namespace Souccar.Hr.Employees.Services
{
    public interface IEmployeeAppService : IAsyncSouccarAppService<EmployeeDto, int, FullPagedRequestDto, CreateEmployeeDto, UpdateEmployeeDto>
    {

    }
}