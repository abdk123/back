using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.SaleManagement.Logs.Services
{
    public class OrderLogDomainService : SouccarDomainService<OrderLog,int>, IOrderLogDomainService
    {
        public OrderLogDomainService(IRepository<OrderLog,int> orderLogRepository) :base(orderLogRepository)
        {
            
        }
    }
}
