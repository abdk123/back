using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Workflows.Dto.WorkflowStepGroupDtos;

namespace Souccar.Workflows.Services.Interfaces
{
    public interface IWorkflowStepGroupAppService : IAsyncSouccarAppService<WorkflowStepGroupDto, int, FullPagedRequestDto, CreateWorkflowStepGroupDto, UpdateWorkflowStepGroupDto>
    {
    }
}
