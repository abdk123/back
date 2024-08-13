using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace Souccar.SaleManagement.Logs
{
    public class OrderLog : FullAuditedAggregateRoot
    {
        public OrderLog()
        {
            Attributes = new List<OrderLogAttribute>();
        }
        public OrderLogType Type { get; set; }
        public int ActionId { get; set; }
        public int RelatedId { get; set; }
        public string FullName { get; set; }
        public IList<OrderLogAttribute> Attributes { get; set; }
    }
}
