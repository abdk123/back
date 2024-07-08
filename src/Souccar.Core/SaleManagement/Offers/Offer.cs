using Abp.Domain.Entities.Auditing;

namespace Souccar.SaleManagement.Offers
{
    public class Offer : FullAuditedAggregateRoot
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
