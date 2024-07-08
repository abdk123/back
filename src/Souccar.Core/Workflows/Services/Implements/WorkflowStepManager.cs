using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Workflows.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Workflows.Services.Implements
{
    public class WorkflowStepManager : SouccarDomainService<WorkflowStep, int>, IWorkflowStepManager
    {
        private readonly IRepository<WorkflowStep, int> _workflowStepRepository;

        public WorkflowStepManager(IRepository<WorkflowStep, int> workflowStepRepository) : base(workflowStepRepository)
        {
            _workflowStepRepository = workflowStepRepository;
        }

        public async Task<IList<WorkflowStep>> GetAllByWorkflowId(int workflowId)
        {
            var steps = await Task.FromResult(_workflowStepRepository.GetAllIncluding(x=>x.Actions)
                .Include(z=>z.Groups).Where(w=>w.WorkflowId == workflowId).ToList());
            return steps;
        }

        public WorkflowStep GetWithDetails(int id)
        {
            var workflowStep = _workflowStepRepository.GetAllIncluding(x => x.Actions).Include(y => y.Groups)
                .FirstOrDefault(z=>z.Id == id);
            return workflowStep;
        }
    }
}
