using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.Logs
{
    public class OrderLogAttribute: Entity
    {
        public OrderLogAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public int? OrderLogId { get; set; }

        [ForeignKey(nameof(OrderLogId))]
        public OrderLog OrderLog { get; set; }
    }
}
