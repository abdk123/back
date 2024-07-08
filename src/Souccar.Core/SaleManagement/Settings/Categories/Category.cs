using Abp.Domain.Entities.Auditing;

namespace Souccar.SaleManagement.Settings.Categories
{
    public class Category : FullAuditedAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
