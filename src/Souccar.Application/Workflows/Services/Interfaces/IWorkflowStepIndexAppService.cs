using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Workflows.Dto.WorkflowStepIndexDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Workflows.Services.Interfaces
{
    public interface IWorkflowStepIndexAppService : IAsyncSouccarAppService<WorkflowStepIndexDto, int, FullPagedRequestDto, CreateWorkflowStepIndexDto, UpdateWorkflowStepIndexDto>
    {
        Task<IList<WorkflowStepIndexForDropdownDto>> GetAllForDropdown();
    }
}
