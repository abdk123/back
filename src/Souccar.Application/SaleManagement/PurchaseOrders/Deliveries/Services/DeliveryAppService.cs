using Abp.Application.Services.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.Deliveries.Services
{
    public class DeliveryAppService :
        AsyncSouccarAppService<Delivery, DeliveryDto, int, FullPagedRequestDto, CreateDeliveryDto, UpdateDeliveryDto>, IDeliveryAppService
    {
        private readonly IDeliveryDomainService _deliveryDomainService;
        public DeliveryAppService(IDeliveryDomainService deliveryDomainService) : base(deliveryDomainService)
        {
            _deliveryDomainService = deliveryDomainService;
        }

        public async Task<DeliveryDto> GetWithDetailsByIdAsync(int deliveryId)
        {
            var delivery = await _deliveryDomainService.GetWithDetailsByIdAsync(deliveryId);
            return ObjectMapper.Map<DeliveryDto>(delivery);
        }

        public IList<DeliveryDto> GetAllByInvoiceId(int invoiceId)
        {
            var receiving = _deliveryDomainService.GetAllByInvoiceId(invoiceId).ToList();
            return ObjectMapper.Map<List<DeliveryDto>>(receiving);
        }

        public async Task<List<DeliveryDto>> GetAllDeliverdAsync()
        {
            var deliveries = await _deliveryDomainService.GetAllDeliverdAsync();
            return ObjectMapper.Map<List<DeliveryDto>>(deliveries);
        }

        protected override IQueryable<Delivery> CreateFilteredQuery(FullPagedRequestDto input)
        {
            var data = _deliveryDomainService.GetAllWithDetail();
            return data;
        }

    }
}

