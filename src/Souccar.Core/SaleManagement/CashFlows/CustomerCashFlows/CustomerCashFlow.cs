using Souccar.SaleManagement.CachFlows;
using Souccar.SaleManagement.Settings.Customers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows
{
    public class CustomerCashFlow : BaseCashFlow
    {
        #region Customer 
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        #endregion
    }
}
