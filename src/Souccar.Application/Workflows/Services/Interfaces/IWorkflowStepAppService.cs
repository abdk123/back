using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Workflows.Dto.WorkflowStepDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Workflows.Services.Interfaces
{
    public interface IWorkflowStepAppService : IAsyncSouccarAppService<WorkflowStepDto, int, FullPagedRequestDto, CreateWorkflowStepDto, UpdateWorkflowStepDto>
    {
        Task<IList<WorkflowStepDto>> GetAllByWorkflowId(int workflowId);
    }
}
