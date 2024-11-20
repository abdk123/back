using Souccar.Core.Services.Interfaces;
using Souccar.SaleManagement.Deliveries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.Deliveries.Services
{
    public interface IDeliveryDomainService : ISouccarDomainService<Delivery, int>
    {
        IQueryable<Delivery> GetAllByCustomerId(int customerId);
        IQueryable<Delivery> GetAllWithDetail();
        Task<Delivery> GetWithDetailsByIdAsync(int id);
        Task<IQueryable<Delivery>> GetAllDeliverdAsync();
        Task<DeliveryItem> ChangeItemStatusAsync(int id, int status);
        IQueryable<RejectedMaterial> GetAllRejected();
        IQueryable<Delivery> GetForSaleInvoice(int customerId);
        IQueryable<Delivery> GetByOfferItems(int[] offerItems);
        Task<IList<RejectedMaterial>> CreateRejectedMaterials(List<RejectedMaterial> rejectedMaterials);
        DeliveryItem GetItemById(int? itemId);
        Task<DeliveryItem> UpdateItemAsync(DeliveryItem deliveryItem);
    }
}

