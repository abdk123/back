using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.SaleManagement.PurchaseOrders.Receives;

namespace Souccar.SaleManagement.Receivings.Services
{
    public class ReceivingDomainService : SouccarDomainService<Receiving, int>, IReceivingDomainService
    {
        public ReceivingDomainService(IRepository<Receiving, int> receivingRepository) : base(receivingRepository)
        {
        }
    }
}

