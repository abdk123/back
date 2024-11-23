using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.Settings.Categories;
using Souccar.SaleManagement.Settings.Units;
using Souccar.SaleManagement.Stocks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        public double TotalQuantity => Stocks.Any() ? Stocks.Sum(x => x.NumberInLargeUnit) : 0;

        #region Category
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        #endregion

        #region Unit
        public int? UnitId { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }
        #endregion

        public virtual IList<Stock> Stocks { get; set; }
    }
}
