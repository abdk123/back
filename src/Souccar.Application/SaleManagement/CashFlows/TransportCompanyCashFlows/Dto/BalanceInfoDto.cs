using Abp.Application.Services.Dto;

namespace Souccar.SaleManagement.CashFlows.TransportCompanyCashFlows.Dto
{
    public class BalanceInfoDto:EntityDto
    {
        public BalanceInfoDto(int id, double dollarBalance, double dinarBalance)
        {
            Id = id;
            DollarBalance = dollarBalance;
            DinarBalance = dinarBalance;
        }

        public double DollarBalance { get; set; }
        public double DinarBalance { get; set; }
    }
}
