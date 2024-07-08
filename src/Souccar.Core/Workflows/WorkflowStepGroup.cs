using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Workflows
{
    public class WorkflowStepGroup : FullAuditedEntity, IMayHaveTenant
    {
        public WorkflowStepGroup()
        {
            //Roles = new List<Role>();
            //Users = new List<User>();
        }
        public int? TenantId { get; set; }

        #region Workflow Step
        [ForeignKey("WorkflowStepId")]
        public virtual WorkflowStep WorkflowStep { get; set; }
        public int? WorkflowStepId { get; set; }
        #endregion

        //public virtual IList<Role> Roles { get; set; }
        //public virtual IList<User> Users { get; set; }

    }
}
