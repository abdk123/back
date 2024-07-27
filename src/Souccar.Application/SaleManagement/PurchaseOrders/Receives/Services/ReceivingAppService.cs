using Souccar.SaleManagement.PurchaseOrders.Receives.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.Receivings.Services;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Receives.Services
{
    public class ReceivingAppService :
        AsyncSouccarAppService<Receiving, ReceivingDto, int, FullPagedRequestDto, ReceivingDto, ReceivingDto>, IReceivingAppService
    {
        private readonly IReceivingDomainService _receivingDomainService;
        public ReceivingAppService(IReceivingDomainService receivingDomainService) : base(receivingDomainService)
        {
            _receivingDomainService = receivingDomainService;
        }

    }
}

