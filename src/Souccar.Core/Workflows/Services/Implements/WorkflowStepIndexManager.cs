using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.Workflows.Services.Interfaces;

namespace Souccar.Workflows.Services.Implements
{
    public class WorkflowStepIndexManager : SouccarDomainService<WorkflowStepIndex, int>, IWorkflowStepIndexManager
    {
        private readonly IRepository<WorkflowStepIndex, int> _workflowIndexRepository;

        public WorkflowStepIndexManager(IRepository<WorkflowStepIndex, int> workflowIndexRepository) : base(workflowIndexRepository)
        {
            _workflowIndexRepository = workflowIndexRepository;
        }
    }
}
