using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using Souccar.SaleManagement.Settings.Customers.Dto;
using System;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Dto
{
    public class CustomerCashFlowDto : EntityDto,ICreationAudited
    {
        public double AmountDollar { get; set; }
        public double CurrentBalanceDollar { get; set; }
        public double AmountDinar { get; set; }
        public double CurrentBalanceDinar { get; set; }
        public string TransactionDetails { get; set; }
        public string Note { get; set; }
        public TransactionName TransactionName { get; set; }
        public int? CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
