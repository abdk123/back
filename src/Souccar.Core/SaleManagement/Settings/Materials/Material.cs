using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.Settings.Categories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.Settings.Materials
{
    public class Material : FullAuditedAggregateRoot
    {
        public string Name { get; set; }
        public string Specification { get; set; }

        #region Category
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        #endregion
    }
}
