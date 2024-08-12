using Abp.Application.Services;
using Souccar.SaleManagement.Logs.Dto;
using System.Collections.Generic;

namespace Souccar.SaleManagement.Logs.Services
{
    public interface IOrderLogAppSerive : IApplicationService
    {
        IList<OrderLogDto> GetAllByOfferId(int offerId);
    }
}
