using Abp.Domain.Entities.Auditing;

namespace Souccar.SaleManagement.Settings.Units
{
    public class Unit : FullAuditedAggregateRoot
    {
        public string Name { get; set; }
    }
}
