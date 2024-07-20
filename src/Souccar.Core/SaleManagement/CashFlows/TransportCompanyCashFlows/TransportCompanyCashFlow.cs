using Souccar.SaleManagement.Settings.Companies;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.SaleManagement.CachFlows.TransportCompanyCachFlows
{
    public class TransportCompanyCashFlow : BaseCashFlow
    {
        #region TransportCompany 
        public int? TransportCompanyId { get; set; }
        [ForeignKey("TransportCompanyId")]
        public virtual TransportCompany TransportCompany { get; set; }
        #endregion
    }
}
