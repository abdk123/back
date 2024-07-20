using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.CashFlows.CustomerCashFlows.Dto
{
    public class CustomerCashFlowDto : EntityDto
    {
        public double AmountDollar { get; set; }
        public double CurrentBalanceDollar { get; set; }
        public double AmountDinar { get; set; }
        public double CurrentBalanceDinar { get; set; }
        public string TransactionDetails { get; set; }
        public string Note { get; set; }
        public TransactionName TransactionName { get; set; }
        public int? CustomerId { get; set; }
    }
}
