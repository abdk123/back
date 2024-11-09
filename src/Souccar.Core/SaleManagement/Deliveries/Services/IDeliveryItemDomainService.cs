using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.Deliveries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Deliveries.Services
{
    public interface IDeliveryItemDomainService : ISouccarDomainService<DeliveryItem, int>
    {
        IQueryable<Delivery> GetAllRejected();
    }
}

