using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.Workflows.Services.Interfaces;

namespace Souccar.Workflows.Services.Implements
{
    public class WorkflowStepGroupManager : SouccarDomainService<WorkflowStepGroup, int>, IWorkflowStepGroupManager
    {
        private readonly IRepository<WorkflowStepGroup, int> _workflowStepGroupRepository;

        public WorkflowStepGroupManager(IRepository<WorkflowStepGroup, int> workflowStepGroupRepository) : base(workflowStepGroupRepository)
        {
            _workflowStepGroupRepository = workflowStepGroupRepository;
        }
    }
}
