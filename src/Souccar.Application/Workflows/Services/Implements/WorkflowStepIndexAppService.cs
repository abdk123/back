using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Workflows.Dto.WorkflowStepIndexDtos;
using Souccar.Workflows.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Workflows.Services.Implements
{
    public class WorkflowStepIndexAppService :
        AsyncSouccarAppService<WorkflowStepIndex, WorkflowStepIndexDto, int, FullPagedRequestDto, CreateWorkflowStepIndexDto, UpdateWorkflowStepIndexDto>, IWorkflowStepIndexAppService
    {
        private readonly IWorkflowStepIndexManager _WorkflowStepIndexDomainService;

        public WorkflowStepIndexAppService(IWorkflowStepIndexManager WorkflowStepIndexDomainService) : base(WorkflowStepIndexDomainService)
        {
            _WorkflowStepIndexDomainService = WorkflowStepIndexDomainService;
        }

        public async Task<IList<WorkflowStepIndexForDropdownDto>> GetAllForDropdown()
        {
            var indexes = await Task.FromResult(_WorkflowStepIndexDomainService.GetAll().ToList());
            return ObjectMapper.Map<IList<WorkflowStepIndexForDropdownDto>>(indexes);
        }
    }
}
