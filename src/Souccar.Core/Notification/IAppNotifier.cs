using Souccar.Authorization.Users;
using Souccar.SaleManagement.PurchaseOrders.SaleInvoices;
using System;
using System.Threading.Tasks;

namespace Souccar.Notification
{
    public interface IAppNotifier
    {
        Task SendMaterialExpiryDate(User user, string name, DateTime date);
        Task SendCreateOutputRequst(User user, string title);
        void SendSaleInvoiceNotify(SaleInvoice saleInvoice);
    }
}
