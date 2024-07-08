using Abp.Domain.Entities.Auditing;

namespace Souccar.SaleManagement.Settings.Stores
{
    public class Store : FullAuditedAggregateRoot
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
