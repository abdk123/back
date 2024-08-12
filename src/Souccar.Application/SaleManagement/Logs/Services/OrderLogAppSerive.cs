using Souccar.SaleManagement.Logs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.SaleManagement.Logs.Services
{
    public class OrderLogAppSerive : SouccarAppServiceBase, IOrderLogAppSerive
    {
        private readonly IOrderLogDomainService _orderLogDomainService;

        public OrderLogAppSerive(IOrderLogDomainService orderLogDomainService)
        {
            _orderLogDomainService = orderLogDomainService;
        }

        public IList<OrderLogDto> GetAllByOfferId(int offerId)
        {
            var logs = _orderLogDomainService.GetAllWithIncluding("Attributes")
                .Where(x => x.OfferId == offerId).ToList();

            return ObjectMapper.Map<List<OrderLogDto>>(logs);
        }
    }
}
