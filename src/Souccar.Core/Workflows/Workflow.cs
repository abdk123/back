using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace Souccar.Workflows
{
    public class Workflow : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public Workflow()
        {
            Steps= new List<WorkflowStep>();
        }
        public int? TenantId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public WorkflowStatus Status { get; set; }
        public virtual IList<WorkflowStep> Steps { get; set; }
    }
}
