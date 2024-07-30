using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.Settings.Categories;
using Souccar.SaleManagement.Stocks;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.Settings.Materials
{
    public class Material : FullAuditedAggregateRoot
    {
        public Material()
        {
            Stocks = new List<Stock>(); 
        }
        public string Name { get; set; }
        public string Specification { get; set; }

        #region Category
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        #endregion

        public virtual IList<Stock> Stocks { get; set; }
    }
}
