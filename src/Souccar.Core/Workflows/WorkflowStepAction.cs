using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Workflows
{
    public class WorkflowStepAction : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public WorkflowActionType Type { get; set; }

        #region Workflow Step
        [ForeignKey("WorkflowStepId")]
        public virtual WorkflowStep WorkflowStep { get; set; }
        public int? WorkflowStepId { get; set; }
        #endregion

        #region Workflow Index
        [ForeignKey("WorkflowIndexId")]
        public virtual WorkflowStepIndex WorkflowIndex { get; set; }
        public int? WorkflowIndexId { get; set; }
        #endregion
    }
}
