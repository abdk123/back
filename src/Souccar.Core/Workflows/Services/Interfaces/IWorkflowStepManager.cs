using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Workflows.Services.Interfaces
{
    public interface IWorkflowStepManager : ISouccarDomainService<WorkflowStep, int>
    {
        WorkflowStep GetWithDetails(int id);
        Task<IList<WorkflowStep>> GetAllByWorkflowId(int workflowId);
    }
}
