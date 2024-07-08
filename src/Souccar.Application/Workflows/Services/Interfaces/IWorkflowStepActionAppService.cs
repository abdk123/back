using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Workflows.Dto.WorkflowStepActionDtos;

namespace Souccar.Workflows.Services.Interfaces
{
    public interface IWorkflowStepActionAppService : IAsyncSouccarAppService<WorkflowStepActionDto, int, FullPagedRequestDto, CreateWorkflowStepActionDto, UpdateWorkflowStepActionDto>
    {
    }
}
