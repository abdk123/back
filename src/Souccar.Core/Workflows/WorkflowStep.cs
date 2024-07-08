using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Workflows
{
    public class WorkflowStep : FullAuditedEntity, IMayHaveTenant
    {
        public WorkflowStep()
        {
            Groups = new List<WorkflowStepGroup>();
            Actions = new List<WorkflowStepAction>();
        }

        public int? TenantId { get; set; }
        public string Title { get; set; }
        public WorkflowStepStatus Status { get; set; }
        public int Index { get; set; }

        #region Workflow
        [ForeignKey("WorkflowId")]
        public virtual Workflow Workflow { get; set; }
        public int? WorkflowId { get; set; }
        #endregion

        public virtual IList<WorkflowStepGroup> Groups { get; set; }
        public virtual IList<WorkflowStepAction> Actions { get; set; }
    }
}
