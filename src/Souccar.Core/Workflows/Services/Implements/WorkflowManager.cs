using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.Workflows.Services.Interfaces;

namespace Souccar.Workflows.Services.Implements
{
    public class WorkflowManager : SouccarDomainService<Workflow, int>, IWorkflowManager
    {
        private readonly IRepository<Workflow, int> _workflowRepository;

        public WorkflowManager(IRepository<Workflow, int> workflowRepository) : base(workflowRepository)
        {
            _workflowRepository = workflowRepository;
        }
    }
}
