

using Abp.Domain.Entities.Auditing;

namespace Souccar.SaleManagement.Settings.Units
{
    /// <summary>
    /// الوحدات الصغيرة
    /// </summary>
    public class Size : FullAuditedAggregateRoot
    {
        public string Name { get; set; }
    }
}
