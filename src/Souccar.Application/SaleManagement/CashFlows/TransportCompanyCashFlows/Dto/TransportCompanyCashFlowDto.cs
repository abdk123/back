using Abp.Application.Services.Dto;
using Souccar.SaleManagement.Settings.Companies.Dto;
using System;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto
{
    public class TransportCompanyCashFlowDto : EntityDto
    {
        public double AmountDollar { get; set; }
        public double CurrentBalanceDollar { get; set; }
        public double AmountDinar { get; set; }
        public double CurrentBalanceDinar { get; set; }
        public string TransactionDetails { get; set; }
        public string Note { get; set; }
        public TransactionName TransactionName { get; set; }
        public int? TransportCompanyId { get; set; }
        public TransportCompanyDto TransportCompany { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
