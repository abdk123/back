using AutoMapper;
using Souccar.SaleManagement.Logs.Dto;

namespace Souccar.SaleManagement.Logs.Map
{
    public class OrderLogMapProfile : Profile
    {
        public OrderLogMapProfile()
        {
            CreateMap<OrderLog, OrderLogDto>();
            CreateMap<OrderLogAttribute, OrderLogAttributeDto>();
        }
    }
}
