using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using System.Collections.Generic;
using Souccar.SaleManagement.Receives.Dto;

namespace Souccar.SaleManagement.Receives.Services
{
    public interface IReceivingAppService : IAsyncSouccarAppService<ReceivingDto, int, FullPagedRequestDto, CreateReceivingDto, UpdateReceivingDto>
    {
        IList<ReceivingDto> GetAllByInvoiceId(int invoiceId);
    }
}

