using Souccar.SaleManagement.PurchaseOrders.Receives.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.Receivings.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Souccar.SaleManagement.PurchaseOrders.Invoises;
using Abp.UI;

namespace Souccar.SaleManagement.PurchaseOrders.Receives.Services
{
    public class ReceivingAppService :
        AsyncSouccarAppService<Receiving, ReceivingDto, int, FullPagedRequestDto, CreateReceivingDto, UpdateReceivingDto>, IReceivingAppService
    {
        private readonly IReceivingDomainService _receivingDomainService;
        private readonly IInvoiceDomainService _invoiceDomainService;
        public ReceivingAppService(IReceivingDomainService receivingDomainService, IInvoiceDomainService invoiceDomainService) : base(receivingDomainService)
        {
            _receivingDomainService = receivingDomainService;
            _invoiceDomainService = invoiceDomainService;
        }

        public IList<ReceivingDto> GetAllByInvoiceId(int invoiceId)
        {
            var receiving = _receivingDomainService.GetAllByInvoiceId(invoiceId).ToList();
            return ObjectMapper.Map<List<ReceivingDto>>(receiving);
        }

        public override async Task<ReceivingDto> CreateAsync(CreateReceivingDto input)
        {
            var receiving = await base.CreateAsync(input);
            var invoice = _invoiceDomainService.GetWithDetail(input.InvoiceId.Value);
            if (invoice == null)
                throw new UserFriendlyException("Not Found");

            invoice.Status = InvoiceStatus.PartialRecieved;
            if(invoice.TotalReceivedQuantity == receiving.TotalReceivedQuantity)
                invoice.Status = InvoiceStatus.Received;

            await _invoiceDomainService.UpdateAsync(invoice);
            return receiving;
        }
    }
}

