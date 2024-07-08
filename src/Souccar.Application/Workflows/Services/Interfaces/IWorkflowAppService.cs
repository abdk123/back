using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Workflows.Dto.WorkflowDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Workflows.Services.Interfaces
{
    public interface IWorkflowAppService : IAsyncSouccarAppService<WorkflowDto, int, FullPagedRequestDto, CreateWorkflowDto, UpdateWorkflowDto>
    {
        Task<IList<WorkflowForDropdownDto>> GetAllForDropdown();
    }
}
