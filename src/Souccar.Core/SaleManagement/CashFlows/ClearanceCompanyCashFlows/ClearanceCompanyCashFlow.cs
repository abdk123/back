using Souccar.SaleManagement.CachFlows;
using Souccar.SaleManagement.Settings.Companies;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.CashFlows.ClearanceCompanyCashFlows
{
    public class ClearanceCompanyCashFlow : BaseCashFlow
    {
        #region ClearanceCompany 
        public int? ClearanceCompanyId { get; set; }
        [ForeignKey("ClearanceCompanyId")]
        public virtual ClearanceCompany ClearanceCompany { get; set; }
        #endregion
    }
}
