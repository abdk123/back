using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.Workflows.Services.Interfaces;

namespace Souccar.Workflows.Services.Implements
{
    public class WorkflowStepActionManager : SouccarDomainService<WorkflowStepAction, int>, IWorkflowStepActionManager
    {
        private readonly IRepository<WorkflowStepAction, int> _workflowStepActionRepository;

        public WorkflowStepActionManager(IRepository<WorkflowStepAction, int> workflowStepActionRepository) : base(workflowStepActionRepository)
        {
            _workflowStepActionRepository = workflowStepActionRepository;
        }
    }
}
