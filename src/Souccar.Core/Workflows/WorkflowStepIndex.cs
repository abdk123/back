using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Souccar.Workflows
{
    public class WorkflowStepIndex : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string ActionName { get; set; }
        public int Order { get; set; }
    }
}
