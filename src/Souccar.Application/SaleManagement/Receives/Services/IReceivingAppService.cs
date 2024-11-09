using Souccar.Core.Services;
using System.Collections.Generic;
using Souccar.SaleManagement.Receives.Dto;
using Abp.Application.Services;

namespace Souccar.SaleManagement.Receives.Services
{
    public interface IReceivingAppService : IAsyncCrudAppService<ReceivingDto, int, PagedReceivingResultRequestDto, CreateReceivingDto, ReceivingDto>
    {
        IList<ReceivingDto> GetAllByInvoiceId(int invoiceId);
        ReceivingDto GetWithDetail(int receiveId);
        ReceivingDto CompleteInfo(CompleteReceivingDto input);
    }
}

