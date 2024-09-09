using Abp.Dependency;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Notification
{
    public interface IAppNotifier
    {
        Task SendSaleInvoiceNotify(string title, Dictionary<string, object> dic, Abp.UserIdentifier[] identifiers);
    }
}
